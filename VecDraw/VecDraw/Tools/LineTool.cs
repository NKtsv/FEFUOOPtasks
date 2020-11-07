#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.DrawTools;
using VecDraw.Shapes;

#endregion

namespace VecDraw.Tools
{
    public class LineTool : Tool
    {
        private readonly Line _line;

        public LineTool()
        {
            _line = new Line();
        }

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDownHandler(startPoint, mouseButton);

            _line.StartPoint = startPoint;
            _line.Outline = Configurator.Outline;
            _line.Thickness = Configurator.Thickness * Drawer.ViewPort.Scale;
            _line.Style = Configurator.Style;
        }

        public override void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {
            if (!ButtonPressed) return;

            _line.EndPoint = endPoint;

            _line.Draw(drawingContext);
        }

        public override void MouseUpHandler()
        {
            base.MouseUpHandler();

            Drawer.ShapeContainer.AddShape(_line.Clone());
        }
    }
}