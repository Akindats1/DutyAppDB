namespace DutyAppDB.Models.Dtos.DutyAssignment
{
    public class UpdateDutyAssignmentDto :BaseDto
    {
        public int DutyId { get; set; } = default!;
        public int StudentId { get; set; } = default!;
        public string DutyName { get; set; } = null!;
    }
}
