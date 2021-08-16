using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestProjAPI.Models
{
    public class RegistrationDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string otherName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string phoneNo { get; set; }
        public string occupation { get; set; }
        public string address { get; set; }
        public string nationality { get; set; }
        public string countryOfResidence { get; set; }
    }
}
