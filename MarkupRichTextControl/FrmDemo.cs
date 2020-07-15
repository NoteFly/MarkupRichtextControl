using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestMarkupRichTextControl
{
    public partial class FrmMainTest : Form
    {
        private MarkupToRichtextParser markupparser;

        public FrmMainTest()
        {
            InitializeComponent();
            this.numUpDownWidthRichMarkupEditorControl.Value = Convert.ToDecimal(this.markupRichtextControl.Width);
            this.markupparser = new MarkupToRichtextParser(this.markupRichtextControl);
            this.cbxWarpOn.SelectedIndex = 0;
        }

        private void btnAddRichtext_Click(object sender, EventArgs e)
        {
            SolidBrush textcolor = new SolidBrush(this.pnlSelectTextColor.BackColor);
            RichTextPart richtextpartFS12 = new RichTextPart(this.tbNewText.Text, "arial", 12, textcolor, (FontStyle)this.getTextStylesValue());
            if (this.chxNewLine.Checked)
            {
                richtextpartFS12.AppendNewLine = true;
            }

            if (this.chxHyperlink.Checked)
            {
                richtextpartFS12.Href = this.tbHyperlink.Text;
            }

            this.markupRichtextControl.Append(richtextpartFS12);
            this.Refresh();
        }

        private void pnlSelectTextColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialogTextcolor.ShowDialog() == DialogResult.OK)
            {
                this.pnlSelectTextColor.BackColor = this.colorDialogTextcolor.Color;
            }
        }

        private int getTextStylesValue()
        {
            int textstylevalue = (int)FontStyle.Regular;
            if (this.chxBold.Checked)
            {
                textstylevalue += (int)FontStyle.Bold;
            }

            if (this.chxItalic.Checked)
            {
                textstylevalue += (int)FontStyle.Italic;
            }

            if (this.chxUnderline.Checked)
            {
                textstylevalue += (int)FontStyle.Underline;
            }

            if (this.chxStrikeout.Checked)
            {
                textstylevalue += (int)FontStyle.Strikeout;
            }
            
            return textstylevalue;
        }

        private void numUpDownWidthRichMarkupEditorControl_ValueChanged(object sender, EventArgs e)
        {
            this.markupRichtextControl.Width = Convert.ToInt32(this.numUpDownWidthRichMarkupEditorControl.Value);
        }

        private void numUpDownWidthRichMarkupEditorControl_Leave(object sender, EventArgs e)
        {
            this.markupRichtextControl.Refresh();
        }

        private void chxHyperlink_CheckedChanged(object sender, EventArgs e)
        {
            this.tbHyperlink.Enabled = this.chxHyperlink.Checked;
            if (this.chxHyperlink.Checked)
            {
                this.chxUnderline.Checked = true;
                this.pnlSelectTextColor.BackColor = Color.Blue;
            } else
            {
                this.chxUnderline.Checked = false;
            }
        }

        private void btnParseMarkupAndDisplay_Click(object sender, EventArgs e)
        {
            this.markupRichtextControl.Clear();
            this.markupparser.ParseMarkup(this.tbMarkup.Text);
        }

        private void cbxWarpOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbxWarpOn.SelectedIndex)
            {
                case 0:
                    this.markupRichtextControl.wordwrapmodus = MarkupRichtextControl.WordWrapMode.OnCharacter;
                    break;
                case 1:
                    this.markupRichtextControl.wordwrapmodus = MarkupRichtextControl.WordWrapMode.OnWord;
                    break;
                case 2:
                    this.markupRichtextControl.wordwrapmodus = MarkupRichtextControl.WordWrapMode.OnSentence;
                    break;
            }

        }

        /// <summary>
        /// Set test 1 markup text to tbMarkup. 
        /// This is just plain text over multiple lines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest1_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "nomarkup\r\ntest\r\ntesttest\r\ntesttesttest\r\ntesttest\r\ntest";
        }

        /// <summary>
        /// Set test 2 markup text to tbMarkup.
        /// This are multiple markup heads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest2_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "# head1\r\n## head2\r\n## head2 with closing##\r\n### head3\r\n####      head4 \r\nSome plaintext before head5.\r\n##### head5\r\n";
        }

        /// <summary>
        /// Set test 3 markup text to tbMarkup.
        /// This are different formatted text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest3_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "plaintext1 *italic1* plaintext2 _italic2_\r\n" +
                "plaintext3 **bold1** plaintext4 __bold2__\r\n" +
                "plaintext5 ***bolditalic1*** plaintext6 ___bolditalic2___\r\n" +
                "plaintext7 *_bold3_*";
        }

        /// <summary>
        /// Set test 4 markup text to tbMarkup.
        /// This is a list in markup. With a dash in the 4th item of the list which should not be a extra list item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest4_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "list:\r\n- item1\r\n-item2\r\n- item3 test\r\n- item4-test\r\n- item5\r\n";
        }

        /// <summary>
        /// Set test 5 markup text to tbMarkup.
        /// For testing strike out text markup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest5_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "Strike out text test ~failed~\r\nTest";
        }

        /// <summary>
        /// Set test 6 markup text to tbMarkup.
        /// Testing markup hyperlinks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest6_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "Test [Github page](https://github.com/NoteFly/MarkupRichtextControl) hyperlink.\r\n";
        }

        /// <summary>
        /// Set test 7 markup text to tbMarkup.
        /// For testing nested markup. Bold and italic text for different overlapping parts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest7_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "richtext *_nested_ text test*\r\n*aaa_bbb_*ccc";
        }

        /// <summary>
        /// Set test 8 markup text to tbMarkup.
        /// Testing the creation of lines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest8_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "---\r\nbegin past, now middle line test:\r\n---\r\nTesting line by stars:\r\n***\r\n\r\n*** not a line, bold text ok.\r\n\r\nAnd a end line test:\r\n---";
        }

        /// <summary>
        /// Set test 9 markup text to tbMarkup.
        /// Testing the displaying of very long heads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest9_Click(object sender, EventArgs e)
        {
            StringBuilder sbhead = new StringBuilder();
            sbhead.Append("#");
            for (int i = 0; i < 10; i++)
            {
                sbhead.Append("longtitle");
            }

            sbhead.AppendLine();
            this.tbMarkup.Text = sbhead.ToString();
        }

        /// <summary>
        /// Set test 10 markup text to tbMarkup.
        /// Testing the displaying of very long plaintext lines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest10_Click(object sender, EventArgs e)
        {
            StringBuilder sbtext = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                sbtext.Append("longline");
            }

            sbtext.AppendLine();
            this.tbMarkup.Text = sbtext.ToString();
        }

        /// <summary>
        /// Set test 11 markup text to tbMarkup.
        /// Set Lorem ipsum text, good for testing word break setting on.
        /// How good or not is break on word/sentence working.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest11_Click(object sender, EventArgs e)
        {
            StringBuilder sbloremipsum = new StringBuilder("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. ");
            sbloremipsum.Append("Aenean commodo ligula eget dolor. Aenean massa. Cum ");
            sbloremipsum.Append("sociis natoque penatibus et magnis dis parturient montes, ");
            sbloremipsum.Append("nascetur ridiculus mus. Donec quam felis, ultricies nec, ");
            sbloremipsum.Append("pellentesque eu, pretium quis, sem. Nulla consequat massa ");
            sbloremipsum.Append("quis enim. Donec pede justo, fringilla vel, aliquet nec, ");
            sbloremipsum.Append("vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, ");
            sbloremipsum.Append("venenatis vitae, justo. Nullam dictum felis eu pede mollis ");
            sbloremipsum.Append("pretium. Integer tincidunt. Cras dapibus. Vivamus elementum ");
            sbloremipsum.Append("semper nisi. Aenean vulputate eleifend tellus. Aenean leo ");
            sbloremipsum.Append("ligula, porttitor eu, consequat vitae, eleifend ac, enim. ");
            this.tbMarkup.Text = sbloremipsum.ToString();
        }

        /// <summary>
        /// Set test 12 markup text to tbMarkup.
        /// Text with all kind of characters and special character going to be mixed up with markup because they are not escaped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMarkupTest12_Click(object sender, EventArgs e)
        {
            StringBuilder sbazAZspec = new StringBuilder("abc def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS ");
            sbazAZspec.AppendLine("TUV WXYZ !\"§ $% & / () =? *'<> #|; ²³~ @`´ ©«» ¤¼× {} abc ");
            sbazAZspec.AppendLine("def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS ");
            sbazAZspec.AppendLine("TUV WXYZ !\"§ $% & / () =? *'<> #|; ²³~ @`´ ©«» ¤¼× {} abc ");
            sbazAZspec.AppendLine("def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS ");
            sbazAZspec.AppendLine("TUV WXYZ !\"§ $% & / () =? *'<> #|; ²³~ @`´ ©«» ¤¼× {}abc ");
            sbazAZspec.AppendLine("def ghi jkl mno pqrs tuv wxyz ABC DEF GHI JKL MNO PQRS ");
            sbazAZspec.AppendLine("TUV WXYZ !\"§ $% & / () ");
            this.tbMarkup.Text = sbazAZspec.ToString();
        }
    }
}
