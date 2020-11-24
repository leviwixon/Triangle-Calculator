using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    public abstract class Triangle
    {
        public static double maxAngle = 180.00;
        public double Area, Perimeter = 0;
        public int totalSides, totalAngles = 0;
        public double tmpa, tmps;
        public double[] a = new double[3];
        public double[] s = new double[3];

        public abstract void findArea();
        public abstract void perimeter();
        public abstract void CalcSides();

        public double LawofCos(double A, double b, double c)
        {
            return Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2) - (2 * b * c) * Math.Cos(A));
        }
        public double LawofCosAngle(double a, double b, double c)
        {
            return Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(a, 2)) / (2 * b * c));
        }
        public double LawofSinSide(double a, double AngleA, double AngleB)
        {
            return (a * Math.Sin(DegToRad(AngleB)))/Math.Sin(DegToRad(AngleA));
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
        /// <summary>
        /// This method essenitally floats up the side that posesses value that isn't a hypotenuse to the user.
        /// It is used to help solve 2 angle problems by narrowing down what approach to take (whether it be sin or cosine.
        /// </summary>
        public void bringSidesUp()
        {
            if (s[1] != 0 && s[0] == 0)
            {
                tmps = s[1];
                tmpa = a[1];
                s[1] = s[0];
                a[1] = a[0];
                s[0] = tmps;
                a[0] = tmpa;
            }
        }

        /// <summary>
        /// This method does the same as bringSidesUp, however it is used to help narrow down what angle needs to be filled out (with the exceptions of the right angle in right triangles).
        /// It helps solve 2 side problems by narrowing down what approach should be taken.
        /// </summary>
        public void bringAnglesUp()
        {
            if (a[1] != 0)
            {
                tmps = s[1];
                tmpa = a[1];
                s[1] = s[0];
                a[1] = a[0];
                s[0] = tmps;
                a[0] = tmpa;
            }
        }
    }
}
