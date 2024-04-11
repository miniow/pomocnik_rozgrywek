﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pomocnik_Rozgrywek.DB;

#nullable disable

namespace Pomocnik_Rozgrywek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchID"));

                    b.Property<int>("TeamAID")
                        .HasColumnType("int");

                    b.Property<int>("TeamAScore")
                        .HasColumnType("int");

                    b.Property<int>("TeamBID")
                        .HasColumnType("int");

                    b.Property<int>("TeamBScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("TournamentID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("MatchID");

                    b.HasIndex("TeamAID");

                    b.HasIndex("TeamBID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TournamentID")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TournamentID"));

                    b.Property<string>("TournamentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.TournamentTeam", b =>
                {
                    b.Property<int>("TournamentID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("TournamentID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("TournamentTeam");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Match", b =>
                {
                    b.HasOne("Pomocnik_Rozgrywek.Models.Team", "TeamA")
                        .WithMany()
                        .HasForeignKey("TeamAID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pomocnik_Rozgrywek.Models.Team", "TeamB")
                        .WithMany()
                        .HasForeignKey("TeamBID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Pomocnik_Rozgrywek.Models.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamA");

                    b.Navigation("TeamB");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Player", b =>
                {
                    b.HasOne("Pomocnik_Rozgrywek.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Team", b =>
                {
                    b.HasOne("Pomocnik_Rozgrywek.Models.Tournament", null)
                        .WithMany("Teams")
                        .HasForeignKey("TournamentID");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.TournamentTeam", b =>
                {
                    b.HasOne("Pomocnik_Rozgrywek.Models.Team", "Team")
                        .WithMany("Tournaments")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pomocnik_Rozgrywek.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("Pomocnik_Rozgrywek.Models.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
