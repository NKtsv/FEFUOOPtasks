#region

using System.Windows;
using System.Windows.Media;
using VecDraw.Tools;

#endregion

namespace VecDraw.Shapes
{
    public class Rectangle : FillShape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var rect = new Rect(StartPoint, EndPoint);

            var pen = new Pen(new SolidColorBrush(Outline), Thickness)
                {DashCap = Configurator.Cap, DashStyle = Style};

            drawingContext.DrawRectangle(new SolidColorBrush(Fill), pen, rect);
        }
    }
}