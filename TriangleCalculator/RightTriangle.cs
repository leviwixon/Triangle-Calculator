using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    class RightTriangle : Triangle
    {
        RightTriangle(Double s1, Double s2, Double s3, Double a1, Double a2, Double a3)
        {
            GetTotalA(s1);
            GetTotalA(s2);
            GetTotalA(s3);
            GetTotalA(a1);
            GetTotalA(a2);
            GetTotalA(a3);
            this.side1 = s1;
            this.side2 = s2;
            this.side3 = s3;
            this.angle1 = a1;
            this.angle2 = a2;
            this.angle3 = a3;
        }
        public override double CalcSides()
        {
            tryCalcs()
        }

        private void tryCalcs()
        {
            if (totalSides >= 2)
            {

            }
        }
        public override double findArea()
        {
            throw new NotImplementedException();
        }

        public override double perimeter()
        {
            throw new NotImplementedException();
        }


        private void GetTotalS(Double check)
        {
            if (check != 0)
            {
                totalSides++;
            }
        }
        private void GetTotalA(Double check)
        {
            if (check != 0)
            {
                totalAngles++;
            }
        }
    }
}
