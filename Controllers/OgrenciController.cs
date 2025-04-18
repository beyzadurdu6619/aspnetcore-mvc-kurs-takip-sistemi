using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EntityFreamwork.Models;
using EntityFreamwork.Data;
using Microsoft.EntityFrameworkCore;


namespace EntityFreamwork.Controllers;

public class OgrenciController : Controller
{
    private readonly DataContext _context;
    public OgrenciController(DataContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var ogr = await _context.Ogrenciler.
        Include(o=>o.KursKayitlari).
        ThenInclude(o=>o.Kurs).
        FirstOrDefaultAsync(o=>o.OgrenciId==id);
        if (ogr == null)
        {
            return NotFound();
        }
        return View(ogr);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ogrenci model)
    {
        if (id != model.OgrenciId)
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
                if (!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))
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
    public async Task<IActionResult> Index()
    {
        var ogrenciler = await _context.Ogrenciler.ToListAsync();
        return View(ogrenciler);

    }
    [HttpPost]
    public async Task<IActionResult> Create(Ogrenci model)
    {
        _context.Ogrenciler.Add(model);
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
        var ogrenci = await _context.Ogrenciler.
        Include(o => o.KursKayitlari).
        ThenInclude(o => o.Kurs).
        FirstOrDefaultAsync(o => o.OgrenciId == id);
        if (ogrenci == null)
        {
            return NotFound();
        }
        return View(ogrenci);

    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var ogrenci = await _context.Ogrenciler.FindAsync(id);
        if (ogrenci == null)
        {
            return NotFound();
        }
        _context.Ogrenciler.Remove(ogrenci);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }



}
