using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Persistance.DataContexts;
using System.Linq.Expressions;

namespace EduCource.Infrastructure.Foundations;

public class CourseStudentService : IEntityBaseService<CourseStudent>
{
    private readonly AppDbContext _appDbContext;

    public CourseStudentService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public async ValueTask<CourseStudent> CreateAsync(CourseStudent courseStudent)
    {
        await _appDbContext.CourseStudents.AddAsync(courseStudent);

        await _appDbContext.SaveChangesAsync();

        return courseStudent;
    }

    public IQueryable<CourseStudent> Get(Expression<Func<CourseStudent, bool>> predicate)
        => _appDbContext.CourseStudents.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<CourseStudent> GetByIdAsync(Guid id)
        => await _appDbContext.CourseStudents.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "CourseStudent not found!");

    public async ValueTask<CourseStudent> UpdateAsync(CourseStudent courseStudent)
    {
        var foundCourseStudent = await GetByIdAsync(courseStudent.Id);

        foundCourseStudent.CourcseId = courseStudent.CourcseId;
        foundCourseStudent.StudentId = courseStudent.StudentId;
        foundCourseStudent.Course = courseStudent.Course;
        foundCourseStudent.Student = courseStudent.Student;

        _appDbContext.CourseStudents.Update(foundCourseStudent);

        await _appDbContext.SaveChangesAsync();
        return foundCourseStudent;
    }

    public async ValueTask<CourseStudent> DeleteAsync(CourseStudent courseStudent)
    {
        _appDbContext.Remove(courseStudent);

        await _appDbContext.SaveChangesAsync();

        return courseStudent;
    }
}