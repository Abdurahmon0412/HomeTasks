using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduCource.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IEntityBaseService<Role> _roleService;

    public RolesController(IEntityBaseService<Role> roleService) => _roleService = roleService;

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var roles = await _roleService.Get(user => true).ToListAsync();
        return roles.Any() ? Ok(roles) : NotFound();
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid roleId)
    {
        var role = await _roleService.GetByIdAsync(roleId);
        return role != null ? Ok(role) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] Role role)
    {
        var createdRole = await _roleService.CreateAsync(role);
        return CreatedAtAction(nameof(GetById),
            new
            {
                userId = createdRole.Id
            },
            createdRole);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Role role)
    {
        await _roleService.UpdateAsync(role);
        return Ok();
    }

    [HttpDelete("{roleId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid roleId)
    {
        var deletedRole = await _roleService.GetByIdAsync(roleId);

        await _roleService.DeleteAsync(deletedRole);

        return Ok();
    }
}
