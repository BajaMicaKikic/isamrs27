using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mrs.ApplicationCore.Entities;
using mrs.Infrastructure.Data;

namespace mrs.Controllers
{
    public class PropAdsController : Controller
    {
        private readonly MrsContext _context;

        public PropAdsController(MrsContext context)
        {
            _context = context;
        }

        // GET: PropAds
        public async Task<IActionResult> Index()
        {
            var mrsContext = _context.PropAds.Include(p => p.ThematicProp).Include(p => p.User);
            return View(await mrsContext.ToListAsync());
        }

        // GET: PropAds/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propAd = await _context.PropAds
                .Include(p => p.ThematicProp)
                .Include(p => p.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (propAd == null)
            {
                return NotFound();
            }

            return View(propAd);
        }
        public async Task<IActionResult>  Reserved(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var propAd = await _context.PropAds
               .Include(p => p.ThematicProp)
               .Include(p => p.User)
               .SingleOrDefaultAsync(m => m.Id == id);
            if (propAd.UserReservedId == null)
            {
                propAd.UserReservedId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                _context.SaveChanges();
                return View(propAd);
            }
            return NotFound();
        }

        // GET: PropAds/Create
        public IActionResult Create()
        {
            ViewData["ThematicPropId"] = new SelectList(_context.ThematicProps, "Id", "PropName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "EmailAddress");
            return View();
        }

        // POST: PropAds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ThematicPropId,PropPrice,PropDescription,EndBidDate,Id")] PropAd propAd)
        {
            if (ModelState.IsValid)
            {
                propAd.UserId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                _context.Add(propAd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ThematicPropId"] = new SelectList(_context.ThematicProps, "Id", "PropName", propAd.ThematicPropId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "EmailAddress", propAd.UserId);
            return View(propAd);
        }

        // GET: PropAds/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propAd = await _context.PropAds.SingleOrDefaultAsync(m => m.Id == id);
            if (propAd == null)
            {
                return NotFound();
            }
            ViewData["ThematicPropId"] = new SelectList(_context.ThematicProps, "Id", "PropName", propAd.ThematicPropId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "EmailAddress", propAd.UserId);
            return View(propAd);
        }

        // POST: PropAds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserId,ThematicPropId,PropPrice,PropDescription,EndBidDate,Id")] PropAd propAd)
        {
            if (id != propAd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propAd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropAdExists(propAd.Id))
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
            ViewData["ThematicPropId"] = new SelectList(_context.ThematicProps, "Id", "PropName", propAd.ThematicPropId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "EmailAddress", propAd.UserId);
            return View(propAd);
        }

        // GET: PropAds/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propAd = await _context.PropAds
                .Include(p => p.ThematicProp)
                .Include(p => p.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (propAd == null)
            {
                return NotFound();
            }

            return View(propAd);
        }

        // POST: PropAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var propAd = await _context.PropAds.SingleOrDefaultAsync(m => m.Id == id);
            _context.PropAds.Remove(propAd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropAdExists(long id)
        {
            return _context.PropAds.Any(e => e.Id == id);
        }
    }
}
