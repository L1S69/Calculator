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
        public string MainString;

        public void Print(string a)
        {
            MainString = a;
        }

        public void AddText(string a)
        {
            MainString += a;
        }

        public void PrintResult(float result)
        {
            MainString = result.ToString();
        }
    }
}
