using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
    public class Candidate
    {

        public string CandidateId { get; set; }
        [Required]
        public string Society { get; set; }
        [Required]
        public string Manifesto { get; set; }
        public int Votes { get; set; }
    }
}