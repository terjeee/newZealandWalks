using newZealandWalks.API.Models.Domain;

namespace newZealandWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> WalkCreateAsync(Walk walk);
    }
}
