using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestProjAPI.Models
{
    public class RegistrationDTOW
    {
        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string lastName { get; set; }

        [MaxLength(100)]
        public string otherName { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [MaxLength(15)]
        public string gender { get; set; }

        [MaxLength(20)]
        public string phoneNo { get; set; }

        [MaxLength(100)]
        public string occupation { get; set; }

        [MaxLength()]
        public string address { get; set; }

        [MaxLength(50)]
        public string nationality { get; set; }

        [MaxLength(50)]
        public string countryOfResidence { get; set; }
    }
}
