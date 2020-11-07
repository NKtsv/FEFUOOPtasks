#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.DrawTools;
using VecDraw.Shapes;

#endregion

namespace VecDraw.Tools
{
    public class PencilTool : Tool
    {
        private readonly Pencil _pencil;

        public PencilTool() => _pencil = new Pencil();

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDownHandler(startPoint, mouseButton);

            _pencil.Outline = Configurator.Outline;
            _pencil.Thickness = Configurator.Thickness * Drawer.ViewPort.Scale;
            _pencil.StartDraw(startPoint);
        }

        public override void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {
            if (!ButtonPressed) return;

            _pencil.AddLine(drawingContext, endPoint);
        }

        public override void MouseUpHandler()
        {
            base.MouseUpHandler();

            Drawer.ShapeContainer.AddShape(_pencil.Clone());
        }
    }
}