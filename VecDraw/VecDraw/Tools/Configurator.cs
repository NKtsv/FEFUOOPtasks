#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ColorPickerWPF;
using VecDraw.DrawTools;

#endregion

namespace VecDraw.Tools
{
    public static class Configurator
    {
        private const int FontSize = 12;
        public static double Thickness;
        public static Color Outline;
        public static Color Fill;
        public static DashStyle Style;
        public static readonly PenLineCap Cap;
        private static StackPanel _stackPanel;

        static Configurator()
        {
            Thickness = 1;
            Outline = Color.FromArgb(255, 0, 0, 0);
            Fill = Color.FromArgb(0, 0, 0, 0);
            Style = DashStyles.Solid;
            Cap = PenLineCap.Round;
        }

        public static StackPanel StackPanel
        {
            set
            {
                _stackPanel = value ?? throw new ArgumentNullException(nameof(value));
                Reconfigure();
            }
        }

        public static void Reconfigure()
        {
            _stackPanel.Children.Clear();
            if (ToolPicker.Tool == ToolPicker.DrawTools.HandTool ||
                ToolPicker.Tool == ToolPicker.DrawTools.ZoomTool)
                return;

            LineConfig(_stackPanel);
            if (ToolPicker.Tool == ToolPicker.DrawTools.RectangleTool ||
                ToolPicker.Tool == ToolPicker.DrawTools.EllipseTool ||
                ToolPicker.Tool == ToolPicker.DrawTools.PieTool)
                FilledConfig(_stackPanel);
        }

        private static void LineConfig(Panel stackPanel)
        {
            var thicknessLabel = new Label {Content = "Line thickness", FontSize = FontSize};
            var thicknessComboBox = new ComboBox();

            var thickness05Label = new Label {Content = "0.5", FontSize = FontSize};
            thicknessComboBox.Items.Add(thickness05Label);
            var thickness1Label = new Label {Content = "1", FontSize = FontSize};
            thicknessComboBox.Items.Add(thickness1Label);
            var thickness2Label = new Label {Content = "2", FontSize = FontSize};
            thicknessComboBox.Items.Add(thickness2Label);
            var thickness4Label = new Label {Content = "4", FontSize = FontSize};
            thicknessComboBox.Items.Add(thickness4Label);
            thicknessComboBox.SelectedIndex = 1;
            thicknessComboBox.SelectionChanged += LineThicknessChange;

            var styleLabel = new Label {Content = "Line style", FontSize = FontSize};
            var styleComboBox = new ComboBox();

            var dashButton = new Label {Content = "Dot", FontSize = FontSize};
            styleComboBox.Items.Add(dashButton);
            var dotLabel = new Label {Content = "Dash", FontSize = FontSize};
            styleComboBox.Items.Add(dotLabel);
            var solidLabel = new Label {Content = "Solid", FontSize = FontSize};
            styleComboBox.Items.Add(solidLabel);
            var dashDotLabel = new Label {Content = "DashDot", FontSize = FontSize};
            styleComboBox.Items.Add(dashDotLabel);
            var dashDotDotLabel = new Label {Content = "DashDotDot", FontSize = FontSize};
            styleComboBox.Items.Add(dashDotDotLabel);
            styleComboBox.SelectedIndex = 2;
            styleComboBox.SelectionChanged += LineStyleChange;

            var colorLabel = new Label {Content = "Line color", FontSize = FontSize};
            var colorButton = new Button {Background = new SolidColorBrush(Outline), Height = 22};
            colorButton.Click += OutlineColor_Click;

            stackPanel.Children.Add(thicknessLabel);
            stackPanel.Children.Add(thicknessComboBox);
            stackPanel.Children.Add(styleLabel);
            stackPanel.Children.Add(styleComboBox);
            stackPanel.Children.Add(colorLabel);
            stackPanel.Children.Add(colorButton);
        }

        private static void FilledConfig(Panel stackPanel)
        {
            var colorLabel = new Label {Content = "Fill color", FontSize = FontSize};
            var colorButton = new Button
                {Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)), Height = 22};
            colorButton.Click += FillColor_Click;

            stackPanel.Children.Add(colorLabel);
            stackPanel.Children.Add(colorButton);
        }

        private static void LineStyleChange(object sender, RoutedEventArgs e)
        {
            if (!(sender is ComboBox dashSelector)) return;

            Style = dashSelector.SelectedIndex switch
            {
                0 => DashStyles.Dot,
                1 => DashStyles.Dash,
                2 => DashStyles.Solid,
                3 => DashStyles.DashDot,
                4 => DashStyles.DashDotDot,
                _ => throw new ArgumentException(nameof(dashSelector))
            };
        }

        private static void OutlineColor_Click(object sender, RoutedEventArgs e)
        {
            if (!ColorPickerWindow.ShowDialog(out var color)) return;

            Outline = color;
            ((Button) sender).Background = new SolidColorBrush(color);
        }

        private static void FillColor_Click(object sender, RoutedEventArgs e)
        {
            if (!ColorPickerWindow.ShowDialog(out var color)) return;

            Fill = color;
            ((Button) sender).Background = new SolidColorBrush(color);
        }

        private static void LineThicknessChange(object sender, RoutedEventArgs e)
        {
            if (!(sender is ComboBox thicknessSelector)) return;

            Thickness = thicknessSelector.SelectedIndex switch
            {
                0 => 0.5,
                1 => 1,
                2 => 2,
                3 => 4,
                _ => throw new ArgumentException(nameof(thicknessSelector))
            };
        }
    }
}