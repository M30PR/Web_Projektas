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
    public class AuthorsController : Controller
    {
        private readonly projektas_dbContext _context;

        public AuthorsController(projektas_dbContext context)
        {
            _context = context;
        }

        // GET: Authors
        public IActionResult Index()
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Author> Authors = dbcontext.Authors.ToList();

            return View(Authors);
        }
        public IActionResult Details(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            Author Authors = dbcontext.Authors.Single(author => author.AuthorId == id);

            return View(Authors);
        }
        public static List<Quote> AuthorQuotes(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Quote> Quotesdb = dbcontext.Quotes.ToList();
            List<Quote> QuotesList = new List<Quote>();
            foreach (Quote quotes in Quotesdb)
            {
                if(quotes.AuthorId == id)
                {
                    QuotesList.Add(quotes);
                }
            }
            return QuotesList;
        }
        public static string ReturnAuthor(int id)
        {
            //returning Author line
            projektas_dbContext dbcontext = new projektas_dbContext();
            string line = " ";
            foreach (Author aut in dbcontext.Authors)
            {
                if (aut.AuthorId == id)
                {
                     line = "-" + aut.Name + " " + aut.Surname;
                    return line;
                }
            }
            return line;
        }
    }
}
