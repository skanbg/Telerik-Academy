using System;

public static class DistanceIn3D
{
    public static double CalculateDistance(Point3D pointOne, Point3D pointTwo)
    {
        return Math.Sqrt(Math.Pow(pointOne.X - pointTwo.X, 2) + Math.Pow(pointOne.Y - pointTwo.Y, 2) + Math.Pow(pointOne.Z - pointTwo.Z, 2));
    }
}