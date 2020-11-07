#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.DrawTools;
using VecDraw.Shapes;

#endregion

namespace VecDraw.Tools
{
    public class PieTool : Tool
    {
        private readonly Pie _pie;

        public PieTool()
        {
            _pie = new Pie();
        }

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDownHandler(startPoint, mouseButton);

            _pie.StartPoint = startPoint;
            _pie.Outline = Configurator.Outline;
            _pie.Thickness = Configurator.Thickness * Drawer.ViewPort.Scale;
            _pie.Style = Configurator.Style;
            _pie.Fill = Configurator.Fill;
        }

        public override void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {
            if (!ButtonPressed) return;

            _pie.EndPoint = endPoint;

            _pie.Draw(drawingContext);
        }

        public override void MouseUpHandler()
        {
            base.MouseUpHandler();

            Drawer.ShapeContainer.AddShape(_pie.Clone());
        }
    }
}