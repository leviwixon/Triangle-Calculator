namespace TriangleCalculator
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
            this.Side1 = new System.Windows.Forms.TextBox();
            this.Side2 = new System.Windows.Forms.TextBox();
            this.Side3 = new System.Windows.Forms.TextBox();
            this.Angle1 = new System.Windows.Forms.TextBox();
            this.Angle2 = new System.Windows.Forms.TextBox();
            this.Angle3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Side1
            // 
            this.Side1.Location = new System.Drawing.Point(83, 34);
            this.Side1.Name = "Side1";
            this.Side1.Size = new System.Drawing.Size(82, 26);
            this.Side1.TabIndex = 0;
            this.Side1.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Side2
            // 
            this.Side2.Location = new System.Drawing.Point(83, 75);
            this.Side2.Name = "Side2";
            this.Side2.Size = new System.Drawing.Size(82, 26);
            this.Side2.TabIndex = 1;
            this.Side2.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Side3
            // 
            this.Side3.Location = new System.Drawing.Point(83, 117);
            this.Side3.Name = "Side3";
            this.Side3.Size = new System.Drawing.Size(82, 26);
            this.Side3.TabIndex = 2;
            this.Side3.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Angle1
            // 
            this.Angle1.Location = new System.Drawing.Point(252, 34);
            this.Angle1.Name = "Angle1";
            this.Angle1.Size = new System.Drawing.Size(82, 26);
            this.Angle1.TabIndex = 3;
            this.Angle1.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Angle2
            // 
            this.Angle2.Location = new System.Drawing.Point(252, 75);
            this.Angle2.Name = "Angle2";
            this.Angle2.Size = new System.Drawing.Size(82, 26);
            this.Angle2.TabIndex = 4;
            this.Angle2.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Angle3
            // 
            this.Angle3.Location = new System.Drawing.Point(252, 117);
            this.Angle3.Name = "Angle3";
            this.Angle3.Size = new System.Drawing.Size(82, 26);
            this.Angle3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Side a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angle C:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Angle B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Angle A:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Side c:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Side b:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 27);
            this.button1.TabIndex = 12;
            this.button1.Text = "Find the Triangle!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Enabled = false;
            this.WarningLabel.Location = new System.Drawing.Point(69, 196);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(0, 19);
            this.WarningLabel.TabIndex = 13;
            this.WarningLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(850, 436);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Angle3);
            this.Controls.Add(this.Angle2);
            this.Controls.Add(this.Angle1);
            this.Controls.Add(this.Side3);
            this.Controls.Add(this.Side2);
            this.Controls.Add(this.Side1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Geometry Calculator (Triangles)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Side1;
        private System.Windows.Forms.TextBox Side2;
        private System.Windows.Forms.TextBox Side3;
        private System.Windows.Forms.TextBox Angle1;
        private System.Windows.Forms.TextBox Angle2;
        private System.Windows.Forms.TextBox Angle3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label WarningLabel;
    }
}

