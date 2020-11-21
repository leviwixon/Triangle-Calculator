using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    abstract class Triangle
    {
        public Double[] a;
        public Double[] s;
        public double angle1, angle2, angle3, side1, side2, side3 = 0;
        public static double maxAngle = 180.00;
        public double Area, Perimeter = 0;
        public int totalSides, totalAngles = 0;
        public abstract double findArea();
        public abstract double perimeter();
        public abstract double CalcSides();

        public double LawofCos(Double a, Double b, Double c)
        {
            return Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2) - (2 * b * c) * Math.Cos(a));
        }

        public double LawofSin(Double a, Double b, Double c)
        {
            // NOT CORRECT
            return Math.Sin(a) / b;
        }
        
        public double Pythagorean(Double a, Double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
}
