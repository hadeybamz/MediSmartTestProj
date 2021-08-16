using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestProjAPI.Models
{
    public class JsonMessage<T>
    {
        public List<T> Results { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

    }
}
