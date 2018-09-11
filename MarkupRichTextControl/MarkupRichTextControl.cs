using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

internal partial class MarkupRichtextControl : UserControl
{
    private List<RichTextPart> richtextparts = new List<RichTextPart>();

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
#if DEBUG
                Console.WriteLine("--- endx=" + endx + " this.width=" + this.Width+ " widthWithoutMargin=" + widthWithoutMargin + " ---");
#endif
                int richTextPartLines = 0;
                for (int n = 0; n < richTextPart.Text.Length; ++n)
                {
                    int linelocx = location.X + richTextPart.GetWidthTextPart(paintEvtArgs, n) - (widthWithoutMargin * richTextPartLines);
#if DEBUG
                    Console.Write("linelocx=" + linelocx + "|");
#endif
                    if (linelocx > widthWithoutMargin)
                    {
#if DEBUG
                        Console.WriteLine("\r\nDrawPart n=" + n);
#endif
                        richTextPart.DrawPart(paintEvtArgs, location, 0, n);
                        ++richTextPartLines;
                        location.X = 0;
                        location.Y += heightLineFontsize;
                        int restTextLength = richTextPart.Text.Length - n;
                        richTextPart.DrawPart(paintEvtArgs, location, n, restTextLength);
                        widthRichTextPart = richTextPart.GetWidthTextPart(paintEvtArgs, restTextLength);
                    }
                }
#if DEBUG

                Console.WriteLine("---");
#endif
            }
            else
            {
                richTextPart.Draw(paintEvtArgs, location);
            }

            // Remove bullit again.
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
