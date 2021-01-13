using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Projektas.Models;
using System.Linq;

namespace Web_Projektas.Controllers
{
    public class NationalityController : Controller
    {
        private readonly projektas_dbContext _context;
        public static string ReturnNationality(int id)
        {
            //returning Nationality line
            projektas_dbContext dbcontext = new projektas_dbContext();
            string line = " ";
            foreach (Nationality nat in dbcontext.Nationalities)
            {
                if (nat.NationalityId == id)
                {
                    line = nat.Name;
                    return line;
                }
            }
            return line;
        }
    }
}
