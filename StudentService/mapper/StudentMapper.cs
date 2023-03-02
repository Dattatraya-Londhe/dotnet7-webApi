using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentService.database.db.models;
using StudentService.database.dto;
using StudentService.dtos;

namespace StudentService.database.mapper
{
    public class StudentMapper
    {
        public static GetStudentDto ToGetStudentDto(Student student)
        {
            return new GetStudentDto
            {
                Name= student.Name,
                Branch= student.Branch,
            };
        }

        public static Student ToStudent(AddStudentDto addStudent)
        {
            return new Student
            {
                Name = addStudent.Name,
                Branch = addStudent.Branch,
            };
        }

        public static List<GetStudentDto> ToGetStudentDto(List<Student> students)
        {
            List<GetStudentDto> StudentRecords= new List<GetStudentDto>();
            foreach (Student student in students)
            {
                StudentRecords.Add(new GetStudentDto
                {
                    Name = student.Name,
                    Branch = student.Branch,
                });
            }
            return StudentRecords;
        }
    }
}
