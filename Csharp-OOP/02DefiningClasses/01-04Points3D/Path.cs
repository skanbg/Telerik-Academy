using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Path
{
    private List<Point3D> pathOfPoints = new List<Point3D>();
    public void AddPoint(Point3D pointToAdd)
    {
        pathOfPoints.Add(pointToAdd);
    }
    public List<Point3D> ReturnPath()
    {
        return pathOfPoints;
    }
}