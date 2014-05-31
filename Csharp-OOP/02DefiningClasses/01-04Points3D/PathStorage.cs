using System;
using System.Text;
using System.IO;
using System.Security;

public static class PathStorage
{
    private const string filePath = "paths.txt";
    public static void WritePathIntoFile(Path pathToWrite)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            StringBuilder outputText = new StringBuilder();
            foreach (var point in pathToWrite.ReturnPath())
            {
                outputText.AppendFormat("{0},{1},{2}{3}", point.X, point.Y, point.Z, Environment.NewLine);
            }
            writer.Write(outputText);
        }
    }

    public static Path LoadPathFromFile()
    {
        Path bufferPath = new Path();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string currentLine;
            while ((currentLine = reader.ReadLine()) != null)
            {
                string[] points = currentLine.Split(',');
                Point3D bufferPoint = new Point3D();
                bufferPoint.X = int.Parse(points[0]);
                bufferPoint.Y = int.Parse(points[1]);
                bufferPoint.Z = int.Parse(points[2]);
                bufferPath.AddPoint(bufferPoint);
            }
        }
        return bufferPath;
    }
}