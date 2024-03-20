namespace CsharpKT.v1
{
    internal class PhoneBook : IHasPhoneNumber
    {
        public PhoneBook(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; set; }

        public string DoSomething(string input)
        {
            return "a";
        }

        public void DoSomethingToUser(User user)
        {
            user.AssignName("NEW NAME");
        }
    }
}
