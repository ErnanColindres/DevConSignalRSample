﻿// <auto-generated />
using System;
using DevConSignalRSampleDataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevConSignalRSampleDataAccessLayer.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20190323075546_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevConSignalRModels.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anime");

                    b.Property<string>("Bio");

                    b.Property<string>("Name");

                    b.Property<string>("ProfilePhoto");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("DevConSignalRModels.Entities.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CandidateId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("DevConSignalRModels.Entities.Vote", b =>
                {
                    b.HasOne("DevConSignalRModels.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}