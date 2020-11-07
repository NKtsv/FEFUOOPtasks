#region

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using VecDraw.DrawTools;
using VecDraw.Tools;

#endregion

namespace VecDraw.Shapes
{
    public class Pencil : Line
    {
        private Pen _pen;

        public Pencil()
        {
            Points = new List<Point>();
        }

        [field: XmlElement] public List<Point> Points { get; set; }

        public override void Draw(DrawingContext drawingContext)
        {
            _pen = new Pen
            {
                Brush = new SolidColorBrush(Outline),
                Thickness = Thickness,
                DashCap = PenLineCap.Round,
                DashStyle = DashStyles.Solid
            };

            for (var i = 0; i < Points.Count - 1; i++) drawingContext.DrawLine(_pen, Points[i], Points[i + 1]);
        }

        public void StartDraw(Point startPoint)
        {
            _pen = new Pen
            {
                Brush = new SolidColorBrush(Outline),
                Thickness = Thickness,
                DashCap = Configurator.Cap,
                DashStyle = Configurator.Style
            };

            Points.Clear();
            Points.Add(startPoint);
        }

        public void AddLine(DrawingContext drawingContext, Point endPoint)
        {
            Points.Add(endPoint);

            drawingContext.DrawLine(_pen, Points[^2], Points[^1]);
        }

        public override void Refresh(DrawTools.ViewPort viewPort)
        {
            for(var i = 0; i < Points.Count; i++)
            {
                Point buffer;
                buffer = Points[i];
                buffer.X = buffer.X * viewPort.Scale + viewPort.X;
                buffer.Y = buffer.Y * viewPort.Scale + viewPort.Y;
                Points[i] = buffer;
            }

            this.Thickness *= viewPort.Scale;
        }

        public override Shape Clone()
        {
            return new Pencil
            {
                Outline = Outline,
                Thickness = Thickness,
                Points = new List<Point>(Points)
            };
        }
    }
}