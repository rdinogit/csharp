namespace CsharpKT.v1
{
    internal class DelegatesSubject
    {
        //public delegate void PrintValueCallback(int value);
        //public delegate int PowerOfTwoCallback(int value);

        public int Value { get; set; }

        //public void DefineValue(int value, PrintValueCallback printValue)
        //{
        //    Value = value;
        //    printValue(Value);
        //}

        public void DefineValue(int value, Action<int> printValue)
        {
            Value = value;
            printValue(Value);
        }

        //public void DefineValueAndPowerIt(int value, PowerOfTwoCallback computePowerOfTwo)
        //{
        //    var poweredValue = computePowerOfTwo(value);
        //    Value = poweredValue;
        //}

        public void DefineValueAndPowerIt(int value, Func<int, int> computePowerOfTwo)
        {
            var poweredValue = computePowerOfTwo(value);
            Value = poweredValue;
        }
    }
}
