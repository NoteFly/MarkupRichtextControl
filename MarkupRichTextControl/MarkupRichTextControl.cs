using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

internal partial class MarkupRichtextControl : UserControl
{
    private List<RichTextPart> richtextparts = new List<RichTextPart>();
    private List<HyperlinkClickablePart> hyperlinkclickablepart = new List<HyperlinkClickablePart>();

    /// <summary>
    /// Add a new part of rich text to this control.
    /// </summary>
    /// <param name="newRichTextPart"></param>
    public void appendText(RichTextPart newRichTextPart)
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
            SizeF textsize = richTextPart.GetSizeText(paintEvtArgs);
            int heightLineFontsize = Convert.ToInt32(textsize.Height);
            int widthRichTextPart = Convert.ToInt32(textsize.Width);
            if (richTextPart.PrependBullit)
            {
                richTextPart.Text = "• " + richTextPart.Text;
            }

            if (location.X + widthRichTextPart >= widthWithoutMargin)
            {
                // TODO: word break design, currently just split in middle of words
                int endx = location.X + widthRichTextPart;
                int richTextPartLines = 0;
                for (int n = 0; n < richTextPart.Text.Length; ++n)
                {
                    int widthpartoftextpart = richTextPart.GetWidthTextPart(paintEvtArgs, n);
                    int linelocx = location.X + widthpartoftextpart - (widthWithoutMargin * richTextPartLines);
                    if (linelocx > widthWithoutMargin)
                    {
                        richTextPart.DrawPart(paintEvtArgs, location, 0, n);
                        if (!String.IsNullOrEmpty(richTextPart.Href))
                        {
                            this.CreateHyperlinkClickablePart(richTextPart, location, widthpartoftextpart, heightLineFontsize);
                        }

                        ++richTextPartLines;
                        location.X = 0;
                        location.Y += heightLineFontsize;
                        int restTextLength = richTextPart.Text.Length - n;
                        richTextPart.DrawPart(paintEvtArgs, location, n, restTextLength);
                        if (!String.IsNullOrEmpty(richTextPart.Href))
                        {
                            widthpartoftextpart = richTextPart.GetWidthTextPart(paintEvtArgs, restTextLength);
                            this.CreateHyperlinkClickablePart(richTextPart, location, widthpartoftextpart, heightLineFontsize);
                        }

                        widthRichTextPart = richTextPart.GetWidthTextPart(paintEvtArgs, restTextLength);
                    }
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
                if (url.StartsWith("https://") ||
                    url.StartsWith("http://"))
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

