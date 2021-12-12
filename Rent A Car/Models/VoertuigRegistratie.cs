using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class VoertuigRegistratie
    {
        [Key]
        public int VoertuigId { get; set; }
        public int MedewerkerId { get; set; }
        public string Merk { get; set; }
        public int Dagprijs { get; set; }
        public string Type { get; set; }
        public string Kenteken { get; set; }
        public string Schakelaar { get; set; }
        public string Brandstof { get; set; }
        public string AantalZitPlaats { get; set; }
        public bool Airco { get; set; }
        public string AantalDeur { get; set; }
        public DateTime BeginDatum { get; set; }
        public int AantalDagen { get; set; }
        public double TotalePrijs
        {
            get
            {
                return AantalDagen * Dagprijs;
            }

        }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
