using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspNetMVC.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Unicode(false)]
        public string Email { get; set; }
    }
}
