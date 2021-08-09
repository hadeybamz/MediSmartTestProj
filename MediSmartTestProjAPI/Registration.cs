using System;
using System.ComponentModel.DataAnnotations;

namespace MediSmartTestProjAPI
{
    public class Registration
    {
        [Key]
        public Int32 id { get; set; }

        [Required]
        [MaxLength(100)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }

        [MaxLength(100)]
        public String OtherName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(15)]
        public String Gender { get; set; }

        [MaxLength(20)]
        public String PhoneNo { get; set; }

        [MaxLength(100)]
        public String Occupation { get; set; }

        [MaxLength()]
        public String Address { get; set; }

        [MaxLength(50)]
        public String Nationality { get; set; }

        [MaxLength(50)]
        public String CountryOfResidence { get; set; }
    }
}