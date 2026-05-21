namespace Domain.DTO.Customer
{
    public enum SeniorityEnum
    {
        New,
        Regular = 365,
        Old = (int)Regular * 2
    }
}