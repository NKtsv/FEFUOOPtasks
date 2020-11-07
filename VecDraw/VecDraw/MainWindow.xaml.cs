#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VecDraw.DrawTools;
using VecDraw.Tools;

#endregion

namespace VecDraw
{
    public partial class MainWindow
    {
        public static Canvas Canv;
        private readonly Drawer _drawer;

        public MainWindow()
        {
            InitializeComponent();

            Canv = DrawablePanel;

            ToolPicker.Tool = ToolPicker.DrawTools.LineTool;
            ToolsCreator.ToolsCreate(StackPanelTools);

            Configurator.StackPanel = StackPanelProperty;

            _drawer = new Drawer();

            DrawablePanel.Children.Add(_drawer.GetVisualHost());
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startPoint = e.GetPosition(DrawablePanel);

            if (e.LeftButton == MouseButtonState.Pressed)
                _drawer.MouseDown(startPoint, MouseButton.Left);
            else if (e.RightButton == MouseButtonState.Pressed)
                _drawer.MouseDown(startPoint, MouseButton.Right);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;

            var endPoint = e.GetPosition(DrawablePanel);
            _drawer.MouseMove(endPoint);
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        //=> _drawer.MouseUp();
        {
            var endPoint = e.GetPosition(DrawablePanel);
            _drawer.MouseUp(endPoint);
        }

        private void Back_Click(object sender, RoutedEventArgs e) => _drawer.RemoveLastShape();

        private void Clear_Click(object sender, RoutedEventArgs e) => _drawer.ClearVisualHost();

        private void Save_Click(object sender, RoutedEventArgs e) => _drawer.Save();

        private void Load_Click(object sender, RoutedEventArgs e) => _drawer.Load();
    }
}