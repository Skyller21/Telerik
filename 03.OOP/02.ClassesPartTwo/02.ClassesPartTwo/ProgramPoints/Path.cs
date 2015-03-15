namespace ProgramPoints
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        public List<Point3D> Points { get; set; }

        public int PathLength
        {
            get { return this.Points.Count; }
        }

        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public Point3D this[int index]
        {
            get
            {
                if (index >= 0 && index < this.PathLength)
                {
                    return this.Points[index];
                }
                else { throw new ArgumentOutOfRangeException("The index is out of the boundaries of the PATH"); }
            }
            set
            {
                if (index >= 0 && index < this.PathLength)
                {
                    this.Points[index] = value;
                }
                else { throw new ArgumentOutOfRangeException("The index is out of the boundaries of the PATH"); }
            }
        }
        public void Add(Point3D point)
        {
            this.Points.Add(point);

        }
        public void AddMultiple(params Point3D[] points)
        {
            this.Points.AddRange(points);
        }

        public void Remove(Point3D point)
        {
            this.Points.Remove(point);
        }

        public void RemoveAt(int index)
        {
            this.Points.RemoveAt(index);
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, this.Points);
        }
    }
}