using System.ComponentModel.DataAnnotations;

namespace StudentService.database.db.models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
