namespace CharacterCreator
{
    partial class SpecialForm
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
            this.clbSpecials = new System.Windows.Forms.CheckedListBox();
            this.rtbSpecialDescription = new System.Windows.Forms.RichTextBox();
            this.commandOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbSpecials
            // 
            this.clbSpecials.FormattingEnabled = true;
            this.clbSpecials.Location = new System.Drawing.Point(12, 12);
            this.clbSpecials.Name = "clbSpecials";
            this.clbSpecials.Size = new System.Drawing.Size(159, 454);
            this.clbSpecials.TabIndex = 0;
            this.clbSpecials.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbSpecials_ItemCheck);
            this.clbSpecials.SelectedIndexChanged += new System.EventHandler(this.clbSpecials_SelectedIndexChanged);
            // 
            // rtbSpecialDescription
            // 
            this.rtbSpecialDescription.Location = new System.Drawing.Point(177, 12);
            this.rtbSpecialDescription.Name = "rtbSpecialDescription";
            this.rtbSpecialDescription.Size = new System.Drawing.Size(604, 451);
            this.rtbSpecialDescription.TabIndex = 1;
            this.rtbSpecialDescription.Text = "";
            // 
            // commandOK
            // 
            this.commandOK.Location = new System.Drawing.Point(706, 469);
            this.commandOK.Name = "commandOK";
            this.commandOK.Size = new System.Drawing.Size(75, 23);
            this.commandOK.TabIndex = 2;
            this.commandOK.Text = "OK";
            this.commandOK.UseVisualStyleBackColor = true;
            this.commandOK.Click += new System.EventHandler(this.commandOK_Click);
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 495);
            this.Controls.Add(this.commandOK);
            this.Controls.Add(this.rtbSpecialDescription);
            this.Controls.Add(this.clbSpecials);
            this.Name = "SpecialForm";
            this.Text = "SpecialForm";
            this.Load += new System.EventHandler(this.SpecialForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbSpecials;
        private System.Windows.Forms.RichTextBox rtbSpecialDescription;
        private System.Windows.Forms.Button commandOK;
    }
}