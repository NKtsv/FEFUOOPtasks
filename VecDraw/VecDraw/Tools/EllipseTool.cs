#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.DrawTools;
using VecDraw.Shapes;

#endregion

namespace VecDraw.Tools
{
    public class EllipseTool : Tool
    {
        private readonly Ellipse _ellipse;

        public EllipseTool()
        {
            _ellipse = new Ellipse();
        }

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDownHandler(startPoint, mouseButton);

            _ellipse.StartPoint = startPoint;
            _ellipse.Outline = Configurator.Outline;
            _ellipse.Thickness = Configurator.Thickness * Drawer.ViewPort.Scale;
            _ellipse.Style = Configurator.Style;
            _ellipse.Fill = Configurator.Fill;
        }

        public override void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {
            if (!ButtonPressed) return;

            _ellipse.EndPoint = endPoint;

            _ellipse.Draw(drawingContext);
        }

        public override void MouseUpHandler()
        {
            base.MouseUpHandler();

            Drawer.ShapeContainer.AddShape(_ellipse.Clone());
        }
    }
}