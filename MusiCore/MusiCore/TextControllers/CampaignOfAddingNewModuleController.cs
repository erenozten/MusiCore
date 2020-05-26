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
    public class CampaignOfAddingNewModuleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampaignOfAddingNewModuleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CampaignOfAddingNewModule
        public async Task<IActionResult> Index()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Modüller";
            ViewData["ViewDataForSecondHeader"] = "Projeye Entegre Edilen/Edilecek Modüller";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            return View(await _context.CampaignOfAddingNewModules.ToListAsync());
        }

        // GET: CampaignOfAddingNewModule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignOfAddingNewModule = await _context.CampaignOfAddingNewModules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignOfAddingNewModule == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Detaylar";
            ViewData["ViewDataForFirstHeader"] = "Detaylar";
            ViewData["ViewDataForSecondHeader"] = "Seçilen Modülün Detayları";

            //alt kısım için --> _PartialViewForCreateTextBottom
            //ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "CampaignOfAddingNewModule";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            //ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            return View(campaignOfAddingNewModule);
        }

        // GET: CampaignOfAddingNewModule/Create
        public IActionResult Create()
        {
            var dts = DateTime.Now;

            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForFirstHeader"] = "Ekle";
            ViewData["ViewDataForSecondHeader"] = "Yeni Modül Ekle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "CampaignOfAddingNewModule";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            return View();
        }

        // POST: CampaignOfAddingNewModule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TextTurkish,TextEnglish,IsDone,DateCompleted,DateCreated")] CampaignOfAddingNewModule campaignOfAddingNewModule)
        {
            var dts = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(campaignOfAddingNewModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaignOfAddingNewModule);
        }

        // GET: CampaignOfAddingNewModule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignOfAddingNewModule = await _context.CampaignOfAddingNewModules.FindAsync(id);
            if (campaignOfAddingNewModule == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForFirstHeader"] = "Düzenle";
            ViewData["ViewDataForSecondHeader"] = "Seçilen Modülü Düzenle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "CampaignOfAddingNewModule";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";
            return View(campaignOfAddingNewModule);
        }

        // POST: CampaignOfAddingNewModule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TextTurkish,TextEnglish,IsDone")] CampaignOfAddingNewModule campaignOfAddingNewModule)
        {
            if (id != campaignOfAddingNewModule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaignOfAddingNewModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignOfAddingNewModuleExists(campaignOfAddingNewModule.Id))
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
            return View(campaignOfAddingNewModule);
        }

        // GET: CampaignOfAddingNewModule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignOfAddingNewModule = await _context.CampaignOfAddingNewModules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignOfAddingNewModule == null)
            {
                return NotFound();
            }

            return View(campaignOfAddingNewModule);
        }

        // POST: CampaignOfAddingNewModule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaignOfAddingNewModule = await _context.CampaignOfAddingNewModules.FindAsync(id);
            _context.CampaignOfAddingNewModules.Remove(campaignOfAddingNewModule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignOfAddingNewModuleExists(int id)
        {
            return _context.CampaignOfAddingNewModules.Any(e => e.Id == id);
        }
    }
}
