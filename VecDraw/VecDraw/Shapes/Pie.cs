#region

using System;
using System.Windows;
using System.Windows.Media;
using VecDraw.Tools;

#endregion

namespace VecDraw.Shapes
{
    public class Pie : FillShape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var geometry = new PathGeometry();
            var radius = Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2));
            var figure = new PathFigure {StartPoint = new Point {X = StartPoint.X, Y = StartPoint.Y - radius}};

            var vLine = new LineSegment {Point = StartPoint};
            var hLine = new LineSegment {Point = EndPoint};

            var largeArc = EndPoint.X < StartPoint.X;

            var arc = new ArcSegment
                {Point = figure.StartPoint, Size = new Size(radius, radius), IsLargeArc = largeArc};

            figure.Segments.Add(vLine);
            figure.Segments.Add(hLine);
            figure.Segments.Add(arc);
            figure.IsFilled = true;

            geometry.Figures.Add(figure);

            var pen = new Pen(new SolidColorBrush(Outline), Thickness)
                {DashCap = Configurator.Cap, DashStyle = Style};

            drawingContext.DrawGeometry(new SolidColorBrush(Fill), pen, geometry);
        }
    }
}