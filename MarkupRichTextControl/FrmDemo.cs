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
            numUpDownWidthRichMarkupEditorControl.Value = Convert.ToDecimal(this.markupRichTextControl.Width);
            this.markupparser = new MarkupToRichtextParser(this.markupRichTextControl);
        }

        private void btnAddRichtext_Click(object sender, EventArgs e)
        {
            SolidBrush textcolor = new SolidBrush(this.pnlSelectTextColor.BackColor);
            RichTextPart richtextpartFS12 = new RichTextPart(this.tbNewText.Text, "arial", 12, textcolor, (FontStyle)this.getTextStylesValue());
            if (this.chxHyperlink.Checked)
            {
                richtextpartFS12.Href = this.tbHyperlink.Text;
            }

            this.markupRichTextControl.appendText(richtextpartFS12);
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
            this.markupRichTextControl.Width = Convert.ToInt32(this.numUpDownWidthRichMarkupEditorControl.Value);
        }

        private void numUpDownWidthRichMarkupEditorControl_Leave(object sender, EventArgs e)
        {
            this.markupRichTextControl.Refresh();
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
            this.markupRichTextControl.Clear();
            this.markupparser.ParseMarkup(this.tbMarkup1.Text);
        }

        private void btnParseMarkupAndDisplay2_Click(object sender, EventArgs e)
        {
            this.markupRichTextControl.Clear();
            this.markupparser.ParseMarkup(this.tbMarkup2.Text);
        }

        private void btnParseMarkupAndDisplay3_Click(object sender, EventArgs e)
        {
            this.markupRichTextControl.Clear();
            this.markupparser.ParseMarkup(this.tbMarkup3.Text);
        }

        private void btnParseMarkupAndDisplay4_Click(object sender, EventArgs e)
        {
            this.markupRichTextControl.Clear();
            this.markupparser.ParseMarkup(this.tbMarkup4.Text);
        }
    }
}
