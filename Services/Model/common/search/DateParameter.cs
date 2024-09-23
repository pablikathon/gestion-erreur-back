using Persist.Entity.CommonField;

namespace Services.Models.Common;

public class DateParameters
{
    public DateTime StartDate { get; set; } = DateTime.Now.AddMonths(-6);
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(6);
    public string DateField { get; set; } = nameof(DateEntity.CreatedAt);
}