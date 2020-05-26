using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusiCore.Data;
using MusiCore.TextModels;

namespace MusiCore.TextControllers
{
    public class UsedApproachController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsedApproachController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Yaklaşımlar";
            ViewData["ViewDataForSecondHeader"] = "Projede Kullanılan Yaklaşımlar";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(await _context.UsedApproaches.ToListAsync());
        }

        // GET: UsedApproach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Detaylar";
            ViewData["ViewDataForFirstHeader"] = "Detaylar";
            ViewData["ViewDataForSecondHeader"] = "Kullanılan Yaklaşımın Detayları";

            //alt kısım için --> _PartialViewForCreateTextBottom
            //ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedApproach";
            //ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            //ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            if (id == null)
            {
                return NotFound();
            }

            var usedApproach = await _context.UsedApproaches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usedApproach == null)
            {
                return NotFound();
            }

            return View(usedApproach);
        }

        // GET: UsedApproach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsedApproach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TextTurkish,TextEnglish")] UsedApproach usedApproach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usedApproach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usedApproach);
        }

        // GET: UsedApproach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedApproach = await _context.UsedApproaches.FindAsync(id);
            if (usedApproach == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForFirstHeader"] = "Düzenle";
            ViewData["ViewDataForSecondHeader"] = "Kullanılan Yaklaşımı Düzenle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedApproach";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(usedApproach);
        }

        // POST: UsedApproach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TextTurkish,TextEnglish")] UsedApproach usedApproach)
        {
            if (id != usedApproach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usedApproach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsedApproachExists(usedApproach.Id))
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
            return View(usedApproach);
        }

        // GET: UsedApproach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedApproach = await _context.UsedApproaches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usedApproach == null)
            {
                return NotFound();
            }

            return View(usedApproach);
        }

        // POST: UsedApproach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usedApproach = await _context.UsedApproaches.FindAsync(id);
            _context.UsedApproaches.Remove(usedApproach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsedApproachExists(int id)
        {
            return _context.UsedApproaches.Any(e => e.Id == id);
        }
    }
}
