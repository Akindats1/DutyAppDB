using DutyAppDB.Models.Dtos.Student;
using DutyAppDB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyAppDB.Repositories.Contracts
{
    public interface IStudentRepository
    {
        Task<int> AddStudent(AddStudentDto request);
    }
}
