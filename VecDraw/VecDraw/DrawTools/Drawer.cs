#region

using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VecDraw.Shapes;
using VecDraw.Tools;

#endregion

namespace VecDraw.DrawTools
{
    public class Drawer
    {
        public static readonly ShapeContainer ShapeContainer;
        public static ViewPort ViewPort;

        private readonly Dictionary<ToolPicker.DrawTools, Tool> _tools;
        private static bool _isMoved;
        private readonly VisualHost _visualHost;

        static Drawer()
        {
            ShapeContainer = new ShapeContainer();
            _isMoved = false;
            ViewPort = new ViewPort
            {
                X = 0,
                Y = 0,
                Scale = 1
            };
        }

        public Drawer()
        {
            _visualHost = new VisualHost();

            _tools = new Dictionary<ToolPicker.DrawTools, Tool>
            {
                {ToolPicker.DrawTools.PencilTool, new PencilTool()},
                {ToolPicker.DrawTools.LineTool, new LineTool()},
                {ToolPicker.DrawTools.RectangleTool, new RectangleTool()},
                {ToolPicker.DrawTools.EllipseTool, new EllipseTool()},
                {ToolPicker.DrawTools.PieTool, new PieTool()},
                {ToolPicker.DrawTools.HandTool, new HandTool()},
                {ToolPicker.DrawTools.ZoomTool, new ZoomTool()}
            };
        }

        public void MouseDown(Point startPoint, MouseButton mouseButton) =>
            _tools[ToolPicker.Tool].MouseDownHandler(startPoint, mouseButton);

        public void MouseMove(Point endPoint)
        {
            _isMoved = true;
            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                _tools[ToolPicker.Tool].MouseMoveHandler(dc, endPoint);
            }

            if (ToolPicker.Tool != ToolPicker.DrawTools.PencilTool)
                _visualHost.Redraw(ShapeContainer.GetShapesList());

            _visualHost.AddChild(dv);
        }

        public void MouseUp(Point endPoint)
        {
            if (!_isMoved && ToolPicker.Tool != ToolPicker.DrawTools.ZoomTool) return;

            _tools[ToolPicker.Tool].MouseUpHandler();

            _visualHost.Redraw(ShapeContainer.GetShapesList());

            _isMoved = false;
        }

        public VisualHost GetVisualHost() => _visualHost;

        public void RemoveLastShape()
        {
            ShapeContainer.RemoveLastShape();
            _visualHost.Redraw(ShapeContainer.GetShapesList());
        }

        public void ClearVisualHost()
        {
            ShapeContainer.Clear();
            _visualHost.Redraw(ShapeContainer.GetShapesList());
        }

        public void Save() => ShapeContainer.SaveShapes();

        public void Load()
        {
            ShapeContainer.LoadShapes();
            _visualHost.Redraw(ShapeContainer.GetShapesList());
        }
    }
}