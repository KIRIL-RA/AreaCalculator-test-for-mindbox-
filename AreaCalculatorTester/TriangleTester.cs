namespace AreaCalculatorTester;

[TestClass]
public class TriangleTester
{
    [TestMethod]
    public void ExceptionTest()
    {
        Triangle triangleTest;
        try
        {
            triangleTest = new Triangle(2, 2, 5);
            // If exception not implemented, test failed
            Assert.Fail();
        }

        catch (InvalidInputE) {
        }
    }

    [TestMethod]
    public void CalculatorTester()
    {
        Triangle triangleTest = new Triangle(3,4,5);
        Assert.AreEqual(triangleTest.CalculateArea(), 6.0);
    }

    [TestMethod]
    public void IsRectangularTester()
    {
        Triangle triangleTest = new Triangle(3, 4, 5);
        Assert.AreEqual(triangleTest.IsRight(), true);
    }

    [TestMethod]
    public void IsNotRectangularTester()
    {
        Triangle triangleTest = new Triangle(3, 4, 6);
        Assert.AreEqual(triangleTest.IsRight(), false);
    }
}
