using FeatureGate.Api.Domain.Entities;

namespace FeatureGate.Api.Domain.Interfaces;

public interface IFeatureRepository
{
    Task<Feature?> GetByNameAsync(string name);
    Task<IEnumerable<Feature>> GetAllAsync();
    Task UpdateAsync(Feature feature);
}
