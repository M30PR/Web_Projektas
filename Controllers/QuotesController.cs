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
    public class QuotesController : Controller
    {
        private readonly projektas_dbContext _context;

        public QuotesController(projektas_dbContext context)
        {
            _context = context;
        }

        // GET: Quotes
        public IActionResult Index()
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            List<Quote> quotes = dbcontext.Quotes.ToList();

            return View(quotes);
        }

        // GET: Quotes/Details/5
        public IActionResult Details(int? id)
        {
            projektas_dbContext dbcontext = new projektas_dbContext();
            Quote quotes = dbcontext.Quotes.Single(top => top.Id == id);

            return View(quotes);
        }

        // GET: Quotes/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId");
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,CreatingDate,UserId,TopicId,AuthorId")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", quote.AuthorId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", quote.TopicId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", quote.UserId);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", quote.AuthorId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", quote.TopicId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", quote.UserId);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,CreatingDate,UserId,TopicId,AuthorId")] Quote quote)
        {
            if (id != quote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", quote.AuthorId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", quote.TopicId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", quote.UserId);
            return View(quote);
        }

        // GET: Quotes/Delete/5
        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }
    }
}
