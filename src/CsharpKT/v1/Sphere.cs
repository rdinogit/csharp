namespace CsharpKT.v1
{
    public class Sphere : Shape
    {
        public override double ComputeSpecificShapeVolume()
        {
            return 20d;
        }
    }

    public class Cube : Shape
    {
        public override double ComputeSpecificShapeVolume()
        {
            return 10d;
        }
    }
}
