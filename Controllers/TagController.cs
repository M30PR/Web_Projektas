using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Projektas.Models;

namespace Web_Projektas.Controllers
{
    public class TagController : Controller
    {
        private readonly projektas_dbContext _context;
        public IActionResult Index()
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Tag> Tags = dbcontext.Tags.ToList();
            return View(Tags);
        }
        public IActionResult Details(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            Tag tag = dbcontext.Tags.Single(top => top.TagsId == id);

            return View(tag);
        }
        public static List<Quote> TagQuotes(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Quote> Quotesdb = dbcontext.Quotes.ToList();
            List<Contains1> Containsdb = dbcontext.Contains1s.ToList();
            List<Quote> QuotesList = new List<Quote>();
            foreach (Contains1 contains in Containsdb)
            {
                if(contains.TagsId == id)
                {
                    int sk = contains.Id;
                     foreach (Quote quotes in Quotesdb)
                     {

                      if (quotes.Id == sk)
                     {
                        QuotesList.Add(quotes);
                     }
                }

                }
                
            }
            return QuotesList;
        }
    }
}
