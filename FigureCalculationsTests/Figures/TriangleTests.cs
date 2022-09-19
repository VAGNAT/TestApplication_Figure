using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FigureCalculations.Figures.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        #region DataForTests
        
        // <summary>
        /// Get data for constructor tests
        /// not exist triangle
        /// </summary>
        /// <returns>{sideA, sideB, sideC}</returns>
        private static IEnumerable<object[]> GetDataForConstructorTest()
        {
            yield return new object[] { 0, 1, 1 }; //first parameter is zero
            yield return new object[] { 1, 0, 1 }; //second parameter is zero
            yield return new object[] { 1, 1, 0 }; //third parameter is zero
            yield return new object[] { -1, 1, 1 }; //first parameter is less than zero
            yield return new object[] { 1, -1, 1 }; //second parameter is less than zero
            yield return new object[] { 1, 1, -1 }; //third parameter is less than zero
            yield return new object[] { 10, 2, 2 }; //sideA is greater than the sum of the others
            yield return new object[] { 2, 10, 2 }; //sideB is greater than the sum of the others
            yield return new object[] { 2, 2, 10 }; //sideC is greater than the sum of the others            
        }

        // <summary>
        /// Get data for area tests
        /// </summary>
        /// <returns>{sideA, sideB, sideC, expected area}</returns>
        private static IEnumerable<object[]> GetDataForAreaTest()
        {
            yield return new object[] { 1, 1, 1, 0.4330127018922193 };
            yield return new object[] { 3, 3, 3, 3.897114317029974 };
            yield return new object[] { 2.5, 1, 3, 1.1709371246996996 };
            yield return new object[] { 4.2, 1.5, 5.3, 2.3916521486202806 };
            yield return new object[] { 9.5, 21, 25.9, 93.44918619228314 };
            yield return new object[] { 10, 10, 12, 48 };
        }

        // <summary>
        /// Get data for name tests
        /// </summary>
        /// <returns>{sideA, sideB, sideC, expected area}</returns>
        private static IEnumerable<object[]> GetDataForNameTest()
        {
            yield return new object[] { 1, 1, 1, "equilateral" };
            yield return new object[] { 3, 3, 1, "isosceles" };
            yield return new object[] { 3, 2, 4, "versatile" };
            yield return new object[] { 2, 2, 3.5, "obtuse" };
            yield return new object[] { 3, 4, 5, "rectangular" };
        }
        #endregion

        [ExpectedException(typeof(ArgumentOutOfRangeException), "Exception was not thrown")]
        [DataTestMethod]
        [DynamicData(nameof(GetDataForConstructorTest), DynamicDataSourceType.Method)]
        public void Triangle_Constructor_Test(double sideA, double sideB, double sideC)
        {
            //act
            new Triangle(sideA, sideB, sideC);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDataForAreaTest), DynamicDataSourceType.Method)]
        public void GetShapeAreaTest(double sideA, double sideB, double sideC, double expectedArea)
        {
            //arange
            Shape triangle = new Triangle(sideA, sideB, sideC);

            //act
            double actualArea = triangle.GetShapeArea();

            //assert
            Assert.AreEqual(expectedArea, actualArea);
        }
        
        [DataTestMethod]
        [DynamicData(nameof(GetDataForNameTest), DynamicDataSourceType.Method)]
        public void Triangle_SetNameTest(double sideA, double sideB, double sideC, string expectedName)
        {
            //arange
            Shape triangle = new Triangle(sideA, sideB, sideC);            

            //act
            string? actualName = triangle.Name;
            
            //assert
            Assert.IsTrue(actualName?.Contains(expectedName));
        }
    }
}