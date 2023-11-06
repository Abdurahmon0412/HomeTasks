using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduCource.API.Controllers;

public class CourseController : ControllerBase
{
    private readonly IEntityBaseService<Course> _courseService;

    public CourseController(IEntityBaseService<Course> courseService) => _courseService = courseService;

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var course = await _courseService.Get(course => true).ToListAsync();
        return course.Any() ? Ok(course) : NotFound();
    }

    [HttpGet("{courseId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid courseId)
    {
        var course = await _courseService.GetByIdAsync(courseId);
        return course != null ? Ok( course) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] Course course)
    {
        var createdCourse = await _courseService.CreateAsync(course   );
        return CreatedAtAction(nameof(GetById),
            new
            {
                userId = createdCourse.Id
            },
            createdCourse);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Course course)
    {
        await _courseService.UpdateAsync(course);
        return Ok();
    }

    [HttpDelete("{courseId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid courseId)
    {
        var deletedCourse = await _courseService.GetByIdAsync(courseId);

        await _courseService.DeleteAsync(deletedCourse);

        return Ok();
    }
}