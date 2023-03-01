using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentService.database.db.models;
using StudentService.database.dto;

namespace StudentService.database.mapper
{
    public class StudentMapper
    {
        public static StudentDto ToStudentDto(Student student)
        {
            return new StudentDto
            {
                Name= student.Name,
                Branch= student.Branch,
            };
        }
    }
}
