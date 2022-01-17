﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFramework_ClassLibrary.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
