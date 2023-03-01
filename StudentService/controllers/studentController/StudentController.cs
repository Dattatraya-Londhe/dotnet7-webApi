using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.database.db.config;
using StudentService.database.db.models;
using StudentService.database.dto;
using StudentService.database.mapper;
using StudentService.services.student.Interface;
using StudentService.services.student.service;
using System.Security.Cryptography.Xml;

namespace StudentService.controllers.studentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            this._service= service;
        }
        //private readonly ApplicationDbContext _db;
        //public StudentController(ApplicationDbContext db)
        //{
        //    this._db = db;
        //}
        /*[HttpPost]
        public ActionResult<StudentDto> CreateStudent([FromBody] Student student)
        {
            try
            {
                Console.WriteLine("Inside the Controller....");
                Console.WriteLine(student.ToString());
                var record = this._service.CreateStudent(student);
                Console.WriteLine("Inside the Controller???");
                //var Dto = StudentMapper.ToStudentDto(record);
                return Ok(record);

                //var record = this._db.Students.Add(student);
                //this._db.SaveChanges();
                //return Ok(record);
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent([FromBody]Student student)
        {
            try
            {
                var record = await _service.CreateStudent(student);
                if (record == null)
                {
                    return BadRequest("Unable to Process");
                }
                return Ok(StudentMapper.ToStudentDto(record));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudent()
        {
            try
            {
                var record = await _service.GetAllStudents();
                if (record== null)
                {
                    return NoContent();
                }
                return Ok(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            try
            {
                var record = await _service.GetStudentById(id);
                if (record == null)
                {
                    return NoContent();
                }
                return Ok(StudentMapper.ToStudentDto(record));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDto>> DeleteStudent(int id)
        {
            try
            {
                var record = await _service.DeleteStudent(id);
                if (record == null)
                {
                    return NotFound();
                }
                return Ok(StudentMapper.ToStudentDto(record));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
