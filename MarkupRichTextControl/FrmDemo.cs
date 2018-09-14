using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            this.markupRichtextControl.appendText(richtextpartFS12);
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

        private void btnLoadMarkupTest1_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "test\r\ntesttest\r\ntesttesttest\r\ntesttest\r\nTest: [Github page](https://github.com/NoteFly/MarkupRichtextControl) hyperlink.\r\n";
        }

        private void btnLoadMarkupTest2_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "# head1\r\n## head2\r\n## head2 with closing##\r\n### head3\r\n#### head4 \r\nSome plaintext before head5.\r\n##### head5\r\n";
        }

        private void btnLoadMarkupTest3_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "plaintext1 *italic1* plaintext2 _italic2_\r\n" +
                "plaintext3 **bold1** plaintext4 __bold2__\r\n" +
                "plaintext5 ***bolditalic1*** plaintext6 ___bolditalic2___\r\n" +
                "plaintext7 *_bold3_*";
        }

        private void btnLoadMarkupTest4_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "list:\r\n- item1\r\n- item2\r\n- item3\r\n";
        }

        private void btnLoadMarkupTest5_Click(object sender, EventArgs e)
        {
            this.tbMarkup.Text = "strikethrough test ~failed~\r\n";
        }
    }
}
