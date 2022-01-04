using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstApproach.Models;

namespace DBFirstApproach.Controllers
{
    public class MstTrainnersController : Controller
    {
        private readonly GMSContext _context;

        public MstTrainnersController(GMSContext context)
        {
            _context = context;
        }

        // GET: MstTrainners
        public async Task<IActionResult> Index()
        {
            return View(await _context.MstTrainner.ToListAsync());
        }

        // GET: MstTrainners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTrainner = await _context.MstTrainner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mstTrainner == null)
            {
                return NotFound();
            }

            return View(mstTrainner);
        }

        // GET: MstTrainners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MstTrainners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainnerName,Gender,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy")] MstTrainner mstTrainner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstTrainner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mstTrainner);
        }

        // GET: MstTrainners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTrainner = await _context.MstTrainner.FindAsync(id);
            if (mstTrainner == null)
            {
                return NotFound();
            }
            return View(mstTrainner);
        }

        // POST: MstTrainners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainnerName,Gender,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy")] MstTrainner mstTrainner)
        {
            if (id != mstTrainner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstTrainner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstTrainnerExists(mstTrainner.Id))
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
            return View(mstTrainner);
        }

        // GET: MstTrainners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstTrainner = await _context.MstTrainner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mstTrainner == null)
            {
                return NotFound();
            }

            return View(mstTrainner);
        }

        // POST: MstTrainners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstTrainner = await _context.MstTrainner.FindAsync(id);
            _context.MstTrainner.Remove(mstTrainner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstTrainnerExists(int id)
        {
            return _context.MstTrainner.Any(e => e.Id == id);
        }
    }
}
