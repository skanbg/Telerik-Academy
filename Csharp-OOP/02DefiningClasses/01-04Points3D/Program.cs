using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        //Creating the first point
        Point3D firstPoint = new Point3D(1, 2, 3);
        //Printing the first point info
        Console.WriteLine(firstPoint.ToString());

        //Printing the static info about Point O
        Console.WriteLine(firstPoint.Opoint.ToString());

        //Calculating Distance between the first point and point O
        Console.WriteLine(DistanceIn3D.CalculateDistance(firstPoint, firstPoint.Opoint));

        //Creating new Path and adding Points
        Path newPath = new Path();
        newPath.AddPoint(firstPoint);
        newPath.AddPoint(firstPoint.Opoint);
        newPath.AddPoint(firstPoint);
        newPath.AddPoint(firstPoint.Opoint);

        List<Point3D> loadedPath = PathStorage.LoadPathFromFile().ReturnPath();
        foreach (Point3D point in loadedPath)
        {
            Console.WriteLine(point.ToString());
        }
    }
}
