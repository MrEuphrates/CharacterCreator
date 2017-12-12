namespace CharacterCreator
{
    partial class PassiveAbilityForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxRequiresAdditionalInput = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbAdditionalInputDescription = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 3;
            // 
            // cbxRequiresAdditionalInput
            // 
            this.cbxRequiresAdditionalInput.AutoSize = true;
            this.cbxRequiresAdditionalInput.Checked = true;
            this.cbxRequiresAdditionalInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRequiresAdditionalInput.Enabled = false;
            this.cbxRequiresAdditionalInput.Location = new System.Drawing.Point(15, 77);
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
            this.label9.Location = new System.Drawing.Point(9, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(275, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Passive abilities require a description and GM evaluation.";
            // 
            // rtbAdditionalInputDescription
            // 
            this.rtbAdditionalInputDescription.Location = new System.Drawing.Point(12, 133);
            this.rtbAdditionalInputDescription.Name = "rtbAdditionalInputDescription";
            this.rtbAdditionalInputDescription.Size = new System.Drawing.Size(568, 96);
            this.rtbAdditionalInputDescription.TabIndex = 20;
            this.rtbAdditionalInputDescription.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Describe what it is you want this passive ability to do:";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(12, 235);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(505, 235);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PassiveAbilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 271);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rtbAdditionalInputDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxRequiresAdditionalInput);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Name = "PassiveAbilityForm";
            this.Text = "PassiveAbilityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbxRequiresAdditionalInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbAdditionalInputDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}