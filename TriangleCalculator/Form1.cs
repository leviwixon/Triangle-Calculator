using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TriangleCalculator
{
    public partial class Form1 : Form
    {
        public Point[] points = new Point[3];
        private double totalAngle;
        private int i = 0;
        public double curPerim, curArea;
        public bool drawType;
        private double triMid, triHeight;
        public double oAngle;
        public int swap = 1;
        double[] s = new double[3];
        double[] a = new double[3];
        public Form1()
        {
            InitializeComponent();
        }
        #region ButtonLogic_REVIST_LOGIC
        private void button1_Click(object sender, EventArgs e)
        {
            swap = 1;
            Solve();
        }

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
                    WarningLabel.Text = string.Concat("Please enter at least 3 fields. ", i);
                    WarningLabel.Visible = true;
                }
                else if (Side1.Text.Equals(String.Empty) && Side2.Text.Equals(string.Empty) && Side3.Text.Equals(string.Empty))
                {
                    WarningLabel.Text = "Please enter at least one side.";
                    WarningLabel.Visible = true;
                }
                //else if (Angle1.Text.Equals(String.Empty) && Angle2.Text.Equals(string.Empty) && Angle3.Text.Equals(string.Empty))
                //{
                //    WarningLabel.Text = "Please enter at least one angle.";
                //    WarningLabel.Visible = true;
                //}
                else
                {


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
                        RightSolve(tri);
                    }
                    else
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (a[j] != 0)
                            {
                                oAngle = a[j];
                            }
                        }
                        NonRight tri = new NonRight(a, s);
                        NonRightSolve(tri);
                    }
                }
            }
        }

        private void RightSolve(Triangle tri)
        {
            tri.CalcSides();
            tri.perimeter();
            tri.findArea();
            WarningLabel.Text = string.Concat("", Math.Round(tri.s[0], 3), " , ", Math.Round(tri.s[1], 2), " , ", Math.Round(tri.s[2], 2), " , ", Math.Round(tri.a[0], 2), " , ", Math.Round(tri.a[1], 2), " , ", Math.Round(tri.a[2], 2), " , ", Math.Round(tri.Perimeter, 2), " , ", Math.Round(tri.Area, 2));
            WarningLabel.Visible = true;
            drawType = true;
            GetPoints(tri);
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Visible = true;
            panel1.Refresh();
            PrintAnswers(tri);
        }

        private void NonRightSolve(Triangle tri)
        {
            tri.CalcSides();
            if (!tri.invalidTri || tri.triType != 0)
            {
                tri.perimeter();
                tri.findArea();
                //WarningLabel.Text = string.Concat("", Math.Round(tri.s[0], 3), " , ", Math.Round(tri.s[1], 2), " , ", Math.Round(tri.s[2], 2), " , ", Math.Round(tri.a[0], 2), " , ", Math.Round(tri.a[1], 2), " , ", Math.Round(tri.a[2], 2), " , ", Math.Round(tri.Perimeter, 2), " , ", Math.Round(tri.Area, 2), " , ", tri.triType);
                //WarningLabel.Visible = true;
                drawType = false;
                GetPoints(tri);
                panel1.Paint += new PaintEventHandler(panel1_Paint);
                panel1.Visible = true;
                panel1.Refresh();
                if (tri.triType == 2)
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
            if (!t.Text.Equals(string.Empty))
            {
                return 1;
            }
            return 0;
        }
        public void DrawTriangle(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            Brush brush = new SolidBrush(Color.Red);
            g.FillPolygon(brush, points);

        }

        private void TriSwitch_Click(object sender, EventArgs e)
        {
            swap = swap * -1;
            if (swap < 0)
            {
                SpecialCase tri = new SpecialCase(a, s);
                tri.triType = 2;
                NonRightSolve(tri);
            }
            else
            {
                NonRight tri = new NonRight(a, s);
                NonRightSolve(tri);
            }
        }



        private void PrintAnswers(Triangle t)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            Side1.Text = "";
            Side2.Text = "";
            Side3.Text = "";
            Angle1.Text = "";
            Angle2.Text = "";
            Angle3.Text = "";
            panel1.Visible = false;
            AreaBox.Visible = false;
            Perim.Visible = false;
            PerimBox.Visible = false;
            AreaLbl.Visible = false;
            TriSwitch.Visible = false;
            swap = 1;
        }

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

        private void GetPoints(Triangle t)
        {
            // Preserves aspect ratio
            float ratX = 150 / (float)((int)t.s[0]); ;
            float ratY = 200 / (float)((int)t.s[1]);
            float ratio = Math.Min(ratX, ratY);

            int newWidth = (int)(t.s[0] * ratio);
            int newHeight = (int)(t.s[1] * ratio);
            triHeight = (2 * t.Area) / t.s[2];
            triMid = t.revPyth(t.s[1], triHeight);
            triHeight = triHeight * ratio;
            triMid = triMid * ratio;
            if (t.a.Contains(90))
            {
                drawType = false;
                points[0] = new Point(80, 250);
                points[1] = new Point(newWidth + 100, 250);
                points[2] = new Point(80, 250 - newHeight);
            }
            else
            {
                points[0] = new Point(80, 250);
                points[1] = new Point((int)triMid, 250 - (int)triHeight);
                points[2] = new Point(newWidth, 250);
            }
        }
    }
    #endregion
}

