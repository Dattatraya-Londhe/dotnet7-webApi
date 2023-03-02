using Microsoft.AspNetCore.Mvc;
using StudentService.database.db.models;
using StudentService.database.dto;
using StudentService.database.mapper;
using StudentService.dtos;
using StudentService.models;
using StudentService.services.student.Interface;


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
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> CreateStudent([FromBody]AddStudentDto addStudent)
        {
            try
            {
                var student = StudentMapper.ToStudent(addStudent);
                var response = await _service.CreateStudent(student);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new ServiceResponse<GetStudentDto>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<GetStudentDto>>> GetAllStudent()
        {
            try
            {
                var response = await _service.GetAllStudents();
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<GetStudentDto>
                {
                    Success = false,
                    Message = ex.Message,
                }) ;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudentById(int id)
        {
            try
            {
                var response = await _service.GetStudentById(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<GetStudentDto>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetStudentDto>> DeleteStudent(int id)
        {
            try
            {
                var response = await _service.DeleteStudent(id);
                if (!response.Success)
                {
                    return BadRequest(response) ;
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<GetStudentDto>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody]AddStudentDto updateStudent)
        {
            try
            {
                var student = StudentMapper.ToStudent(updateStudent);
                var response = await _service.UpdateStudent(id,student);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new ServiceResponse<GetStudentDto>
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }
    }
}
