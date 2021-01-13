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
    public class ProfessionController : Controller
    {
        private readonly projektas_dbContext _context;
        public static string ReturnProfession(int id)
        {
            //returning Profession line
            projektas_dbContext dbcontext = new projektas_dbContext();
            string line = " ";
            foreach (Profession prof in dbcontext.Professions)
            {
                if (prof.ProfesionId == id)
                {
                    line = prof.Name;
                    return line;
                }
            }
            return line;
        }
    }
}
