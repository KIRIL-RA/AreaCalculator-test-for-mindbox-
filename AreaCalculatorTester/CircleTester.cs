namespace AreaCalculatorTester;

[TestClass]
public class CircleTester
{
	[TestMethod]
	public void CalculatorTester()
	{
		Circle testCircle = new Circle(2);
		Assert.AreEqual(testCircle.CalculateArea(), 12.56f);
	}
}

