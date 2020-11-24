using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleCalculator
{
    public partial class Form1 : Form
    {
        private double totalAngle;
        private int i = 0;
        public double curPerim, curArea;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WarningLabel.Text = "";
            WarningLabel.Visible = false;

            int i = 0;
            i += BoxStatus_enter(Side1);
            i += BoxStatus_enter(Side2);
            i += BoxStatus_enter(Side3);
            i += BoxStatus_enter(Angle1);
            i += BoxStatus_enter(Angle2);
            i += BoxStatus_enter(Angle3);

            if (i < 3)
            {
                WarningLabel.Text = string.Concat("Please enter at least 3 fields. ", i);
                WarningLabel.Visible = true;
            }
            else if (Side1.Text.Equals(String.Empty) && Side2.Text.Equals(string.Empty) && Side3.Text.Equals(string.Empty))
            {
                WarningLabel.Text = "Please enter at least one side.";
                WarningLabel.Visible = true;
            }
            else if (Angle1.Text.Equals(String.Empty) && Angle2.Text.Equals(string.Empty) && Angle3.Text.Equals(string.Empty))
            {
                WarningLabel.Text = "Please enter at least one angle.";
                WarningLabel.Visible = true;
            }
            else
            {
                //Error checking the total angles and sides by using the warning label
                //WarningLabel.Text = String.Concat("", i);
                //WarningLabel.Visible = true;
                double[] s = new double[3];
                double[] a = new double[3];

                s[0] = assignment(Side1);
                s[1] = assignment(Side2);
                s[2] = assignment(Side3);
                a[0] = assignment(Angle1);
                a[1] = assignment(Angle2);
                a[2] = assignment(Angle3);

                if (!a.Contains(0))
                {
                    totalAngle = a.Sum();
                }

                if (a.Contains(90))
                {
                    RightTriangle tri = new RightTriangle(a, s);
                    tri.CalcSides();
                    tri.perimeter();
                    tri.findArea();
                    WarningLabel.Text = string.Concat("", Math.Round(tri.s[0], 3), " , ", Math.Round(tri.s[1], 2), " , ", Math.Round(tri.s[2], 2), " , ", Math.Round(tri.a[0], 2), " , ", Math.Round(tri.a[1], 2), " , ", Math.Round(tri.a[2], 2), " , ", Math.Round(tri.Perimeter, 2), " , ", Math.Round(tri.Area, 2));
                    WarningLabel.Visible = true;
                }
            }
             
        }
        private double assignment(TextBox t)
        {
            // Only assigns non-zero value when the textbox is not empty
            // Does not need to verify how many sides and angles have been entered as it is already done by BoxStatus
            double val = 0;
            if (!t.Text.Equals(string.Empty))
            {
                val = double.Parse(t.Text);
            }
            return val;
        }

        private void BoxStatus_leave(object sender, EventArgs e)
        {
            // When the user leaves the box, it verifies if something has changed or if the string is empty
            if (!(sender as TextBox).Text.Equals(string.Empty))
            {
                i++;
            }
        }

        private int BoxStatus_enter(TextBox t)
        { 
            // This acts as if the text box that is active has never been entered into
            // If the user has entered into it, but deleted the info, the box will return to the state where nothing is entered yet
            // Otherwise, if the user just modifies the numbers, the box will return to the state in which something was entered because of the boxstatus leave.
            if (!t.Text.Equals(string.Empty)) {
                return 1;
            }
            return 0;
        }
    }
}
