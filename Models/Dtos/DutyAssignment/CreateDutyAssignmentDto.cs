using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyAppDB.Models.Dtos.DutyAssignment
{
    public class CreateDutyAssignmentDto
    {
            public int DutyId { get; set; }
            public int StudentId { get; set; }
            public string StudentCode { get; set; } = string.Empty;
            public string StudentName { get; set; } = string.Empty;
            public string DutyName { get; set; } = string.Empty;
    }
}
