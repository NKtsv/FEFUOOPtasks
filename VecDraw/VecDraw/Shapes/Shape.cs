#region

using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using VecDraw.DrawTools;

#endregion

namespace VecDraw.Shapes
{
    [XmlInclude(typeof(Pencil))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Ellipse))]
    [XmlInclude(typeof(Pie))]
    [Serializable]

    public abstract class Shape
    {
        public Color Outline;

        protected Shape()
        {
            StartPoint = new Point(-1, -1);
            EndPoint = new Point(-1, -1);
            Outline = Color.FromRgb(0, 0, 0);
            Thickness = 1;
        }

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public double Thickness { get; set; }

        public DashStyle Style { get; set; }

        public abstract void Draw(DrawingContext drawingContext);

        public virtual Shape Clone() => (Shape) MemberwiseClone();

        public virtual void Refresh(ViewPort viewPort)
        {
            this.StartPoint = new Point
            {
                X = this.StartPoint.X * viewPort.Scale + viewPort.X,
                Y = this.StartPoint.Y * viewPort.Scale + viewPort.Y
            };

            this.EndPoint = new Point
            {
                X = this.EndPoint.X * viewPort.Scale + viewPort.X,
                Y = this.EndPoint.Y * viewPort.Scale + viewPort.Y
            };

            this.Thickness *= viewPort.Scale;
        }

        protected void RoundPoints()
        {
            var start = new Point
            {
                X = Math.Round(StartPoint.X - Drawer.ViewPort.X, 3),
                Y = Math.Round(StartPoint.Y - Drawer.ViewPort.Y, 3)
            };
            var end = new Point
            {
                X = Math.Round(EndPoint.X - Drawer.ViewPort.X, 3),
                Y = Math.Round(EndPoint.Y - Drawer.ViewPort.Y, 3)
            };

            StartPoint = start;
            EndPoint = end;
        }
    }
}