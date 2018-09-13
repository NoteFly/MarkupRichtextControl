﻿using System;
using System.Collections.Generic;
using System.Drawing;

public class MarkupToken
{
    public MarkupToken()
    {
        this.CharLeft = '\0';
        this.CharRight = '\0';
        this.Level = 0;
        this.Nomarkup = false;
        this.TextLeftPosition = Int32.MaxValue;
        this.Text = null;
        this.TextAppendNewLine = false;
    }

    public char CharLeft { get; set; }
    public char CharRight { get; set; }
    public int Level { get; set; }
    public int TextLeftPosition { get; set; }
    public bool Nomarkup { get; set; }
    public string Text { get; set; }
    public bool TextAppendNewLine { get;  set; }
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
        for (int i = 0; i < this.markup.Length; i++)
        {
            char chr = this.markup[i];
            if (chr == '\r' || chr == '\n')
            {
                int textlength = i - markuptoken.TextLeftPosition;
                if (markuptoken.CharLeft == '#' || markuptoken.CharLeft == '-')
                {
                    // do not need closing tag(head) or closing tag forbidden(list/line)                    
                    markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength).Trim();
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
            }
            else if (chr == '_' || chr == '*' || chr == '#' || chr == '-' || chr == '~' || chr == '`' ||
                chr == '[' || chr == ']' || chr == '(' || chr == ')')
            {
                if (markuptoken.CharLeft == '\0' && !markuptoken.Nomarkup)
                {
                    markuptoken.CharLeft = chr;
                    markuptoken.TextLeftPosition = i + 1;
                }
                else if (markuptoken.CharLeft == chr && markuptoken.TextLeftPosition == i)
                {
                    markuptoken.TextLeftPosition = i + 1;
                    markuptoken.Level += 1;
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
                    markuptoken.CharRight = chr;
                    int textlength = i - markuptoken.TextLeftPosition;
                    String text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                    if (chr == '#')
                    {
                        text = text.Trim();
                    }

                    markuptoken.Text = text;
                    
                    this.markuptokens.Add(markuptoken);
                    markuptoken = new MarkupToken();
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
            switch (markuptokens[i].CharLeft)
            {
                case '#':
                    // head
                    int headlevel = markuptokens[i].Level;
                    richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.headsfontsizes[headlevel], solidbrushTextcolorDefault, FontStyle.Bold);
                    richtextpart.AppendNewLine = true;
                    this.markuptextcontrol.appendText(richtextpart);
                    previous_markuptokon_hyperlinktext = false;
                    break;
                case '-':
                    // list
                    richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Regular);
                    richtextpart.PrependBullit = true;
                    richtextpart.AppendNewLine = true;
                    this.markuptextcontrol.appendText(richtextpart);
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
                    this.markuptextcontrol.appendText(richtextpart);
                    previous_markuptokon_hyperlinktext = false;
                    break;
                case '~':
                    // strikethrough
                    richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Strikeout);
                    this.markuptextcontrol.appendText(richtextpart);
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
                        richtextpart = new RichTextPart(markuptokens[i-1].Text, "Arial", this.fontsizedefault, solidbrushHyperlink, fontsylehyperlink);
                        richtextpart.Href = markuptokens[i].Text;
                        this.markuptextcontrol.appendText(richtextpart);
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
                        this.markuptextcontrol.appendText(richtextpart);
                    }

                    break;
            }
        }

        this.markuptextcontrol.Refresh();
    }
}
