namespace CsharpKT.v1
{
    internal class SerializationSubject
    {
        public SerializationSubject()
        {
        }

        public static SerializationSubject CreateNew()
        {
            return new SerializationSubject()
            {
                Value = 1
            };
        }

        public int Value { get; set; }

        public void UpdateValue(int value)
        {
            Value = value;
        }
    }
}
