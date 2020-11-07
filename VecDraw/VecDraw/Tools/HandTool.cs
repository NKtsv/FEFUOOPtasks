#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.DrawTools;

#endregion

namespace VecDraw.Tools
{
    public class HandTool : Tool
    {
        private Point _lastPosition;

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            base.MouseDownHandler(startPoint, mouseButton);
            _lastPosition = startPoint;
        }

        public override void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {
            if (!ButtonPressed) return;

            var offset = new ViewPort
            {
                X = -(_lastPosition.X - endPoint.X),
                Y = -(_lastPosition.Y - endPoint.Y),
                Scale = 1
            };
            Drawer.ViewPort.X += offset.X;
            Drawer.ViewPort.Y += offset.Y;

            Drawer.ShapeContainer.ChangeViewPort(offset);

            _lastPosition = endPoint;
        }
    }
}