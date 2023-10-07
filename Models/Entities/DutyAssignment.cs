namespace DutyAppDB.Models.Entities;

public class DutyAssignment : BaseEntity
{
    public int DutyId { get; set; } = default!;
    public int StudentId { get; set; } = default!;
    public string StudentCode { get; set; } = null!;
    public string StudentName { get; set; } = null!;
    public string DutyName { get; set; } = null!;
}