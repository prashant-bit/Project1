using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Required*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
