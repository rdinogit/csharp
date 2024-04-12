using CsharpKT.ApiModels;
using CsharpKTApi.Models.v1;

namespace CsharpKTApi.Mappers
{
    public class DeveloperMapper : IDeveloperMapper
    {
        public Developer Map(DeveloperRequestModel request)
        {
            return Developer.Create(Guid.NewGuid().ToString(), request.Name);
        }
    }
}
