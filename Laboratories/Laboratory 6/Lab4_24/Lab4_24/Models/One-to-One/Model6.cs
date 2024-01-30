using Lab4_24.Models.Base;

namespace Lab4_24.Models.One_to_One
{
    public class Model6: BaseEntity
    {
        public bool IsDeleted { get; set; }

        // relation
        public Model5 Model5 { get; set; } = default!;

        public Guid Model5Id {  get; set; }
    }
}
