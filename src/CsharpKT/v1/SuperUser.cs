
namespace CsharpKT.v1
{
    public class SuperUser : User
    {
        public SuperUser(Guid id, string name) : base(id, name)
        {
            HasSuperPowers = true;
        }

        public bool HasSuperPowers { get; private set; }

        public void ValidateId()
        {
            ValidateId(Guid.NewGuid());
        }

        public void VirtualValidateId()
        {
            VirtualValidateId(Guid.NewGuid());
        }

        public override void VirtualValidateId(Guid? newId)
        {
            // do nothing
        }

        public void CopyUserData(User anotherUser)
        {
            Id = anotherUser.Id;
            AssignName(anotherUser.Name);
        }
    }
}
