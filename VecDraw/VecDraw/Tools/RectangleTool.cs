#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.DrawTools;
using VecDraw.Shapes;

#endregion

namespace VecDraw.Tools
{
    public class RectangleTool : Tool
    {
        private readonly Rectangle _rectangle;

        public RectangleTool()
        {
            _rectangle = new Rectangle();
        }

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDownHandler(startPoint, mouseButton);

            _rectangle.StartPoint = startPoint;
            _rectangle.Outline = Configurator.Outline;
            _rectangle.Thickness = Configurator.Thickness * Drawer.ViewPort.Scale;
            _rectangle.Style = Configurator.Style;
            _rectangle.Fill = Configurator.Fill;
        }

        public override void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {
            if (!ButtonPressed) return;

            _rectangle.EndPoint = endPoint;

            _rectangle.Draw(drawingContext);
        }

        public override void MouseUpHandler()
        {
            base.MouseUpHandler();

            Drawer.ShapeContainer.AddShape(_rectangle.Clone());
        }
    }
}