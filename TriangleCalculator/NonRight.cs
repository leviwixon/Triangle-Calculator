using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    class NonRight : Triangle
    {
        public NonRight(double[] angles, double[] sides)
        {
            for (int i = 0; i < 3; i++)
            {
                s[i] = sides[i];
                a[i] = angles[i];
            }
        }

        public override void CalcSides()
        { 
            throw new NotImplementedException();
        }

        public override void findArea()
        {
            throw new NotImplementedException();
        }

        public override void perimeter()
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
