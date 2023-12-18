using Lab2_24.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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

        // ACTIVITATE - Lab 2
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

        // CONTINUARE IN LAB 3
        [HttpGet("byId")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id.Equals(id));
        }

        [HttpGet("byid/{id}")]
        public Student GetIdByRoute(int id)
        {
            return students.FirstOrDefault(s => s.Id.Equals(id));
        }

        [HttpGet("filter/{name}/{age}")]
        public Student GetWithFilters(string name, int age)
        {
            return students.FirstOrDefault(s => s.Name.Equals(name) && s.Age.Equals(age));
        }

        [HttpGet("fromRouteWithId/{id}")]
        public Student GetByIdWithFromRoute([FromRoute] int id)
        {
            return students.FirstOrDefault(s => s.Id.Equals(id));
        }

        [HttpGet("fromHeader")]
        public Student GetByIdWithFromHeader([FromHeader] int id)
        {
            return students.FirstOrDefault(s => s.Id.Equals(id));
        }

        [HttpGet("fromQuery")]
        public Student GetByIdWithFromQuery([FromQuery] int id)
        {
            return students.FirstOrDefault(s => s.Id.Equals(id));
        }

        [HttpPost("fromBody")]
        public IActionResult AddWithFromBody([FromBody] Student student)
        {
            students.Add(student);
            return Ok("Student has been added");
        }

        [HttpPost("fromForm")]
        public IActionResult AddWithFromForm([FromForm] Student student)
        {
            students.Add(student);
            return Ok("Student has been added");
        }

        // Update partial - patch
        [HttpPatch]
        public IActionResult Patch([FromQuery] int id, [FromBody] JsonPatchDocument<Student> student)
        {
            if(student!=null)
            {
                var StudentToUpdate = students.FirstOrDefault(s => s.Id.Equals(id));
                student.ApplyTo(StudentToUpdate, ModelState);

                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(students);
            }
            return BadRequest("User is null");

            /*return NotFound();
            return NoContent();
            return Forbid();*/
        }

    }
}
