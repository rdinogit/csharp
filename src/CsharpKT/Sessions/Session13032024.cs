using CsharpKT.v1;

namespace CsharpKT.Sessions
{
    internal static class Session13032024
    {
        public static void RunSessionCode()
        {
            Console.WriteLine("Hello, World!");

            var id = Guid.NewGuid();
            var name = "Diviyanshu";

            var baseUser = new User(id, name);

            var classPropertyValue = baseUser.Name;

            baseUser.AssignName("No Longer Diviyanshu");

            try
            {
                baseUser.AssignName(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            baseUser.AssignNewId(Guid.NewGuid());

            var superUser = new SuperUser(Guid.NewGuid(), "aName");
            superUser.ValidateId();

            var superUser2 = new SuperUser(Guid.NewGuid(), "other");

            superUser.CopyUserData(superUser2);

            var sphere = new Sphere();
            var volume = sphere.ComputeVolume();

        }
    }
}
