using Lab2_24.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ana", Age = 21},
            new Student { Id = 2, Name = "Maria", Age = 19},
            new Student { Id = 3, Name = "Vlad", Age = 22},
            new Student { Id = 4, Name = "Florin", Age = 25},
            new Student { Id = 5, Name = "Marian", Age = 20}
        };

        // endpoint
        // Get
        [HttpGet]
        public List<Student> GetStudents()
        {
            return students;
        }

        // Create
        [HttpPost]
        public List<Student> Add(Student student)
        {
            student.Id = students.Count() + 1;
            students.Add(student);
            return students;
        }

        // Delete
        [HttpDelete]
        public List<Student> Delete(Student student)
        {
            var studentIndex = students.FindIndex(s => s.Id == student.Id);
            students.RemoveAt(studentIndex);
            return students;
        }

        // ACTIVITATE
        // Delete by "id"
        [HttpDelete("{id}")]
        public List<Student> DeleteById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return students;
        }

        // Endpoint "getAllOrdered"
        [HttpGet("getAllOrdered")]
        public List<Student> GetAllOrdered()
        {
            return students.OrderBy(s => s.Age).ToList();
        }
    }
}
