using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Voter
    {
                 [Required]
        public string  VoterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        public int Voted { get; set; }
    }
}