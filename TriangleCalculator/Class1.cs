using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculator
{
    abstract class Triangle
    {
        public abstract double findArea();
        public abstract double perimeter();
        public abstract double CalcSides();

        public double LawofCos()
        {
            throw new NotImplementedException();
        }

        public double LawofSin()
        {
            throw new NotImplementedException();
        }
    }
}
