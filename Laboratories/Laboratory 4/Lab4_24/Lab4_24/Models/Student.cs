using Lab4_24.Data;
using Lab4_24.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Lab4_24.Models
{
    public class Student: BaseEntity
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set;}
        public int Age {  get; set; }
        public string Email { get; set; } = default;
    }
}
