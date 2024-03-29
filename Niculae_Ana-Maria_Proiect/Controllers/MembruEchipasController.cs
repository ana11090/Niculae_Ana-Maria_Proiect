﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Niculae_Ana_Maria_Proiect.Data;
using Niculae_Ana_Maria_Proiect.Models;

namespace Niculae_Ana_Maria_Proiect.Controllers
{
    public class MembruEchipasController : Controller
    {
        private readonly LibraryContext _context;

        public MembruEchipasController(LibraryContext context)
        {
            _context = context;
        }

        // GET: MembruEchipas
        public async Task<IActionResult> Index()
        {
              return _context.MembriEchipa != null ? 
                          View(await _context.MembriEchipa.ToListAsync()) :
                          Problem("Entity set 'LibraryContext.MembriEchipa'  is null.");
        }

        // GET: MembruEchipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembriEchipa == null)
            {
                return NotFound();
            }

            var membruEchipa = await _context.MembriEchipa
                .FirstOrDefaultAsync(m => m.MembruEchipaId == id);
            if (membruEchipa == null)
            {
                return NotFound();
            }

            return View(membruEchipa);
        }

        // GET: MembruEchipas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembruEchipas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembruEchipaId,Nume")] MembruEchipa membruEchipa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membruEchipa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membruEchipa);
        }

        // GET: MembruEchipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MembriEchipa == null)
            {
                return NotFound();
            }

            var membruEchipa = await _context.MembriEchipa.FindAsync(id);
            if (membruEchipa == null)
            {
                return NotFound();
            }
            return View(membruEchipa);
        }

        // POST: MembruEchipas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembruEchipaId,Nume")] MembruEchipa membruEchipa)
        {
            if (id != membruEchipa.MembruEchipaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membruEchipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembruEchipaExists(membruEchipa.MembruEchipaId))
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
            return View(membruEchipa);
        }

        // GET: MembruEchipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembriEchipa == null)
            {
                return NotFound();
            }

            var membruEchipa = await _context.MembriEchipa
                .FirstOrDefaultAsync(m => m.MembruEchipaId == id);
            if (membruEchipa == null)
            {
                return NotFound();
            }

            return View(membruEchipa);
        }

        // POST: MembruEchipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembriEchipa == null)
            {
                return Problem("Entity set 'LibraryContext.MembriEchipa'  is null.");
            }
            var membruEchipa = await _context.MembriEchipa.FindAsync(id);
            if (membruEchipa != null)
            {
                _context.MembriEchipa.Remove(membruEchipa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembruEchipaExists(int id)
        {
          return (_context.MembriEchipa?.Any(e => e.MembruEchipaId == id)).GetValueOrDefault();
        }
    }
}
