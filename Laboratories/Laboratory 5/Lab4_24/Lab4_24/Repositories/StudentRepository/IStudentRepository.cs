using Lab4_24.Models;
using Lab4_24.Models.One_to_Many;

namespace Lab4_24.Repositories.StudentRepository;

public interface IStudentRepository
{
    List<Student> OrderByAge(int age);
    Student Where(int age);
    void GroupBy();
    dynamic GetAllWithJoin();
    List<Model1> GetAllWithInclude();
}