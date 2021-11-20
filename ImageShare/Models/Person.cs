using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.Models
{
    public class Person
    {
      

      

        [Key]
        [Column("User_id")]
        public Guid id { get; set; }

        [Required]
        [EmailAddress]
        [Column("User_Email")]
        public String email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage ="Name can only be 10 Characters Long")]
        [Column("User_Name")]
        public String name { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(10, ErrorMessage = "Surname can only be 10 Characters Long")]
        [Column("User_Surname")]
        public String surname { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Column("User_Contact")]
        public string contact{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column("User_Password")]
        public string password { get; set; }
    }
}
