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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TriSwitch = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.PerimBox = new System.Windows.Forms.TextBox();
            this.AreaBox = new System.Windows.Forms.TextBox();
            this.AreaLbl = new System.Windows.Forms.Label();
            this.Perim = new System.Windows.Forms.Label();
            this.Ratio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Side1
            // 
            this.Side1.Location = new System.Drawing.Point(83, 56);
            this.Side1.Name = "Side1";
            this.Side1.ReadOnly = true;
            this.Side1.Size = new System.Drawing.Size(82, 26);
            this.Side1.TabIndex = 0;
            this.Side1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle3_KeyPress);
            this.Side1.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Side2
            // 
            this.Side2.Location = new System.Drawing.Point(83, 110);
            this.Side2.Name = "Side2";
            this.Side2.ReadOnly = true;
            this.Side2.Size = new System.Drawing.Size(82, 26);
            this.Side2.TabIndex = 1;
            this.Side2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle3_KeyPress);
            this.Side2.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Side3
            // 
            this.Side3.Location = new System.Drawing.Point(83, 160);
            this.Side3.Name = "Side3";
            this.Side3.ReadOnly = true;
            this.Side3.Size = new System.Drawing.Size(82, 26);
            this.Side3.TabIndex = 2;
            this.Side3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle3_KeyPress);
            this.Side3.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Angle1
            // 
            this.Angle1.Location = new System.Drawing.Point(252, 56);
            this.Angle1.Name = "Angle1";
            this.Angle1.ReadOnly = true;
            this.Angle1.Size = new System.Drawing.Size(82, 26);
            this.Angle1.TabIndex = 3;
            this.Angle1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle3_KeyPress);
            this.Angle1.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Angle2
            // 
            this.Angle2.Location = new System.Drawing.Point(252, 110);
            this.Angle2.Name = "Angle2";
            this.Angle2.ReadOnly = true;
            this.Angle2.Size = new System.Drawing.Size(82, 26);
            this.Angle2.TabIndex = 4;
            this.Angle2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle3_KeyPress);
            this.Angle2.Leave += new System.EventHandler(this.BoxStatus_leave);
            // 
            // Angle3
            // 
            this.Angle3.Location = new System.Drawing.Point(252, 160);
            this.Angle3.Name = "Angle3";
            this.Angle3.ReadOnly = true;
            this.Angle3.Size = new System.Drawing.Size(82, 26);
            this.Angle3.TabIndex = 5;
            this.Angle3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle3_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Side a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angle C:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Angle B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Angle A:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Side c:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Side b:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 196);
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
            this.WarningLabel.Location = new System.Drawing.Point(37, 257);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(93, 19);
            this.WarningLabel.TabIndex = 13;
            this.WarningLabel.Text = "this is test text";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.WarningLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(388, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 300);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TriSwitch
            // 
            this.TriSwitch.Location = new System.Drawing.Point(463, 355);
            this.TriSwitch.Name = "TriSwitch";
            this.TriSwitch.Size = new System.Drawing.Size(135, 27);
            this.TriSwitch.TabIndex = 16;
            this.TriSwitch.Text = "Switch Triangle";
            this.TriSwitch.UseVisualStyleBackColor = true;
            this.TriSwitch.Visible = false;
            this.TriSwitch.Click += new System.EventHandler(this.TriSwitch_Click);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(94, 9);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(530, 19);
            this.Description.TabIndex = 17;
            this.Description.Text = "This calculator requires a minimum of 3 entries. In the case of 3 angles, it will" +
    " require 4.";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(145, 229);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(91, 27);
            this.Clear.TabIndex = 18;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // PerimBox
            // 
            this.PerimBox.Location = new System.Drawing.Point(252, 308);
            this.PerimBox.Name = "PerimBox";
            this.PerimBox.ReadOnly = true;
            this.PerimBox.Size = new System.Drawing.Size(82, 26);
            this.PerimBox.TabIndex = 19;
            this.PerimBox.Visible = false;
            // 
            // AreaBox
            // 
            this.AreaBox.Location = new System.Drawing.Point(57, 308);
            this.AreaBox.Name = "AreaBox";
            this.AreaBox.ReadOnly = true;
            this.AreaBox.Size = new System.Drawing.Size(82, 26);
            this.AreaBox.TabIndex = 20;
            this.AreaBox.Visible = false;
            // 
            // AreaLbl
            // 
            this.AreaLbl.AutoSize = true;
            this.AreaLbl.Location = new System.Drawing.Point(9, 311);
            this.AreaLbl.Name = "AreaLbl";
            this.AreaLbl.Size = new System.Drawing.Size(42, 19);
            this.AreaLbl.TabIndex = 21;
            this.AreaLbl.Text = "Area:";
            this.AreaLbl.Visible = false;
            // 
            // Perim
            // 
            this.Perim.AutoSize = true;
            this.Perim.Location = new System.Drawing.Point(179, 311);
            this.Perim.Name = "Perim";
            this.Perim.Size = new System.Drawing.Size(70, 19);
            this.Perim.TabIndex = 22;
            this.Perim.Text = "Perimeter:";
            this.Perim.Visible = false;
            // 
            // Ratio
            // 
            this.Ratio.AutoSize = true;
            this.Ratio.Location = new System.Drawing.Point(347, 408);
            this.Ratio.Name = "Ratio";
            this.Ratio.Size = new System.Drawing.Size(369, 19);
            this.Ratio.TabIndex = 23;
            this.Ratio.Text = "*Graph may not be realistic representation of measurements";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(728, 436);
            this.Controls.Add(this.Ratio);
            this.Controls.Add(this.Perim);
            this.Controls.Add(this.AreaLbl);
            this.Controls.Add(this.AreaBox);
            this.Controls.Add(this.PerimBox);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.TriSwitch);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button TriSwitch;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox PerimBox;
        private System.Windows.Forms.TextBox AreaBox;
        private System.Windows.Forms.Label AreaLbl;
        private System.Windows.Forms.Label Perim;
        private System.Windows.Forms.Label Ratio;
    }
}

