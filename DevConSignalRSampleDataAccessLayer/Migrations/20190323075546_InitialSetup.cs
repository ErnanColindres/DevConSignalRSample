using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevConSignalRSampleDataAccessLayer.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var view = @"Create View [dbo].CandidateVotes
                As 
                (Select c.Id, c.Anime, c.ProfilePhoto, c.[Name], c.Bio, Count(v.Id) as Votes from [DevConSignalRCodeCamp].[dbo].[Candidates] c
                Inner Join [DevConSignalRCodeCamp].[dbo].[Votes] v On c.Id = v.CandidateId
                Group By v.Id, c.Id, c.Anime, c.ProfilePhoto, c.[Name], c.Bio)";

            migrationBuilder.Sql(view);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view dbo.CandidateVotes");
        }
    }
}
