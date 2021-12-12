﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class Beheerder
    {
        [Key]
        public string BeheerderId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }

        public int TelefoonNummer { get; set; }
    }
}
