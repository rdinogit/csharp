using CsharpKT.v1;

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
    throw;
}
catch (ArgumentOutOfRangeException ex)
{
}


baseUser.AssignNewId(Guid.NewGuid());


var superUser = new SuperUser(Guid.NewGuid(), "aName");
superUser.ValidateId();

var superUser2 = new SuperUser(Guid.NewGuid(), "other");

superUser.CopyUserData(superUser2);


var sphere = new Sphere();

sphere.ComputeVolume();



bool breaker = false;
