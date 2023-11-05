using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Persistance.DataContexts;
using System.Linq.Expressions;

namespace EduCource.Infrastructure.Foundations;

public class CourseService : IEntityBaseService<Course>
{
    private readonly AppDbContext _appDbContext;

    public CourseService(AppDbContext appDbContext) => _appDbContext = appDbContext;
    
    public async ValueTask<Course> CreateAsync(Course course)
    {
        await _appDbContext.Courses.AddAsync(course);

        await _appDbContext.SaveChangesAsync();

        return course;
    }
    
    public IQueryable<Course> Get(Expression<Func<Course, bool>> predicate)
            => _appDbContext.Courses.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Course> GetByIdAsync(Guid id)
        => await _appDbContext.Courses.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "Course not found!");

    public async ValueTask<Course> UpdateAsync(Course course)
    {
        var foundCourse = await GetByIdAsync(course.Id);

        foundCourse.Title = course.Title;
        foundCourse.Description = course.Description;
        foundCourse.Teacher = course.Teacher;
        foundCourse.TeacherId = course.TeacherId;

        _appDbContext.Courses.Update(foundCourse);

        await _appDbContext.SaveChangesAsync();
        return foundCourse;
    }

    public async ValueTask<Course> DeleteAsync(Course course)
    {
        _appDbContext.Remove(course);

        await _appDbContext.SaveChangesAsync();

        return course;
    }
}