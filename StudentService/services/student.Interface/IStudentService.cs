using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentService.database.db.models;
using StudentService.database.dto;

namespace StudentService.services.student.Interface
{

    public interface IStudentService
    {
        public Task<Student?> CreateStudent(Student student);

        public Task<List<Student>?> GetAllStudents();

        public Task<Student?> GetStudentById(int id);

        public Task<Student> UpdateStudent(Student student);

        public Task<Student> DeleteStudent(int id);
    }
}
