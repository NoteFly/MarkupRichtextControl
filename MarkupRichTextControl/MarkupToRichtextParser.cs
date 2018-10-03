using System;
using System.Collections.Generic;
using System.Drawing;

public class MarkupToken
{
    public MarkupToken()
    {
        this.CharLeft = '\0';
        this.CharRight = '\0';
        this.Level = 0;
        this.Levelclosed = 0;
        this.Nomarkup = false;
        this.TextLeftPosition = Int32.MaxValue;
        this.Text = null;
        this.TextAppendNewLine = false;
        this.IsLine = false;
    }

    public char CharLeft { get; set; }
    public char CharRight { get; set; }
    public int Level { get; set; }
    public int Levelclosed { get; set; }
    public int TextLeftPosition { get; set; }
    public bool Nomarkup { get; set; }
    public string Text { get; set; }
    public bool TextAppendNewLine { get;  set; }
    public bool IsLine { get; set; }
}

public class MarkupTokenizer {

    private string markup;

    private List<MarkupToken> markuptokens;

    public MarkupTokenizer(string markup)
    {
        this.markup = markup;
        this.markuptokens = new List<MarkupToken>();
    }

    public MarkupToken[] GetTokens()
    {
        return this.markuptokens.ToArray();
    }

    public void Clear()
    {
        this.markuptokens.Clear();
        this.markup = "";
    }

    public void FindTokens()
    {
        this.markuptokens.Clear();
        MarkupToken markuptoken = new MarkupToken();
        int linenr = 0;

        int numdashes = 0;
        int lastlinenrdash = -1;

        int numstars = 0;
        int lastlinenrstar = -1;

        for (int i = 0; i < this.markup.Length; i++)
        {
            char chr = this.markup[i];
            if (chr == '\r' || chr == '\n' || i == this.markup.Length -1)
            {
                int textlength = i - markuptoken.TextLeftPosition;
                if (i == this.markup.Length - 1)
                {
                    // Include chr on last character of markup as no new line characters can be excepted.
                    textlength += 1;
                }

                if (markuptoken.CharLeft == '#' ||
                    markuptoken.CharLeft == '-' || markuptoken.CharLeft == '*')
                {
                    // do not need closing tag(head) or closing tag forbidden(list/line)
                    if (!markuptoken.IsLine)
                    {
                        markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength).Trim();
                    }

                    this.markuptokens.Add(markuptoken);
                    markuptoken = new MarkupToken();
                }
                else if (markuptoken.Nomarkup)
                {
                    // plaintext
                    markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                    markuptoken.TextAppendNewLine = true;
                    this.markuptokens.Add(markuptoken);
                    markuptoken = new MarkupToken();
                    markuptoken.CharLeft = '\0';
                    markuptoken.TextLeftPosition = i + 1;
                    markuptoken.Nomarkup = false;
                }
                else if (textlength > 0 && !markuptoken.Nomarkup)
                {
                    if (markuptoken.Level > 0 && markuptoken.Levelclosed < markuptoken.Level)
                    {
                        markuptoken.Levelclosed += 1;
                    }
                    else
                    {
                        markuptoken.CharRight = chr;
                        textlength = i - markuptoken.TextLeftPosition - markuptoken.Level;
                        String text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                        markuptoken.Text = text;
                        markuptoken.TextAppendNewLine = true;
                        this.markuptokens.Add(markuptoken);
                        markuptoken = new MarkupToken();
                    }
                }

                linenr++;
            }
            else if (chr == '_' || chr == '*' || chr == '#' || chr == '-' || chr == '~' || chr == '`' || 
                     chr == '[' || chr == ']' || chr == '(' || chr == ')')
            {
                if (markuptoken.CharLeft == '\0' && !markuptoken.Nomarkup)
                {
                    // Start new rich text.
                    markuptoken.CharLeft = chr;
                    markuptoken.TextLeftPosition = i + 1;
                    if (chr == '-')
                    {
                        numdashes = this.UpdateNumberOfCharInLine(numdashes, lastlinenrdash, linenr);
                        lastlinenrdash = linenr;
                    }
                    else if (chr == '*')
                    {
                        numstars = this.UpdateNumberOfCharInLine(numstars, lastlinenrstar, linenr);
                        lastlinenrstar = linenr;
                    }
                }
                else if (markuptoken.CharLeft == chr && markuptoken.TextLeftPosition == i)
                {
                    // Repeating - or *
                    markuptoken.TextLeftPosition = i + 1;
                    markuptoken.Level += 1;
                    if (chr == '-')
                    {
                        numdashes = this.UpdateNumberOfCharInLine(numdashes, lastlinenrdash, linenr);
                        lastlinenrdash = linenr;
                        if (numdashes == 2)
                        {
                            markuptoken.IsLine = true;
                        }
                    }
                    else if (chr == '*')
                    {
                        numstars = this.UpdateNumberOfCharInLine(numstars, lastlinenrstar, linenr);
                        lastlinenrstar = linenr;
                        if (numstars >= 3)
                        {
                            markuptoken.IsLine = false;
                            // Don't make line if next char is not: a line ending char, or at end of the markup.
                            if (i + 1 >= this.markup.Length)
                            {
                                markuptoken.IsLine = true;
                            }
                            else
                            {
                                char nextchar = this.markup[i + 1];
                                if (nextchar == '\r' || nextchar == '\n')
                                {
                                    markuptoken.IsLine = true;
                                }
                            }
                        }
                    }
                }
                else if (markuptoken.Nomarkup)
                {
                    // plaintext
                    int textlength = i - markuptoken.TextLeftPosition - 1;
                    markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                    this.markuptokens.Add(markuptoken);
                    markuptoken = new MarkupToken();
                    markuptoken.CharLeft = chr;
                    markuptoken.TextLeftPosition = i + 1;
                }
                else
                {
                    if (markuptoken.Level > 0 && markuptoken.Levelclosed < markuptoken.Level)
                    {
                        markuptoken.Levelclosed += 1;
                    }
                    else
                    {
                        bool inlinedash = false;
                        if (chr == '-')
                        {
                            if (i + 1 < this.markup.Length)
                            {
                                Char nextchr = this.markup[i + 1];
                                if (nextchr != '\r' && nextchr != '\n')
                                {
                                    inlinedash = true;
                                }
                            }
                        }

                        if (!inlinedash)
                        {
                            markuptoken.CharRight = chr;
                            int textlength = i - markuptoken.TextLeftPosition - markuptoken.Level;
                            String text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                            // Remove leading and ending space from headings
                            if (chr == '#')
                            {
                                text = text.Trim();
                            }

                            markuptoken.Text = text;
                            this.markuptokens.Add(markuptoken);
                            markuptoken = new MarkupToken();
                        }
                    }
                 }
            }
            else if (markuptoken.TextLeftPosition == 0 || markuptoken.CharLeft == '\0')
            {
                if (!markuptoken.Nomarkup)
                {
                    markuptoken.TextLeftPosition = i;
                }

                markuptoken.Nomarkup = true;
            }
        }
    }

    private int UpdateNumberOfCharInLine(int number_of_char, int lastlinenrchar, int linenr)
    {
        if (linenr != lastlinenrchar)
        {
            number_of_char = 0;
        }

        return ++number_of_char;
    }
}

partial class MarkupToRichtextParser
{
    private int fontsizedefault = 12;

    private int[] headsfontsizes = new int[] { 32, 24, 20, 18, 16, 14 };

    private MarkupRichtextControl markuptextcontrol;

    public MarkupToRichtextParser(MarkupRichtextControl markuptextcontrol)
    {
        this.markuptextcontrol = markuptextcontrol;
    }

    /// <summary>
    /// Parse the markup to RichTextParts and add them to the markuptextcontrol.
    /// </summary>
    /// <param name="markup"></param>
    public void ParseMarkup(string markup)
    {
        MarkupTokenizer tokonizer = new MarkupTokenizer(markup);
        tokonizer.FindTokens();
        MarkupToken[] markuptokens = tokonizer.GetTokens();
        SolidBrush solidbrushTextcolorDefault = new SolidBrush(Color.Black);
        RichTextPart richtextpart = null;
        bool previous_markuptokon_hyperlinktext = false;
        for (int i = 0; i < markuptokens.Length; ++i)
        {
            if (markuptokens[i].IsLine)
            {
                richtextpart = new RichTextPart(Pens.Black);
                this.markuptextcontrol.Append(richtextpart);
            }
            else
            {
                switch (markuptokens[i].CharLeft)
                {
                    case '#':
                        // head
                        int headlevel = markuptokens[i].Level;
                        richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.headsfontsizes[headlevel], solidbrushTextcolorDefault, FontStyle.Bold);
                        richtextpart.AppendNewLine = true;
                        this.markuptextcontrol.Append(richtextpart);
                        previous_markuptokon_hyperlinktext = false;
                        break;
                    case '-':
                        // list
                        richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Regular);
                        richtextpart.PrependBullit = true;
                        richtextpart.AppendNewLine = true;
                        this.markuptextcontrol.Append(richtextpart);
                        previous_markuptokon_hyperlinktext = false;
                        break;
                    case '*':
                    case '_':
                        // emphasis
                        int emphasislevel = markuptokens[i].Level;
                        int emphasisfontstyle = (int)FontStyle.Italic;
                        if (emphasislevel >= 1)
                        {
                            emphasisfontstyle = (int)FontStyle.Bold;
                        }
                        if (emphasislevel >= 2)
                        {
                            emphasisfontstyle += (int)FontStyle.Italic;
                        }

                        richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, (FontStyle)emphasisfontstyle);
                        this.markuptextcontrol.Append(richtextpart);
                        previous_markuptokon_hyperlinktext = false;
                        break;
                    case '~':
                        // strikethrough
                        richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Strikeout);
                        this.markuptextcontrol.Append(richtextpart);
                        previous_markuptokon_hyperlinktext = false;
                        break;
                    case '[':
                        // hyperlink text
                        previous_markuptokon_hyperlinktext = true;
                        break;
                    case '(':
                        // hyperlink url
                        if (previous_markuptokon_hyperlinktext && i > 0)
                        {
                            FontStyle fontsylehyperlink = FontStyle.Underline;
                            SolidBrush solidbrushHyperlink = new SolidBrush(Color.Blue);
                            richtextpart = new RichTextPart(markuptokens[i - 1].Text, "Arial", this.fontsizedefault, solidbrushHyperlink, fontsylehyperlink);
                            richtextpart.Href = markuptokens[i].Text;
                            this.markuptextcontrol.Append(richtextpart);
                        }

                        previous_markuptokon_hyperlinktext = false;
                        break;
                    case '`':
                        // literally and code highlighting
                        // TODO
                        previous_markuptokon_hyperlinktext = false;
                        break;
                    default:
                        if (markuptokens[i].Nomarkup)
                        {
                            richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Regular);
                            richtextpart.AppendNewLine = markuptokens[i].TextAppendNewLine;
                            this.markuptextcontrol.Append(richtextpart);
                        }

                        break;
                }
            }
        }

        this.markuptextcontrol.Refresh();
    }
}
