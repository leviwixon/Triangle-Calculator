using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TriangleCalculator
{
    public partial class Form1 : Form
    {
        #region VarsUsed
        public Point[] points = new Point[3];
        private int i = 0;
        public bool drawType;
        private double triMid, triHeight;
        public int swap = 1;
        double[] s = new double[3];
        double[] a = new double[3];

        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Solve
        private void button1_Click(object sender, EventArgs e)
        {
            // This resets the swap variable in case a user enters another possible 2 triangle.
            swap = 1;
            Solve();
        }

        /// <summary>
        /// This grabs the variables from their textboxes and assigns them into an array, using a counter variable
        /// to ensure the proper amount of information is provided.
        /// </summary>
        private void Solve()
        {
            {
                WarningLabel.Text = "";
                WarningLabel.Visible = false;
                TriSwitch.Visible = false;

                int i = 0;
                i += BoxStatus_enter(Side1);
                i += BoxStatus_enter(Side2);
                i += BoxStatus_enter(Side3);
                i += BoxStatus_enter(Angle1);
                i += BoxStatus_enter(Angle2);
                i += BoxStatus_enter(Angle3);

                if (i < 3)
                {
                    WarningLabel.Text = string.Concat("Please enter at least 3 fields. ");
                    WarningLabel.Visible = true;
                }
                else if (Side1.Text.Equals(String.Empty) && Side2.Text.Equals(string.Empty) && Side3.Text.Equals(string.Empty))
                {
                    WarningLabel.Text = "Please enter at least one side.";
                    WarningLabel.Visible = true;
                }
                else
                {
                    s[0] = assignment(Side1);
                    s[1] = assignment(Side2);
                    s[2] = assignment(Side3);
                    a[0] = assignment(Angle1);
                    a[1] = assignment(Angle2);
                    a[2] = assignment(Angle3);

                    if (a.Contains(90))
                    {
                        RightTriangle tri = new RightTriangle(a, s);
                        RightSolve(tri);
                    }
                    else
                    {
                        NonRight tri = new NonRight(a, s);
                        NonRightSolve(tri);
                    }
                }
            }
        }

        // Exists in case calculator is ever made to solve unit circle problems where angles are negative,
        // otherwise negatives cannot exist because the input validation does not have any specification for
        // approaching a '-' entry;
        //private bool CheckNegative()
        //{
        //    for (int j = 0; j < 3; j++)
        //    {
        //        if (a[j] < 0 || s[j] < 0)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        #endregion

        #region Right
        /// <summary>
        /// Solves a provided 90 degree triangle. This skips some steps that would usually require checking in the non-right case
        /// and is only preformed if it is KNOWN that it is a 90 degree triangle. Should the product of some measurements produce a 90 degree triangle,
        /// it must unfortunately go through the non-right solving mechanism.
        /// </summary>
        /// <param name="tri"></param>
        private void RightSolve(Triangle tri)
        {
            tri.FindTri();
            if (!tri.InvalidTri)
            {
                GetPoints(tri);
                PrintAnswers(tri);
                panel1.Paint += new PaintEventHandler(panel1_Paint);
                panel1.Visible = true;
                panel1.Refresh();
            }
            else
            {
                WarningLabel.Text = "Invalid triangle. Try again with different measurements.";
                WarningLabel.Visible = true;
                panel1.Visible = false;
            }

        }
        #endregion

        #region NonRight
        /// <summary>
        /// Solves non-right triangle, considering the possible edge cases along with it.
        /// </summary>
        /// <param name="tri"></param>
        private void NonRightSolve(Triangle tri)
        {
            tri.FindTri();
            if (!tri.InvalidTri)
            {
                GetPoints(tri);
                panel1.Paint += new PaintEventHandler(panel1_Paint);
                panel1.Visible = true;
                panel1.Refresh();
                if (tri.TriType == 2)
                {
                    TriSwitch.Visible = true;
                }
                PrintAnswers(tri);
            }
            else
            {
                WarningLabel.Text = "Invalid triangle. Try again with different measurements.";
                WarningLabel.Visible = true;
                panel1.Visible = false;
            }
        }

        private void TriSwitch_Click(object sender, EventArgs e)
        {
            swap = swap * -1;
            if (swap < 0)
            {
                SpecialCase tri = new SpecialCase(a, s);
                NonRightSolve(tri);
                tri.TriType = 2;
            }
            else
            {
                NonRight tri = new NonRight(a, s);
                NonRightSolve(tri);
            }
        }
        #endregion

        #region TextBoxStuff
        /// <summary>
        /// Only assigns non-zero value when the textbox is not empty
        /// Does not need to verify how many sides and angles have been entered as it is already done by BoxStatus
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private double assignment(TextBox t)
        {

            double val = 0;
            if (!t.Text.Equals(string.Empty))
            {
                val = double.Parse(t.Text);
            }
            return val;
        }
        /// <summary>
        /// When the user leaves the box, it verifies if something has changed or if the string is empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxStatus_leave(object sender, EventArgs e)
        {
            if (!(sender as TextBox).Text.Equals(string.Empty))
            {
                i++;
            }
        }

        /// <summary>
        /// This acts as if the text box that is active has never been entered into
        /// If the user has entered into it, but deleted the info, the box will return to the state where nothing is entered yet
        /// Otherwise, if the user just modifies the numbers, the box will return to the state in which something was entered because of the boxstatus leave.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private int BoxStatus_enter(TextBox t)
        {
            
            if (!t.Text.Equals(string.Empty))
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// This function judges which triangle to show in a 2 triangle case based upon a swap value that alternates between < 0 and > 0 as a result of 
        /// negative multiplication.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion

        #region Print/Clear
        /// <summary>
        /// This rearranges the answers that have likely been sorted into different forms over the course of being solved. It looks at the original input, and 
        /// sorts the information as best it can into correct order. It then prints into all the boxes the information, and unhides them.
        /// </summary>
        /// <param name="t"></param>
        private void PrintAnswers(Triangle t)
        {
            if (!t.InvalidTri || t.TriType != 0)
            {
                double tmpa, tmps;
                int n = 3;
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if ((s[j] == t.s[k] || a[j] == t.a[k]) && k != j && s[j] != 0 && a[j] != 0)
                        {
                            tmpa = t.a[k];
                            tmps = t.s[k];
                            t.s[k] = t.s[j];
                            t.a[k] = t.a[j];
                            t.s[j] = tmps;
                            t.a[j] = tmpa;
                        }
                    }
                }
                Side1.Text = (Math.Round(t.s[0], 3)).ToString();
                Side2.Text = (Math.Round(t.s[1], 3)).ToString();
                Side3.Text = (Math.Round(t.s[2], 3)).ToString();
                Angle1.Text = (Math.Round(t.a[0], 3)).ToString();
                Angle2.Text = (Math.Round(t.a[1], 3)).ToString();
                Angle3.Text = (Math.Round(t.a[2], 3)).ToString();
                AreaBox.Text = Math.Round(t.Area, 3).ToString();
                PerimBox.Text = Math.Round(t.Perimeter, 3).ToString();
                PerimBox.Visible = true;
                AreaBox.Visible = true;
                Perim.Visible = true;
                AreaLbl.Visible = true;
            }
            
        }

        /// <summary>
        /// This essentially just resets the state of the calculator to default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            Side1.Text = "";
            Side2.Text = "";
            Side3.Text = "";
            Angle1.Text = "";
            Angle2.Text = "";
            Angle3.Text = "";
            WarningLabel.Text = "";
            panel1.Visible = false;
            AreaBox.Visible = false;
            Perim.Visible = false;
            PerimBox.Visible = false;
            AreaLbl.Visible = false;
            TriSwitch.Visible = false;
        }
        #endregion

        #region KeyPress
        /// <summary>
        /// Occurs when any key is pressed for any textbox. It calls the switch statement in KeyReader to validate input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Angle3_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyReader(sender as TextBox, e);
        }

        /// <summary>
        /// This function is called by the keyPress event for every textbox except for area and perimeter. Because the textboxes are readonly,
        /// the only way to effectively edit them is to go through the keyPress event and the KeyReader function by extension. KeyReader leverages
        /// the ASCII value of a key ((int)e.keyChar) in a switch statement so that keys that should not be pressed (such as letters) default to doing
        /// nothing, while number keys, decimal keys, etc. have an append event tied to them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyReader(TextBox sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case 48:
                    sender.Text += "0";
                    break;
                case 49:
                    sender.Text += "1";
                    break;
                case 50:
                    sender.Text += "2";
                    break;
                case 51:
                    sender.Text += "3";
                    break;
                case 52:
                    sender.Text += "4";
                    break;
                case 53:
                    sender.Text += "5";
                    break;
                case 54:
                    sender.Text += "6";
                    break;
                case 55:
                    sender.Text += "7";
                    break;
                case 56:
                    sender.Text += "8";
                    break;
                case 57:
                    sender.Text += "9";
                    break;
                case 46:
                    if (!sender.Text.Contains("."))
                    {
                        sender.Text += ".";
                    }
                    break;
                case 8:
                    if (sender.Text.Length > 1)
                    {
                        sender.Text = sender.Text.Remove(sender.Text.Length - 1);
                    }
                    else
                    {
                        sender.Text = "";
                    }
                    break;
                case 13:
                    button1_Click(button1, new EventArgs());
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Painting
        /// <summary>
        /// This is a painting function that gathers the points that resulted from the GetPoints functions and draws a triangle in black to match them.
        /// It also leverages a previously defined variable "drawType" to determine whether a right triangle is being created (which would require a different point 
        /// structe to preserve the right angle), or if a nonRight is being made. It uses a red color scheme to write angles, and a blue color scheme to write sides.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            g.DrawPolygon(p, points);
            SolidBrush Bbrush = new SolidBrush(Color.Blue);
            SolidBrush Rbrush = new SolidBrush(Color.Red);
            if (drawType == true)
            {
                using (Rbrush)
                {
                    StringFormat sf = new StringFormat();
                    g.DrawString("B", this.Font, Rbrush, points[1].X, points[1].Y - 10);
                    g.DrawString("C", this.Font, Rbrush, points[0].X, points[0].Y - 20);
                    g.DrawString("A", this.Font, Rbrush, points[2].X, points[2].Y + 10);

                }
                using (Bbrush)
                {
                    StringFormat sf = new StringFormat();
                    g.DrawString("b", this.Font, Bbrush, points[2].X - 12, (points[2].Y + points[0].Y) / 2);
                    g.DrawString("c", this.Font, Bbrush, (points[1].X + points[2].X) / 2 + 10, (points[2].Y + points[1].Y) / 2 - 10);
                    g.DrawString("a", this.Font, Bbrush, (points[1].X + points[0].X) / 2, points[0].Y);
                }
            }
            else
            {
                using (Rbrush)
                {
                    StringFormat sf = new StringFormat();
                    g.DrawString("B", this.Font, Rbrush, points[1].X, points[1].Y - 10);
                    g.DrawString("C", this.Font, Rbrush, points[0].X, points[0].Y);
                    g.DrawString("A", this.Font, Rbrush, points[2].X - 5, points[2].Y);

                }
                using (Bbrush)
                {
                    StringFormat sf = new StringFormat();
                    g.DrawString("b", this.Font, Bbrush, (points[2].X + points[0].X) / 2, (points[2].Y + points[0].Y) / 2);
                    g.DrawString("c", this.Font, Bbrush, (points[1].X + points[2].X) / 2 + 10, (points[2].Y + points[1].Y) / 2 - 10);
                    g.DrawString("a", this.Font, Bbrush, Math.Abs((points[1].X - points[0].X)) - 15, (points[1].Y + points[0].Y) / 2);
                }
            }
        }

        /// <summary>
        /// This function determines what kind of triangle is going to be drawn, as well as what aspect ratio to use to ensure correct ratio, but not a ratio that 
        /// would overflow the bounds of the panel. This function also produces the points array used to draw the triangle.
        /// </summary>
        /// <param name="t"></param>
        private void GetPoints(Triangle t)
        {
            int[] roundedAngles = new int[3];
            for (int i = 0; i < 3; i++)
            {
                roundedAngles[i] = (int)(Math.Round(t.a[i]));
            }
            // Preserves aspect ratio
            float ratX = 200 / (float)(t.s[0]); ;
            float ratY = 200 / (float)(t.s[1]);
            float ratio = Math.Min(ratX, ratY);

            int newWidth = (int)(t.s[0] * ratio);
            int newHeight = (int)(t.s[1] * ratio);
            if (roundedAngles.Contains(90))
            {
                drawType = false;
                points[0] = new Point(80, 250);
                points[1] = new Point(newWidth + 100, 250);
                points[2] = new Point(80, 250 - newHeight);
            }
            else
            {
                triHeight = (2 * t.Area) / t.s[0];
                triMid = t.revPyth(t.s[1], triHeight);
                triHeight = triHeight * ratio;
                triMid = triMid * ratio;
                drawType = true;
                points[0] = new Point(80, 250);
                points[1] = new Point((int)triMid, 250 - (int)triHeight);
                points[2] = new Point(newWidth, 250);
            }
        }
        #endregion
    }
}

