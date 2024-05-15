using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> AsyncGetAll();

        Task<Region> AsyncGetById(Guid id);
    }
}
