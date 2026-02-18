namespace CheeseGuider
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            idlabel = new Label();
            label1 = new Label();
            transitionsList = new RichTextBox();
            canExitLabel = new Label();
            journeyHistory = new RichTextBox();
            CurrentLocationTextLabel = new Label();
            videoRedirect = new Button();
            canExitTextLabel = new Label();
            LocationNamesCheckbox = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            rhizome_56 = new TextBox();
            rhizome_98 = new TextBox();
            rhizome_204 = new TextBox();
            rhizome_268 = new TextBox();
            rhizome_350 = new TextBox();
            rhizome_476 = new TextBox();
            multiplePathCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // idlabel
            // 
            idlabel.AutoSize = true;
            idlabel.Location = new Point(536, 161);
            idlabel.Name = "idlabel";
            idlabel.Size = new Size(59, 15);
            idlabel.TabIndex = 0;
            idlabel.Text = "посхалко";
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // transitionsList
            // 
            transitionsList.BorderStyle = BorderStyle.FixedSingle;
            transitionsList.Location = new Point(389, 184);
            transitionsList.Name = "transitionsList";
            transitionsList.ReadOnly = true;
            transitionsList.ScrollBars = RichTextBoxScrollBars.Vertical;
            transitionsList.Size = new Size(223, 202);
            transitionsList.TabIndex = 1;
            transitionsList.Text = "";
            // 
            // canExitLabel
            // 
            canExitLabel.AutoSize = true;
            canExitLabel.Location = new Point(160, 417);
            canExitLabel.Name = "canExitLabel";
            canExitLabel.Size = new Size(23, 15);
            canExitLabel.TabIndex = 2;
            canExitLabel.Text = "No";
            // 
            // journeyHistory
            // 
            journeyHistory.BorderStyle = BorderStyle.FixedSingle;
            journeyHistory.Location = new Point(12, 161);
            journeyHistory.Name = "journeyHistory";
            journeyHistory.ReadOnly = true;
            journeyHistory.ScrollBars = RichTextBoxScrollBars.Vertical;
            journeyHistory.Size = new Size(366, 145);
            journeyHistory.TabIndex = 1;
            journeyHistory.Text = "";
            // 
            // CurrentLocationTextLabel
            // 
            CurrentLocationTextLabel.AutoSize = true;
            CurrentLocationTextLabel.Location = new Point(389, 161);
            CurrentLocationTextLabel.Name = "CurrentLocationTextLabel";
            CurrentLocationTextLabel.Size = new Size(141, 15);
            CurrentLocationTextLabel.TabIndex = 3;
            CurrentLocationTextLabel.Text = "Current location number:";
            // 
            // videoRedirect
            // 
            videoRedirect.Location = new Point(389, 392);
            videoRedirect.Name = "videoRedirect";
            videoRedirect.Size = new Size(223, 40);
            videoRedirect.TabIndex = 4;
            videoRedirect.Text = "Watch the YT video about this location";
            videoRedirect.UseVisualStyleBackColor = true;
            // 
            // canExitTextLabel
            // 
            canExitTextLabel.AutoSize = true;
            canExitTextLabel.Location = new Point(12, 417);
            canExitTextLabel.Name = "canExitTextLabel";
            canExitTextLabel.Size = new Size(142, 15);
            canExitTextLabel.TabIndex = 3;
            canExitTextLabel.Text = "Can I quit the game now?";
            // 
            // LocationNamesCheckbox
            // 
            LocationNamesCheckbox.AutoSize = true;
            LocationNamesCheckbox.Location = new Point(12, 312);
            LocationNamesCheckbox.Name = "LocationNamesCheckbox";
            LocationNamesCheckbox.Size = new Size(372, 19);
            LocationNamesCheckbox.TabIndex = 5;
            LocationNamesCheckbox.Text = "Unofficial location names (highly subjective, use at your own risk)";
            LocationNamesCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ControlLight;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 3, 0, 0);
            label2.Size = new Size(600, 138);
            label2.TabIndex = 6;
            label2.Text = "Pathfinder";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLight;
            label3.Location = new Point(29, 34);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "From";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(70, 32);
            numericUpDown1.Maximum = new decimal(new int[] { 666, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(38, 23);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(138, 32);
            numericUpDown2.Maximum = new decimal(new int[] { 666, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(38, 23);
            numericUpDown2.TabIndex = 8;
            numericUpDown2.Value = new decimal(new int[] { 666, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLight;
            label4.Location = new Point(114, 34);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 7;
            label4.Text = "to";
            // 
            // button1
            // 
            button1.Location = new Point(491, 27);
            button1.Name = "button1";
            button1.Size = new Size(101, 32);
            button1.TabIndex = 9;
            button1.Text = "Find cheese!";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(29, 76);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(563, 54);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLight;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Location = new Point(12, 334);
            label5.Name = "label5";
            label5.Size = new Size(164, 74);
            label5.TabIndex = 6;
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLight;
            label6.Location = new Point(39, 334);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 10;
            label6.Text = "Key locations visited";
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ControlLight;
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(12, 359);
            label7.Name = "label7";
            label7.Size = new Size(164, 49);
            label7.TabIndex = 11;
            label7.Text = "fsjdfhksjdf djkfhsdk jfsdkfjdshk fsd fhsdj fdkfdhf";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ControlLight;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Location = new Point(214, 334);
            label8.Name = "label8";
            label8.Size = new Size(164, 74);
            label8.TabIndex = 6;
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ControlLight;
            label9.Location = new Point(257, 334);
            label9.Name = "label9";
            label9.Size = new Size(80, 15);
            label9.TabIndex = 10;
            label9.Text = "Meta rhizome";
            // 
            // rhizome_56
            // 
            rhizome_56.BackColor = SystemColors.ControlLight;
            rhizome_56.BorderStyle = BorderStyle.None;
            rhizome_56.ForeColor = Color.Red;
            rhizome_56.Location = new Point(227, 359);
            rhizome_56.Name = "rhizome_56";
            rhizome_56.ReadOnly = true;
            rhizome_56.Size = new Size(17, 16);
            rhizome_56.TabIndex = 12;
            rhizome_56.Text = "56";
            // 
            // rhizome_98
            // 
            rhizome_98.BackColor = SystemColors.ControlLight;
            rhizome_98.BorderStyle = BorderStyle.None;
            rhizome_98.ForeColor = Color.Red;
            rhizome_98.Location = new Point(261, 359);
            rhizome_98.Name = "rhizome_98";
            rhizome_98.ReadOnly = true;
            rhizome_98.Size = new Size(17, 16);
            rhizome_98.TabIndex = 12;
            rhizome_98.Text = "98";
            // 
            // rhizome_204
            // 
            rhizome_204.BackColor = SystemColors.ControlLight;
            rhizome_204.BorderStyle = BorderStyle.None;
            rhizome_204.ForeColor = Color.Red;
            rhizome_204.Location = new Point(297, 359);
            rhizome_204.Name = "rhizome_204";
            rhizome_204.ReadOnly = true;
            rhizome_204.Size = new Size(21, 16);
            rhizome_204.TabIndex = 12;
            rhizome_204.Text = "204";
            // 
            // rhizome_268
            // 
            rhizome_268.BackColor = SystemColors.ControlLight;
            rhizome_268.BorderStyle = BorderStyle.None;
            rhizome_268.ForeColor = Color.Red;
            rhizome_268.Location = new Point(342, 359);
            rhizome_268.Name = "rhizome_268";
            rhizome_268.ReadOnly = true;
            rhizome_268.Size = new Size(21, 16);
            rhizome_268.TabIndex = 12;
            rhizome_268.Text = "268";
            // 
            // rhizome_350
            // 
            rhizome_350.BackColor = SystemColors.ControlLight;
            rhizome_350.BorderStyle = BorderStyle.None;
            rhizome_350.ForeColor = Color.Red;
            rhizome_350.Location = new Point(257, 381);
            rhizome_350.Name = "rhizome_350";
            rhizome_350.ReadOnly = true;
            rhizome_350.Size = new Size(21, 16);
            rhizome_350.TabIndex = 12;
            rhizome_350.Text = "350";
            // 
            // rhizome_476
            // 
            rhizome_476.BackColor = SystemColors.ControlLight;
            rhizome_476.BorderStyle = BorderStyle.None;
            rhizome_476.ForeColor = Color.Red;
            rhizome_476.Location = new Point(297, 381);
            rhizome_476.Name = "rhizome_476";
            rhizome_476.ReadOnly = true;
            rhizome_476.Size = new Size(21, 16);
            rhizome_476.TabIndex = 12;
            rhizome_476.Text = "476";
            // 
            // multiplePathCheckbox
            // 
            multiplePathCheckbox.AutoSize = true;
            multiplePathCheckbox.BackColor = SystemColors.ControlLight;
            multiplePathCheckbox.Location = new Point(196, 35);
            multiplePathCheckbox.Name = "multiplePathCheckbox";
            multiplePathCheckbox.Size = new Size(280, 19);
            multiplePathCheckbox.TabIndex = 13;
            multiplePathCheckbox.Text = "Show multiple possible paths (not only shortest)";
            multiplePathCheckbox.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(multiplePathCheckbox);
            Controls.Add(rhizome_476);
            Controls.Add(rhizome_350);
            Controls.Add(rhizome_268);
            Controls.Add(rhizome_204);
            Controls.Add(rhizome_98);
            Controls.Add(rhizome_56);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(LocationNamesCheckbox);
            Controls.Add(videoRedirect);
            Controls.Add(canExitTextLabel);
            Controls.Add(CurrentLocationTextLabel);
            Controls.Add(canExitLabel);
            Controls.Add(journeyHistory);
            Controls.Add(transitionsList);
            Controls.Add(label1);
            Controls.Add(idlabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Cheese Guider";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idlabel;
        private Label label1;
        private RichTextBox transitionsList;
        private Label canExitLabel;
        private RichTextBox journeyHistory;
        private Label CurrentLocationTextLabel;
        private Button videoRedirect;
        private Label canExitTextLabel;
        private CheckBox LocationNamesCheckbox;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private Button button1;
        private RichTextBox richTextBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox rhizome_56;
        private TextBox rhizome_98;
        private TextBox rhizome_204;
        private TextBox rhizome_268;
        private TextBox rhizome_350;
        private TextBox rhizome_476;
        private CheckBox multiplePathCheckbox;
    }
}
