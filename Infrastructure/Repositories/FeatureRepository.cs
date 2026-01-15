using FeatureGate.Api.Domain.Entities;
using FeatureGate.Api.Domain.Interfaces;
using FeatureGate.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FeatureGate.Api.Infrastructure.Repositories;

public class FeatureRepository : IFeatureRepository
{
    private readonly ApplicationDbContext _context;

    public FeatureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Feature?> GetByNameAsync(string name)
    {
        return await _context.Features.FirstOrDefaultAsync(f => f.Name == name);
    }

    public async Task<IEnumerable<Feature>> GetAllAsync()
    {
        return await _context.Features.ToListAsync();
    }

    public async Task UpdateAsync(Feature feature)
    {
        _context.Features.Update(feature);
        await _context.SaveChangesAsync();
    }
}
