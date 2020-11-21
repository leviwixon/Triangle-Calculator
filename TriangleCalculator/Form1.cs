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
                Double s1, s2, s3;
                Double a1, a2, a3;
                s1 = assignment(Side1);
                s2 = assignment(Side2);
                s3 = assignment(Side3);
                a1 = assignment(Angle1);
                a2 = assignment(Angle2);
                a3 = assignment(Angle3);

                if (a1 != 0 && a2 != 0 && a3 != 0)
                {
                    totalAngle = a1 + a2 + a3;
                    if (totalAngle != 180)
                    {
                        WarningLabel.Text = "Sum of Angles must be 180\nPlease try again with valid angles.";
                        WarningLabel.Visible = true;
                    }
                }
                if (a1 == 90 || a2 == 90 || a3 = 90)
                {
                    new RightTrianlge tri = RightTriangle();
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
