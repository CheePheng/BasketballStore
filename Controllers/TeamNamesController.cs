using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasketballStore.Data;
using BasketballStore.Models;

namespace BasketballStore.Controllers
{
    public class TeamNamesController : Controller
    {
        private readonly BasketballStoreContext _context;

        public TeamNamesController(BasketballStoreContext context)
        {
            _context = context;
        }

        // GET: TeamNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamName.ToListAsync());
        }

        // GET: TeamNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamName = await _context.TeamName
                .FirstOrDefaultAsync(m => m.TeamNameId == id);
            if (teamName == null)
            {
                return NotFound();
            }

            return View(teamName);
        }

        // GET: TeamNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamNameId,Name")] TeamName teamName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamName);
        }

        // GET: TeamNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamName = await _context.TeamName.FindAsync(id);
            if (teamName == null)
            {
                return NotFound();
            }
            return View(teamName);
        }

        // POST: TeamNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamNameId,Name")] TeamName teamName)
        {
            if (id != teamName.TeamNameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamNameExists(teamName.TeamNameId))
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
            return View(teamName);
        }

        // GET: TeamNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamName = await _context.TeamName
                .FirstOrDefaultAsync(m => m.TeamNameId == id);
            if (teamName == null)
            {
                return NotFound();
            }

            return View(teamName);
        }

        // POST: TeamNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamName = await _context.TeamName.FindAsync(id);
            if (teamName != null)
            {
                _context.TeamName.Remove(teamName);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamNameExists(int id)
        {
            return _context.TeamName.Any(e => e.TeamNameId == id);
        }
    }
}
