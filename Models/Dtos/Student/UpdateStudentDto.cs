using DutyAppDB.Enums;

namespace DutyAppDB.Models.Dtos.Student
{
    public class UpdateStudentDto : BaseDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
