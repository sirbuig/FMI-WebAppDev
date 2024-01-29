using Lab4_24.Data;
using Lab4_24.Models;
using Lab4_24.Models.One_to_Many;
using Lab4_24.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab4_24.Repositories.StudentRepository;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(Lab4Context lab4Context) : base(lab4Context)
    {
    }

    public List<Student> OrderByAge(int age)
    {
        // multiple examples

        var studentsOrderedAsc1 = _table.OrderBy(s => s.Age);
        var studentsOrderedDesc1 = _table.OrderByDescending(s => s.Age);
        var studentsOrderedByMultiple1 = _table.OrderBy(s => s.Age).ThenBy(s => s.Id);
        var studentsOrderedByMultiple2 = _table.OrderByDescending(s => s.Age).ThenByDescending(s => s.Id);

        // linq query syntax
        var studentsOrderedAsc2 =
            from s in _table
            orderby s.Age
            select s;

        var studentsOrderedDesc2 =
            from s in _table
            orderby s.Age descending
            select s;

        return studentsOrderedAsc1.ToList();
    }

    public Student Where(int age)
    {
        var result1 = _table.Where(s => s.Age == age).FirstOrDefault();
        var result2 = _table.FirstOrDefault(s => s.Age == age);
        var result3 = _table.LastOrDefault(s => s.Age == age);

        // linq query syntax
        var result4 =
            from s in _table
            where s.Age == age
            select s;

        return result1;
    }

    public void GroupBy()
    {
        var groupedStudents = _table.GroupBy(s => s.Age);
        var groupedStudents2 =
            from s in _table
            group s by s.Age;

        foreach (var groupedStudentsByAge in groupedStudents2)
        {
            Console.WriteLine("Students group age: " + groupedStudentsByAge.Key);

            foreach (var s in groupedStudentsByAge) Console.WriteLine("Student name: " + s.FirstName);
        }
    }

    public dynamic GetAllWithJoin()
    {
        var result = _lab4Context.Models1.Join(_lab4Context.Models2, model1 => model1.Id, model2 => model2.Model1Id,
            (model1, model2) => new { NewPropertyModel1 = model1.Name, model2 }).ToList();

        return result;
    }

    public List<Model1> GetAllWithInclude()
    {
        var result = _lab4Context.Models1.Include(m1 => m1.Models2).ToList();
        return result;
    }
}