using System;

namespace TriangleCalculator
{
    class RightTriangle : Triangle
    {
        private int rightIndex;
        public RightTriangle(double[] angles, double[] sides)
        {
            for (int i = 0; i < 3; i++)
            {
                s[i] = sides[i];
                a[i] = angles[i];
            }
            updateTotals();
            if (rightIndex != 2)
            {
                tmps = s[rightIndex];
                tmpa = a[rightIndex];
                s[rightIndex] = s[2];
                a[rightIndex] = a[2];
                s[2] = tmps;
                a[2] = tmpa;
            }
        }

        #region CalcSides
        /// <summary>
        /// Helper function that points the program in the direction in which it will find the triangle's answer (SSA or SAA).
        /// This is more specific to a right triangle, as a Non Right triangle has further possibilities (e.g SSS triangles).
        /// </summary>
        public override void CalcSides()
        {
            if (totalAngles >= 2)
            {
                tryCalcsSAA();
            }
            else if (totalSides >= 2)
            {
                tryCalcsSSA();
            }
            CheckValid();
        }
        /// <summary>
        /// Due to directionality mattering when using the law of sines (e.g what is opposite of what angle is crucial for real results), this function
        /// is recursive, and will continue to keep going until every side has a a value. It will recursively call itself each time it changes a value
        /// which ensures it will continue until every value has been found.
        /// </summary>
        private void tryCalcsSAA()
        {
            // Solves for bare minimum of a SAA triangle using trigonometric functions and rudimentary array sorting.
            if (totalAngles >= 2)
            {
                updateTotals();
                findThirdSAA();
                bringSidesUp();
                // If the bringSidesUp method could not bring anything up, and the element at 0 is a zero, then the only nonzero element is the opposing angle to 90 deg,
                // which is always stored at the final array index before the terminating character.
                if (s[0] == 0)
                {
                    s[0] = LawofSinSide(s[2], a[2], a[0]);
                    tryCalcsSAA();
                }
                // To reach this point, s[0] must've been a nonzero number, which means we can preform a tan operation to solve for this side.
                else if (s[1] == 0)
                {
                    s[1] = LawofSinSide(s[0], a[0], a[1]);
                    tryCalcsSAA();
                }
                // This is the final check to ensure that the hypotenuse has been found. At least two other sides should have been found at this point, so sin is leveraged
                // to find the final side if needed.
                else if (s[2] == 0)
                {
                    s[2] = LawofSinSide(s[0], a[0], a[2]);
                    tryCalcsSAA();
                }
            }
        }

        /// <summary>
        /// After getting the third side, this finds the remaining angles.
        /// </summary>
        private void tryCalcsSSA()
        {
            findThirdSSA();
            bringAnglesUp();
            for (int i = 0; i < 2; i++)
            {
                if (a[i] == 0)
                {
                    a[i] = Math.Round(RadToDeg((Math.Asin(s[i] / s[2]))), 2);
                }
            }
        }



        /// <summary>
        /// Looks for a third angle IF it hasn't already been found.
        /// </summary>
        private void findThirdSAA()
        {
            if (totalAngles != 3)
            {
                bringAnglesUp();
                a[1] = maxAngle - 90 - a[0];
                updateTotals();
            }
        }

        /// <summary>
        /// Looks for a third side IF it hasn't already been found
        /// </summary>
        private void findThirdSSA()
        {
            if (totalSides != 3)
            {
                bringSidesUp();
                if (s[1] == 0)
                {
                    s[1] = revPyth(s[2], s[0]);
                    updateTotals();
                }
                else
                {
                    s[2] = Pythagorean(s[0], s[1]);
                    updateTotals();
                }
            }
        }
        #endregion

        #region HelperFunctions
        /// <summary>
        /// Finds the area.
        /// </summary>
        public override void findArea()
        {
            this.Area = (s[0] * s[1]) / 2;
        }

        /// <summary>
        /// This function updates the total angles and sides. It has to differ from the non-right iteration because it must know the rightIndex.
        /// </summary>
        private void updateTotals()
        {
            totalSides = 0;
            totalAngles = 0;
            for (int j = 0; j < 3; j++)
            {
                if (a[j] != 0)
                {
                    totalAngles++;
                }
                if (a[j] == 90)
                {
                    rightIndex = j;
                }
                if (s[j] != 0)
                {
                    totalSides++;
                }
            }
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
        #endregion

        #region Validation
        /// <summary>
        /// This puts the triangle through some basic validity checks. While it is possible for a triangle to be calculated with most measurements,
        /// the resulting values can be invalid if they break certain rules. This means a calculable triangle is not necessarily a true triangle,
        /// and this should weed out those cases.
        /// </summary>
        private void CheckValid()
        {
            if (a[0] + a[1] + a[2] > maxAngle)
            {
                Invalidate();
            }
            for (int i = 0; i < 3; i++)
            {
                if (s[i] > s[(i + 1) % 3] + s[(i + 2) % 3])
                {
                    Invalidate();
                }
            }
        }
        #endregion
    }
}
