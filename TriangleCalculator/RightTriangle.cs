using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    class RightTriangle : Triangle
    {
        private int rightIndex;
        private Double tmpa, tmps;
        public double[] a = new double[3];
        public double[] s = new double[3];

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
        }
        #region OLD_CALCS
        /*private void tryCalcs()
        {
            if (this.totalSides >= 2)
            {
                if (s[2] == 0)
                {
                    s[2] = Pythagorean(s[0], s[1]);
                    updateTotals();
                    tryCalcs();
                }
                if (s.Contains(0) && s[2] != 0)
                {
                    if (s[0] != 0)
                    {
                        nonZeroIndex = 0;
                        zeroIndex = 1;
                    }
                    else
                    {
                        nonZeroIndex = 1;
                        zeroIndex = 0;
                    }
                    s[zeroIndex] = revPyth(s[2], s[nonZeroIndex]);
                    updateTotals();
                    tryCalcs();
                }
                if (totalSides == 3 && totalAngles != 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (a[i] == 0 && i != 3)
                        {
                            a[i] = Math.Round(Math.Asin(s[i] / s[2]) * (180 / Math.PI), 2);
                        }
                    }
                }
            }
            if (this.totalAngles >= 2)
            {
                if (a.Contains(0))
                {
                    if (a[0] != 0 && a[1] == 0)
                    {
                        a[1] = maxAngle - a[0] - a[2];
                        updateTotals();
                        tryCalcs();
                    }
                    else if (a[0] == 0 && a[1] != 0)
                    {
                        a[0] = maxAngle - a[1] - a[2];
                        updateTotals();
                        tryCalcs();
                    }
                }
                if (s.Contains(0))
                {
                    // CASE IF: One side is zero but not the other.
                    if (s[0] != 0 && s[1] == 0)
                    {
                        s[1] = s[0] / Math.Tan(a[0]);
                        updateTotals();
                        tryCalcs();
                    }
                    if (s[0] != 0 && s[2] == 0)
                    {
                        s[2] = s[0] / Math.Sin(a[0]);
                        updateTotals();
                        tryCalcs();
                    }
                }
            }
        }*/

        //TEST CODE
        #endregion

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
        /// This method essenitally floats up the side that posesses value that isn't a hypotenuse to the user.
        /// It is used to help solve 2 angle problems by narrowing down what approach to take (whether it be sin or cosine.
        /// </summary>
        private void bringSidesUp()
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
        /// This method does the same as bringSidesUp, however it is used to help narrow down what angle needs to be filled out (with the exceptions of the right angle).
        /// It helps solve 2 side problems by narrowing down what approach should be taken.
        /// </summary>
        private void bringAnglesUp()
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
        public override void findArea()
        {
            this.Area = (s[0] * s[1]) / 2;
        }

        public override void perimeter()
        {
            this.Perimeter = s[0] + s[1] + s[2];
        }

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
    }
}
