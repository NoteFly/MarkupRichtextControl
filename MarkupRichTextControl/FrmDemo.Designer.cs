namespace TestMarkupRichTextControl
{
    partial class FrmMainTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddRichtext = new System.Windows.Forms.Button();
            this.tbNewText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.colorDialogTextcolor = new System.Windows.Forms.ColorDialog();
            this.pnlSelectTextColor = new System.Windows.Forms.Panel();
            this.chxBold = new System.Windows.Forms.CheckBox();
            this.chxItalic = new System.Windows.Forms.CheckBox();
            this.chxUnderline = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numUpDownWidthRichMarkupEditorControl = new System.Windows.Forms.NumericUpDown();
            this.tbMarkup = new System.Windows.Forms.TextBox();
            this.btnParseMarkupAndDisplay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chxStrikeout = new System.Windows.Forms.CheckBox();
            this.tbHyperlink = new System.Windows.Forms.TextBox();
            this.chxHyperlink = new System.Windows.Forms.CheckBox();
            this.markupRichTextControl = new MarkupRichtextControl();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidthRichMarkupEditorControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRichtext
            // 
            this.btnAddRichtext.Location = new System.Drawing.Point(406, 32);
            this.btnAddRichtext.Name = "btnAddRichtext";
            this.btnAddRichtext.Size = new System.Drawing.Size(70, 48);
            this.btnAddRichtext.TabIndex = 5;
            this.btnAddRichtext.Text = "Add rich text";
            this.btnAddRichtext.UseVisualStyleBackColor = true;
            this.btnAddRichtext.Click += new System.EventHandler(this.btnAddRichtext_Click);
            // 
            // tbNewText
            // 
            this.tbNewText.Location = new System.Drawing.Point(43, 57);
            this.tbNewText.Name = "tbNewText";
            this.tbNewText.Size = new System.Drawing.Size(158, 20);
            this.tbNewText.TabIndex = 6;
            this.tbNewText.Text = "test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Text:";
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Location = new System.Drawing.Point(207, 57);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(34, 13);
            this.lblTextColor.TabIndex = 9;
            this.lblTextColor.Text = "Color:";
            // 
            // pnlSelectTextColor
            // 
            this.pnlSelectTextColor.BackColor = System.Drawing.Color.Red;
            this.pnlSelectTextColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSelectTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSelectTextColor.ForeColor = System.Drawing.Color.Black;
            this.pnlSelectTextColor.Location = new System.Drawing.Point(247, 48);
            this.pnlSelectTextColor.Name = "pnlSelectTextColor";
            this.pnlSelectTextColor.Size = new System.Drawing.Size(32, 32);
            this.pnlSelectTextColor.TabIndex = 10;
            this.pnlSelectTextColor.Click += new System.EventHandler(this.pnlSelectTextColor_Click);
            // 
            // chxBold
            // 
            this.chxBold.AutoSize = true;
            this.chxBold.Location = new System.Drawing.Point(285, 45);
            this.chxBold.Name = "chxBold";
            this.chxBold.Size = new System.Drawing.Size(47, 17);
            this.chxBold.TabIndex = 11;
            this.chxBold.Text = "Bold";
            this.chxBold.UseVisualStyleBackColor = true;
            // 
            // chxItalic
            // 
            this.chxItalic.AutoSize = true;
            this.chxItalic.Location = new System.Drawing.Point(285, 63);
            this.chxItalic.Name = "chxItalic";
            this.chxItalic.Size = new System.Drawing.Size(48, 17);
            this.chxItalic.TabIndex = 12;
            this.chxItalic.Text = "Italic";
            this.chxItalic.UseVisualStyleBackColor = true;
            // 
            // chxUnderline
            // 
            this.chxUnderline.AutoSize = true;
            this.chxUnderline.Location = new System.Drawing.Point(339, 63);
            this.chxUnderline.Name = "chxUnderline";
            this.chxUnderline.Size = new System.Drawing.Size(71, 17);
            this.chxUnderline.TabIndex = 13;
            this.chxUnderline.Text = "Underline";
            this.chxUnderline.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "RichMarkupEditorControl width:";
            // 
            // numUpDownWidthRichMarkupEditorControl
            // 
            this.numUpDownWidthRichMarkupEditorControl.Location = new System.Drawing.Point(168, 19);
            this.numUpDownWidthRichMarkupEditorControl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownWidthRichMarkupEditorControl.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpDownWidthRichMarkupEditorControl.Name = "numUpDownWidthRichMarkupEditorControl";
            this.numUpDownWidthRichMarkupEditorControl.Size = new System.Drawing.Size(68, 20);
            this.numUpDownWidthRichMarkupEditorControl.TabIndex = 15;
            this.numUpDownWidthRichMarkupEditorControl.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numUpDownWidthRichMarkupEditorControl.ValueChanged += new System.EventHandler(this.numUpDownWidthRichMarkupEditorControl_ValueChanged);
            this.numUpDownWidthRichMarkupEditorControl.Leave += new System.EventHandler(this.numUpDownWidthRichMarkupEditorControl_Leave);
            // 
            // tbMarkup
            // 
            this.tbMarkup.Location = new System.Drawing.Point(16, 412);
            this.tbMarkup.Multiline = true;
            this.tbMarkup.Name = "tbMarkup";
            this.tbMarkup.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMarkup.Size = new System.Drawing.Size(368, 125);
            this.tbMarkup.TabIndex = 16;
            this.tbMarkup.Text = "# head1\r\n##  head2\r\n##  head2withclosing ##\r\n###head3\r\n#### head4\r\n##### head5\r\n-" +
    " item1\r\n- item2\r\n~test~ *test*";
            // 
            // btnParseMarkupAndDisplay
            // 
            this.btnParseMarkupAndDisplay.Location = new System.Drawing.Point(390, 467);
            this.btnParseMarkupAndDisplay.Name = "btnParseMarkupAndDisplay";
            this.btnParseMarkupAndDisplay.Size = new System.Drawing.Size(98, 70);
            this.btnParseMarkupAndDisplay.TabIndex = 17;
            this.btnParseMarkupAndDisplay.Text = "Parse markup and display rich text";
            this.btnParseMarkupAndDisplay.UseVisualStyleBackColor = true;
            this.btnParseMarkupAndDisplay.Click += new System.EventHandler(this.btnParseMarkupAndDisplay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chxStrikeout);
            this.groupBox1.Controls.Add(this.tbHyperlink);
            this.groupBox1.Controls.Add(this.chxHyperlink);
            this.groupBox1.Controls.Add(this.btnAddRichtext);
            this.groupBox1.Controls.Add(this.chxBold);
            this.groupBox1.Controls.Add(this.chxItalic);
            this.groupBox1.Controls.Add(this.numUpDownWidthRichMarkupEditorControl);
            this.groupBox1.Controls.Add(this.chxUnderline);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pnlSelectTextColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTextColor);
            this.groupBox1.Controls.Add(this.tbNewText);
            this.groupBox1.Location = new System.Drawing.Point(12, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 91);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual add rich text";
            // 
            // chxStrikeout
            // 
            this.chxStrikeout.AutoSize = true;
            this.chxStrikeout.Location = new System.Drawing.Point(338, 45);
            this.chxStrikeout.Name = "chxStrikeout";
            this.chxStrikeout.Size = new System.Drawing.Size(68, 17);
            this.chxStrikeout.TabIndex = 18;
            this.chxStrikeout.Text = "Strikeout";
            this.chxStrikeout.UseVisualStyleBackColor = true;
            // 
            // tbHyperlink
            // 
            this.tbHyperlink.Enabled = false;
            this.tbHyperlink.Location = new System.Drawing.Point(326, 8);
            this.tbHyperlink.Name = "tbHyperlink";
            this.tbHyperlink.Size = new System.Drawing.Size(150, 20);
            this.tbHyperlink.TabIndex = 17;
            this.tbHyperlink.Text = "https://www.github.com/NoteFly";
            // 
            // chxHyperlink
            // 
            this.chxHyperlink.AutoSize = true;
            this.chxHyperlink.Location = new System.Drawing.Point(254, 10);
            this.chxHyperlink.Name = "chxHyperlink";
            this.chxHyperlink.Size = new System.Drawing.Size(73, 17);
            this.chxHyperlink.TabIndex = 16;
            this.chxHyperlink.Text = "Hyperlink:";
            this.chxHyperlink.UseVisualStyleBackColor = true;
            this.chxHyperlink.CheckedChanged += new System.EventHandler(this.chxHyperlink_CheckedChanged);
            // 
            // markupRichTextControl
            // 
            this.markupRichTextControl.BackColor = System.Drawing.Color.White;
            this.markupRichTextControl.Location = new System.Drawing.Point(12, 12);
            this.markupRichTextControl.Name = "markupRichTextControl";
            this.markupRichTextControl.Size = new System.Drawing.Size(400, 297);
            this.markupRichTextControl.TabIndex = 4;
            // 
            // FrmMainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnParseMarkupAndDisplay);
            this.Controls.Add(this.tbMarkup);
            this.Controls.Add(this.markupRichTextControl);
            this.Name = "FrmMainTest";
            this.Text = "NoteFly testing MarkupRichTextControl";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidthRichMarkupEditorControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MarkupRichtextControl markupRichTextControl;
        private System.Windows.Forms.Button btnAddRichtext;
        private System.Windows.Forms.TextBox tbNewText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.ColorDialog colorDialogTextcolor;
        private System.Windows.Forms.Panel pnlSelectTextColor;
        private System.Windows.Forms.CheckBox chxBold;
        private System.Windows.Forms.CheckBox chxItalic;
        private System.Windows.Forms.CheckBox chxUnderline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDownWidthRichMarkupEditorControl;
        private System.Windows.Forms.TextBox tbMarkup;
        private System.Windows.Forms.Button btnParseMarkupAndDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chxHyperlink;
        private System.Windows.Forms.TextBox tbHyperlink;
        private System.Windows.Forms.CheckBox chxStrikeout;
    }
}

