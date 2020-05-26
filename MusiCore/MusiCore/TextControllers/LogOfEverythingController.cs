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
    public class LogOfEverythingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogOfEverythingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LogOfEverything
        public async Task<IActionResult> Index()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForFirstHeader"] = "Log'lar";
            ViewData["ViewDataForSecondHeader"] = "Projede Yapılan Şeylerin Tümü";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(await _context.LogOfEverythings.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logOfEverything = await _context.LogOfEverythings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logOfEverything == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Detaylar";
            ViewData["ViewDataForFirstHeader"] = "Detaylar";
            ViewData["ViewDataForSecondHeader"] = "Seçilen Log'un Detayları";

            //alt kısım için --> _PartialViewForCreateTextBottom
            //ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "LogOfEverything";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            //ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            return View(logOfEverything);
        }

        // GET: LogOfEverything/Create
        public IActionResult Create()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Ekle";
            ViewData["ViewDataForSecondHeader"] = "Yeni Log Ekle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";
            return View();
        }

        // POST: LogOfEverything/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TextTurkish,TextEnglish")] LogOfEverything logOfEverything)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logOfEverything);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logOfEverything);
        }

        // GET: LogOfEverything/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logOfEverything = await _context.LogOfEverythings.FindAsync(id);
            if (logOfEverything == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForFirstHeader"] = "Düzenle";
            ViewData["ViewDataForSecondHeader"] = "Log'u Düzenle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "LogOfEverything";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(logOfEverything);
        }

        // POST: LogOfEverything/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TextTurkish,TextEnglish")] LogOfEverything logOfEverything)
        {
            if (id != logOfEverything.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logOfEverything);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogOfEverythingExists(logOfEverything.Id))
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
            return View(logOfEverything);
        }

        // GET: LogOfEverything/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logOfEverything = await _context.LogOfEverythings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logOfEverything == null)
            {
                return NotFound();
            }

            return View(logOfEverything);
        }

        // POST: LogOfEverything/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logOfEverything = await _context.LogOfEverythings.FindAsync(id);
            _context.LogOfEverythings.Remove(logOfEverything);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogOfEverythingExists(int id)
        {
            return _context.LogOfEverythings.Any(e => e.Id == id);
        }
    }
}
