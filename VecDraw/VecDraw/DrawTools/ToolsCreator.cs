#region

using System;
using System.Windows;
using System.Windows.Controls;
using VecDraw.Tools;

#endregion

namespace VecDraw.DrawTools
{
    public static class ToolsCreator
    {
        private const int ToolsCount = 7;

        private static readonly ToolMethod[] ToolClick =
        {
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.PencilTool;
                Configurator.Reconfigure();
            },
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.LineTool;
                Configurator.Reconfigure();
            },
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.RectangleTool;
                Configurator.Reconfigure();
            },
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.EllipseTool;
                Configurator.Reconfigure();
            },
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.PieTool;
                Configurator.Reconfigure();
            },
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.HandTool;
                Configurator.Reconfigure();
            },
            (sender, args) =>
            {
                ToolPicker.Tool = ToolPicker.DrawTools.ZoomTool;
                Configurator.Reconfigure();
            }
        };

        private static readonly string[] Content =
            {"Pencil", "Line", "Rectangle", "Ellipse", "Pie", "Hand", "Zoom"};

        public static void ToolsCreate(StackPanel stackPanel)
        {
            if (stackPanel == null)
                throw new ArgumentNullException(nameof(stackPanel));

            for (var i = 0; i < ToolsCount; i++)
            {
                var button = new Button {Content = Content[i]};
                button.Click += new RoutedEventHandler(ToolClick[i]);
                stackPanel.Children.Add(button);
            }
        }

        private delegate void ToolMethod(object sender, RoutedEventArgs e);
    }
}