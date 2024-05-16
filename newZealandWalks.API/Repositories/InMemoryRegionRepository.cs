//using newZealandWalks.API.Models.Domain;

//namespace newZealandWalks.API.Repositories
//{
//    public class InMemoryRegionRepository : IRegionRepository
//    {
//        public async Task<List<Region>> AsyncGetAll() // warning pga funciton ikke har await
//        {
//            var regions = new List<Region>
//            {
//                new Region()
//                {
//                    Id = Guid.NewGuid(),
//                    Name = "InMemory",
//                    Code = "InMemory",
//                }
//            };

//            return regions;
//        }

//        public Task<Region> AsyncGetById(Guid id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
