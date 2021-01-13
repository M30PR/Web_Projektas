using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Projektas.Models;

namespace Web_Projektas.Controllers
{
    public class AdminController : Controller
    {
        private readonly projektas_dbContext _context;
        public AdminController(projektas_dbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllQuotes()
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Quote> quotes = dbcontext.Quotes.ToList();

            return View(quotes);
        }
        public IActionResult Details(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            Quote quotes = dbcontext.Quotes.Single(top => top.Id == id);

            return View(quotes);
        }
    }
}
