using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_PFE.Models
{
    public class Projet
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Nom de Projet")]
        public string nameProjet { get; set; }
        [Required]
        [StringLength(50)]
        public string theme { get; set; }
        public string description { get; set; }
        [ForeignKey("EncadrantID")]
        public int EncadrantID { get; set; }
        public Encadrant Encadrant { get; set; }
        [ForeignKey("EtudiantID")]
        public int EtudiantID { get; set; }
        public Etudiant Etudiant { get; set; }
        
    }
}
