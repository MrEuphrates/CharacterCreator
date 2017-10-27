namespace CharacterCreator
{
    partial class AbilityForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.nudEnergy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDamageBase = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddSpecial = new System.Windows.Forms.Button();
            this.listBoxSpecial = new System.Windows.Forms.ListBox();
            this.nudDamageActual = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.nudAttacks = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudEnergyModifier = new System.Windows.Forms.NumericUpDown();
            this.cbxRequiresAdditionalInput = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbAdditionalInputDescription = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamageBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamageActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergyModifier)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time";
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(12, 26);
            this.nudTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(42, 20);
            this.nudTime.TabIndex = 1;
            this.nudTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTime.ValueChanged += new System.EventHandler(this.nudTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(60, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 3;
            // 
            // nudEnergy
            // 
            this.nudEnergy.Enabled = false;
            this.nudEnergy.Location = new System.Drawing.Point(246, 26);
            this.nudEnergy.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudEnergy.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudEnergy.Name = "nudEnergy";
            this.nudEnergy.Size = new System.Drawing.Size(92, 20);
            this.nudEnergy.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Energy";
            // 
            // nudDamageBase
            // 
            this.nudDamageBase.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDamageBase.Location = new System.Drawing.Point(344, 26);
            this.nudDamageBase.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDamageBase.Name = "nudDamageBase";
            this.nudDamageBase.Size = new System.Drawing.Size(92, 20);
            this.nudDamageBase.TabIndex = 6;
            this.nudDamageBase.ValueChanged += new System.EventHandler(this.nudDamageBase_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Damage";
            // 
            // buttonAddSpecial
            // 
            this.buttonAddSpecial.Location = new System.Drawing.Point(12, 51);
            this.buttonAddSpecial.Name = "buttonAddSpecial";
            this.buttonAddSpecial.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSpecial.TabIndex = 8;
            this.buttonAddSpecial.Text = "Add Special";
            this.buttonAddSpecial.UseVisualStyleBackColor = true;
            this.buttonAddSpecial.Click += new System.EventHandler(this.buttonAddSpecial_Click);
            // 
            // listBoxSpecial
            // 
            this.listBoxSpecial.FormattingEnabled = true;
            this.listBoxSpecial.Location = new System.Drawing.Point(12, 80);
            this.listBoxSpecial.Name = "listBoxSpecial";
            this.listBoxSpecial.Size = new System.Drawing.Size(568, 121);
            this.listBoxSpecial.TabIndex = 9;
            // 
            // nudDamageActual
            // 
            this.nudDamageActual.Enabled = false;
            this.nudDamageActual.Location = new System.Drawing.Point(442, 26);
            this.nudDamageActual.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDamageActual.Name = "nudDamageActual";
            this.nudDamageActual.Size = new System.Drawing.Size(92, 20);
            this.nudDamageActual.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Damage (Modded)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "How it looks on the character sheet:";
            // 
            // txtDisplay
            // 
            this.txtDisplay.Enabled = false;
            this.txtDisplay.Location = new System.Drawing.Point(15, 230);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(565, 20);
            this.txtDisplay.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(537, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Attacks";
            // 
            // nudAttacks
            // 
            this.nudAttacks.Location = new System.Drawing.Point(540, 26);
            this.nudAttacks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAttacks.Name = "nudAttacks";
            this.nudAttacks.Size = new System.Drawing.Size(40, 20);
            this.nudAttacks.TabIndex = 14;
            this.nudAttacks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAttacks.ValueChanged += new System.EventHandler(this.nudAttacks_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Energy Modifier:";
            // 
            // nudEnergyModifier
            // 
            this.nudEnergyModifier.Enabled = false;
            this.nudEnergyModifier.Location = new System.Drawing.Point(206, 52);
            this.nudEnergyModifier.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudEnergyModifier.Name = "nudEnergyModifier";
            this.nudEnergyModifier.Size = new System.Drawing.Size(58, 20);
            this.nudEnergyModifier.TabIndex = 17;
            // 
            // cbxRequiresAdditionalInput
            // 
            this.cbxRequiresAdditionalInput.AutoSize = true;
            this.cbxRequiresAdditionalInput.Location = new System.Drawing.Point(15, 290);
            this.cbxRequiresAdditionalInput.Name = "cbxRequiresAdditionalInput";
            this.cbxRequiresAdditionalInput.Size = new System.Drawing.Size(142, 17);
            this.cbxRequiresAdditionalInput.TabIndex = 18;
            this.cbxRequiresAdditionalInput.Text = "Requires additional input";
            this.cbxRequiresAdditionalInput.UseVisualStyleBackColor = true;
            this.cbxRequiresAdditionalInput.CheckedChanged += new System.EventHandler(this.cbxRequiresAdditionalInput_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(454, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "If this tool cannot adequately represent this ability, requiring input from your " +
    "GM, check this box:";
            // 
            // rtbAdditionalInputDescription
            // 
            this.rtbAdditionalInputDescription.Enabled = false;
            this.rtbAdditionalInputDescription.Location = new System.Drawing.Point(12, 346);
            this.rtbAdditionalInputDescription.Name = "rtbAdditionalInputDescription";
            this.rtbAdditionalInputDescription.Size = new System.Drawing.Size(568, 96);
            this.rtbAdditionalInputDescription.TabIndex = 20;
            this.rtbAdditionalInputDescription.Text = "";
            this.rtbAdditionalInputDescription.TextChanged += new System.EventHandler(this.rtbAdditionalInputDescription_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(320, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Describe what it is you want to do that this tool does not represent:";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(506, 448);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // AbilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 476);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rtbAdditionalInputDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxRequiresAdditionalInput);
            this.Controls.Add(this.nudEnergyModifier);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudAttacks);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudDamageActual);
            this.Controls.Add(this.listBoxSpecial);
            this.Controls.Add(this.buttonAddSpecial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudDamageBase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudEnergy);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTime);
            this.Controls.Add(this.label1);
            this.Name = "AbilityForm";
            this.Text = "AbilityForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamageBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamageActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergyModifier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudEnergy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDamageBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddSpecial;
        private System.Windows.Forms.ListBox listBoxSpecial;
        private System.Windows.Forms.NumericUpDown nudDamageActual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudAttacks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudEnergyModifier;
        private System.Windows.Forms.CheckBox cbxRequiresAdditionalInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbAdditionalInputDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdOK;
    }
}