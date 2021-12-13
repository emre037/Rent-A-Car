
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Emre_Erdem.Utility
{
    public static class Helper
    {
        public static readonly string Medewerker = "Medewerker";
        public static readonly string Customer = "Klant";
        public static readonly string Beheerder = "Beheerder";




        public static List<SelectListItem> AdminRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {

                new SelectListItem{ Value=Helper.Medewerker, Text=Helper.Medewerker}
            };
            return items.OrderBy(s => s.Text).ToList();
        }
        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
             
                new SelectListItem{ Value=Helper.Customer, Text=Helper.Customer}
            };
            return items.OrderBy(s => s.Text).ToList();
        }
       

    }
}
