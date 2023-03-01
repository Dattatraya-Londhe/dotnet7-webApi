using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentService.database.db.config;
using StudentService.database.db.models;
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
       /* public EntityEntry<Student> CreateStudent(Student student)
        {
            try
            {
                Console.WriteLine("Inside the Service....");
                Console.WriteLine(student.ToString());
                var record = this._db.Students.Add(student);
                Console.WriteLine(record.ToString());
                Console.WriteLine("Inside the Service????");
                return record;
                
            }
            catch(Exception e) 
            {
               throw new Exception("500 -Internal Server Error ");
            }
        }*/

        public async Task<Student?> CreateStudent(Student student)
        {
            try
            {
                var record = await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return record.Entity;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                var record = await _db.Students.FirstOrDefaultAsync(c=>c.Id== id);
                if (record != null)
                {
                    var student = _db.Students.Remove(record).Entity;
                    await _db.SaveChangesAsync();
                    return student;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Student>?> GetAllStudents()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Student?> GetStudentById(int id)
        {
            try
            {
                return await _db.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
