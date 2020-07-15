using System;
using System.Drawing;

public class RichTextPart
{
    private string text;
    private Font font;
    private SolidBrush textcolor;
    private Pen linecolor;
    private SizeF richtextpartsize;
    private bool appendNewLine = false;
    private bool prependBullit = false;
    private string href = null;
    private bool isline = false;

    public RichTextPart(string text, string fontfamily, int fontsize, SolidBrush textcolor, FontStyle fontstyle)
    {
        this.text = text;
        this.font = new Font(fontfamily, fontsize, fontstyle);
        this.textcolor = textcolor;
    }

    public RichTextPart(Pen linecolor)
    {
        this.IsLine = true;
        this.linecolor = linecolor;
    }

    public string Text
    {
        get
        {
            return this.text;
        }
        set
        {
            this.text = value;
        }
    }

    public string Href { get; set; }
    public int Fontsize { get; }
    public int Color { get; }
    public bool AppendNewLine { get; set; }
    public bool PrependBullit { get; set; }
    public bool IsLine { get; set; }

    public SizeF GetSizeText(System.Windows.Forms.PaintEventArgs e)
    {
        // Avoid expensive MeasureString calls
        if (this.richtextpartsize.IsEmpty)
        {
            this.richtextpartsize = e.Graphics.MeasureString(this.text, this.font);
        }
        
        return this.richtextpartsize;
    }

    public int GetWidthTextPart(System.Windows.Forms.PaintEventArgs e, int startpos, int textlength)
    {
        SizeF sizef = e.Graphics.MeasureString(this.text.Substring(startpos, textlength), this.font);
        return Convert.ToInt32(sizef.Width);
    }

    public void Draw(System.Windows.Forms.PaintEventArgs e, Point location)
    {
        e.Graphics.DrawString(this.text, this.font, this.textcolor, location);
    }

    public void DrawPart(System.Windows.Forms.PaintEventArgs e, Point location, int start, int length)
    {
        e.Graphics.DrawString(this.text.Substring(start, length), this.font, this.textcolor, location);
    }

    public void DrawLine(System.Windows.Forms.PaintEventArgs e, Point locationstart, Point locationend)
    {
        e.Graphics.DrawLine(this.linecolor, locationstart, locationend);
    }
}
