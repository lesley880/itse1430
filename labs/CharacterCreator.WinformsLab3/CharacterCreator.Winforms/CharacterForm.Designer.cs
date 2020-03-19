namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.Title1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlProfession = new System.Windows.Forms.ComboBox();
            this.ddlRace = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.txtIntelligence = new System.Windows.Forms.TextBox();
            this.txtWisdom = new System.Windows.Forms.TextBox();
            this.txtDexterity = new System.Windows.Forms.TextBox();
            this.txtConstitution = new System.Windows.Forms.TextBox();
            this.Strength = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.Label();
            this.Wisdom = new System.Windows.Forms.Label();
            this.Dexterity = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title1
            // 
            this.Title1.AutoSize = true;
            this.Title1.Location = new System.Drawing.Point(32, 24);
            this.Title1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(35, 13);
            this.Title1.TabIndex = 0;
            this.Title1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profession";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Attributes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 251);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // ddlProfession
            // 
            this.ddlProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProfession.FormattingEnabled = true;
            this.ddlProfession.Location = new System.Drawing.Point(70, 45);
            this.ddlProfession.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlProfession.Name = "ddlProfession";
            this.ddlProfession.Size = new System.Drawing.Size(92, 21);
            this.ddlProfession.TabIndex = 5;
            // 
            // ddlRace
            // 
            this.ddlRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRace.FormattingEnabled = true;
            this.ddlRace.Location = new System.Drawing.Point(70, 69);
            this.ddlRace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlRace.Name = "ddlRace";
            this.ddlRace.Size = new System.Drawing.Size(92, 21);
            this.ddlRace.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(70, 22);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 20);
            this.txtName.TabIndex = 8;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(70, 249);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(185, 84);
            this.txtDescription.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(146, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnOK);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(207, 348);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnCancel);
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(125, 126);
            this.txtStrength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(29, 20);
            this.txtStrength.TabIndex = 12;
            // 
            // txtIntelligence
            // 
            this.txtIntelligence.Location = new System.Drawing.Point(125, 150);
            this.txtIntelligence.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIntelligence.Name = "txtIntelligence";
            this.txtIntelligence.Size = new System.Drawing.Size(29, 20);
            this.txtIntelligence.TabIndex = 13;
            // 
            // txtWisdom
            // 
            this.txtWisdom.Location = new System.Drawing.Point(125, 172);
            this.txtWisdom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtWisdom.Name = "txtWisdom";
            this.txtWisdom.Size = new System.Drawing.Size(29, 20);
            this.txtWisdom.TabIndex = 14;
            // 
            // txtDexterity
            // 
            this.txtDexterity.Location = new System.Drawing.Point(125, 195);
            this.txtDexterity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDexterity.Name = "txtDexterity";
            this.txtDexterity.Size = new System.Drawing.Size(29, 20);
            this.txtDexterity.TabIndex = 15;
            // 
            // txtConstitution
            // 
            this.txtConstitution.Location = new System.Drawing.Point(125, 218);
            this.txtConstitution.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.Size = new System.Drawing.Size(29, 20);
            this.txtConstitution.TabIndex = 16;
            // 
            // Strength
            // 
            this.Strength.AutoSize = true;
            this.Strength.Location = new System.Drawing.Point(68, 128);
            this.Strength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Strength.Name = "Strength";
            this.Strength.Size = new System.Drawing.Size(47, 13);
            this.Strength.TabIndex = 17;
            this.Strength.Text = "Strength";
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(55, 152);
            this.txt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(61, 13);
            this.txt.TabIndex = 18;
            this.txt.Text = "Intelligence";
            // 
            // Wisdom
            // 
            this.Wisdom.AutoSize = true;
            this.Wisdom.Location = new System.Drawing.Point(70, 175);
            this.Wisdom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Wisdom.Name = "Wisdom";
            this.Wisdom.Size = new System.Drawing.Size(45, 13);
            this.Wisdom.TabIndex = 19;
            this.Wisdom.Text = "Wisdom";
            // 
            // Dexterity
            // 
            this.Dexterity.AutoSize = true;
            this.Dexterity.Location = new System.Drawing.Point(67, 197);
            this.Dexterity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dexterity.Name = "Dexterity";
            this.Dexterity.Size = new System.Drawing.Size(48, 13);
            this.Dexterity.TabIndex = 20;
            this.Dexterity.Text = "Dexterity";
            // 
            // txtC
            // 
            this.txtC.AutoSize = true;
            this.txtC.Location = new System.Drawing.Point(52, 220);
            this.txtC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(62, 13);
            this.txtC.TabIndex = 21;
            this.txtC.Text = "Constitution";
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 390);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.Dexterity);
            this.Controls.Add(this.Wisdom);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.Strength);
            this.Controls.Add(this.txtConstitution);
            this.Controls.Add(this.txtDexterity);
            this.Controls.Add(this.txtWisdom);
            this.Controls.Add(this.txtIntelligence);
            this.Controls.Add(this.txtStrength);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.ddlRace);
            this.Controls.Add(this.ddlProfession);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(301, 429);
            this.Name = "CharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Character Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlProfession;
        private System.Windows.Forms.ComboBox ddlRace;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.TextBox txtIntelligence;
        private System.Windows.Forms.TextBox txtWisdom;
        private System.Windows.Forms.TextBox txtDexterity;
        private System.Windows.Forms.TextBox txtConstitution;
        private System.Windows.Forms.Label Strength;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label Wisdom;
        private System.Windows.Forms.Label Dexterity;
        private System.Windows.Forms.Label txtC;
    }
}