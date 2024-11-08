﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HWK4.Data;
using HWK4.Models;

namespace HWK4.Controllers
{
    public class stepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public stepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: steps
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.steps.ToListAsync());
        }

        ///GET: steps/SearchForm/
        public async Task<IActionResult> ShowFrom()
        {
            return View();
        }

        /// <summary>
        /// Data Analasys
        /// GET: steps/ShowSearchResults
        /// </summary>
        /// <param name="SearchPhrase"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.steps.Where(j => j.Day.Contains(SearchPhrase)).ToListAsync());
        }


        /// <summary>
        /// GET: steps/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.steps == null)
            {
                return NotFound();
            }

            var steps = await _context.steps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (steps == null)
            {
                return NotFound();
            }

            return View(steps);
        }

        /// <summary>
        /// GET: steps/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: steps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Day,StepsToday")] steps steps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(steps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(steps);
        }

        /// <summary>
        /// GET: steps/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.steps == null)
            {
                return NotFound();
            }

            var steps = await _context.steps.FindAsync(id);
            if (steps == null)
            {
                return NotFound();
            }
            return View(steps);
        }

        /// <summary>
        /// POST: steps/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Day,StepsToday")] steps steps)
        {
            if (id != steps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(steps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!stepsExists(steps.Id))
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
            return View(steps);
        }

        /// <summary>
        /// GET: steps/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.steps == null)
            {
                return NotFound();
            }

            var steps = await _context.steps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (steps == null)
            {
                return NotFound();
            }

            return View(steps);
        }

        /// <summary>
        /// POST: steps/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.steps == null)
            {
                return Problem("Entity set 'ApplicationDbContext.steps'  is null.");
            }
            var steps = await _context.steps.FindAsync(id);
            if (steps != null)
            {
                _context.steps.Remove(steps);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Data Analysis
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/report")]
        public async Task<string> GetReport()
        {

            var Steps = await _context.steps.ToListAsync();
            return steps.Reports(Steps);

        }



        private bool stepsExists(int id)
        {
            return _context.steps.Any(e => e.Id == id);
        }
    }
}
    


