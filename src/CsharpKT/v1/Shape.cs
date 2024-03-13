
namespace CsharpKT.v1
{
    public abstract class Shape
    {
        public double ComputeVolume()
        {
            var result = ComputeSpecificShapeVolume();
            return result;
        }

        public abstract double ComputeSpecificShapeVolume();
    }
}
