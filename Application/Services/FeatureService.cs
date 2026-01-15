using FeatureGate.Api.Application.Interfaces;
using FeatureGate.Api.Domain.Entities;
using FeatureGate.Api.Domain.Interfaces;

namespace FeatureGate.Api.Application.Services;

public class FeatureService : IFeatureService
{
    private readonly IFeatureRepository _repository;

    public FeatureService(IFeatureRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsFeatureEnabledAsync(string featureName)
    {
        var feature = await _repository.GetByNameAsync(featureName);
        return feature?.IsEnabled ?? false;
    }

    public async Task<IEnumerable<Feature>> GetFeaturesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task UpdateFeatureAsync(Feature feature)
    {
        await _repository.UpdateAsync(feature);
    }
}
