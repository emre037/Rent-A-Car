using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class VoertuigReservatie
    {
        [Key]
        public int VoertuigId { get; set; }
        public int KlantId { get; set; }
        public string AutoType { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
