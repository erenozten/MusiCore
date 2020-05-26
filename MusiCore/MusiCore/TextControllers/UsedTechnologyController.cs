using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusiCore.Data;
using MusiCore.TextModels;

namespace MusiCore.TextControllers
{
    public class UsedTechnologyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsedTechnologyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Teknolojiler";
            ViewData["ViewDataForSecondHeader"] = "Projede Kullanılan Teknolojiler";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(await _context.UsedTechnologies.ToListAsync());
        }

        public async Task<IActionResult> AddSampleData()
        {
            //sampleUsedTechnologiesList
            var sampleUsedTechnologiesList = new List<UsedTechnology>()
            {
                new UsedTechnology()
                {
                    TextEnglish = "asdf",
                },
                new UsedTechnology()
                {
                    TextEnglish = "asdf",
                },
            };

        _context.UsedTechnologies.AddRange(sampleUsedTechnologiesList);
        _context.SaveChanges();
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Detaylar";
            ViewData["ViewDataForFirstHeader"] = "Detaylar";
            ViewData["ViewDataForSecondHeader"] = "Seçilen teknolojinin Detayları";

            //alt kısım için --> _PartialViewForCreateTextBottom
            //ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            //ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            //ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            if (id == null)
            {
                return NotFound();
            }

            var usedTechnology = await _context.UsedTechnologies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usedTechnology == null)
            {
                return NotFound();
            }

            return View(usedTechnology);
        }

        public IActionResult Create()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Ekle";
            ViewData["ViewDataForSecondHeader"] = "Yeni Teknoloji Ekle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TextTurkish,TextEnglish")] UsedTechnology usedTechnology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usedTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usedTechnology);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedTechnology = await _context.UsedTechnologies.FindAsync(id);
            if (usedTechnology == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Düzenle";
            ViewData["ViewDataForSecondHeader"] = "Seçilen Teknolojiyi Düzenle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(usedTechnology);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TextTurkish,TextEnglish")] UsedTechnology usedTechnology)
        {
            if (id != usedTechnology.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usedTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsedTechnologyExists(usedTechnology.Id))
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
            return View(usedTechnology);
        }

        // GET: UsedTechnology/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usedTechnology = await _context.UsedTechnologies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usedTechnology == null)
            {
                return NotFound();
            }

            return View(usedTechnology);
        }

        // POST: UsedTechnology/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usedTechnology = await _context.UsedTechnologies.FindAsync(id);
            _context.UsedTechnologies.Remove(usedTechnology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsedTechnologyExists(int id)
        {
            return _context.UsedTechnologies.Any(e => e.Id == id);
        }
    }
}
