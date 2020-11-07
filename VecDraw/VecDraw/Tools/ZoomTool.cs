#region

using System;
using System.Windows;
using System.Windows.Input;
using VecDraw.DrawTools;

#endregion

namespace VecDraw.Tools
{
    public class ZoomTool : Tool
    {
        private MouseButton _mouseButton;
        private Point _startPoint;

        public override void MouseDownHandler(Point startPoint, MouseButton mouseButton)
        {
            _startPoint = startPoint;
            _mouseButton = mouseButton;
        }

        public override void MouseUpHandler()
        {
            if (_mouseButton == MouseButton.Left)
                Left_Click(_startPoint);
            else if (_mouseButton == MouseButton.Right) 
                Right_Click(_startPoint);
        }

        private void Left_Click(Point startPoint)
        {
            if (Drawer.ViewPort.Scale * 2 > 16) return;

            Drawer.ViewPort.Scale *= 2;

            var vp = new ViewPort
            {
                X = startPoint.X - MainWindow.Canv.ActualWidth / 16,
                Y = startPoint.Y - MainWindow.Canv.ActualHeight /  16,
                Scale = 2
            };

            vp.X = -Math.Abs(vp.X);
            vp.Y = -Math.Abs(vp.Y);

            Drawer.ShapeContainer.ChangeViewPort(vp);
        }

        private void Right_Click(Point startPoint)
        {
            if (Drawer.ViewPort.Scale / 2 < 0.25) return;

            Drawer.ViewPort.Scale /= 2;

            var vp = new ViewPort
            {
                X = startPoint.X - MainWindow.Canv.ActualWidth / 4,
                Y = startPoint.Y - MainWindow.Canv.ActualHeight / 4,
                Scale = 0.5
            };

            vp.X = Math.Abs(vp.X);
            vp.Y = Math.Abs(vp.Y);

            Drawer.ShapeContainer.ChangeViewPort(vp);
        }
    }
}