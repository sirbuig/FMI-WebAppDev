using Lab4_24.Models.Base;

namespace Lab4_24.Models.One_to_Many
{
    public class Model2: BaseEntity
    {
        public string Description { get; set; } = default;

        // relation
        public Model1 Model1 { get; set; } = default;
        public Guid Model1Id { get; set; }
    }
}
