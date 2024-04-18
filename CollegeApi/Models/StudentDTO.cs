using CollegeApi.Validation;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollegeApi.Models
{
    public class StudentDTO
    {
      
        public int id { get; set; }
      

        public string? name { get; set; }
  
        public string? email { get; set; }

        public long phone { get; set; }
        [DateCheck]
        public DateTime AdmissionDate { get; set; }

    }
}
