using CsharpKT.ApiModels;
using CsharpKTApi.Models;

namespace CsharpKTApi.Mappers
{
    public interface IDeveloperMapper
    {
        public Developer Map(DeveloperRequestModel request);
    }
}
