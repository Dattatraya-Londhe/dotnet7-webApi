using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentService.database.db.models;
using StudentService.database.dto;
using StudentService.dtos;
using StudentService.models;

namespace StudentService.services.student.Interface
{

    public interface IStudentService
    {
        public Task<ServiceResponse<GetStudentDto?>> CreateStudent(Student student);

        public Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();

        public Task<ServiceResponse<GetStudentDto>> GetStudentById(int id);

        public Task<ServiceResponse<GetStudentDto>> UpdateStudent(int id,Student student);

        public Task<ServiceResponse<GetStudentDto>> DeleteStudent(int id);
    }
}
