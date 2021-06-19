using Gestion_PFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_PFE.Data
{
    public class DbInitialise
    {
        public static void Initialise(GestionContext context)
        {
            // Look for any Etudiants.
            if (context.etudiants.Any())
            {
                return;   // DB has been seeded
            }

            var etudiant = new Etudiant[]
            {
                new Etudiant { FirstMidName = "Carson",   LastName = "Alexander", },
                new Etudiant { FirstMidName = "Meredith", LastName = "Alonso", },
                new Etudiant { FirstMidName = "Arturo",   LastName = "Anand", },
               
            };

            foreach (Etudiant s in etudiant)
            {
                context.etudiants.Add(s);
            }
            context.SaveChanges();

            var encadrant = new Encadrant[]
{
                new Encadrant { FirstMidName = "Ali",   LastName = "Issou", },
                new Encadrant { FirstMidName = "Badr", LastName = "Alim", },
              

};

            foreach (Encadrant s in encadrant)
            {
                context.encadrants.Add(s);
            }
            context.SaveChanges();


            var projets = new Projet[]
{
                new Projet {nameProjet="AA",theme="energy",description="Coucou",
                            EtudiantID = etudiant.Single(i=>i.LastName=="Alexander").ID,Encadrant= encadrant.Single(i=>i.LastName=="Issou")},
                new Projet {nameProjet="BB",theme="Automobile",description="Coucou 2 ",
                            EtudiantID = etudiant.Single(i=>i.LastName=="Alonso").ID,Encadrant= encadrant.Single(i=>i.LastName=="Alim")},

};

            foreach (Projet s in projets)
            {
                context.projets.Add(s);
            }
            context.SaveChanges();
        }

    
    }
}
