using CsharpKT.ApiModels;

namespace CsharpKTApi.Repositories
{
    public interface IDeveloperRepository
    {
        public Task Add(Developer developer);
        public Task<Developer?> Get(string id);
        public Task UpdateDetails(string id, string name);
    }
}
