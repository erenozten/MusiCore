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
    public class CampaignOfFixationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampaignOfFixationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CampaignOfFixation
        public async Task<IActionResult> Index()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForFirstHeader"] = "Hatalar";
            ViewData["ViewDataForSecondHeader"] = "Çözülmüş veya Çözülecek Hatalar";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            //ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            var asdff = _context.CampaignOfFixations.FirstOrDefault();
            var qq = asdff.GetMonth;

            return View(await _context.CampaignOfFixations.ToListAsync());
        }

        // GET: CampaignOfFixation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignOfFixation = await _context.CampaignOfFixations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignOfFixation == null)
            {
                return NotFound();
            }

            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Detaylar";
            ViewData["ViewDataForFirstHeader"] = "Detaylar";
            ViewData["ViewDataForSecondHeader"] = "Seçilen Hatanın Detayları";

            //alt kısım için --> _PartialViewForCreateTextBottom
            //ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "CampaignOfFixation";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            //ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            return View(campaignOfFixation);
        }

        // GET: CampaignOfFixation/Create
        public IActionResult Create()
        {

            //üst kısım için --> _PartialViewForCreateTextTop
            ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Ekle";
            ViewData["ViewDataForSecondHeader"] = "Yeni Hata Ekle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Ekle!";

            return View();
        }

        // POST: CampaignOfFixation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TextTurkish,TextEnglish,IsDone")] CampaignOfFixation campaignOfFixation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaignOfFixation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaignOfFixation);
        }

        // GET: CampaignOfFixation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            ViewData["ViewDataForClassName"] = "Teknoloji";
            ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Düzenle";
            ViewData["ViewDataForSecondHeader"] = "Seçilen Hatayı Düzenle";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            if (id == null)
            {
                return NotFound();
            }

            var campaignOfFixation = await _context.CampaignOfFixations.FindAsync(id);
            if (campaignOfFixation == null)
            {
                return NotFound();
            }
            return View(campaignOfFixation);
        }

        // POST: CampaignOfFixation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TextTurkish,TextEnglish,IsDone")] CampaignOfFixation campaignOfFixation)
        {
            if (id != campaignOfFixation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaignOfFixation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignOfFixationExists(campaignOfFixation.Id))
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
            return View(campaignOfFixation);
        }

        // GET: CampaignOfFixation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignOfFixation = await _context.CampaignOfFixations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignOfFixation == null)
            {
                return NotFound();
            }

            return View(campaignOfFixation);
        }

        // POST: CampaignOfFixation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaignOfFixation = await _context.CampaignOfFixations.FindAsync(id);
            _context.CampaignOfFixations.Remove(campaignOfFixation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignOfFixationExists(int id)
        {
            return _context.CampaignOfFixations.Any(e => e.Id == id);
        }
    }
}
