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
        this.TextLeftPosition = Int32.MaxValue;
        this.Nomarkup = false;
        this.AppendEnter = false;
    }

    public char CharLeft { get; set; }
    public char CharRight { get; set; }
    public int Level { get; set; }
    public int TextLeftPosition { get; set; }
    public bool Nomarkup { get; set; }
    public string Text { get; set; }
    public bool AppendEnter { get;  set; }
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
                if (markuptoken.CharLeft == '#' || markuptoken.CharLeft == '-')
                {
                    // do not need closing tag(head) or closing tag forbidden(list/line)
                    int textlength = i - markuptoken.TextLeftPosition;
                    markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                    this.markuptokens.Add(markuptoken);
                    markuptoken = new MarkupToken();
                }
                else if (markuptoken.Nomarkup)
                {
                    // plaintext
                    int textlength = i - markuptoken.TextLeftPosition;
                    markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
                    this.markuptokens.Add(markuptoken);
                    markuptoken = new MarkupToken();
                    markuptoken.AppendEnter = true;
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
                    markuptoken.Text = this.markup.Substring(markuptoken.TextLeftPosition, textlength);
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
        bool previousmarkuptokonhyperlinktext = false;
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
                    previousmarkuptokonhyperlinktext = false;
                    break;
                case '-':
                    // list
                    richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Regular);
                    richtextpart.PrependBullit = true;
                    richtextpart.AppendNewLine = true;
                    this.markuptextcontrol.appendText(richtextpart);
                    previousmarkuptokonhyperlinktext = false;
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
                    previousmarkuptokonhyperlinktext = false;
                    break;
                case '~':
                    // strikethrough
                    richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Strikeout);
                    this.markuptextcontrol.appendText(richtextpart);
                    previousmarkuptokonhyperlinktext = false;
                    break;
                case '[':
                    // hyperlink text
                    previousmarkuptokonhyperlinktext = true;
                    break;
                case '(':
                    // hyperlink url
                    if (previousmarkuptokonhyperlinktext && i > 0)
                    {
                        richtextpart = new RichTextPart(markuptokens[i-1].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Regular);
                        richtextpart.Href = markuptokens[i].Text;
                        this.markuptextcontrol.appendText(richtextpart);
                        previousmarkuptokonhyperlinktext = false;
                    }

                    break;
                case '`':
                    // literally and code highlighting
                    // TODO
                    break;
                default:
                    if (markuptokens[i].Nomarkup)
                    {
                        richtextpart = new RichTextPart(markuptokens[i].Text, "Arial", this.fontsizedefault, solidbrushTextcolorDefault, FontStyle.Regular);
                        richtextpart.AppendNewLine = markuptokens[i].AppendEnter;
                        this.markuptextcontrol.appendText(richtextpart);
                    }

                    break;
            }
        }
/*
        DECREATED:

        bool markupcode = false;
        char previous_markup_char = '\0';
        char next_markup_char = '\0';
        int previous_markup_char_position = int.MinValue;
        char previous_char = '\0';
        int richtextpart_start_pos = 0;
        int markup_last_char_pos = markup.Length - 1;

        bool execstrikethrough = false;
        bool execemphasis = false;

        bool head_on = false;
        bool head_closing = false;
        int headlevel = 0;

        bool list_on = false;
        int numrepeateddashes = 0;

        bool emphasis_on = false;
        int emphasis_start_position = 0;
        bool emphasis_closing = false;
        int emphasislevel = 0;

        bool strikethrough_on = false;

        SolidBrush solidbrushBlack = new SolidBrush(Color.Black);
        
        for (int i = 0; i < markup.Length; i++)
        {
            bool newline = false;
            char chr = markup[i];
            if (i != markup_last_char_pos)
            {
                next_markup_char = markup[i+1];
            }
#if DEBUG
            Console.WriteLine(i+"|chr=" + chr);
#endif
            switch (chr)
            {
                case '#':
                    // head
                    markupcode = true;
                    if (previous_markup_char_position != (i - 1))
                    {
                        head_closing = true;
                    }

                    if (previous_char == chr && !head_closing)
                    {
                        headlevel++;
                    }

                    head_on = true;
                    break;
                case '-':
                    // list
                    markupcode = true;
                    list_on = true;
                    if (chr == previous_char)
                    {
                        numrepeateddashes++;
                        if (numrepeateddashes >= 2)
                        {
                            // line instead of list.
                            list_on = false;
                        }
                    }

                    break;
                case '*':
                case '_':
                    // emphasis
                    markupcode = true;
                    if (!emphasis_on && chr != previous_char) //  && emphasis_start_position != 0
                    {
                        emphasis_closing = true;
                        if (i == markup_last_char_pos)
                        {
                            execemphasis = true;
                        }
                        else
                        {
                            if (next_markup_char != chr)
                            {
                                execemphasis = true;
                            }
                        }
                    }

                    if (!emphasis_closing)
                    {
                        // increase emphasis, additional * or _
                        emphasislevel++;
                    }

                    
                    emphasis_start_position = i;

#if DEBUG
                    Console.WriteLine("emphasislevel=" + emphasislevel);
#endif
                    emphasis_on = true;
                    break;
                case '~':
                    // strikethrough
                    markupcode = true;

                    if (chr != previous_char)
                    {
                        strikethrough_on = !strikethrough_on;    
                    }
                    //else if (chr == previous_markup_char)
                    //{
                        //strikethrough_on = !strikethrough_on;
                    //}

                    if (!strikethrough_on)
                    {
                        execstrikethrough = true;
                    }

                    break;
                case '`':
                    // literally and code highlighting
                    markupcode = true;
                    break;
                case '[':
                case ']':
                case '(':
                case ')':
                    // hyperlink
                    markupcode = true;
                    break;
                case '\r':
                case '\n':
                    newline = true;
                    markupcode = true;
                    break;
                default:
                    if (markupcode)
                    {
                        // Previous char was a markup char, start of new richtextpart text.
                        //markupclosing = !markupclosing;
                        richtextpart_start_pos = i;
#if DEBUG
                        Console.WriteLine("richtextpartstartpos=" + richtextpart_start_pos);
#endif
                    }

                    numrepeateddashes = 0;
                    markupcode = false;
                    break;
            }

            if (head_on && (newline || i == markup_last_char_pos))
            {
                // Reached end of head on new line character.
                string plaintext = markup.Substring(richtextpart_start_pos, i - richtextpart_start_pos).Trim();
                if (i == markup_last_char_pos)
                {
                    // incl. last char.
                    plaintext = markup.Substring(richtextpart_start_pos, (i + 1) - richtextpart_start_pos).Trim();
                }

                // remove closing head if any
                char[] headchars = { '#' };
                plaintext = plaintext.TrimEnd(headchars);
#if DEBUG
                Console.WriteLine("head"+ headlevel + " at " + richtextpart_start_pos + " for " + (i - richtextpart_start_pos) + " chars.");
#endif       
                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.headsfontsizes[headlevel], solidbrushBlack, FontStyle.Bold);
                richtextpart.AppendNewLine = true;
                this.markuptextcontrol.appendText(richtextpart);
                // reset:
                head_on = false;
                head_closing = false;
                headlevel = 0;
            }
            else if (list_on && (newline || i == markup_last_char_pos))
            {
                // Reached end of list item on new line character.
                string plaintext = markup.Substring(richtextpart_start_pos, i - richtextpart_start_pos).Trim();
                if (i == markup_last_char_pos)
                {
                    // incl. last char.
                    plaintext = markup.Substring(richtextpart_start_pos, (i + 1) - richtextpart_start_pos).Trim();
                }

                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.fontsizedefault, solidbrushBlack, FontStyle.Bold);
                richtextpart.PrependBullit = true;
                richtextpart.AppendNewLine = true;
                this.markuptextcontrol.appendText(richtextpart);
                // reset:
                list_on = false;
            }
            else if (execstrikethrough)
            {
                // Reached end a strikethrough richtextpart.
#if DEBUG
                Console.WriteLine("Striketought at " + richtextpart_start_pos + " for " + (i - richtextpart_start_pos) + " chars.");
#endif
                string plaintext = markup.Substring(richtextpart_start_pos, i - richtextpart_start_pos);
                // remove closing head if any
                char[] headchars = { '*', '_' };
                plaintext = plaintext.TrimEnd(headchars);

                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.fontsizedefault, solidbrushBlack, FontStyle.Strikeout);
                this.markuptextcontrol.appendText(richtextpart);
                execstrikethrough = false;
            }
            else if (execemphasis)
            {
#if DEBUG
                Console.WriteLine("Emphasis"+ emphasislevel + " at " + richtextpart_start_pos + " for " + (i - richtextpart_start_pos) + " chars.");
#endif
                int emphasisfontstyle = (int)FontStyle.Italic;
                if (emphasislevel >= 2)
                {
                    emphasisfontstyle = (int)FontStyle.Bold;
                }
                if (emphasislevel >= 3)
                {
                    emphasisfontstyle += (int)FontStyle.Italic;
                }

                string plaintext = markup.Substring(richtextpart_start_pos, i - richtextpart_start_pos);
                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.fontsizedefault, solidbrushBlack, (FontStyle)emphasisfontstyle);
                this.markuptextcontrol.appendText(richtextpart);
                // reset:
                execemphasis = false;
                emphasis_closing = false;
                emphasis_on = false;
                emphasislevel = 0;
            }
            
         
            if (markupcode)
            {
                previous_markup_char = chr;
                previous_markup_char_position = i;
            }

            previous_char = chr;
        }
*/

        this.markuptextcontrol.Refresh();
    }
}
