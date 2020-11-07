#region

using System.Windows.Media;
using VecDraw.DrawTools;
using VecDraw.Tools;

#endregion

namespace VecDraw.Shapes
{
    public class Line : Shape
    {
        public override void Draw(DrawingContext drawingContext)
        {
            var pen = new Pen(new SolidColorBrush(Outline), Thickness)
                {DashCap = Configurator.Cap, DashStyle = Style};

            drawingContext.DrawLine(pen, StartPoint, EndPoint);
        }
    }
}