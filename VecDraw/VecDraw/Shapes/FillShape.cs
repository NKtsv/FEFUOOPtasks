#region

using System.Windows.Media;

#endregion

namespace VecDraw.Shapes
{
    public abstract class FillShape : Shape
    {
        public Color Fill { get; set; }
    }
}