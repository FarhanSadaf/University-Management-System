namespace UniversityManagementSystem.UI
{
    partial class LauncherUI
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
            this.studentUIButton = new System.Windows.Forms.Button();
            this.takesCorseUIButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentUIButton
            // 
            this.studentUIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentUIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentUIButton.Location = new System.Drawing.Point(342, 140);
            this.studentUIButton.Name = "studentUIButton";
            this.studentUIButton.Size = new System.Drawing.Size(116, 51);
            this.studentUIButton.TabIndex = 0;
            this.studentUIButton.Text = "StudentUI";
            this.studentUIButton.UseVisualStyleBackColor = true;
            this.studentUIButton.Click += new System.EventHandler(this.studentUIButton_Click);
            // 
            // takesCorseUIButton
            // 
            this.takesCorseUIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.takesCorseUIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takesCorseUIButton.Location = new System.Drawing.Point(342, 222);
            this.takesCorseUIButton.Name = "takesCorseUIButton";
            this.takesCorseUIButton.Size = new System.Drawing.Size(116, 51);
            this.takesCorseUIButton.TabIndex = 1;
            this.takesCorseUIButton.Text = "TakesCourseUI";
            this.takesCorseUIButton.UseVisualStyleBackColor = true;
            this.takesCorseUIButton.Click += new System.EventHandler(this.takesCorseUIButton_Click);
            // 
            // LauncherUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.takesCorseUIButton);
            this.Controls.Add(this.studentUIButton);
            this.Name = "LauncherUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LauncherUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button studentUIButton;
        private System.Windows.Forms.Button takesCorseUIButton;
    }
}