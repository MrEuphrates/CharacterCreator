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
            this.SuspendLayout();
            // 
            // clbSpecials
            // 
            this.clbSpecials.FormattingEnabled = true;
            this.clbSpecials.Location = new System.Drawing.Point(12, 12);
            this.clbSpecials.Name = "clbSpecials";
            this.clbSpecials.Size = new System.Drawing.Size(159, 694);
            this.clbSpecials.TabIndex = 0;
            this.clbSpecials.SelectedIndexChanged += new System.EventHandler(this.clbSpecials_SelectedIndexChanged);
            // 
            // rtbSpecialDescription
            // 
            this.rtbSpecialDescription.Location = new System.Drawing.Point(177, 12);
            this.rtbSpecialDescription.Name = "rtbSpecialDescription";
            this.rtbSpecialDescription.Size = new System.Drawing.Size(604, 696);
            this.rtbSpecialDescription.TabIndex = 1;
            this.rtbSpecialDescription.Text = "";
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 720);
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
    }
}