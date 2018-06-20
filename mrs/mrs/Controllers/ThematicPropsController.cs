using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mrs.ApplicationCore.Entities;
using mrs.Infrastructure.Data;

namespace mrs.Controllers
{
    public class ThematicPropsController : Controller
    {
        private readonly MrsContext _context;

        public ThematicPropsController(MrsContext context)
        {
            _context = context;
        }

        // GET: ThematicProps
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThematicProps.ToListAsync());
        }

        // GET: ThematicProps/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thematicProp = await _context.ThematicProps
                .SingleOrDefaultAsync(m => m.Id == id);
            if (thematicProp == null)
            {
                return NotFound();
            }

            return View(thematicProp);
        }

        // GET: ThematicProps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThematicProps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropName,Id")] ThematicProp thematicProp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thematicProp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thematicProp);
        }

        // GET: ThematicProps/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thematicProp = await _context.ThematicProps.SingleOrDefaultAsync(m => m.Id == id);
            if (thematicProp == null)
            {
                return NotFound();
            }
            return View(thematicProp);
        }

        // POST: ThematicProps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PropName,Id")] ThematicProp thematicProp)
        {
            if (id != thematicProp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thematicProp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThematicPropExists(thematicProp.Id))
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
            return View(thematicProp);
        }

        // GET: ThematicProps/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thematicProp = await _context.ThematicProps
                .SingleOrDefaultAsync(m => m.Id == id);
            if (thematicProp == null)
            {
                return NotFound();
            }

            return View(thematicProp);
        }

        // POST: ThematicProps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var thematicProp = await _context.ThematicProps.SingleOrDefaultAsync(m => m.Id == id);
            _context.ThematicProps.Remove(thematicProp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThematicPropExists(long id)
        {
            return _context.ThematicProps.Any(e => e.Id == id);
        }
    }
}
