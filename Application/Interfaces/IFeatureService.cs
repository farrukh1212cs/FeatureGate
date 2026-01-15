using FeatureGate.Api.Domain.Entities;

namespace FeatureGate.Api.Application.Interfaces;

public interface IFeatureService
{
    Task<bool> IsFeatureEnabledAsync(string featureName);
    Task<IEnumerable<Feature>> GetFeaturesAsync();
    Task UpdateFeatureAsync(Feature feature);
}
