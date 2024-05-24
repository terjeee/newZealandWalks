using Microsoft.EntityFrameworkCore;
using newZealandWalks.API.Data;
using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly newZealandWalksDbContext dbContext;
        public SQLWalkRepository( newZealandWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> WalkCreateAsync(Walk walkDM)
        {
            await dbContext.Walks.AddAsync(walkDM);
            await dbContext.SaveChangesAsync();

            return walkDM;
        }
    }
}
