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
    public class TopicsController : Controller
    {
        private readonly projektas_dbContext _context;

        public TopicsController(projektas_dbContext context)
        {
            _context = context;
        }

        // GET: Topics
        public IActionResult Index()
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Topic> Topics = dbcontext.Topics.ToList();

            return View(Topics);
        }

        // GET: Topics/Details/5
        public IActionResult Details(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            Topic Topics = dbcontext.Topics.Single(top => top.TopicId == id);

            return View(Topics);
        }
        public static List<Quote> TopicQuotes(int id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Quote> Quotesdb = dbcontext.Quotes.ToList();
            List<Quote> QuotesList = new List<Quote>();
            foreach (Quote quotes in Quotesdb)
            {
                if (quotes.TopicId == id)
                {
                    QuotesList.Add(quotes);
                }
            }
            return QuotesList;
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.TopicId == id);
        }
    }
}
