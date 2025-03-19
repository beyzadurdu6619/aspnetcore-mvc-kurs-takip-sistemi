using EntityFreamwork.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace EntityFreamwork.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context;

        public KursKayitController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var kursKayitleri = await _context.KursKayit.Include(x => x.Ogrenci).Include(x => x.Kurs).ToListAsync();

            return View(kursKayitleri);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.KursKayit.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
         public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var kurs = await _context.KursKayit.FindAsync(id);
        if (kurs == null)
        {
            return NotFound();
        }
        return View(kurs);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, KursKayit model)
    {
        if (id != model.KayitId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.KursKayit.Any(o => o.KayitId == model.KayitId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToAction("Index");
        }
        return View(model);
    }
   
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var kurs = await _context.KursKayit.FindAsync(id);
        if (kurs == null)
        {
            return NotFound();
        }
        return View(kurs);

    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var kurs = await _context.KursKayit.FindAsync(id);
        if (kurs == null)
        {
            return NotFound();
        }
        _context.KursKayit.Remove(kurs);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }



    }

}