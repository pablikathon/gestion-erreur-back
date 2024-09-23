namespace Persist.Entity.CommonField;

public abstract class DateEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}