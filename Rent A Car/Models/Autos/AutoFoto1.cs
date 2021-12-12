using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_A_Car.Models
{
    public class AutoFoto1
    {
        [Key] [StringLength(maximumLength: 50)] 
        public string Bestandsnaam { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] Foto { get; set; }

        [ForeignKey("Auto1")]
        public Autos.Auto1 Voertuig { get; set; }
    }
}