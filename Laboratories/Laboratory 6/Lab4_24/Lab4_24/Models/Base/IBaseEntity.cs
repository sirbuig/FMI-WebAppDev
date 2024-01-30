namespace Lab4_24.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime? DateCreated {  get; set; }
        DateTime? DateModified { get; set; }
        bool IsDeleted { get; set; }
    }
}
