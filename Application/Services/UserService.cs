using FeatureGate.Api.Application.Interfaces;
using FeatureGate.Api.Domain.Entities;

namespace FeatureGate.Api.Application.Services;

public class UserService : IUserService
{
    private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
        new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
    };

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public void Create(User user)
    {
        user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(user);
    }

    public void Update(User user)
    {
        var existing = GetById(user.Id);
        if (existing != null)
        {
            existing.Name = user.Name;
            existing.Email = user.Email;
        }
    }

    public void Delete(int id)
    {
        var user = GetById(id);
        if (user != null) _users.Remove(user);
    }
}
