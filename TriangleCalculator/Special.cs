using System;

namespace TriangleCalculator
{
    class SpecialCase : NonRight
    {
        double supAngle = 0;
        public SpecialCase(double[] angles, double[] sides)
        {
            for (int i = 0; i < 3; i++)
            {
                s[i] = sides[i];
                a[i] = angles[i];
            }
        }

        public override void CalcSides()
        {
            updateTotals();
            if (totalAngles != 3 && totalSides != 3)
            {
                AngleIndex();
            }
            updateTotals();
            if (totalAngles != 3 && totalSides != 3)
            {
                SSANonSpecial();
                for (int i = 0; i < 3; i++)
                {
                    if (a[i] != a[angleIndex] && a[i] < 90)
                    {
                        supAngle = Math.Abs(a[i] - 180);
                        a[i] = supAngle;
                    }
                }
                Change();
                InvalidCheck();
            }
        }

        private void Change()
        {
            for (int i = 0; i < 3; i++)
            {
                if (a[i] != a[angleIndex] && a[i] != supAngle)
                {
                    a[i] = maxAngle - supAngle - a[angleIndex];
                    s[i] = LawofSinSide(s[angleIndex], a[angleIndex], a[i]);
                }
            }
        }

        public override void findArea()
        {
            double angle = DegToRad(a[2]);
            angle = Math.Sin(angle);
            Area = (s[0] * s[1] * angle) / 2;
        }
    }
}
