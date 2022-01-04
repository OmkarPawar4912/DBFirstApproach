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
    public class TblPlansController : Controller
    {
        private readonly GMSContext _context;

        public TblPlansController(GMSContext context)
        {
            _context = context;
        }

        // GET: TblPlans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblPlan.ToListAsync());
        }

        // GET: TblPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPlan = await _context.TblPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPlan == null)
            {
                return NotFound();
            }

            return View(tblPlan);
        }

        // GET: TblPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPlans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PlanId,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy")] TblPlan tblPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPlan);
        }

        // GET: TblPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPlan = await _context.TblPlan.FindAsync(id);
            if (tblPlan == null)
            {
                return NotFound();
            }
            return View(tblPlan);
        }

        // POST: TblPlans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PlanId,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy")] TblPlan tblPlan)
        {
            if (id != tblPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPlanExists(tblPlan.Id))
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
            return View(tblPlan);
        }

        // GET: TblPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPlan = await _context.TblPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPlan == null)
            {
                return NotFound();
            }

            return View(tblPlan);
        }

        // POST: TblPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPlan = await _context.TblPlan.FindAsync(id);
            _context.TblPlan.Remove(tblPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPlanExists(int id)
        {
            return _context.TblPlan.Any(e => e.Id == id);
        }
    }
}
