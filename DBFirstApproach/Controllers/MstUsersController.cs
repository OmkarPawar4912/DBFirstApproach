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
    public class MstUsersController : Controller
    {
        private readonly GMSContext _context;

        public MstUsersController(GMSContext context)
        {
            _context = context;
        }

        // GET: MstUsers
        public async Task<IActionResult> Index()
        {
            var gMSContext = _context.MstUser.Include(m => m.Plan).Include(m => m.Trainner);
            return View(await gMSContext.ToListAsync());
        }

        // GET: MstUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstUser = await _context.MstUser
                .Include(m => m.Plan)
                .Include(m => m.Trainner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mstUser == null)
            {
                return NotFound();
            }

            return View(mstUser);
        }

        // GET: MstUsers/Create
        public IActionResult Create()
        {
            ViewData["PlanId"] = new SelectList(_context.TblPlan, "Id", "Id");
            ViewData["TrainnerId"] = new SelectList(_context.MstTrainner, "Id", "TrainnerName");
            return View();
        }

        // POST: MstUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,Name,Phone,Age,Gender,TrainnerId,PlanId,Role,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy")] MstUser mstUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanId"] = new SelectList(_context.TblPlan, "Id", "Id", mstUser.PlanId);
            ViewData["TrainnerId"] = new SelectList(_context.MstTrainner, "Id", "TrainnerName", mstUser.TrainnerId);
            return View(mstUser);
        }

        // GET: MstUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstUser = await _context.MstUser.FindAsync(id);
            if (mstUser == null)
            {
                return NotFound();
            }
            ViewData["PlanId"] = new SelectList(_context.TblPlan, "Id", "Id", mstUser.PlanId);
            ViewData["TrainnerId"] = new SelectList(_context.MstTrainner, "Id", "TrainnerName", mstUser.TrainnerId);
            return View(mstUser);
        }

        // POST: MstUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,Name,Phone,Age,Gender,TrainnerId,PlanId,Role,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy")] MstUser mstUser)
        {
            if (id != mstUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mstUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MstUserExists(mstUser.Id))
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
            ViewData["PlanId"] = new SelectList(_context.TblPlan, "Id", "Id", mstUser.PlanId);
            ViewData["TrainnerId"] = new SelectList(_context.MstTrainner, "Id", "TrainnerName", mstUser.TrainnerId);
            return View(mstUser);
        }

        // GET: MstUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mstUser = await _context.MstUser
                .Include(m => m.Plan)
                .Include(m => m.Trainner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mstUser == null)
            {
                return NotFound();
            }

            return View(mstUser);
        }

        // POST: MstUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mstUser = await _context.MstUser.FindAsync(id);
            _context.MstUser.Remove(mstUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MstUserExists(int id)
        {
            return _context.MstUser.Any(e => e.Id == id);
        }
    }
}
