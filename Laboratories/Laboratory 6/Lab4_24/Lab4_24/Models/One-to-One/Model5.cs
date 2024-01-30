using Lab4_24.Models.Base;

namespace Lab4_24.Models.One_to_One
{
    public class Model5: BaseEntity
    {
        public int Size {  get; set; }

        // relation
        public Model6 Model6 { get; set; } = default!;
    }
}
