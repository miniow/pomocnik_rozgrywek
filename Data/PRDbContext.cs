﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Models;

namespace Pomocnik_Rozgrywek.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Pearson> People { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Competition> Tournaments { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Season> Seasons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pearson>()
                .HasOne(p => p.CurrentTeam)
                .WithMany(t => t.Squad)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Season)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Competition)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}