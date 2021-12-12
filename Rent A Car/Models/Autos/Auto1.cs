using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_A_Car.Models.Autos
{
    public class Auto1
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "char")]
        [MaxLength(7)]
        public string Code { get; set; }

        [StringLength(maximumLength: 25)]
        [Column(TypeName = "nvarchar(25)")]
        public string Voornaam { get; set; }

        [StringLength(maximumLength: 50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Achternaam { get; set; }

        public AutoFoto1 AutoAfbeelding { get; set; }
    }
}