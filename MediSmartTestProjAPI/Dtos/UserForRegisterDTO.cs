using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestProjAPI.Dtos
{
    public class UserForRegisterDTOW
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You Must Specify password between 4 and 8 characters")]
        public string password { get; set; }
    }
}
