namespace PCPA_DB
{
    partial class Popup
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
            this.okBttn = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBttn
            // 
            this.okBttn.Location = new System.Drawing.Point(215, 84);
            this.okBttn.Name = "okBttn";
            this.okBttn.Size = new System.Drawing.Size(75, 23);
            this.okBttn.TabIndex = 1;
            this.okBttn.Text = "OK";
            this.okBttn.UseVisualStyleBackColor = true;
            this.okBttn.Click += new System.EventHandler(this.CloseBttn_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 41);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(468, 20);
            this.pathBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input valid CSV file path";
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 119);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.okBttn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okBttn;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label label1;
    }
}