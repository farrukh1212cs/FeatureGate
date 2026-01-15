using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FeatureGate.Api.Application.Interfaces;

namespace FeatureGate.Api.Web.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class FeatureGateAttribute : Attribute, IAsyncActionFilter
{
    private readonly string _featureName;

    public FeatureGateAttribute(string featureName)
    {
        _featureName = featureName;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var featureService = context.HttpContext.RequestServices.GetRequiredService<IFeatureService>();
        
        if (!await featureService.IsFeatureEnabledAsync(_featureName))
        {
            context.Result = new ObjectResult(new { message = $"Feature '{_featureName}' is currently disabled." }) 
            { 
                StatusCode = StatusCodes.Status403Forbidden 
            };
            return;
        }

        await next();
    }
}
