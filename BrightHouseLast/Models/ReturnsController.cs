using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BrightHouseLast.Models
{
    [Authorize]
    public class ReturnsController : Controller
    {
        private readonly BrightHouseLastContext _context;

        public ReturnsController(BrightHouseLastContext context)
        {
            _context = context;
        }

        // GET: Returns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Returns.ToListAsync());
        }

        // GET: Returns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returns = await _context.Returns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (returns == null)
            {
                return NotFound();
            }

            return View(returns);
        }

        // GET: Returns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Returns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Returned,OrderID,Region")] Returns returns)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returns);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(returns);
        }

        // GET: Returns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returns = await _context.Returns.FindAsync(id);
            if (returns == null)
            {
                return NotFound();
            }
            return View(returns);
        }

        // POST: Returns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Returned,OrderID,Region")] Returns returns)
        {
            if (id != returns.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returns);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnsExists(returns.Id))
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
            return View(returns);
        }

        // GET: Returns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returns = await _context.Returns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (returns == null)
            {
                return NotFound();
            }

            return View(returns);
        }

        // POST: Returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var returns = await _context.Returns.FindAsync(id);
            _context.Returns.Remove(returns);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnsExists(string id)
        {
            return _context.Returns.Any(e => e.Id == id);
        }
    }
}
