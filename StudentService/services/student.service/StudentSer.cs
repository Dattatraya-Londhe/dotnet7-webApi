using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentService.database.db.config;
using StudentService.database.db.models;
using StudentService.database.dto;
using StudentService.database.mapper;
using StudentService.dtos;
using StudentService.models;
using StudentService.services.student.Interface;

namespace StudentService.services.student.service
{
    public class StudentSer : IStudentService
    {
        private readonly ApplicationDbContext _db;

        public StudentSer(ApplicationDbContext db)
        {
            this._db = db;
        }
      public async Task<ServiceResponse<GetStudentDto>> CreateStudent(Student student)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            try
            {
                var record = await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                response.Data = StudentMapper.ToGetStudentDto(record.Entity);
                response.Message = "Student created successfully";
                return response; 
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<GetStudentDto>?> DeleteStudent(int id)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            try
            {
                var record = await _db.Students.FirstOrDefaultAsync(c=>c.Id== id);
                if (record != null)
                {
                    var student = _db.Students.Remove(record);
                    await _db.SaveChangesAsync();
                    response.Data = StudentMapper.ToGetStudentDto(student.Entity);
                    response.Message = "Student Deleted successfully";
                    return response;
                }
                response.Message = $"Student with Id {id} not found";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            ServiceResponse<List<GetStudentDto>> response = new ServiceResponse<List<GetStudentDto>>();
            try
            {
                var records = await _db.Students.ToListAsync();
                response.Data = StudentMapper.ToGetStudentDto(records);
                response.Message = "Students information retrieved successfully";
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            try
            {
                var record = await _db.Students.FindAsync(id);
                if(record is not null)
                {
                    response.Data = StudentMapper.ToGetStudentDto(record);
                    response.Message = "Student information retrieved successfully"
                    return response;
                }
                response.Message = $"Student with Id = {id} not found";
                return response;
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(int id, Student student)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            try
            {
                var record = await _db.Students.FirstOrDefaultAsync(c=>c.Id== id);
                if (record != null)
                {
                    record.Name = student.Name;
                    record.Branch = student.Branch;
                    await _db.SaveChangesAsync();
                    response.Data= StudentMapper.ToGetStudentDto(record);
                    response.Message = "Student information updated successfully";
                    return response;
                }
                response.Message = $"Student with Id {id} not found";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
