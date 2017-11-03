namespace CharacterCreator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMight = new System.Windows.Forms.NumericUpDown();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStrength = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMarksmanship = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTech = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCharacterPoints = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddAbility = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxAttacksBasic = new System.Windows.Forms.ListBox();
            this.listBoxAttacksSpecial = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxAbilities = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdEditAbility = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarksmanship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharacterPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(16, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Might:";
            // 
            // nudMight
            // 
            this.nudMight.Enabled = false;
            this.nudMight.Location = new System.Drawing.Point(258, 29);
            this.nudMight.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMight.Name = "nudMight";
            this.nudMight.Size = new System.Drawing.Size(38, 20);
            this.nudMight.TabIndex = 3;
            this.nudMight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(17, 78);
            this.nudSpeed.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(75, 20);
            this.nudSpeed.TabIndex = 5;
            this.nudSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Speed:";
            // 
            // nudStrength
            // 
            this.nudStrength.Location = new System.Drawing.Point(98, 78);
            this.nudStrength.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudStrength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudStrength.Name = "nudStrength";
            this.nudStrength.Size = new System.Drawing.Size(75, 20);
            this.nudStrength.TabIndex = 7;
            this.nudStrength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Strength:";
            // 
            // nudMarksmanship
            // 
            this.nudMarksmanship.Location = new System.Drawing.Point(179, 78);
            this.nudMarksmanship.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMarksmanship.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMarksmanship.Name = "nudMarksmanship";
            this.nudMarksmanship.Size = new System.Drawing.Size(75, 20);
            this.nudMarksmanship.TabIndex = 9;
            this.nudMarksmanship.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Marksmanship:";
            // 
            // nudTech
            // 
            this.nudTech.Location = new System.Drawing.Point(260, 78);
            this.nudTech.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudTech.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTech.Name = "nudTech";
            this.nudTech.Size = new System.Drawing.Size(75, 20);
            this.nudTech.TabIndex = 11;
            this.nudTech.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tech:";
            // 
            // nudCharacterPoints
            // 
            this.nudCharacterPoints.Enabled = false;
            this.nudCharacterPoints.Location = new System.Drawing.Point(302, 29);
            this.nudCharacterPoints.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nudCharacterPoints.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            -2147483648});
            this.nudCharacterPoints.Name = "nudCharacterPoints";
            this.nudCharacterPoints.Size = new System.Drawing.Size(89, 20);
            this.nudCharacterPoints.TabIndex = 13;
            this.nudCharacterPoints.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Points Remaining:";
            // 
            // buttonAddAbility
            // 
            this.buttonAddAbility.Location = new System.Drawing.Point(12, 104);
            this.buttonAddAbility.Name = "buttonAddAbility";
            this.buttonAddAbility.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAbility.TabIndex = 14;
            this.buttonAddAbility.Text = "Add Ability";
            this.buttonAddAbility.UseVisualStyleBackColor = true;
            this.buttonAddAbility.Click += new System.EventHandler(this.buttonAddAbility_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Basic Attacks";
            // 
            // listBoxAttacksBasic
            // 
            this.listBoxAttacksBasic.FormattingEnabled = true;
            this.listBoxAttacksBasic.Location = new System.Drawing.Point(12, 146);
            this.listBoxAttacksBasic.Name = "listBoxAttacksBasic";
            this.listBoxAttacksBasic.Size = new System.Drawing.Size(379, 95);
            this.listBoxAttacksBasic.TabIndex = 16;
            this.listBoxAttacksBasic.SelectedIndexChanged += new System.EventHandler(this.listBoxAttacksBasic_SelectedIndexChanged);
            // 
            // listBoxAttacksSpecial
            // 
            this.listBoxAttacksSpecial.FormattingEnabled = true;
            this.listBoxAttacksSpecial.Location = new System.Drawing.Point(12, 275);
            this.listBoxAttacksSpecial.Name = "listBoxAttacksSpecial";
            this.listBoxAttacksSpecial.Size = new System.Drawing.Size(379, 95);
            this.listBoxAttacksSpecial.TabIndex = 18;
            this.listBoxAttacksSpecial.SelectedIndexChanged += new System.EventHandler(this.listBoxAttacksSpecial_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Special Attacks";
            // 
            // listBoxAbilities
            // 
            this.listBoxAbilities.FormattingEnabled = true;
            this.listBoxAbilities.Location = new System.Drawing.Point(12, 405);
            this.listBoxAbilities.Name = "listBoxAbilities";
            this.listBoxAbilities.Size = new System.Drawing.Size(379, 95);
            this.listBoxAbilities.TabIndex = 20;
            this.listBoxAbilities.SelectedIndexChanged += new System.EventHandler(this.listBoxAbilities_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 389);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Abilities";
            // 
            // cmdEditAbility
            // 
            this.cmdEditAbility.Location = new System.Drawing.Point(93, 104);
            this.cmdEditAbility.Name = "cmdEditAbility";
            this.cmdEditAbility.Size = new System.Drawing.Size(75, 23);
            this.cmdEditAbility.TabIndex = 21;
            this.cmdEditAbility.Text = "Edit Ability";
            this.cmdEditAbility.UseVisualStyleBackColor = true;
            this.cmdEditAbility.Click += new System.EventHandler(this.cmdEditAbility_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(465, 12);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 22;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(465, 41);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(75, 23);
            this.cmdLoad.TabIndex = 23;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 517);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdEditAbility);
            this.Controls.Add(this.listBoxAbilities);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBoxAttacksSpecial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBoxAttacksBasic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonAddAbility);
            this.Controls.Add(this.nudCharacterPoints);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudTech);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudMarksmanship);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudStrength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "CharacterForm";
            this.Text = "CharacterForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.nudMight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMarksmanship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharacterPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMight;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudStrength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMarksmanship;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTech;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCharacterPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddAbility;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxAttacksBasic;
        private System.Windows.Forms.ListBox listBoxAttacksSpecial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBoxAbilities;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdEditAbility;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdLoad;
    }
}