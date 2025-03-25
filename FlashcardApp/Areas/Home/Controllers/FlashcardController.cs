using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlashcardApp.Data;
using FlashcardApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace FlashcardApp.Areas.Home.Controllers
{
    [Area("Home")]
    public class FlashcardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlashcardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home/Flashcards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Flashcards.Include(f => f.Deck);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/Flashcards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.Flashcards
                .Include(f => f.Deck)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flashcard == null)
            {
                return NotFound();
            }

            return View(flashcard);
        }

        // GET: Home/Flashcards/Create
        public IActionResult Create()
        {
            ViewData["DeckId"] = new SelectList(_context.Decks, "Id", "Id");
            return View();
        }

        // POST: Home/Flashcards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeckId,Question,Answer,ImageUrl,CreatedAt")] Flashcard flashcard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flashcard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeckId"] = new SelectList(_context.Decks, "Id", "Id", flashcard.DeckId);
            return View(flashcard);
        }

        // GET: Home/Flashcards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.Flashcards.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }
            ViewData["DeckId"] = new SelectList(_context.Decks, "Id", "Id", flashcard.DeckId);
            return View(flashcard);
        }

        // POST: Home/Flashcards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeckId,Question,Answer,ImageUrl,CreatedAt")] Flashcard flashcard)
        {
            if (id != flashcard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flashcard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlashcardExists(flashcard.Id))
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
            ViewData["DeckId"] = new SelectList(_context.Decks, "Id", "Id", flashcard.DeckId);
            return View(flashcard);
        }

        // GET: Home/Flashcards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.Flashcards
                .Include(f => f.Deck)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flashcard == null)
            {
                return NotFound();
            }

            return View(flashcard);
        }

        // POST: Home/Flashcards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flashcard = await _context.Flashcards.FindAsync(id);
            if (flashcard != null)
            {
                _context.Flashcards.Remove(flashcard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlashcardExists(int id)
        {
            return _context.Flashcards.Any(e => e.Id == id);
        }
    }
}
