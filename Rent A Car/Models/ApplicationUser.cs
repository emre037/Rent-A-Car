using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{

    public class ApplicationUser : IdentityUser

    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(MiddleName))
                {
                    return FirstName + " " + LastName;
                }
                else
                {
                    return FirstName + " " + MiddleName + " " + LastName;
                }

            }

        }

    }
}
    
