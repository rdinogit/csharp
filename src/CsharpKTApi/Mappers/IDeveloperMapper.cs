using CsharpKT.ApiModels;
using CsharpKTApi.Models.v1;

namespace CsharpKTApi.Mappers
{
    public interface IDeveloperMapper
    {
        public Developer Map(DeveloperRequestModel request);
    }
}
