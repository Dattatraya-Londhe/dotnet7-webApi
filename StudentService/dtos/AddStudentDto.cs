using System.ComponentModel.DataAnnotations;

namespace StudentService.dtos
{
    public class AddStudentDto
    {
        public string Name { get; set; }

        public string Branch { get; set; }
    }
}
