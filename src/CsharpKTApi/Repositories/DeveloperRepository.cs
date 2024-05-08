using CsharpKT.ApiModels;
using CsharpKTApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CsharpKTApi.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly CsharpDbContext _context;

        public DeveloperRepository(CsharpDbContext context)
        {
            _context = context;
        }

        public async Task Add(Developer developer)
        {
            await _context.Developers.AddAsync(developer);
            await _context.SaveChangesAsync();
        }

        public async Task<Developer?> Get(string id)
        {
            return _context.Developers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateDetails(string id, string name)
        {
            var developer = _context.Developers.FirstOrDefault(x => x.Id == id);
            developer.UpdateName(name);
            await _context.SaveChangesAsync();
        }
    }
}
