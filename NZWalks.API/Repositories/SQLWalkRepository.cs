using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalksRepository
    {
        private readonly NZWalksDbContext _context;
        public SQLWalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }
        public async Task<Walk> CreateAsync(Walk newWalk)
        {
            await _context.Walks.AddAsync(newWalk);
            await _context.SaveChangesAsync();

            return newWalk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
           var walks = await _context.Walks.ToListAsync();

            return walks;
        }
    }
}
