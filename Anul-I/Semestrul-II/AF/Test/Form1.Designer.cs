
namespace Test
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pointDisplay = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.removePoint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(475, 451);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(594, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 1;
            // 
            // pointDisplay
            // 
            this.pointDisplay.Location = new System.Drawing.Point(594, 105);
            this.pointDisplay.Name = "pointDisplay";
            this.pointDisplay.Size = new System.Drawing.Size(100, 23);
            this.pointDisplay.TabIndex = 2;
            this.pointDisplay.Text = "Display";
            this.pointDisplay.UseVisualStyleBackColor = true;
            this.pointDisplay.Click += new System.EventHandler(this.pointDisplay_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(642, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 3;
            // 
            // removePoint
            // 
            this.removePoint.Location = new System.Drawing.Point(594, 134);
            this.removePoint.Name = "removePoint";
            this.removePoint.Size = new System.Drawing.Size(100, 23);
            this.removePoint.TabIndex = 4;
            this.removePoint.Text = "Remove Point";
            this.removePoint.UseVisualStyleBackColor = true;
            this.removePoint.Click += new System.EventHandler(this.removePoint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removePoint);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pointDisplay);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button pointDisplay;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button removePoint;
    }
}

