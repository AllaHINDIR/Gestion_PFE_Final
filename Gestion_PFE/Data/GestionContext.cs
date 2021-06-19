using Gestion_PFE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_PFE.Data
{
    public class GestionContext : DbContext
    {
        public GestionContext(DbContextOptions<GestionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etudiant>().ToTable("Etudiant");
            modelBuilder.Entity<Encadrant>().ToTable("Encadrant");
            modelBuilder.Entity<Projet>().ToTable("Projet");
            modelBuilder.Entity<Demande>().ToTable("Demande");


         
        }

        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Encadrant> encadrants { get; set; }
        public DbSet<Projet> projets { get; set; }
        
        public DbSet<Demande> Demandes { get; set; }
        
        public DbSet<Gestion_PFE.Models.User> User { get; set; }
    }
}
