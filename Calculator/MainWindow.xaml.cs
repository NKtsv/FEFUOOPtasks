using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{   
    
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Font_Check()
        {
            if (SubWindow.Text.Length >= 49)
                SubWindow.Text = SubWindow.Text.Substring(SubWindow.Text.Length - 49);
            if (Window.Text.Length >= 10)
                Window.FontSize = 745 / Window.Text.Length;
            else
                Window.FontSize = 80;
        }
        bool IsExitButtonOut = false;
        
        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            string Help = "Программа \"Калькулятор\"\n\n- клавиши с цифрами нужны для ввода числа\n- клавиши со знаками нужны для выполнения действий с числами\n- клавиша \"=\" используется для вывода результата на экран\n- клавиша\"CE\" используется для удаления раннее введенных данных";
            MessageBox.Show(Help,"Справка");
        }
        private void Button_Click_About(object sender, RoutedEventArgs e)
        {
            string About = "Программа \"Калькулятор\" Версия 1.0\nНаписана NKtsv в 2020 году\nКривая и косая, но автор старался\nПрава не защищены";
            MessageBox.Show(About, "О программе");
        }
        private void Button_Click_Menu(object sender, RoutedEventArgs e)
        {
            if (!IsExitButtonOut)
            {
                ExitButton.Visibility = Visibility.Visible;
                IsExitButtonOut = true;
            }
            else
            {
                ExitButton.Visibility = Visibility.Hidden;
                IsExitButtonOut = false;
            }
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void Digit_Button_Click(string digit)
        {
            if (IsElementIn == false)
            {
                Window.Text = $"{digit}";
                IsElementIn = true;
            }
            else
            {
                if (Window.Text.Length < 16)
                {
                    Window.Text += $"{digit}";
                    IsElementIn = true;
                }
            }
            Font_Check();
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (Window.Text != "0")
                Digit_Button_Click("0");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
              Digit_Button_Click("1");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("2");
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("3");
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("4");
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("5");
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("6");
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("7");
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("8");
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Digit_Button_Click("9");
        }

        int Sign;
        bool IsFEIn = false;
        string FirstElement, SecondElement;
        bool IsElementIn;

        public void Counting()
        {
            if (IsFEIn == false) 
            {
                FirstElement = Window.Text;
                if (FirstElement.Contains("Деление на ноль невозможно"))
                    FirstElement = "0";
                SubWindow.Text = FirstElement;
                IsFEIn = true;              
            }         

            SecondElement = Window.Text;
            if (Sign != 0)
                SubWindow.Text += SecondElement;

            switch (Sign)
            {
                case 1:
                    FirstElement = Convert.ToString(Convert.ToDouble(FirstElement) + Convert.ToDouble(SecondElement));
                    break;
                case 2:
                    FirstElement = Convert.ToString(Convert.ToDouble(FirstElement) - Convert.ToDouble(SecondElement));
                    break;
                case 3:
                    FirstElement = Convert.ToString(Convert.ToDouble(FirstElement) * Convert.ToDouble(SecondElement));
                    break;
                case 4:
                    if (SecondElement == "0")
                    {
                        FirstElement = "Деление на ноль невозможно";
                    }
                    else                    
                        FirstElement = Convert.ToString(Convert.ToDouble(FirstElement) / Convert.ToDouble(SecondElement));                   
                    break;
            }
        }
        public void Operator_Button_Click(int op) 
        {            
            Counting();
            
            switch (op)
            {
                case 1:
                    SubWindow.Text += " + ";
                    break;
                case 2:
                    SubWindow.Text += " - ";
                    break;
                case 3:
                    SubWindow.Text += " * ";
                    break;
                case 4:
                    SubWindow.Text += " / ";
                    break;
            }   
            
            Sign = op;            
            Window.Text = FirstElement;
            Font_Check();
            IsElementIn = false;
        }
        private void Button_Click_Sum(object sender, RoutedEventArgs e)
        {
            Operator_Button_Click(1);
        }
        private void Button_Click_Sub(object sender, RoutedEventArgs e)
        {
            Operator_Button_Click(2);
        }
        private void Button_Click_Mul(object sender, RoutedEventArgs e)
        {
            Operator_Button_Click(3);
        }
        private void Button_Click_Div(object sender, RoutedEventArgs e)
        {
            Operator_Button_Click(4);
        }
        public void Erase()
        {
            FirstElement = "0";
            SecondElement = "0";
            Window.FontSize = 80;
            IsElementIn = false;
            IsFEIn = false;
            Sign = 0;
        }
        private void Button_Click_Ers(object sender, RoutedEventArgs e)
        {
            Window.Text = "0";
            SubWindow.Text = "";
            Erase();
        }
        private void Button_Click_Eqv(object sender, RoutedEventArgs e)
        {
            Counting();
            SubWindow.Text += " =";
            Window.Text = FirstElement;
            Erase();
            Font_Check();           
        }
    }
}
           