using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineVotingSystem.Models
{
    public class User
    {   
         [DisplayName("Username")]
         [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
       
       
        [DisplayName("Type of User")]
        public string TypeOfUser { get; set; }



        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //   // var field = new[] {"TypeOfUser"};
        //    if (!(TypeOfUser == "Student" || TypeOfUser == "Candidate" || TypeOfUser == "Admin"))
        //        yield return new ValidationResult("Please specify one of the following values {Admin,Student,Candidate}");


        //}
    }
}