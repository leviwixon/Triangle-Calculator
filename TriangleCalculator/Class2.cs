using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    class RightTriangle : Triangle
    {
        public static double maxAngle = 180.00;

        private class triangleInfo
        {
            public double side1, side2, side3 = 0;
            public double angle1, angle2, angle3 = 0;
        }

        public override double CalcSides()
        {
            throw new NotImplementedException();
        }

        public override double findArea()
        {
            throw new NotImplementedException();
        }

        public override double perimeter()
        {
            throw new NotImplementedException();
        }

        private double Pythagorean()
        {
            throw new NotImplementedException();
        }
    }
}
