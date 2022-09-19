using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureCalculations.Figures.Tests
{
    [TestClass()]
    public class CircleTests
    {
        /// <summary>
        /// Get data for tests
        /// </summary>
        /// <returns>{radius, expected area}</returns>
        private static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, 3.141592653589793 };
            yield return new object[] { 2.5, 19.634954084936208 };
            yield return new object[] { 3.2, 32.169908772759484 };
            yield return new object[] { 5, 78.53981633974483 };
            yield return new object[] { 10, 314.1592653589793 };
        }

        #region ConstructorTest

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception was not thrown")]
        public void Circle_Constructour_parameter_zero()
        {
            //act
            new Circle(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception was not thrown")]
        public void Circle_Constructour_parameter_less_than_zero()
        {
            //act
            new Circle(-1);
        }

        #endregion

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Circle_GetShapeArea(double radius, double expectedArea)
        {
            //arange
            Shape circle = new Circle(radius);

            //act
            double actualArea = circle.GetShapeArea();

            //assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Circle_SetNameTest(double radius, double _)
        {
            //arange
            Shape circle = new Circle(radius);

            //act
            string? actualName = circle.Name;

            //assert
            Assert.IsTrue(actualName?.Contains("Circle"));
        }
    }
}