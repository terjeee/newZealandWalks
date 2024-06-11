using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> WalkCreateAsync(Walk walk);
        Task<List<Walk>> WalkGetAllAsync(string? filterOn = null, string? filterQuery = null);
        Task<Walk?> WalkGetByIdAsync(Guid id);
        Task<Walk?> WalkUpdateAsync(Guid id, Walk walk);
        Task<Walk?> WalkDeleteAsync(Guid id);
    }
}
