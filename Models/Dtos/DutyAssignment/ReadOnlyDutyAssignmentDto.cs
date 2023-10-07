namespace DutyAppDB.Models.Dtos.DutyAssignment
{
    public class ReadOnlyDutyAssignmentDto : BaseDto
    {
        public string StudentCode { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string DutyName { get; set; } = null!;
    }
}
