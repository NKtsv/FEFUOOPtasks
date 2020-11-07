#region

using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using VecDraw.DrawTools;

#endregion

namespace VecDraw.Shapes
{
    public class ShapeContainer
    {
        private List<Shape> _shapes;

        public ShapeContainer() => _shapes = new List<Shape>();

        public void AddShape(Shape shape) => _shapes.Add(shape);

        public List<Shape> GetShapesList() => _shapes;

        public void RemoveLastShape()
        {
            if (_shapes.Count == 0) return;

            _shapes.RemoveAt(_shapes.Count - 1);
        }

        public void Clear() => _shapes.Clear();

        public void ChangeViewPort(ViewPort viewPort)
        {
            foreach (var shape in _shapes)
            {
                shape.Refresh(viewPort);
            }
        }

        public void SaveShapes()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            using (var writer = new StreamWriter("save.xaml"))
            {
                xmlSerializer.Serialize(writer, _shapes);
            }
        }

        public void LoadShapes()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Shape>));
            using (var reader = new StreamReader("save.xaml"))
            {
                _shapes = (List<Shape>) xmlSerializer.Deserialize(reader);
            } 
        }
    }
}