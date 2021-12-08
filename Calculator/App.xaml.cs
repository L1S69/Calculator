using System.Windows;

namespace Calculator
{
    public partial class App : Application
    {
    }

    public static class Clk
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

    public class Printer
    {
        private string _mainString;
        public string MainString { get => _mainString; private set => _mainString = value; }

        public void Print(string a)
        {
            _mainString = a;
        }

        public void AddText(string a)
        {
            _mainString += a;
        }

        public void PrintResult(float result)
        {
            _mainString = result.ToString();
        }
    }
}
