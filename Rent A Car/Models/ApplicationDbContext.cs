using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rent_A_Car.Models;

namespace Rent_A_Car.Models
{
   
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
                    
            
    }
        public DbSet<VoertuigRegistratie> VoertuigRegistratie { get; set; }
        public DbSet<VoertuigReservatie> VoertuigReservatie { get; set; }
        public DbSet<Autos.Auto1> Auto1s
        {
            get; set;

        }
        public DbSet<AutoFoto1> AutoFoto1s { get; set; }
        public DbSet<Rent_A_Car.Models.VoertuigRegistratie> Factuur { get; set; }
        public DbSet<Rent_A_Car.Models.Medewerker> Medewerker { get; set; }
        public DbSet<RegisterViewModel> RegisterViewModel { get; set; }
      

    }
    }

