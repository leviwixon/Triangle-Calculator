using System;

namespace TriangleCalculator.Triangles
{
    public abstract class Triangle
    {
        public static double maxAngle = 180.00;
        protected double _area, _perimeter = 0;
        public int totalSides, totalAngles = 0;
        private int _triType = 1;
        public double tmpa, tmps;
        private bool _invalidTri = false;
        public double[] a = new double[3];
        public double[] s = new double[3];

        public bool InvalidTri { get { return this._invalidTri; } }
        public int TriType { 
            get
            {
                return this._triType;
            }
            set
            {
                if (value >= 0 && value <= 3)
                {
                    this._triType = value;
                }
            }
        }
        public double Perimeter { get
            {
                return this._perimeter;
            }
        }
        public double Area { get
            {
                return this._area;
            }
        }


        protected abstract void findArea();
        protected abstract void CalcSides();

        public void FindTri()
        {
            CalcSides();
            findArea();
            perimeter();
        }

        protected void perimeter()
        {
            _perimeter = s[0] + s[1] + s[2];
        }

        public double LawofCos(double A, double b, double c)
        {
            double tmpAngle = DegToRad(A);
            double angle = Math.Cos(tmpAngle);
            return Math.Sqrt((b * b) + (c * c) - 2 * b * c * angle);
        }
        public double LawofCosAngle(double a, double b, double c)
        {
            double tmp = Math.Acos((Math.Pow(c, 2) + Math.Pow(b, 2) - Math.Pow(a, 2)) / (2 * b * c));
            return RadToDeg(tmp);
        }
        public double LawofSinAngle(double a, double b, double AngleA)
        {
            double angle = DegToRad(AngleA);
            angle = Math.Sin(angle);
            if (angle > 1 || angle < -1)
            {
                this.Invalidate();
            }
            angle = Math.Asin((angle / a) * b);
            angle = RadToDeg(angle);
            return angle;
        }
        public double LawofSinSide(double a, double AngleA, double AngleB)
        {
            double angle1, angle2;
            angle1 = DegToRad(AngleA);
            angle2 = DegToRad(AngleB);

            return a * Math.Sin(angle2) / Math.Sin(angle1);
        }

        public double Pythagorean(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
        public double revPyth(double c, double b)
        {
            return Math.Sqrt(Math.Pow(c, 2) - Math.Pow(b, 2));
        }
        public double RadToDeg(double rad)
        {
            return rad * (180 / Math.PI);
        }
        public double DegToRad(double deg)
        {
            return deg * (Math.PI / 180);
        }
        public void Invalidate()
        {
            _invalidTri = true;
        }


    }
}
