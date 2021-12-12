using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class Factuur
    {
        public int FactuurId {get; set;}
        public DateTime Factuurdatum { get { return DateTime.Now; } }

    }
}
