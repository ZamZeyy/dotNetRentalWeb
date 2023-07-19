using AspMVC.Data;
using AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class PracController : Controller
{
    private readonly ApplicationDbContext _context;

    public PracController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult PracIndex()
    {
        var rentals = _context.Rentals.ToList();
        return View(rentals);
    }

    public IActionResult Create()
    {
        var rental = new CarViewModel();
        return View(rental);
    }
   public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var rental = _context.Rentals.Find(id);
        if (rental == null)
        {
            return NotFound();
        }
        return View(rental);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarViewModel carViewModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(carViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PracIndex));
        }
        return View(carViewModel);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var rental = _context.Rentals.Find(id);
        if (rental == null)
        {
            return NotFound();
        }
        return View(rental);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CarViewModel carViewModel)
    {
        if (id != carViewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(carViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PracIndex));
        }
        return View(carViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var car = await _context.Rentals.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(car);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            // Log the exception, ex
            return Json(new { success = false, error = ex.Message });
        }
    }


}
