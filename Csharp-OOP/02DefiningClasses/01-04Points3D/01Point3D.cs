using System;

/*
 * Task 01:
 * Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
 * Implement the ToString() to enable printing a 3D point.
 * Task 02:
 * Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
 * Add a static property to return the point O.
*/

public struct Point3D
{
    private int x;
    private int y;
    private int z;
    private static readonly Point3D opoint = new Point3D(0, 0, 0);

    public Point3D(int x, int y, int z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public Point3D Opoint
    {
        get
        {
            return opoint;
        }
    }

    public override string ToString()
    {
        return String.Format("X position: {0} , Y position: {1} , Z position: {2}", this.X, this.Y, this.Z);
    }
}