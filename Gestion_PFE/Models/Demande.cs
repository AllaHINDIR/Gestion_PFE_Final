using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_PFE.Models
{
    public enum Etat
    {
        Encours,
        Acceptée,
        Refusée
    }
    public class Demande
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Titre")]
        [StringLength(50, MinimumLength = 2)]
        public string titre { get; set; }
        [Required]
        public int EncadrantID { get; set; }
        public Encadrant Encadrant { get; set; }
        [Required]
        [ForeignKey("EtudiantID")]
        public int EtudiantID { get; set; }
        public Etudiant Etudiant { get; set; }
        public Etat etat { get; set; } = Etat.Encours;

    }
}
