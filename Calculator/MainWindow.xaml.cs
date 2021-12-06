using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private TextBlock _mainText;
        public string MainString;

        private string _action;

        private float _firstValue;
        private float _secondValue;
        private float _result;

        private bool _canType = true;

        private void UpdateMainText() 
        {
            _mainText.Text = MainString;
        }

        public MainWindow()
        {
            InitializeComponent();
            _mainText = FindName("MainText") as TextBlock;
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
                Print("0");
            }
            else if (_canType)
            {
                if (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(","))
                {
                    AddText("0");
                }
            }
            else if (!_canType)
            {
                if (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(","))
                {
                    Print("0");
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
                    AddText(",");
                }
            }
            else if (!_canType)
            {
                if (!_mainText.Text.Contains(","))
                {
                    AddText(",");
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
                        PrintResult(_result);
                        break;

                    case "Substract":
                        _result = Clk.Substract(_firstValue, _secondValue);
                        PrintResult(_result);
                        break;

                    case "Increase":
                        _result = Clk.Increase(_firstValue, _secondValue);
                        PrintResult(_result);
                        break;

                    case "Divide":
                        if (_firstValue != 0f && _secondValue != 0f)
                        {
                            _result = Clk.Divide(_firstValue, _secondValue);
                            PrintResult(_result);
                        }
                        else
                        {
                            Print("Cant divide by 0");
                            _canType = false;
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
                Print("");
                _action = action;
            }
        }

        private void Print(string a) 
        {
            MainString = a;
            UpdateMainText();
        }

        private void AddText(string a) 
        {
            MainString += a;
            UpdateMainText();
        }

        private void PrintResult(float result)
        {
            MainString = result.ToString();
            UpdateMainText();
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
            PrintResult(_result);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Print("");
        }

        private void Revert(object sender, RoutedEventArgs e)
        {
            if (_mainText.Text != "" && _canType && float.Parse(_mainText.Text) != 0f)
            {
                if (!_mainText.Text.Contains("-"))
                {
                    Print("-" + _mainText.Text);
                }
                else
                {
                    Print(_mainText.Text.Substring(1));
                }
            }
        }

        private void AddNum(string num)
        {
            if (_mainText.Text != "")
            {
                if (_canType && (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(",")))
                {
                    AddText(num);
                }
                else if (!_canType || (float.Parse(_mainText.Text) == 0f && !_mainText.Text.Contains(",")))
                {
                    Print(num);
                    _canType = true;
                }
            }
            else
            {
                Print(num);
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
    }

}
