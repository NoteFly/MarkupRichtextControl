using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal partial class MarkupRichtextControl : UserControl
{
    private List<RichTextPart> richtextparts = new List<RichTextPart>();
    private List<HyperlinkClickablePart> hyperlinkclickablepart = new List<HyperlinkClickablePart>();
    private string[] protocolshyperlink = new string[] { "https", "http" };
    const int MARGIN_LINE_LEFT = 4;
    const int MARGIN_LINE_RIGHT = 4;
    const int MARGIN_LINE_TOP = 4;
    const int LINE_HEIGHT = 8;

    private ToolTip tooltip = new ToolTip();
    private const int DURATIONURLTOOLTIP = 2000;

    public enum WordWrapMode { OnCharacter, OnWord, OnSentence }

    
    [DisplayName("WordWrapModus")]
    [Category("Appearance")]
    [Description("Set the text wordwrap modus. How the too long lines get wrapped.")]
    public WordWrapMode wordwrapmodus { get; set; }

    [DisplayName("HyperlinkUrlTooltip")]
    [Category("Appearance")]
    [Description("Show a tooltip on hovering above a url in the markup control.")]
    public bool hyperlinkUrlTooltip { get; set; }

    /// <summary>
    /// Add a new part of rich text to this control.
    /// </summary>
    /// <param name="newRichTextPart"></param>
    public void Append(RichTextPart newRichTextPart)
    {
        this.richtextparts.Add(newRichTextPart);
    }

    /// <summary>
    /// Remove all rich text from this control.
    /// </summary>
    public void Clear()
    {
        this.hyperlinkclickablepart.Clear();
        this.richtextparts.Clear();
    }

    protected override void OnPaint(PaintEventArgs paintEvtArgs)
    {
        int widthWithoutMargin = this.Width - this.Margin.Horizontal;
        Point location = new Point(0, 0);
        for (int i = 0; i < this.richtextparts.Count; ++i)
        {
            RichTextPart richTextPart = this.richtextparts[i];
            if (richTextPart.IsLine)
            {
                Point linestart = location;
                Point lineend = location;
                linestart.X += MARGIN_LINE_LEFT;
                linestart.Y += MARGIN_LINE_TOP;
                lineend.X += this.Width - MARGIN_LINE_RIGHT;
                lineend.Y += MARGIN_LINE_TOP;
                richTextPart.DrawLine(paintEvtArgs, linestart, lineend);
                location.Y += LINE_HEIGHT;
                continue;
            }

            if (richTextPart.PrependBullit)
            {
                richTextPart.Text = "• " + richTextPart.Text;
            }

            if (richTextPart.Text.Length == 0)
            {
                continue;
            }

            SizeF textsize = richTextPart.GetSizeText(paintEvtArgs);
            int heightLineFontsize = Convert.ToInt32(textsize.Height);
            int widthRichTextPart = Convert.ToInt32(textsize.Width);
            // Check if richTextPart needs to be an extra line/multiple line(s). 
            if (location.X + widthRichTextPart >= widthWithoutMargin)
            {
                int posstartpartofrichtextpart = 0;
                int restTextLength = richTextPart.Text.Length - posstartpartofrichtextpart;
                int widthpartoftextpart = 0;
                int lastspacerichtextpart = 0;
                int lastdotrichtextpart = 0;
                // Check foreach characters where to split in this richtext part
                for (int n = 0; n < richTextPart.Text.Length; ++n)
                {
                    if (richTextPart.Text[n] == ' ')
                    {
                        lastspacerichtextpart = n;
                    }
                    else if (richTextPart.Text[n] == '.')
                    {
                        lastdotrichtextpart = n;
                    }

                    int posstartwrap = n;
                    if (this.wordwrapmodus == WordWrapMode.OnCharacter ||
                        lastspacerichtextpart == 0 && this.wordwrapmodus == WordWrapMode.OnWord)
                    {
                        posstartwrap = n;
                    }
                    else if (this.wordwrapmodus == WordWrapMode.OnWord ||
                             lastdotrichtextpart == 0 && this.wordwrapmodus == WordWrapMode.OnSentence)
                    {
                        posstartwrap = lastspacerichtextpart;
                    }
                    else if (this.wordwrapmodus == WordWrapMode.OnSentence)
                    {
                        posstartwrap = lastdotrichtextpart;
                    }

                    int textlengthpartofrichtextpart = posstartwrap - posstartpartofrichtextpart;
                    if (textlengthpartofrichtextpart == 0)
                    {
                        continue;
                    }

                    widthpartoftextpart = richTextPart.GetWidthTextPart(paintEvtArgs, posstartpartofrichtextpart, textlengthpartofrichtextpart);
                    int widthcharpartoftextpart = richTextPart.GetWidthTextPart(paintEvtArgs, posstartpartofrichtextpart, n - posstartpartofrichtextpart);
                    int charlocx = location.X + widthcharpartoftextpart;
                    if (charlocx >= widthWithoutMargin)
                    {
                        // A new line in control is needed for part of richtextpart.
                        richTextPart.DrawPart(paintEvtArgs, location, posstartpartofrichtextpart, textlengthpartofrichtextpart);
                        if (!String.IsNullOrEmpty(richTextPart.Href))
                        {
                            this.CreateHyperlinkClickablePart(richTextPart, location, widthpartoftextpart, heightLineFontsize);
                        }

                        // Update location position for next subpart of the richtextpart.
                        location.X = 0;
                        location.Y += heightLineFontsize;
                        // Update start position character and textlength for spliting next subpart of the richtextpart over multiple lines.
                        posstartpartofrichtextpart = posstartwrap;
                        restTextLength = richTextPart.Text.Length - posstartpartofrichtextpart;
                        widthRichTextPart = richTextPart.GetWidthTextPart(paintEvtArgs, posstartpartofrichtextpart, restTextLength);
                    }
                }

                // Draw rest of characters that still fit on one a line.
                richTextPart.DrawPart(paintEvtArgs, location, posstartpartofrichtextpart, restTextLength);
                if (!String.IsNullOrEmpty(richTextPart.Href))
                {
                    widthpartoftextpart = richTextPart.GetWidthTextPart(paintEvtArgs, posstartpartofrichtextpart, restTextLength);
                    this.CreateHyperlinkClickablePart(richTextPart, location, widthpartoftextpart, heightLineFontsize);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(richTextPart.Href))
                {
                    this.CreateHyperlinkClickablePart(richTextPart, location, widthRichTextPart, heightLineFontsize);
                }

                richTextPart.Draw(paintEvtArgs, location);
            }

            if (richTextPart.PrependBullit)
            {
                richTextPart.Text = richTextPart.Text.Substring(2);
            }

            location = this.UpdateLocationNewRichTextPart(widthRichTextPart, heightLineFontsize, location, widthWithoutMargin);
            if (richTextPart.AppendNewLine)
            {
                location.Y += heightLineFontsize;
                location.X = 0;
            }
        }
    }

    private void CreateHyperlinkClickablePart(RichTextPart richtextpart, Point location, int widthRichTextPart, int heightLineFontsize)
    {
        HyperlinkClickablePart hyperlinkClickablepart = new HyperlinkClickablePart();
        hyperlinkClickablepart.location = location;
        hyperlinkClickablepart.width = widthRichTextPart;
        hyperlinkClickablepart.height = heightLineFontsize;
        hyperlinkClickablepart.richtextpart = richtextpart;
        this.hyperlinkclickablepart.Add(hyperlinkClickablepart);
    }

    protected override void OnClick(EventArgs e)
    {
        MouseEventArgs mouseeventargs = (MouseEventArgs)e;
        foreach (HyperlinkClickablePart hyperlinkClickablepart in this.hyperlinkclickablepart)
        {
            if (mouseeventargs.X >= hyperlinkClickablepart.location.X  &&
                mouseeventargs.X <= hyperlinkClickablepart.location.X + hyperlinkClickablepart.width &&
                mouseeventargs.Y >= hyperlinkClickablepart.location.Y &&
                mouseeventargs.Y <= hyperlinkClickablepart.location.Y + hyperlinkClickablepart.height)
            {
                string url = hyperlinkClickablepart.richtextpart.Href;
                foreach (string protocol in protocolshyperlink)
                {
                    if (url.StartsWith(protocol+"://"))
                    {

                        System.Diagnostics.ProcessStartInfo procstartinfo = new System.Diagnostics.ProcessStartInfo(url);
                        try
                        {
                            System.Diagnostics.Process.Start(procstartinfo);
                        }
                        catch (System.ComponentModel.Win32Exception w32exc)
                        {
                            MessageBox.Show(w32exc.Message, "Error link");
                        }

                        break;
                    }
                }


                break;
            }
        }

        base.OnClick(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        Point pointcursor = this.PointToClient(Cursor.Position);
        foreach (HyperlinkClickablePart hyperlinkClickablepart in this.hyperlinkclickablepart)
        {
            if (pointcursor.X >= hyperlinkClickablepart.location.X &&
                pointcursor.X <= hyperlinkClickablepart.location.X + hyperlinkClickablepart.width &&
                pointcursor.Y >= hyperlinkClickablepart.location.Y &&
                pointcursor.Y <= hyperlinkClickablepart.location.Y + hyperlinkClickablepart.height)
            {
                Cursor.Current = Cursors.Hand;
                return;
            } 
        }

        Cursor.Current = Cursors.Default;
        //base.OnMouseMove(e);
    }

    protected override void OnMouseHover(EventArgs e)
    {
        tooltip.RemoveAll();
        Point pointcursor = this.PointToClient(Cursor.Position);
        foreach (HyperlinkClickablePart hyperlinkClickablepart in this.hyperlinkclickablepart)
        {
            if (pointcursor.X >= hyperlinkClickablepart.location.X &&
                pointcursor.X <= hyperlinkClickablepart.location.X + hyperlinkClickablepart.width &&
                pointcursor.Y >= hyperlinkClickablepart.location.Y &&
                pointcursor.Y <= hyperlinkClickablepart.location.Y + hyperlinkClickablepart.height)
            {
                if (this.hyperlinkUrlTooltip)
                {
                    tooltip.Show(hyperlinkClickablepart.richtextpart.Href, this, pointcursor.X, pointcursor.Y + 24, DURATIONURLTOOLTIP);
                }

                break;
            }
        }

        base.OnMouseHover(e);
    }


    /// <summary>
    /// Calculate new point for next rich text part.
    /// </summary>
    /// <param name="widthLastLineRichTextPart"></param>
    /// <param name="heightLineFontsize"></param>
    /// <param name="location"></param>
    /// <param name="maxWidthPerLine"></param>
    /// <returns></returns>
    private Point UpdateLocationNewRichTextPart(int widthLastLineRichTextPart, int heightLineFontsize, Point location, int maxWidthPerLine)
    {
        int numLinesCurRichTextPart = 1;
        int x = location.X + widthLastLineRichTextPart;
        while (x >= maxWidthPerLine && x >= 0 && numLinesCurRichTextPart < Int32.MaxValue)
        {
            x -= maxWidthPerLine;
            ++numLinesCurRichTextPart;
        }

        int y = location.Y;
        y += (heightLineFontsize * (numLinesCurRichTextPart - 1));
        return new Point(x, y);
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // MarkupTextControl
        // 
        this.AutoSize = true;
        this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.BackColor = System.Drawing.Color.White;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Name = "MarkupTextControl";
        this.Size = new System.Drawing.Size(0, 0);
        this.ResumeLayout(false);
    }
}

