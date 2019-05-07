using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class SoundTrackController : Controller
    {
        private readonly AppDbContext _context;

        public SoundTrackController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SoundTrack
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoundTrack.ToListAsync());
        }

        // GET: SoundTrack/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundTrack = await _context.SoundTrack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soundTrack == null)
            {
                return NotFound();
            }

            return View(soundTrack);
        }

        // GET: SoundTrack/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoundTrack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ApplicationUserId")] SoundTrack soundTrack)
        {
            if (ModelState.IsValid)
            {
                soundTrack.Id = Guid.NewGuid();
                _context.Add(soundTrack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soundTrack);
        }

        // GET: SoundTrack/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundTrack = await _context.SoundTrack.FindAsync(id);
            if (soundTrack == null)
            {
                return NotFound();
            }
            return View(soundTrack);
        }

        // POST: SoundTrack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,ApplicationUserId")] SoundTrack soundTrack)
        {
            if (id != soundTrack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soundTrack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoundTrackExists(soundTrack.Id))
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
            return View(soundTrack);
        }

        // GET: SoundTrack/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soundTrack = await _context.SoundTrack
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soundTrack == null)
            {
                return NotFound();
            }

            return View(soundTrack);
        }

        // POST: SoundTrack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var soundTrack = await _context.SoundTrack.FindAsync(id);
            _context.SoundTrack.Remove(soundTrack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoundTrackExists(Guid id)
        {
            return _context.SoundTrack.Any(e => e.Id == id);
        }
    }
}
