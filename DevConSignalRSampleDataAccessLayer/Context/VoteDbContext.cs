using DevConSignalRModels.DTO;
using DevConSignalRModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DevConSignalRSampleDataAccessLayer.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options)
            : base(options)
        { }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<CandidateVote> CandidateVotes { get; set; }
    }
}
