using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
       Task<List<Region>>GetAllAsync();
       Task<Region?>GetByIDAsync(Guid id);
       Task<Region>CreateAsync(Region region);
       Task<Region> UpdateAsync(Guid id, Region regionDomainModel);
       Task<Region> DeleteAsync(Guid id);
       Task<List<Region>> CreateAsync(List<Region> regionsDomainModel);

    }
}
