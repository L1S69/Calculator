using System;
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

        public static float Root(float _first, float _second) 
        {
            decimal _firstDec = new decimal(_first);
            decimal _secondDec = new decimal(_second);

            double _firstDouble = (double)_firstDec;
            double _secondDouble = (double)_secondDec;

            float _result = (float)Math.Pow(_firstDouble, 1/_secondDouble);
            return _result;
        }

        public static float SquareRoot(float _first)
        {
            decimal _firstDec = new decimal(_first);

            double _firstDouble = (double)_firstDec;

            float _result = (float)Math.Pow(_firstDouble, 0.5);
            return _result;
        }

        public static float Degree(float _first, float _second)
        {
            decimal _firstDec = new decimal(_first);
            decimal _secondDec = new decimal(_second);

            double _firstDouble = (double)_firstDec;
            double _secondDouble = (double)_secondDec;

            float _result = (float)Math.Pow(_firstDouble, _secondDouble);
            return _result;
        }

        public static float DegTwo(float _first)
        {
            decimal _firstDec = new decimal(_first);

            double _firstDouble = (double)_firstDec;

            float _result = (float)Math.Pow(_firstDouble, 2);
            return _result;
        }

        public static float DegThree(float _first)
        {
            decimal _firstDec = new decimal(_first);

            double _firstDouble = (double)_firstDec;

            float _result = (float)Math.Pow(_firstDouble, 3);
            return _result;
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
