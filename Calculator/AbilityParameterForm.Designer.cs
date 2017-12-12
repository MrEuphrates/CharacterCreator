namespace Calculator
{
    partial class AbilityParameterForm
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
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.rtbAbilityDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvParameters.Location = new System.Drawing.Point(11, 268);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.Size = new System.Drawing.Size(389, 121);
            this.dgvParameters.TabIndex = 0;
            this.dgvParameters.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameters_CellValueChanged);
            // 
            // rtbAbilityDescription
            // 
            this.rtbAbilityDescription.Location = new System.Drawing.Point(12, 12);
            this.rtbAbilityDescription.Name = "rtbAbilityDescription";
            this.rtbAbilityDescription.Size = new System.Drawing.Size(389, 224);
            this.rtbAbilityDescription.TabIndex = 1;
            this.rtbAbilityDescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type the values for the variables of this special in the Input column below";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(325, 395);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // AbilityParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 428);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbAbilityDescription);
            this.Controls.Add(this.dgvParameters);
            this.Name = "AbilityParameterForm";
            this.Text = "ParameterForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.RichTextBox rtbAbilityDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
    }
}