using System;
using System.Drawing;

partial class MarkupToRichtextParser
{
    private int fontsizedefault = 12;

    private int[] headsfontsizes = new int[] { 24, 22, 20, 18, 16, 14 };

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
        bool markupcode = false;
        bool markupclosing = false;
        char previous_markup_char = '\0';
        char previous_char = '\0';
        int richtextpart_start_pos = 0;
        int markup_last_char_pos = markup.Length - 1;

        bool execstrikethrough = false;
        bool execemphasis = false;

        bool head_on = false;
        int headlevel = 0;

        bool list_on = false;
        int numrepeateddashes = 0;

        bool emphasis_on = false;
        int emphasislevel = 0;

        bool strikethrough_on = false;
        SolidBrush solidbrushBlack = new SolidBrush(Color.Black);
        
        for (int i = 0; i < markup.Length; i++)
        {
            bool newline = false;
            char chr = markup[i];
#if DEBUG
            Console.WriteLine(i+"|chr=" + chr);
#endif
            switch (chr)
            {
                case '#':
                    // head
                    markupcode = true;
                    head_on = true;
                    //if (!markupclosing)
                    //{
                        headlevel++;
                    //}

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
                    if (!emphasis_on)
                    {
                        emphasislevel = 1;
                    }
                    if (chr == previous_char)
                    {
                        emphasislevel++;
                    }
                    else if (chr == previous_markup_char)
                    {
                        markupclosing = true;
                        emphasislevel--;
                        if (emphasislevel == 0)
                        {
                            execemphasis = true;
                        }
                    }

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
                        //if (markupclosing)
                        //{
                            richtextpart_start_pos = i;
#if DEBUG
                            Console.WriteLine("richtextpartstartpos=" + richtextpart_start_pos);
#endif
                        //}
                        markupclosing = !markupclosing;
#if DEBUG
                        Console.WriteLine("markupclosing=" + markupclosing.ToString());
#endif
                    }

                    numrepeateddashes = 0;
                    markupcode = false;
                    //markupclosing = false;
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
                Console.WriteLine("head"+ headlevel + " at " + richtextpart_start_pos + " for " + (i - richtextpart_start_pos) + " chars.");
                
                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.headsfontsizes[headlevel], solidbrushBlack, FontStyle.Bold);
                richtextpart.AppendNewLine = true;
                this.markuptextcontrol.appendText(richtextpart);
                // reset:
                head_on = false;
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
                Console.WriteLine("Striketought at " + richtextpart_start_pos + " for " + (i - richtextpart_start_pos) + " chars.");
                string plaintext = markup.Substring(richtextpart_start_pos, i - richtextpart_start_pos);
                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.fontsizedefault, solidbrushBlack, FontStyle.Strikeout);
                this.markuptextcontrol.appendText(richtextpart);
                execstrikethrough = false;
            }
            else if (execemphasis)
            {
                Console.WriteLine("Emphasis at " + richtextpart_start_pos + " for " + (i - richtextpart_start_pos) + " chars.");
                string plaintext = markup.Substring(richtextpart_start_pos, i - richtextpart_start_pos);
                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.fontsizedefault, solidbrushBlack, FontStyle.Bold);
                this.markuptextcontrol.appendText(richtextpart);
                execemphasis = false;
            }
            /*

            else if (markupcode || i == markup.Length && i > 0 && !markupclosing)
            {
                // normal text.
                string plaintext = markup.Substring(richtextpartstartpos, i - richtextpartstartpos);
                RichTextPart richtextpart = new RichTextPart(plaintext, "Arial", this.fontsizedefault, solidbrushBlack, FontStyle.Regular);
                this.markuptextcontrol.appendText(richtextpart);
            }
             */

            if (markupcode)
            {
                previous_markup_char = chr;
            }

            previous_char = chr;
        }


        this.markuptextcontrol.Refresh();
    }
}
