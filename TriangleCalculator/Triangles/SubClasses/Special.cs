using System;
using System.Linq;

namespace TriangleCalculator.Triangles.SubClasses
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

        /// <summary>
        /// This is a tweaked nonRight CalcSides that changes an angle from a solved nonright triangle, making it the supplement. It follows this up
        /// by tweaking a couple of values that depended on the previous angle, creating the secondary possible triangle.
        /// </summary>
        protected override void CalcSides()
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

        /// <summary>
        /// Finds the values that must change for the new angle, and changes them.
        /// </summary>
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

        /// <summary>
        /// FindArea just like previous iterations.
        /// </summary>
        protected override void findArea()
        {
            double angle = DegToRad(a[2]);
            angle = Math.Sin(angle);
            _area = (s[0] * s[1] * angle) / 2;
        }
    }
}
