using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EntityFreamwork.Models;
using EntityFreamwork.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFreamwork.Controllers;
public class OgretmenController : Controller
{
    private readonly DataContext _context;
    public OgretmenController(DataContext context)
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
        var ogr = await _context.
        Ogretmenler.FindAsync(id);
        if (ogr == null)
        {
            return NotFound();
        }
        return View(ogr);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ogretmen model)
    {
        if (id != model.OgretmenId)
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
                if (!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId))
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
        var ogretmenler = await _context.Ogretmenler.ToListAsync();
        return View(ogretmenler);

    }
    [HttpPost]
    public async Task<IActionResult> Create(Ogretmen model)
    {
        _context.Ogretmenler.Add(model);
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
        var ogrenci = await _context.
        Ogretmenler.FindAsync(id);
        if (ogrenci == null)
        {
            return NotFound();
        }
        return View(ogrenci);

    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var ogrenci = await _context.Ogretmenler.FindAsync(id);
        if (ogrenci == null)
        {
            return NotFound();
        }
        _context.Ogretmenler.Remove(ogrenci);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }



}
