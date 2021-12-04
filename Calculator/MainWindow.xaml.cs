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
        private TextBlock _mainText;

        private string _action;

        private float _firstValue;
        private float _secondValue;
        private float _result;

        private bool _canType = true;

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
                _mainText.Text = "0";
            }
            else if (_canType)
            {
                if (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(","))
                {
                    _mainText.Text += "0";
                }
            }
            else if (!_canType)
            {
                if (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(","))
                {
                    _mainText.Text = "0";
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
                    _mainText.Text += ",";
                }
            }
            else if (!_canType)
            {
                if (!_mainText.Text.Contains(","))
                {
                    _mainText.Text += ",";
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
            _mainText.Text = a;
        }

        private void PrintResult(float result)
        {
            Print(result.ToString());
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
                    _mainText.Text = "-" + _mainText.Text;
                }
                else
                {
                    _mainText.Text = _mainText.Text.Substring(1);
                }
            }
        }

        private void AddNum(string num)
        {
            if (_mainText.Text != "")
            {
                if (_canType && (float.Parse(_mainText.Text) != 0f || _mainText.Text.Contains(",")))
                {
                    _mainText.Text += num;
                }
                else if (!_canType || (float.Parse(_mainText.Text) == 0f && !_mainText.Text.Contains(",")))
                {
                    _mainText.Text = num;
                    _canType = true;
                }
            }
            else
            {
                _mainText.Text = num;
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

    static class Clk
    {
        public static float Add(float _first, float _second)
        {
            return _first + _second;
        }

        public static float Substract(float _first, float _second)
        {
            return _first - _second;
        }

        public static float Increase(float _first, float _second)
        {
            return _first * _second;
        }

        public static float Divide(float _first, float _second)
        {
            return _first / _second;
        }

        public static float Percent(float _value)
        {
            return _value / 100;
        }
    }
}
