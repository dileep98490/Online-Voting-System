using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineVotingSystem.Models
{
    public class SystemDbNaya : DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Voter> Voters{get;set;}
        public DbSet<Candidate> Candidates{get; set;}

    }
}