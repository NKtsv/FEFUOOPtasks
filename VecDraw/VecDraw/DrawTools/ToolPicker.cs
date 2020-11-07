namespace VecDraw.DrawTools
{
    public static class ToolPicker
    {
        public enum DrawTools
        {
            PencilTool = 0,
            LineTool = 1,
            RectangleTool = 2,
            EllipseTool = 3,
            PieTool = 4,
            HandTool = 5,
            ZoomTool = 6,
            None = 99
        }
        public static DrawTools Tool = DrawTools.None;
    }
}