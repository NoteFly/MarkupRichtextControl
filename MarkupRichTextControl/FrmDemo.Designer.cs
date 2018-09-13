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
            this.lbTextText = new System.Windows.Forms.Label();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.colorDialogTextcolor = new System.Windows.Forms.ColorDialog();
            this.pnlSelectTextColor = new System.Windows.Forms.Panel();
            this.chxBold = new System.Windows.Forms.CheckBox();
            this.chxItalic = new System.Windows.Forms.CheckBox();
            this.chxUnderline = new System.Windows.Forms.CheckBox();
            this.lbTextControlWidth = new System.Windows.Forms.Label();
            this.numUpDownWidthRichMarkupEditorControl = new System.Windows.Forms.NumericUpDown();
            this.tbMarkup1 = new System.Windows.Forms.TextBox();
            this.btnParseMarkupAndDisplay1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chxNewLine = new System.Windows.Forms.CheckBox();
            this.lbTextControlWidthUnits = new System.Windows.Forms.Label();
            this.chxStrikeout = new System.Windows.Forms.CheckBox();
            this.tbHyperlink = new System.Windows.Forms.TextBox();
            this.chxHyperlink = new System.Windows.Forms.CheckBox();
            this.tbMarkup2 = new System.Windows.Forms.TextBox();
            this.tbMarkup3 = new System.Windows.Forms.TextBox();
            this.btnParseMarkupAndDisplay2 = new System.Windows.Forms.Button();
            this.btnParseMarkupAndDisplay3 = new System.Windows.Forms.Button();
            this.tbMarkup4 = new System.Windows.Forms.TextBox();
            this.btnParseMarkupAndDisplay4 = new System.Windows.Forms.Button();
            this.markupRichTextControl = new MarkupRichtextControl();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidthRichMarkupEditorControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRichtext
            // 
            this.btnAddRichtext.Location = new System.Drawing.Point(497, 42);
            this.btnAddRichtext.Name = "btnAddRichtext";
            this.btnAddRichtext.Size = new System.Drawing.Size(98, 48);
            this.btnAddRichtext.TabIndex = 5;
            this.btnAddRichtext.Text = "Add rich text";
            this.btnAddRichtext.UseVisualStyleBackColor = true;
            this.btnAddRichtext.Click += new System.EventHandler(this.btnAddRichtext_Click);
            // 
            // tbNewText
            // 
            this.tbNewText.Location = new System.Drawing.Point(43, 57);
            this.tbNewText.Name = "tbNewText";
            this.tbNewText.Size = new System.Drawing.Size(171, 20);
            this.tbNewText.TabIndex = 6;
            this.tbNewText.Text = "test";
            // 
            // lbTextText
            // 
            this.lbTextText.AutoSize = true;
            this.lbTextText.Location = new System.Drawing.Point(6, 60);
            this.lbTextText.Name = "lbTextText";
            this.lbTextText.Size = new System.Drawing.Size(31, 13);
            this.lbTextText.TabIndex = 7;
            this.lbTextText.Text = "Text:";
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Location = new System.Drawing.Point(419, 65);
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
            this.pnlSelectTextColor.Location = new System.Drawing.Point(459, 48);
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
            // lbTextControlWidth
            // 
            this.lbTextControlWidth.AutoSize = true;
            this.lbTextControlWidth.Location = new System.Drawing.Point(6, 26);
            this.lbTextControlWidth.Name = "lbTextControlWidth";
            this.lbTextControlWidth.Size = new System.Drawing.Size(146, 13);
            this.lbTextControlWidth.TabIndex = 14;
            this.lbTextControlWidth.Text = "MarkupRichtextControl width:";
            // 
            // numUpDownWidthRichMarkupEditorControl
            // 
            this.numUpDownWidthRichMarkupEditorControl.Location = new System.Drawing.Point(168, 24);
            this.numUpDownWidthRichMarkupEditorControl.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownWidthRichMarkupEditorControl.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numUpDownWidthRichMarkupEditorControl.Name = "numUpDownWidthRichMarkupEditorControl";
            this.numUpDownWidthRichMarkupEditorControl.Size = new System.Drawing.Size(46, 20);
            this.numUpDownWidthRichMarkupEditorControl.TabIndex = 15;
            this.numUpDownWidthRichMarkupEditorControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUpDownWidthRichMarkupEditorControl.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numUpDownWidthRichMarkupEditorControl.ValueChanged += new System.EventHandler(this.numUpDownWidthRichMarkupEditorControl_ValueChanged);
            this.numUpDownWidthRichMarkupEditorControl.Leave += new System.EventHandler(this.numUpDownWidthRichMarkupEditorControl_Leave);
            // 
            // tbMarkup1
            // 
            this.tbMarkup1.Location = new System.Drawing.Point(16, 412);
            this.tbMarkup1.Multiline = true;
            this.tbMarkup1.Name = "tbMarkup1";
            this.tbMarkup1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMarkup1.Size = new System.Drawing.Size(191, 125);
            this.tbMarkup1.TabIndex = 16;
            this.tbMarkup1.Text = "test\r\ntesttest\r\ntesttesttest\r\ntesttest\r\nhyperlinktest\r\n[Github page control](http" +
    "s://github.com/NoteFly/MarkupRichtextControl) \r\nNoteFly [website](https://www.no" +
    "tefly.org)\r\n";
            // 
            // btnParseMarkupAndDisplay1
            // 
            this.btnParseMarkupAndDisplay1.Location = new System.Drawing.Point(12, 543);
            this.btnParseMarkupAndDisplay1.Name = "btnParseMarkupAndDisplay1";
            this.btnParseMarkupAndDisplay1.Size = new System.Drawing.Size(195, 40);
            this.btnParseMarkupAndDisplay1.TabIndex = 17;
            this.btnParseMarkupAndDisplay1.Text = "Parse markup and display rich text";
            this.btnParseMarkupAndDisplay1.UseVisualStyleBackColor = true;
            this.btnParseMarkupAndDisplay1.Click += new System.EventHandler(this.btnParseMarkupAndDisplay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chxItalic);
            this.groupBox1.Controls.Add(this.chxNewLine);
            this.groupBox1.Controls.Add(this.lbTextControlWidthUnits);
            this.groupBox1.Controls.Add(this.chxStrikeout);
            this.groupBox1.Controls.Add(this.tbHyperlink);
            this.groupBox1.Controls.Add(this.chxHyperlink);
            this.groupBox1.Controls.Add(this.btnAddRichtext);
            this.groupBox1.Controls.Add(this.chxBold);
            this.groupBox1.Controls.Add(this.numUpDownWidthRichMarkupEditorControl);
            this.groupBox1.Controls.Add(this.chxUnderline);
            this.groupBox1.Controls.Add(this.lbTextControlWidth);
            this.groupBox1.Controls.Add(this.pnlSelectTextColor);
            this.groupBox1.Controls.Add(this.lbTextText);
            this.groupBox1.Controls.Add(this.lblTextColor);
            this.groupBox1.Controls.Add(this.tbNewText);
            this.groupBox1.Location = new System.Drawing.Point(12, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 91);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manually add rich text part";
            // 
            // chxNewLine
            // 
            this.chxNewLine.AutoSize = true;
            this.chxNewLine.Location = new System.Drawing.Point(220, 61);
            this.chxNewLine.Name = "chxNewLine";
            this.chxNewLine.Size = new System.Drawing.Size(68, 17);
            this.chxNewLine.TabIndex = 20;
            this.chxNewLine.Text = "NewLine";
            this.chxNewLine.UseVisualStyleBackColor = true;
            // 
            // lbTextControlWidthUnits
            // 
            this.lbTextControlWidthUnits.AutoSize = true;
            this.lbTextControlWidthUnits.Location = new System.Drawing.Point(220, 26);
            this.lbTextControlWidthUnits.Name = "lbTextControlWidthUnits";
            this.lbTextControlWidthUnits.Size = new System.Drawing.Size(18, 13);
            this.lbTextControlWidthUnits.TabIndex = 19;
            this.lbTextControlWidthUnits.Text = "px";
            // 
            // chxStrikeout
            // 
            this.chxStrikeout.AutoSize = true;
            this.chxStrikeout.Location = new System.Drawing.Point(339, 45);
            this.chxStrikeout.Name = "chxStrikeout";
            this.chxStrikeout.Size = new System.Drawing.Size(87, 17);
            this.chxStrikeout.TabIndex = 18;
            this.chxStrikeout.Text = "strikethrough";
            this.chxStrikeout.UseVisualStyleBackColor = true;
            // 
            // tbHyperlink
            // 
            this.tbHyperlink.Enabled = false;
            this.tbHyperlink.Location = new System.Drawing.Point(373, 16);
            this.tbHyperlink.Name = "tbHyperlink";
            this.tbHyperlink.Size = new System.Drawing.Size(222, 20);
            this.tbHyperlink.TabIndex = 17;
            this.tbHyperlink.Text = "https://github.com/NoteFly/MarkupRichtextControl";
            // 
            // chxHyperlink
            // 
            this.chxHyperlink.AutoSize = true;
            this.chxHyperlink.Location = new System.Drawing.Point(285, 19);
            this.chxHyperlink.Name = "chxHyperlink";
            this.chxHyperlink.Size = new System.Drawing.Size(87, 17);
            this.chxHyperlink.TabIndex = 16;
            this.chxHyperlink.Text = "Hyperlink url:";
            this.chxHyperlink.UseVisualStyleBackColor = true;
            this.chxHyperlink.CheckedChanged += new System.EventHandler(this.chxHyperlink_CheckedChanged);
            // 
            // tbMarkup2
            // 
            this.tbMarkup2.Location = new System.Drawing.Point(213, 412);
            this.tbMarkup2.Multiline = true;
            this.tbMarkup2.Name = "tbMarkup2";
            this.tbMarkup2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMarkup2.Size = new System.Drawing.Size(199, 125);
            this.tbMarkup2.TabIndex = 19;
            this.tbMarkup2.Text = "# head1\r\n## head2\r\n## head2 with closing##\r\n### head3\r\n#### head4 \r\nSome plaintex" +
    "t before head5.\r\n##### head5\r\n";
            // 
            // tbMarkup3
            // 
            this.tbMarkup3.Location = new System.Drawing.Point(418, 412);
            this.tbMarkup3.Multiline = true;
            this.tbMarkup3.Name = "tbMarkup3";
            this.tbMarkup3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMarkup3.Size = new System.Drawing.Size(214, 125);
            this.tbMarkup3.TabIndex = 20;
            this.tbMarkup3.Text = "strikethrough test ~failed~\r\nlist:\r\n- item1\r\n- item2\r\n- item3\r\n";
            // 
            // btnParseMarkupAndDisplay2
            // 
            this.btnParseMarkupAndDisplay2.Location = new System.Drawing.Point(213, 543);
            this.btnParseMarkupAndDisplay2.Name = "btnParseMarkupAndDisplay2";
            this.btnParseMarkupAndDisplay2.Size = new System.Drawing.Size(199, 40);
            this.btnParseMarkupAndDisplay2.TabIndex = 21;
            this.btnParseMarkupAndDisplay2.Text = "Parse markup and display rich text";
            this.btnParseMarkupAndDisplay2.UseVisualStyleBackColor = true;
            this.btnParseMarkupAndDisplay2.Click += new System.EventHandler(this.btnParseMarkupAndDisplay2_Click);
            // 
            // btnParseMarkupAndDisplay3
            // 
            this.btnParseMarkupAndDisplay3.Location = new System.Drawing.Point(418, 543);
            this.btnParseMarkupAndDisplay3.Name = "btnParseMarkupAndDisplay3";
            this.btnParseMarkupAndDisplay3.Size = new System.Drawing.Size(214, 40);
            this.btnParseMarkupAndDisplay3.TabIndex = 22;
            this.btnParseMarkupAndDisplay3.Text = "Parse markup and display rich text";
            this.btnParseMarkupAndDisplay3.UseVisualStyleBackColor = true;
            this.btnParseMarkupAndDisplay3.Click += new System.EventHandler(this.btnParseMarkupAndDisplay3_Click);
            // 
            // tbMarkup4
            // 
            this.tbMarkup4.Location = new System.Drawing.Point(638, 412);
            this.tbMarkup4.Multiline = true;
            this.tbMarkup4.Name = "tbMarkup4";
            this.tbMarkup4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMarkup4.Size = new System.Drawing.Size(196, 125);
            this.tbMarkup4.TabIndex = 23;
            this.tbMarkup4.Text = "plaintext1 *italic1* plaintext2 _italic2_ plaintext3 **bold1** plaintext4 __bold2" +
    "__ plaintext5\r\n***bolditalic1*** plaintext6 ___bolditalic2___ plaintext7";
            // 
            // btnParseMarkupAndDisplay4
            // 
            this.btnParseMarkupAndDisplay4.Location = new System.Drawing.Point(638, 543);
            this.btnParseMarkupAndDisplay4.Name = "btnParseMarkupAndDisplay4";
            this.btnParseMarkupAndDisplay4.Size = new System.Drawing.Size(196, 40);
            this.btnParseMarkupAndDisplay4.TabIndex = 24;
            this.btnParseMarkupAndDisplay4.Text = "Parse markup and display rich text";
            this.btnParseMarkupAndDisplay4.UseVisualStyleBackColor = true;
            this.btnParseMarkupAndDisplay4.Click += new System.EventHandler(this.btnParseMarkupAndDisplay4_Click);
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
            this.ClientSize = new System.Drawing.Size(846, 599);
            this.Controls.Add(this.btnParseMarkupAndDisplay4);
            this.Controls.Add(this.tbMarkup4);
            this.Controls.Add(this.btnParseMarkupAndDisplay3);
            this.Controls.Add(this.btnParseMarkupAndDisplay2);
            this.Controls.Add(this.tbMarkup3);
            this.Controls.Add(this.tbMarkup2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnParseMarkupAndDisplay1);
            this.Controls.Add(this.tbMarkup1);
            this.Controls.Add(this.markupRichTextControl);
            this.Name = "FrmMainTest";
            this.Text = "Testing of MarkupRichTextControl";
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
        private System.Windows.Forms.Label lbTextText;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.ColorDialog colorDialogTextcolor;
        private System.Windows.Forms.Panel pnlSelectTextColor;
        private System.Windows.Forms.CheckBox chxBold;
        private System.Windows.Forms.CheckBox chxItalic;
        private System.Windows.Forms.CheckBox chxUnderline;
        private System.Windows.Forms.Label lbTextControlWidth;
        private System.Windows.Forms.NumericUpDown numUpDownWidthRichMarkupEditorControl;
        private System.Windows.Forms.TextBox tbMarkup1;
        private System.Windows.Forms.Button btnParseMarkupAndDisplay1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chxHyperlink;
        private System.Windows.Forms.TextBox tbHyperlink;
        private System.Windows.Forms.CheckBox chxStrikeout;
        private System.Windows.Forms.TextBox tbMarkup2;
        private System.Windows.Forms.TextBox tbMarkup3;
        private System.Windows.Forms.Button btnParseMarkupAndDisplay2;
        private System.Windows.Forms.Button btnParseMarkupAndDisplay3;
        private System.Windows.Forms.Label lbTextControlWidthUnits;
        private System.Windows.Forms.TextBox tbMarkup4;
        private System.Windows.Forms.Button btnParseMarkupAndDisplay4;
        private System.Windows.Forms.CheckBox chxNewLine;
    }
}

