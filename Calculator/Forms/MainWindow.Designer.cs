namespace CharacterCreator
{
    partial class MainWindow
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
            this.labelHowManyCPs = new System.Windows.Forms.Label();
            this.nudCharacterPoints = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharacterPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHowManyCPs
            // 
            this.labelHowManyCPs.AutoSize = true;
            this.labelHowManyCPs.Location = new System.Drawing.Point(13, 13);
            this.labelHowManyCPs.Name = "labelHowManyCPs";
            this.labelHowManyCPs.Size = new System.Drawing.Size(142, 13);
            this.labelHowManyCPs.TabIndex = 0;
            this.labelHowManyCPs.Text = "How many character points?";
            // 
            // nudCharacterPoints
            // 
            this.nudCharacterPoints.Location = new System.Drawing.Point(162, 11);
            this.nudCharacterPoints.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nudCharacterPoints.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudCharacterPoints.Name = "nudCharacterPoints";
            this.nudCharacterPoints.Size = new System.Drawing.Size(59, 20);
            this.nudCharacterPoints.TabIndex = 1;
            this.nudCharacterPoints.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(227, 8);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 50);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.nudCharacterPoints);
            this.Controls.Add(this.labelHowManyCPs);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            ((System.ComponentModel.ISupportInitialize)(this.nudCharacterPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHowManyCPs;
        private System.Windows.Forms.NumericUpDown nudCharacterPoints;
        private System.Windows.Forms.Button buttonStart;
    }
}

