using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private TextBlock _mainText;
        private Border _window;

        private string _action;

        private float _firstValue;
        private float _secondValue;
        private float _result;

        private bool _canType = true;

        private Printer _printer = new Printer();

        public void UpdateMainText() 
        {
            _mainText.Text = _printer.MainString;
        }

        public MainWindow()
        {
            InitializeComponent();
            _mainText = FindName("MainText") as TextBlock;
            _window = FindName("Window") as Border;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception _exception)
            {
                MessageBox.Show(_exception.Message);
            }
        }

        private void AddZero(object sender, RoutedEventArgs e)
        {
            if (_mainText.Text == "") 
            {
                _printer.Print("0");

                UpdateMainText();
            }
            else if (_canType)
            {
                if (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(","))
                {
                    _printer.AddText("0");

                    UpdateMainText();
                }
            }
            else if (!_canType)
            {
                if (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(","))
                {
                    _printer.Print("0");

                    UpdateMainText();
                }
                _canType = true;
            }
        }

        private void AddDot(object sender, RoutedEventArgs e)
        {
            if (_canType)
            {
                if (!_mainText.Text.Contains(","))
                {
                    _printer.AddText(",");

                    UpdateMainText();
                }
            }
            else if (!_canType)
            {
                if (!_mainText.Text.Contains(","))
                {
                    _printer.AddText(",");

                    UpdateMainText();
                }
            }
        }

        private void CalculateResult(object sender, RoutedEventArgs e)
        {
            if (_canType)
            {
                _secondValue = float.Parse(_mainText.Text);
                switch (_action)
                {
                    case "Add":
                        _result = Clk.Add(_firstValue, _secondValue);
                        _printer.PrintResult(_result);

                        UpdateMainText();
                        break;

                    case "Substract":
                        _result = Clk.Substract(_firstValue, _secondValue);
                        _printer.PrintResult(_result);

                        UpdateMainText();
                        break;

                    case "Increase":
                        _result = Clk.Increase(_firstValue, _secondValue);
                        _printer.PrintResult(_result);

                        UpdateMainText();
                        break;

                    case "Divide":
                        if (_firstValue != 0f && _secondValue != 0f)
                        {
                            _result = Clk.Divide(_firstValue, _secondValue);
                            _printer.PrintResult(_result);

                            UpdateMainText();
                        }
                        else
                        {
                            _printer.Print("Cant divide by 0");
                            _canType = false;

                            UpdateMainText();
                        }
                        break;
                }
            }
        }

        private void SetAction(string action)
        {
            if (_canType)
            {
                _firstValue = float.Parse(_mainText.Text);
                _printer.Print("");
                _action = action;

                UpdateMainText();
            }
        }

        private void SetActionAdd(object sender, RoutedEventArgs e)
        {
            SetAction("Add");
        }

        private void SetActionSubstract(object sender, RoutedEventArgs e)
        {
            SetAction("Substract");
        }

        private void SetActionIncrease(object sender, RoutedEventArgs e)
        {
            SetAction("Increase");
        }

        private void SetActionDivide(object sender, RoutedEventArgs e)
        {
            SetAction("Divide");
        }

        private void SetActionPercent(object sender, RoutedEventArgs e)
        {
            _firstValue = float.Parse(_mainText.Text);
            _result = Clk.Percent(_firstValue);
            _printer.PrintResult(_result);

            UpdateMainText();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            _printer.Print("");

            UpdateMainText();
        }

        private void Revert(object sender, RoutedEventArgs e)
        {
            if (_mainText.Text != "" && _canType && float.Parse(_mainText.Text) != 0f)
            {
                if (!_mainText.Text.Contains("-"))
                {
                    _printer.Print("-" + _mainText.Text);

                    UpdateMainText();
                }
                else
                {
                    _printer.Print(_mainText.Text.Substring(1));

                    UpdateMainText();
                }
            }
        }

        private void AddNum(string num)
        {
            if (_mainText.Text != "")
            {
                if (_canType && (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(",")))
                {
                    _printer.AddText(num);

                    UpdateMainText();
                }
                else if (!_canType || (float.Parse(_mainText.Text) == 0f && !_mainText.Text.Contains(",")))
                {
                    _printer.Print(num);
                    _canType = true;

                    UpdateMainText();
                }
            }
            else
            {
                _printer.Print(num);

                UpdateMainText();
            }
        }

        private void AddOne(object sender, RoutedEventArgs e)
        {
            AddNum("1");
        }

        private void AddTwo(object sender, RoutedEventArgs e)
        {
            AddNum("2");
        }

        private void AddThree(object sender, RoutedEventArgs e)
        {
            AddNum("3");
        }

        private void AddFour(object sender, RoutedEventArgs e)
        {
            AddNum("4");
        }

        private void AddFive(object sender, RoutedEventArgs e)
        {
            AddNum("5");
        }

        private void AddSix(object sender, RoutedEventArgs e)
        {
            AddNum("6");
        }

        private void AddSeven(object sender, RoutedEventArgs e)
        {
            AddNum("7");
        }

        private void AddEight(object sender, RoutedEventArgs e)
        {
            AddNum("8");
        }

        private void AddNine(object sender, RoutedEventArgs e)
        {
            AddNum("9");
        }

        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeApp(object sender, RoutedEventArgs e)
        {
            if (IsMaximized()) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        private bool IsMaximized() 
        {
            return WindowState == WindowState.Maximized;
        }

        private void EnableDarkMode(object sender, RoutedEventArgs e)
        {
            SetModeDark();
        }

        private void EnableLightMode(object sender, RoutedEventArgs e)
        {
            SetModeLight();
        }

        private void SetModeLight() 
        {
            SetMode(255, 94, 115, 101);
        }

        private void SetModeDark()
        {
            SetMode(32, 255, 255, 255);
        }

        private void SetMode(byte background, byte foreground1, byte foreground2, byte foreground3)
        {
            _window.Background = new SolidColorBrush(Color.FromRgb(background, background, background));
            _mainText.Foreground = new SolidColorBrush(Color.FromRgb(foreground1, foreground2, foreground3));
        }
    }

}
