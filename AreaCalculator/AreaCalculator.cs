namespace AreaCalculator
{
    public class InvalidInputE : Exception
    {
        public InvalidInputE(string message) : base(message) { }
    }

    public interface Figure
    {
        public string figureType { get; }

        public float[] edges { get; }

        public int edgesCount { get; }

        public float CalculateArea();
    }

    /// <summary>
    /// Class for work with triangle objects
    /// </summary>
    public class Triangle : Figure
    {
        public float[] edges { get; }
        public int edgesCount { get; }
        public string figureType { get; }

        /// <summary>
        /// Constructor for triangle object
        /// </summary>
        /// <param name="a">a side length</param>
        /// <param name="b">b side length</param>
        /// <param name="c">c side length</param>
        public Triangle(float a, float b, float c)
        {
            // Check correctly of input values
            if (a >= b+c ||
                b >= a+c ||
                c >= a+b ) throw new InvalidInputE("One side length can't be bigger that sum of other two sides");

            edgesCount = 3;
            edges = new float[3];
            edges[0] = a;
            edges[1] = b;
            edges[2] = c;
            figureType = "Triangle";
        }

        /// <summary>
        /// Calculate area of this triangle
        /// </summary>
        /// <returns>Area of triangle</returns>
        public float CalculateArea()
        {
            float p = (edges[0] + edges[1] + edges[2])/2; // Half-perimeter
            float s = (float)Math.Sqrt(p * (p - edges[0]) * (p - edges[1]) * (p - edges[2]));
            
            return s;
        }

        /// <summary>
        /// Check, is triangle rectangular
        /// </summary>
        /// <returns>true if triangle rectangular, false if not</returns>
        public bool IsRectangular()
        {
            // Checking by Pythagorean theorem
            float maxSide = edges[0];
            float legsSum = 0;

            // Finding max side of triangle
            foreach (float edge in edges) maxSide = maxSide > edge ? maxSide : edge;

            // Calculate sum of leg squares
            foreach (float edge in edges) if (edge != maxSide) legsSum += (float)Math.Pow(edge, 2);

            return ((float)Math.Pow(maxSide, 2) == legsSum);
        }
    }

    /// <summary>
    /// Class for work with circle objects
    /// </summary>
    public class Circle : Figure
    {
        public float[] edges { get; }
        public int edgesCount { get; }
        public string figureType { get; }

        private float pi = 3.14f;

        /// <summary>
        /// Constructor for circle object
        /// </summary>
        /// <param name="radius">Radius of circle</param>
        public Circle(float radius)
        {
            edgesCount = 1;
            edges = new float[1];
            edges[0] = radius;
            figureType = "Circle";
        }

        /// <summary>
        /// Calculate area of this circle
        /// </summary>
        /// <returns>Area of this triangle</returns>
        public float CalculateArea() => (float)(pi * Math.Pow(edges[0], 2));
    }
}