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
    }
}
