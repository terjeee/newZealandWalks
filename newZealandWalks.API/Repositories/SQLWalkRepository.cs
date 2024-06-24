using Microsoft.EntityFrameworkCore;
using newZealandWalks.API.Data;
using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly newZealandWalksDbContext dbContext;
        public SQLWalkRepository(newZealandWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> WalkCreateAsync(Walk walkDM)
        {
            await dbContext.Walks.AddAsync(walkDM);
            await dbContext.SaveChangesAsync();

            return walkDM;
        }

        public async Task<List<Walk>> WalkGetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // filter
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // SORTING
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            return await walks.ToListAsync();
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync
        }

        public async Task<Walk?> WalkGetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(walkItem => walkItem.Id == id);
        }

        public async Task<Walk?> WalkUpdateAsync(Guid id, Walk walkDTO)
        {
            var existingWalk = await dbContext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(walk => walk.Id == id);

            if (existingWalk == null) { return null; }

            existingWalk.Name = walkDTO.Name ?? existingWalk.Name;
            existingWalk.Description = walkDTO.Description ?? existingWalk.Description;
            existingWalk.LengthInKm = walkDTO.LengthInKm;
            existingWalk.WalkImageUrl = walkDTO.WalkImageUrl ?? existingWalk.WalkImageUrl;
            existingWalk.DifficultyId = walkDTO.DifficultyId;
            existingWalk.RegionId = walkDTO.RegionId;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk?> WalkDeleteAsync(Guid id)
        {
            var walkDM = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walkDM == null) { return null; }

            dbContext.Walks.Remove(walkDM);
            await dbContext.SaveChangesAsync();

            return walkDM;
        }
    }
}
