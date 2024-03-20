using CsharpKT.v1;
using System.Text.Json;

namespace CsharpKT.Sessions
{
    public static class Session_20032024
    {
        public static void RunSessionCode()
        {
            var user = new User(Guid.NewGuid(), "Ruben");
            var otherUser = new User(Guid.NewGuid(), "NotRuben");

            user.CopyPhoneNumber(otherUser);

            var phoneBook = new PhoneBook("12345");
            var input = "c";

            input = phoneBook.DoSomething(input);

            phoneBook.DoSomethingToUser(user);

            var subject = SerializationSubject.CreateNew();
            subject.UpdateValue(2);

            var jsonString = JsonSerializer.Serialize(subject);
            var revertedSubject = JsonSerializer.Deserialize<SerializationSubject>(jsonString);

            var delegateSubject = new DelegatesSubject();
            delegateSubject.DefineValue(2, PrintAGivenNumericValueInAWeirdWay);
            delegateSubject.DefineValue(2, (int value) =>
            {
                Console.WriteLine(value);
            });

            delegateSubject.DefineValueAndPowerIt(2, ComputePowerOfTwo);
            delegateSubject.DefineValueAndPowerIt(2, (int value) =>
            {
                return value * value;
            });

            var aList = new List<int>() { 2, 5, 1, 4, 6 };

            var itemsOfInterest = aList.Where(x => x % 2 == 1).ToList();
            var aListOfstring = aList.Select(x => new PhoneBook(x.ToString())).ToList();

            var aValue = 4;
            var result = aValue.DivideByTwo();

            Console.WriteLine("-------------");

            4.Times((int iteration) => Console.WriteLine("Hello World"));
        }

        public static void PrintAGivenNumericValue(int value)
        {
            Console.WriteLine(value);
        }

        public static void PrintAGivenNumericValueInAWeirdWay(int value)
        {
            Console.WriteLine($"This is weird, {value}");
        }

        public static int ComputePowerOfTwo(int value)
        {
            return value * value;
        }

    }
}
