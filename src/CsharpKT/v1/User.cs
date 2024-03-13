namespace CsharpKT.v1
{
    public class User
    {
        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }

        public void AssignNewId(Guid? newId)
        {
            ValidateId(newId);

            Id = (Guid)newId;
        }

        public void AssignName(string newName)
        {
            _ = string.IsNullOrWhiteSpace(newName) ? throw new ArgumentNullException(nameof(newName)) : newName;
            Name = newName;
        }

        protected static void ValidateId(Guid? newId)
        {
            if (newId is null)
                throw new ArgumentNullException(nameof(newId));
        }


        private static void PrivateValidateId(Guid? newId)
        {
            if (newId is null)
                throw new ArgumentNullException(nameof(newId));
        }

        public virtual void VirtualValidateId(Guid? newId)
        {
            if (newId is null)
                throw new ArgumentNullException(nameof(newId));
        }
    }
}
