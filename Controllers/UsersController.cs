using FeatureGate.Api.Application.Interfaces;
using FeatureGate.Api.Domain.Entities;
using FeatureGate.Api.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FeatureGate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [FeatureGate("UserView")]
    public IActionResult Get() => Ok(_userService.GetAll());

    [HttpGet("{id}")]
    [FeatureGate("UserView")]
    public IActionResult Get(int id)
    {
        var user = _userService.GetById(id);
        return user != null ? Ok(user) : NotFound();
    }

    [HttpPost]
    [FeatureGate("UserCreate")]
    public IActionResult Post(User user)
    {
        _userService.Create(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    [FeatureGate("UserUpdate")]
    public IActionResult Put(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        _userService.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [FeatureGate("UserDelete")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return NoContent();
    }
}
