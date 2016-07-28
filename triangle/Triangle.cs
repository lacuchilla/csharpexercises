using System;

namespace exercism.triangle
{
    public class TriangleException : Exception
    {
    }

    public enum TriangleKind
    {
        Equilateral,
        Isosceles,
        Scalene
    }

    public class Triangle
    {
        public static TriangleKind Kind(decimal a, decimal b, decimal c)
        {
            ValidateTriangle(a, b, c);
            if (a == b && a == c)
                return TriangleKind.Equilateral;

            if (a != b && a != c && b != c)
                return TriangleKind.Scalene;
            return TriangleKind.Isosceles;
        }

        private static void ValidateTriangle(decimal a, decimal b, decimal c)
        {
            CheckInequality(a, b, c);
            CheckInequality(a, c, b);
            CheckInequality(b, c, a);
        }

        private static void CheckInequality(decimal a, decimal b, decimal c)
        {
            if (a + b <= c)
                throw new TriangleException();
        }
    }
}