using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    class NonRight : Triangle
    {
        public static double maxAngle = 180.00;
        public double angle1, angle2, angle3, side1, side2, side3 = 0;

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

        private void triangleType()
        {
            throw new NotImplementedException();
        }

        private void twoTriangle()
        {

        }

        private void oneTriangle()
        {

        }
    }
}
