namespace DutyAppDB.Models.Dtos.DutyAssignment
{
    public class ViewDutyAssignmentDetailDto : BaseDto
    {
        public string StudentCode { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string DutyName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
