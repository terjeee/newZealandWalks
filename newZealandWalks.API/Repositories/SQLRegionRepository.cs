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

        public async Task<Region?> AsyncGetById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(regionItem => regionItem.Id == id);
        }

        public async Task<Region> AsyncCreate(Region regionDM)
        {
            await dbContext.Regions.AddAsync(regionDM);
            await dbContext.SaveChangesAsync();

            return regionDM;
        }

        public async Task<Region?> AsyncUpdate(Guid id, Region regionDM)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);

            if (existingRegion == null) { return null; }

            existingRegion.Code = regionDM.Code ?? existingRegion.Code;
            existingRegion.Name = regionDM.Name ?? existingRegion.Name;
            existingRegion.RegionImageUrl = regionDM.RegionImageUrl ?? existingRegion.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> AsyncDelete(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);

            if (existingRegion == null) { return null; }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
