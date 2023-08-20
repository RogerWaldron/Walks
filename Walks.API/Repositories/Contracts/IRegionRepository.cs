namespace Walks.API.Repositories
{
    public interface IRegionRepository
	{
        /// <summary>
        /// Return all regions including records marked as deleted and closed
        /// </summary>
        /// <returns>Models.Domain.Region</returns>
        Task<ICollection<Models.Domain.Region>> GetAllRegionsAsync();

        /// <summary>
        /// Return all regions including records not marked as deleted
        /// </summary>
        /// <returns>Models.Domain.Region</returns>
        Task<ICollection<Region>> GetRegionsAsync();

        /// <summary>
        /// Return all regions marked as deleted
        /// </summary>
        /// <returns>Models.Domain.Region</returns>
        Task<ICollection<Region>> GetDeletedRegionsAsync();

        /// <summary>
        /// Return all regions marked as closed
        /// </summary>
        /// <returns>Models.Domain.Region</returns>
        Task<ICollection<Region>> GetClosedRegionsAsync();

        /// <summary>
        /// Return a region record
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns>Models.Domain.Region</returns>
        Task<Region> GetRegionByGuidAsync(Guid GUID);

        /// <summary>
        /// Return a region record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Models.Domain.Region</returns>
        Task<Region> GetRegionByIdAsync(int Id);

        /// <summary>
        /// Return True or False if record exists
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>bool</returns>
        Task<bool> RegionExistsAsync(int Id);

        /// <summary>
        /// Return True or False if record exists
        /// </summary>
        /// <param name="RegionName"></param>
        /// <returns>bool</returns>
        Task<bool> RegionExistsAsync(string RegionName);

        /// <summary>
        /// Add a new region record 
        /// </summary>
        /// <param name="region"></param>
        /// <returns>bool</returns>
        Task<bool> CreateRegionAsync(Region region);

        /// <summary>
        /// Update a region record
        /// </summary>
        /// <param name="region"></param>
        /// <returns>bool</returns>
        Task<bool> UpdateRegionAsync(Region region);

        /// <summary>
        /// Delete a region record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>bool</returns>
        Task<bool> SoftDeleteRegionAsync(int Id);

        /// <summary>
        /// Delete a region record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>bool</returns>
        Task<bool> HardDeleteRegionAsync(int Id);
    }
}

