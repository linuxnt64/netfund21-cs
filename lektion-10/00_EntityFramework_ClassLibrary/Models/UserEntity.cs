using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFramework_ClassLibrary.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        [Key]                       
        public int Id { get; set; }

        [Required]                  
        [StringLength(50)]          
        public string FirstName { get; set; }

        [Required]                  
        [StringLength(50)]         
        public string LastName { get; set; }

        [Required]                  
        [StringLength(100)]
        [Unicode(false)]            
        public string Email { get; set; }

        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
