using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSPViolation;

namespace NoInheritence
{

    [TestClass]
    public class CalculateAreaTest
    {
        [TestMethod]
        public void SixFor2x3Rectange()
        {
            var myRectangle = new Rectangle { Height = 2, Width = 3 };
            Assert.AreEqual(6, myRectangle.Area());   
        }

        [TestMethod]
        public void NineFor3x3Squre()
        {
            var squre = new Squre { SideLength = 3 };
            Assert.AreEqual(9, squre.Area());
        }

        [TestMethod]
        public void TwentyFor4x5ShapeAnd9For3x3Squre()
        {
            var shapes = new List<Shape>
            {
                new Rectangle{Height = 4, Width = 5},
                new Squre{SideLength = 3}
            };

            var areas = new List<int>();

            #region problem
            //violate Open close principle
            //Enumerator should have same type
            //Casting is an overhead
            //Non substitutalbe code violate polymorphism
            //If you iterate in different object it will difficult to manage using if codition it is not correct also
            //Partially implemented base class can raise error             
            #endregion
          
            foreach (Shape shape in shapes)
            {
                if (shape.GetType() == typeof(Rectangle)) //Enumerator should have same type
                {
                    areas.Add(((Rectangle)shape).Area()); //Casting is an overhead
                }
                if (shape.GetType() == typeof(Squre))
                {
                    areas.Add(((Squre)shape).Area());
                }
            }

            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);


        }

    }

   

    public abstract class Shape
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class Squre : Shape
    {
        public int SideLength;
        public int Area()
        {
            return SideLength * SideLength;
        }
    }


    /// <summary>
    /// 
    /// </summary>

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Area()
        {
           // return 6;
            return Height * Width;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Triangle : Shape
    {
        public int Base;
        public int Height;

        public double Area()
        {
            // return 6;
            return 0.5 * Base * Height;
        }
    }
}
