using Microsoft.EntityFrameworkCore;
using newZealandWalks.API.Data;
using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly newZealandWalksDbContext dbContext;

        public SQLRegionRepository(newZealandWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> AsyncGetAll()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> AsyncGetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
