using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EntityFreamwork.Models;
using EntityFreamwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EntityFreamwork.Controllers;

public class KursController : Controller
{
    private readonly DataContext _context;
    public KursController(DataContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var kurslar = await _context.Kurslar.ToListAsync();
        return View(kurslar);

    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var kurs = await _context.Kurslar.
        Include(k=>k.KursKayitlari).
        ThenInclude(k=>k.Ogrenci).
        FirstOrDefaultAsync(k=>k.KursId==id);
        if (kurs == null)
        {
            return NotFound();
        }
        return View(kurs);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Kurs model)
    {
        if (id != model.KursId)
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
                if (!_context.Kurslar.Any(o => o.KursId == model.KursId))
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
    public async Task<IActionResult> Create()
    {
        ViewBag.Ogrenciler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "Ad");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Kurs model)
    {
        _context.Kurslar.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var kurs = await _context.Kurslar.FindAsync(id);
        if (kurs == null)
        {
            return NotFound();
        }
        return View(kurs);

    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var kurs = await _context.Kurslar.FindAsync(id);
        if (kurs == null)
        {
            return NotFound();
        }
        _context.Kurslar.Remove(kurs);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }


}
