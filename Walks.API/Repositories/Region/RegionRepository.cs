using Walks.API.Data;

namespace Walks.API.Repositories.Region
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext _dataContext;

        public RegionRepository(WalksDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateRegionAsync(Region region)
        {
            await _dataContext.Regions.AddAsync(region);

            return await IsSuccessful();
        }

        public async Task<bool> HardDeleteRegionAsync(int Id)
        {
            var _region = await GetRegionByIdAsync(Id);

            if (_region != null)
            {
                _dataContext.Remove(_region);

                return await IsSuccessful();
            }

            return false;
        }

        public async Task<bool> SoftDeleteRegionAsync(int Id)
        {
            var _region = await GetRegionByIdAsync(Id);

            if (_region != null)
            {
                _region.IsDeleted = true;

                return await IsSuccessful();
            }

            return false;
        }

        public async Task<ICollection<Region>> GetAllRegionsAsync()
        {
            return await _dataContext.Regions.ToListAsync();
        }

        public async Task<ICollection<Region>> GetDeletedRegionsAsync()
        {
            return await _dataContext.Regions.Where(r => r.IsDeleted == true).ToListAsync();
        }

        public async Task<Region> GetRegionByGuidAsync(Guid GUID)
        {
            return await _dataContext.Regions.FirstAsync(r => r.GUID == GUID);
        }

        public async Task<Region> GetRegionByIdAsync(int Id)
        {
            return await _dataContext.Regions.FirstAsync(r => r.Id == Id);
        }

        public async Task<ICollection<Region>> GetRegionsAsync()
        {
            return await _dataContext.Regions.Where(r => r.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> RegionExistsAsync(int Id)
        {
            return await _dataContext.Regions.AnyAsync(r => r.Id == Id);
        }

        public async Task<bool> RegionExistsAsync(string RegionName)
        {
            return await _dataContext.Regions.AnyAsync(r => r.RegionName.Contains(RegionName));
        }

        public async Task<bool> UpdateRegionAsync(Region region)
        {
            await _dataContext.Regions.AddAsync(region);

            return await IsSuccessful();
        }

        private async Task<bool> IsSuccessful()
        {
            return await _dataContext.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<ICollection<Region>> GetClosedRegionsAsync()
        {
            return await _dataContext.Regions.Where(r => r.IsClosed == true).ToListAsync();
        }
    }
}

