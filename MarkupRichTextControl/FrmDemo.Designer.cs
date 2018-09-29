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
            this.tbMarkup = new System.Windows.Forms.TextBox();
            this.btnParseMarkupAndDisplay1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chxNewLine = new System.Windows.Forms.CheckBox();
            this.chxStrikeout = new System.Windows.Forms.CheckBox();
            this.tbHyperlink = new System.Windows.Forms.TextBox();
            this.chxHyperlink = new System.Windows.Forms.CheckBox();
            this.lbTextControlWidthUnits = new System.Windows.Forms.Label();
            this.btnLoadMarkupTest1 = new System.Windows.Forms.Button();
            this.lblTextLoadMarkupTest = new System.Windows.Forms.Label();
            this.btnLoadMarkupTest2 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest3 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest4 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest5 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest6 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest7 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest8 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest9 = new System.Windows.Forms.Button();
            this.btnLoadMarkupTest10 = new System.Windows.Forms.Button();
            this.cbxWarpOn = new System.Windows.Forms.ComboBox();
            this.markupRichtextControl = new MarkupRichtextControl();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidthRichMarkupEditorControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRichtext
            // 
            this.btnAddRichtext.Location = new System.Drawing.Point(718, 24);
            this.btnAddRichtext.Name = "btnAddRichtext";
            this.btnAddRichtext.Size = new System.Drawing.Size(103, 48);
            this.btnAddRichtext.TabIndex = 5;
            this.btnAddRichtext.Text = "Add rich text";
            this.btnAddRichtext.UseVisualStyleBackColor = true;
            this.btnAddRichtext.Click += new System.EventHandler(this.btnAddRichtext_Click);
            // 
            // tbNewText
            // 
            this.tbNewText.Location = new System.Drawing.Point(38, 24);
            this.tbNewText.Name = "tbNewText";
            this.tbNewText.Size = new System.Drawing.Size(328, 20);
            this.tbNewText.TabIndex = 6;
            // 
            // lbTextText
            // 
            this.lbTextText.AutoSize = true;
            this.lbTextText.Location = new System.Drawing.Point(6, 27);
            this.lbTextText.Name = "lbTextText";
            this.lbTextText.Size = new System.Drawing.Size(31, 13);
            this.lbTextText.TabIndex = 7;
            this.lbTextText.Text = "Text:";
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Location = new System.Drawing.Point(605, 37);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(57, 13);
            this.lblTextColor.TabIndex = 9;
            this.lblTextColor.Text = "Text color:";
            // 
            // pnlSelectTextColor
            // 
            this.pnlSelectTextColor.BackColor = System.Drawing.Color.Black;
            this.pnlSelectTextColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSelectTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSelectTextColor.ForeColor = System.Drawing.Color.Black;
            this.pnlSelectTextColor.Location = new System.Drawing.Point(668, 26);
            this.pnlSelectTextColor.Name = "pnlSelectTextColor";
            this.pnlSelectTextColor.Size = new System.Drawing.Size(44, 41);
            this.pnlSelectTextColor.TabIndex = 10;
            this.pnlSelectTextColor.Click += new System.EventHandler(this.pnlSelectTextColor_Click);
            // 
            // chxBold
            // 
            this.chxBold.AutoSize = true;
            this.chxBold.Location = new System.Drawing.Point(552, 27);
            this.chxBold.Name = "chxBold";
            this.chxBold.Size = new System.Drawing.Size(47, 17);
            this.chxBold.TabIndex = 11;
            this.chxBold.Text = "Bold";
            this.chxBold.UseVisualStyleBackColor = true;
            // 
            // chxItalic
            // 
            this.chxItalic.AutoSize = true;
            this.chxItalic.Location = new System.Drawing.Point(552, 51);
            this.chxItalic.Name = "chxItalic";
            this.chxItalic.Size = new System.Drawing.Size(48, 17);
            this.chxItalic.TabIndex = 12;
            this.chxItalic.Text = "Italic";
            this.chxItalic.UseVisualStyleBackColor = true;
            // 
            // chxUnderline
            // 
            this.chxUnderline.AutoSize = true;
            this.chxUnderline.Location = new System.Drawing.Point(464, 51);
            this.chxUnderline.Name = "chxUnderline";
            this.chxUnderline.Size = new System.Drawing.Size(71, 17);
            this.chxUnderline.TabIndex = 13;
            this.chxUnderline.Text = "Underline";
            this.chxUnderline.UseVisualStyleBackColor = true;
            // 
            // lbTextControlWidth
            // 
            this.lbTextControlWidth.AutoSize = true;
            this.lbTextControlWidth.Location = new System.Drawing.Point(18, 481);
            this.lbTextControlWidth.Name = "lbTextControlWidth";
            this.lbTextControlWidth.Size = new System.Drawing.Size(35, 13);
            this.lbTextControlWidth.TabIndex = 14;
            this.lbTextControlWidth.Text = "width:";
            // 
            // numUpDownWidthRichMarkupEditorControl
            // 
            this.numUpDownWidthRichMarkupEditorControl.Location = new System.Drawing.Point(54, 479);
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
            this.numUpDownWidthRichMarkupEditorControl.Size = new System.Drawing.Size(52, 20);
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
            // tbMarkup
            // 
            this.tbMarkup.Location = new System.Drawing.Point(12, 64);
            this.tbMarkup.Multiline = true;
            this.tbMarkup.Name = "tbMarkup";
            this.tbMarkup.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMarkup.Size = new System.Drawing.Size(325, 363);
            this.tbMarkup.TabIndex = 16;
            // 
            // btnParseMarkupAndDisplay1
            // 
            this.btnParseMarkupAndDisplay1.Location = new System.Drawing.Point(12, 433);
            this.btnParseMarkupAndDisplay1.Name = "btnParseMarkupAndDisplay1";
            this.btnParseMarkupAndDisplay1.Size = new System.Drawing.Size(325, 40);
            this.btnParseMarkupAndDisplay1.TabIndex = 17;
            this.btnParseMarkupAndDisplay1.Text = "Parse markup and display rich text";
            this.btnParseMarkupAndDisplay1.UseVisualStyleBackColor = true;
            this.btnParseMarkupAndDisplay1.Click += new System.EventHandler(this.btnParseMarkupAndDisplay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chxItalic);
            this.groupBox1.Controls.Add(this.chxNewLine);
            this.groupBox1.Controls.Add(this.chxStrikeout);
            this.groupBox1.Controls.Add(this.tbHyperlink);
            this.groupBox1.Controls.Add(this.chxHyperlink);
            this.groupBox1.Controls.Add(this.btnAddRichtext);
            this.groupBox1.Controls.Add(this.chxBold);
            this.groupBox1.Controls.Add(this.chxUnderline);
            this.groupBox1.Controls.Add(this.pnlSelectTextColor);
            this.groupBox1.Controls.Add(this.lbTextText);
            this.groupBox1.Controls.Add(this.lblTextColor);
            this.groupBox1.Controls.Add(this.tbNewText);
            this.groupBox1.Location = new System.Drawing.Point(12, 512);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 75);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manually add rich text part";
            // 
            // chxNewLine
            // 
            this.chxNewLine.AutoSize = true;
            this.chxNewLine.Location = new System.Drawing.Point(372, 26);
            this.chxNewLine.Name = "chxNewLine";
            this.chxNewLine.Size = new System.Drawing.Size(86, 17);
            this.chxNewLine.TabIndex = 20;
            this.chxNewLine.Text = "add new line";
            this.chxNewLine.UseVisualStyleBackColor = true;
            // 
            // chxStrikeout
            // 
            this.chxStrikeout.AutoSize = true;
            this.chxStrikeout.Location = new System.Drawing.Point(464, 27);
            this.chxStrikeout.Name = "chxStrikeout";
            this.chxStrikeout.Size = new System.Drawing.Size(87, 17);
            this.chxStrikeout.TabIndex = 18;
            this.chxStrikeout.Text = "strikethrough";
            this.chxStrikeout.UseVisualStyleBackColor = true;
            // 
            // tbHyperlink
            // 
            this.tbHyperlink.Enabled = false;
            this.tbHyperlink.Location = new System.Drawing.Point(130, 49);
            this.tbHyperlink.Name = "tbHyperlink";
            this.tbHyperlink.Size = new System.Drawing.Size(328, 20);
            this.tbHyperlink.TabIndex = 17;
            this.tbHyperlink.Text = "https://";
            // 
            // chxHyperlink
            // 
            this.chxHyperlink.AutoSize = true;
            this.chxHyperlink.Location = new System.Drawing.Point(9, 51);
            this.chxHyperlink.Name = "chxHyperlink";
            this.chxHyperlink.Size = new System.Drawing.Size(118, 17);
            this.chxHyperlink.TabIndex = 16;
            this.chxHyperlink.Text = "Make hyperlink, url:";
            this.chxHyperlink.UseVisualStyleBackColor = true;
            this.chxHyperlink.CheckedChanged += new System.EventHandler(this.chxHyperlink_CheckedChanged);
            // 
            // lbTextControlWidthUnits
            // 
            this.lbTextControlWidthUnits.AutoSize = true;
            this.lbTextControlWidthUnits.Location = new System.Drawing.Point(112, 481);
            this.lbTextControlWidthUnits.Name = "lbTextControlWidthUnits";
            this.lbTextControlWidthUnits.Size = new System.Drawing.Size(18, 13);
            this.lbTextControlWidthUnits.TabIndex = 19;
            this.lbTextControlWidthUnits.Text = "px";
            // 
            // btnLoadMarkupTest1
            // 
            this.btnLoadMarkupTest1.Location = new System.Drawing.Point(105, 7);
            this.btnLoadMarkupTest1.Name = "btnLoadMarkupTest1";
            this.btnLoadMarkupTest1.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest1.TabIndex = 19;
            this.btnLoadMarkupTest1.Text = "#1";
            this.btnLoadMarkupTest1.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest1.Click += new System.EventHandler(this.btnLoadMarkupTest1_Click);
            // 
            // lblTextLoadMarkupTest
            // 
            this.lblTextLoadMarkupTest.AutoSize = true;
            this.lblTextLoadMarkupTest.Location = new System.Drawing.Point(9, 12);
            this.lblTextLoadMarkupTest.Name = "lblTextLoadMarkupTest";
            this.lblTextLoadMarkupTest.Size = new System.Drawing.Size(92, 13);
            this.lblTextLoadMarkupTest.TabIndex = 20;
            this.lblTextLoadMarkupTest.Text = "Load markup test:";
            // 
            // btnLoadMarkupTest2
            // 
            this.btnLoadMarkupTest2.Location = new System.Drawing.Point(142, 7);
            this.btnLoadMarkupTest2.Name = "btnLoadMarkupTest2";
            this.btnLoadMarkupTest2.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest2.TabIndex = 21;
            this.btnLoadMarkupTest2.Text = "#2";
            this.btnLoadMarkupTest2.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest2.Click += new System.EventHandler(this.btnLoadMarkupTest2_Click);
            // 
            // btnLoadMarkupTest3
            // 
            this.btnLoadMarkupTest3.Location = new System.Drawing.Point(180, 7);
            this.btnLoadMarkupTest3.Name = "btnLoadMarkupTest3";
            this.btnLoadMarkupTest3.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest3.TabIndex = 22;
            this.btnLoadMarkupTest3.Text = "#3";
            this.btnLoadMarkupTest3.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest3.Click += new System.EventHandler(this.btnLoadMarkupTest3_Click);
            // 
            // btnLoadMarkupTest4
            // 
            this.btnLoadMarkupTest4.Location = new System.Drawing.Point(217, 7);
            this.btnLoadMarkupTest4.Name = "btnLoadMarkupTest4";
            this.btnLoadMarkupTest4.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest4.TabIndex = 23;
            this.btnLoadMarkupTest4.Text = "#4";
            this.btnLoadMarkupTest4.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest4.Click += new System.EventHandler(this.btnLoadMarkupTest4_Click);
            // 
            // btnLoadMarkupTest5
            // 
            this.btnLoadMarkupTest5.Location = new System.Drawing.Point(255, 7);
            this.btnLoadMarkupTest5.Name = "btnLoadMarkupTest5";
            this.btnLoadMarkupTest5.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest5.TabIndex = 24;
            this.btnLoadMarkupTest5.Text = "#5";
            this.btnLoadMarkupTest5.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest5.Click += new System.EventHandler(this.btnLoadMarkupTest5_Click);
            // 
            // btnLoadMarkupTest6
            // 
            this.btnLoadMarkupTest6.Location = new System.Drawing.Point(105, 35);
            this.btnLoadMarkupTest6.Name = "btnLoadMarkupTest6";
            this.btnLoadMarkupTest6.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest6.TabIndex = 26;
            this.btnLoadMarkupTest6.Text = "#6";
            this.btnLoadMarkupTest6.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest6.Click += new System.EventHandler(this.btnLoadMarkupTest6_Click);
            // 
            // btnLoadMarkupTest7
            // 
            this.btnLoadMarkupTest7.Location = new System.Drawing.Point(143, 35);
            this.btnLoadMarkupTest7.Name = "btnLoadMarkupTest7";
            this.btnLoadMarkupTest7.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest7.TabIndex = 27;
            this.btnLoadMarkupTest7.Text = "#7";
            this.btnLoadMarkupTest7.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest7.Click += new System.EventHandler(this.btnLoadMarkupTest7_Click);
            // 
            // btnLoadMarkupTest8
            // 
            this.btnLoadMarkupTest8.Location = new System.Drawing.Point(180, 35);
            this.btnLoadMarkupTest8.Name = "btnLoadMarkupTest8";
            this.btnLoadMarkupTest8.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest8.TabIndex = 28;
            this.btnLoadMarkupTest8.Text = "#8";
            this.btnLoadMarkupTest8.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest8.Click += new System.EventHandler(this.btnLoadMarkupTest8_Click);
            // 
            // btnLoadMarkupTest9
            // 
            this.btnLoadMarkupTest9.Location = new System.Drawing.Point(217, 35);
            this.btnLoadMarkupTest9.Name = "btnLoadMarkupTest9";
            this.btnLoadMarkupTest9.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest9.TabIndex = 29;
            this.btnLoadMarkupTest9.Text = "#9";
            this.btnLoadMarkupTest9.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest9.Click += new System.EventHandler(this.btnLoadMarkupTest9_Click);
            // 
            // btnLoadMarkupTest10
            // 
            this.btnLoadMarkupTest10.Location = new System.Drawing.Point(255, 35);
            this.btnLoadMarkupTest10.Name = "btnLoadMarkupTest10";
            this.btnLoadMarkupTest10.Size = new System.Drawing.Size(37, 23);
            this.btnLoadMarkupTest10.TabIndex = 30;
            this.btnLoadMarkupTest10.Text = "#10";
            this.btnLoadMarkupTest10.UseVisualStyleBackColor = true;
            this.btnLoadMarkupTest10.Click += new System.EventHandler(this.btnLoadMarkupTest10_Click);
            // 
            // cbxWarpOn
            // 
            this.cbxWarpOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWarpOn.FormattingEnabled = true;
            this.cbxWarpOn.Items.AddRange(new object[] {
            "Warp long text on Character",
            "Warp long text on Word",
            "Warp long text on Sentence"});
            this.cbxWarpOn.Location = new System.Drawing.Point(156, 478);
            this.cbxWarpOn.Name = "cbxWarpOn";
            this.cbxWarpOn.Size = new System.Drawing.Size(181, 21);
            this.cbxWarpOn.TabIndex = 31;
            this.cbxWarpOn.SelectedIndexChanged += new System.EventHandler(this.cbxWarpOn_SelectedIndexChanged);
            // 
            // markupRichtextControl
            // 
            this.markupRichtextControl.BackColor = System.Drawing.Color.White;
            this.markupRichtextControl.Location = new System.Drawing.Point(343, 12);
            this.markupRichtextControl.Name = "markupRichtextControl";
            this.markupRichtextControl.Size = new System.Drawing.Size(400, 494);
            this.markupRichtextControl.TabIndex = 25;
            this.markupRichtextControl.wordwrapmodus = MarkupRichtextControl.WordWrapMode.OnCharacter;
            // 
            // FrmMainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 599);
            this.Controls.Add(this.cbxWarpOn);
            this.Controls.Add(this.btnLoadMarkupTest10);
            this.Controls.Add(this.btnLoadMarkupTest9);
            this.Controls.Add(this.btnLoadMarkupTest8);
            this.Controls.Add(this.btnLoadMarkupTest7);
            this.Controls.Add(this.btnLoadMarkupTest6);
            this.Controls.Add(this.markupRichtextControl);
            this.Controls.Add(this.btnLoadMarkupTest5);
            this.Controls.Add(this.btnLoadMarkupTest4);
            this.Controls.Add(this.lbTextControlWidthUnits);
            this.Controls.Add(this.btnLoadMarkupTest3);
            this.Controls.Add(this.btnLoadMarkupTest2);
            this.Controls.Add(this.lblTextLoadMarkupTest);
            this.Controls.Add(this.btnLoadMarkupTest1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTextControlWidth);
            this.Controls.Add(this.btnParseMarkupAndDisplay1);
            this.Controls.Add(this.numUpDownWidthRichMarkupEditorControl);
            this.Controls.Add(this.tbMarkup);
            this.Name = "FrmMainTest";
            this.Text = "MarkupRichTextControl demo";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidthRichMarkupEditorControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.TextBox tbMarkup;
        private System.Windows.Forms.Button btnParseMarkupAndDisplay1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chxHyperlink;
        private System.Windows.Forms.TextBox tbHyperlink;
        private System.Windows.Forms.CheckBox chxStrikeout;
        private System.Windows.Forms.Label lbTextControlWidthUnits;
        private System.Windows.Forms.CheckBox chxNewLine;
        private System.Windows.Forms.Button btnLoadMarkupTest1;
        private System.Windows.Forms.Label lblTextLoadMarkupTest;
        private System.Windows.Forms.Button btnLoadMarkupTest2;
        private System.Windows.Forms.Button btnLoadMarkupTest3;
        private System.Windows.Forms.Button btnLoadMarkupTest4;
        private System.Windows.Forms.Button btnLoadMarkupTest5;
        private MarkupRichtextControl markupRichtextControl;
        private System.Windows.Forms.Button btnLoadMarkupTest6;
        private System.Windows.Forms.Button btnLoadMarkupTest7;
        private System.Windows.Forms.Button btnLoadMarkupTest8;
        private System.Windows.Forms.Button btnLoadMarkupTest9;
        private System.Windows.Forms.Button btnLoadMarkupTest10;
        private System.Windows.Forms.ComboBox cbxWarpOn;
    }
}

