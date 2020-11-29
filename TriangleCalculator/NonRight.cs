using System;
using System.Linq;

namespace TriangleCalculator
{
    class NonRight : Triangle
    {
        private readonly int len = 3;
        public int angleIndex = 0;
        private double tmpAngle, tmpSide, tmpLarSide;
        public NonRight(double[] angles, double[] sides)
        {
            for (int i = 0; i < 3; i++)
            {
                s[i] = sides[i];
                a[i] = angles[i];
                updateTotals();
            }
        }
        /// <summary>
        /// This constructor is made to allow proper inheritance from NonRight into Special.
        /// </summary>
        public NonRight()
        {

        }

        #region CalcSides
        /// <summary>
        /// Chooses what kind of triangle has been inputed, and solves it based on the side and angle total.
        /// </summary>
        public override void CalcSides()
        {
            {
                updateTotals();
                // SSS
                if (totalSides == 3 && totalAngles < 3)
                {
                    tryCalcsSSS();
                }
                // SSA
                else if (totalSides >= 2 && totalAngles <= 1)
                {
                    tryCalcsSSA();
                }
                // SAA
                else if (totalAngles >= 2 && totalSides <= 2)
                {
                    tryCalcsSAA();
                }
                InvalidCheck();
                if (invalidTri == true)
                {
                    triType = 0;
                }
            }
        }

        /// <summary>
        /// Calculates SSS triangles using the Law of Cosine.
        /// </summary>
        private void tryCalcsSSS()
        {
            bringSidesUp();
            for (int i = 0; i < 3; i++)
            {
                a[i] = LawofCosAngle(s[i % 3], s[(i + 1) % 3], s[(i + 2) % 3]);
            }
            updateTotals();
        }

        /// <summary>
        /// Given a case where an angle and the opposing side are given, the following code sends the information to a modified SSA,
        /// but is still ultimately calculated by the regular SSA function. Because invalid values return as NaN and don't crash everything,
        /// The special case can run the regular calculations, even if the triangle cannot exist. If it fails to calculate, and NaN appears,
        /// it won't make it to the regular screen because their is error checking that changes the InvalidTri boolean value to true should
        /// a triangle violate some rule. This prevents the user from recieving a triangle that cannot exist.
        /// </summary>
        private void tryCalcsSSA()
        {
            bringAnglesUp();
            if (s[0] != 0)
            {
                tmpAngle = a[0];
                tmpSide = s[0];
                bringSidesUp();
                tmpLarSide = s[0];
                SSASpecial();
            }
            else
            {
                SSANonSpecial();
            }

        }

        /// <summary>
        /// This is the special SSA triangle handler. It makes sure to define some variables that really don't matter to the user, but are
        /// needed to find the possible triangles. It relies on logic which leverages obtuse triangle cases and acute triangle cases to
        /// determine whether or not a triangle is possible based on those angles and some other factors. It does not build this second triangle,
        /// but it changes the triType val to 0 or 2 if the triangle is either not possible or more than one is possible respectively. TriType
        /// will eventually inspire a button to appear that allows users to toggle which triangle if there is 2 possible, or a notification that
        /// a triangle isn't possible if the triType is 0.
        /// </summary>
        private void SSASpecial()
        {
            double height, sup;
            SSANonSpecial();
            bringAnglesUp();
            findArea();

            height = (2 * Area) / s[0];
            sup = findSupplement();
            ObtuseAngle();
            AcuteAngle(height, sup);
        }

        /// <summary>
        /// Solves SSA triangles for both non-special cases, as well as special cases.
        /// </summary>
        public void SSANonSpecial()
        {
            bringSidesUp();
            AngleIndex();
            if (s[angleIndex] != 0)
            {
                if (s[(angleIndex + 1) % 3] != 0)
                {
                    a[(angleIndex + 1) % 3] = LawofSinAngle(s[angleIndex], s[(angleIndex + 1) % 3], a[angleIndex]);
                    a[(angleIndex + 2) % 3] = maxAngle - a[angleIndex] - a[(angleIndex + 1) % 3];
                }
                else
                {
                    a[(angleIndex + 2) % 3] = LawofSinAngle(s[angleIndex], s[(angleIndex + 2) % 3], a[angleIndex]);
                    a[(angleIndex + 1) % 3] = maxAngle - a[angleIndex] - a[(angleIndex + 2) % 3];
                }
                s[2] = LawofSinSide(s[0], a[0], a[2]);
            }
            else
            {
                s[angleIndex] = LawofCos(a[angleIndex], s[(angleIndex + 1) % 3], s[(angleIndex + 2) % 3]);
            }
            CalcSides();
        }

        /// <summary>
        /// Deals with SAA triangles and the calculations needed for them.
        /// </summary>
        private void tryCalcsSAA()
        {
            bringAnglesUp();
            // Checks for the missing angle.
            if (a[2] == 0)
            {
                a[2] = maxAngle - a[1] - a[0];
            }
            bringSidesUp();
            for (int i = 0; i < 3; i++)
            {
                if (s[i] == 0)
                {
                    s[i] = LawofSinSide(s[0], a[0], a[i]);
                }
            }
        }

        /// <summary>
        /// Area function specific to non-right triangles.
        /// </summary> 
        public override void findArea()
        {
            double angle = DegToRad(a[2]);
            angle = Math.Sin(angle);
            Area = (s[0] * s[1] * angle) / 2;
        }
        #endregion

        #region HelperFunctions
        /// <summary>
        /// Uses the rules surrounding acute angle SSA's of this type to determine if a triangle(s) is even possible.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="supplement"></param>
        private void AcuteAngle(double height, double supplement)
        {
            if (tmpSide < height)
            {
                Invalidate();
            }
            else if (tmpSide == height)
            {
                triType = 1;
            }
            else if (tmpSide > height && tmpSide > tmpLarSide)
            {
                triType = 1;
            }
            else if (tmpSide > height && tmpSide < tmpLarSide && 180 - supplement > 0)
            {
                triType = 2;
            }
            if (RightExists())
            {
                triType = 1;
            }
        }

        /// <summary>
        /// Uses Obtuse angle rules to determine if a triangle(s) is even possible.
        /// </summary>
        private void ObtuseAngle()
        {
            if (tmpAngle > 90 && tmpSide <= tmpLarSide)
            {
                Invalidate();
            }
            else if (tmpAngle > 90 && tmpSide > tmpLarSide)
            {
                triType = 1;
            }
        }

        /// <summary>
        /// Finds supplementary angle and returns it for use in determining triangle viability.
        /// </summary>
        /// <returns></returns>
        private double findSupplement()
        {
            double val = 180;
            for (int i = 0; i < 3; i++)
            {
                if (a[i] != tmpAngle && a[i] < 90)
                {
                    val = a[i];
                }
            }
            return val;
        }

        private bool RightExists()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Math.Round(a[i]) == 90)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Very similar to the update totals included for the right triangle, although it has no need of a right angle index.
        /// </summary>
        public void updateTotals()
        {
            totalSides = 0;
            totalAngles = 0;
            for (int j = 0; j < 3; j++)
            {
                if (a[j] != 0)
                {
                    totalAngles++;
                }
                if (s[j] != 0)
                {
                    totalSides++;
                }
            }
        }
        /// <summary>
        /// NonRight triangle implementation of bringSidesUp. Uses bubble sorting (due to small array size that will always be static) to put largest elements in front.
        /// </summary>
        public void bringSidesUp()
        {
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (s[j] < s[j + 1])
                    {
                        tmps = s[j];
                        tmpa = a[j];
                        s[j] = s[j + 1];
                        a[j] = a[j + 1];
                        s[j + 1] = tmps;
                        a[j + 1] = tmpa;
                    }
                }
            }
        }

        /// <summary>
        /// NonRight triangle implementation of bringAnglesUp. Uses bubble sorting (due to small array size that will always be static) to put largest elements in front.
        /// </summary>
        public void bringAnglesUp()
        {
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        tmps = s[j];
                        tmpa = a[j];
                        s[j] = s[j + 1];
                        a[j] = a[j + 1];
                        s[j + 1] = tmps;
                        a[j + 1] = tmpa;
                    }
                }
            }
        }
        /// <summary>
        /// Indexes the location of the angle for a SSA triangle to help the program choose a path.
        /// </summary>
        public void AngleIndex()
        {
            for (int i = 0; i < 3; i++)
            {
                if (a[i] != 0)
                {
                    angleIndex = i;
                }
            }

        }

        #endregion

        #region Validation
        /// <summary>
        /// Does some basic checks to determine whether or not the calculate triangle actually follows rules correctly,
        /// otherwise the user may have had an invalid triangle.
        /// </summary>
        public void InvalidCheck()
        {
            if (totalSides == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    // This is a rule in which 2 sides of a triangle added together must ALWAYS be larger than the remaining side.
                    if (s[i] > s[(i + 1) % 3] + s[(i + 2) % 3])
                    {
                        Invalidate();
                    }
                }
            }
            if (a[0] + a[1] + a[2] > 180)
            {
                Invalidate();
            }
            if (a.Contains(0) || s.Contains(0))
            {
                Invalidate();
            }
            for (int i = 0; i < len; i++)
            {
                if (double.IsNaN(a[i]) || double.IsNaN(s[i]))
                {
                    Invalidate();
                }
                if (s[i] > s[(i + 1) % 3] + s[(i + 2) % 3])
                {
                    Invalidate();
                }
            }
        }
        #endregion
    }
}
