#region

using System.Windows;
using System.Windows.Media;
using VecDraw.Tools;

#endregion

namespace VecDraw.Shapes
{
    public class Ellipse : FillShape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var center = new Point
            {
                X = StartPoint.X + (EndPoint.X - StartPoint.X) / 2,
                Y = StartPoint.Y + (EndPoint.Y - StartPoint.Y) / 2
            };

            var radiusX = EndPoint.X - center.X;
            var radiusY = EndPoint.Y - center.Y;

            var pen = new Pen(new SolidColorBrush(Outline), Thickness)
                {DashCap = Configurator.Cap, DashStyle = Style};
            drawingContext.DrawEllipse(new SolidColorBrush(Fill), pen, center, radiusX, radiusY);
        }
    }
}