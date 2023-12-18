using Lab3_24.Models.Base;

namespace Lab3_24.Models
{
    public class Student: BaseEntity
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
