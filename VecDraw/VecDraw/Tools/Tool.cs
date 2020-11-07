#region

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

#endregion

namespace VecDraw.Tools
{
    public abstract class Tool
    {
        protected bool ButtonPressed;

        protected Tool()
        {
            ButtonPressed = false;
        }

        public virtual void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            ButtonPressed = true;
        }

        public virtual void MouseMoveHandler(DrawingContext drawingContext, Point endPoint)
        {

        }

        public virtual void MouseUpHandler()
        {
            ButtonPressed = false;
        }
    }
}