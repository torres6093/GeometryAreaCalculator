using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAreaCalculator
{
    /// <summary>
    /// Base abstract class for all geometric shapes.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// An abstract method for calculating the area of any 2D shape.
        /// </summary>
        protected abstract double GetArea();
    }
}
