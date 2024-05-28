using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> WalkCreateAsync(Walk walk);
        Task<List<Walk>> WalkGetAllAsync();
        Task<Walk?> WalkGetByIdAsync(Guid id);
    }
}
