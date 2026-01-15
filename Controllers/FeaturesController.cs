using FeatureGate.Api.Application.Interfaces;
using FeatureGate.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FeatureGate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _featureService.GetFeaturesAsync());

    [HttpPut]
    public async Task<IActionResult> Put(Feature feature)
    {
        await _featureService.UpdateFeatureAsync(feature);
        return NoContent();
    }
}
