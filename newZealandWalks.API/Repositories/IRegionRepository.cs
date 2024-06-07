using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> AsyncGetAll();

        Task<Region?> AsyncGetById(Guid id);

        Task<Region> AsyncCreate(Region regionDM);

        Task<Region?> AsyncUpdate(Guid id, Region regionDM);

        Task<Region?> AsyncDelete(Guid id);
    }
}
