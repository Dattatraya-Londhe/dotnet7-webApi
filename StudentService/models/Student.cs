using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentService.database.db.models
{
    public class Student//:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is must......")]
        public string Name { get; set; }

        public string Branch { get; set; }
        //public ICollection<Address> Address { get; set; }
    }
}
