using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MediSmartTestProjAPI.Models
{
    public partial class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string OtherName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string Gender { get; set; }

        [MaxLength(20)]
        public string PhoneNo { get; set; }

        [MaxLength(100)]
        public string Occupation { get; set; }

        [MaxLength()]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Nationality { get; set; }

        [MaxLength(50)]
        public string CountryOfResidence { get; set; }
    }
}
