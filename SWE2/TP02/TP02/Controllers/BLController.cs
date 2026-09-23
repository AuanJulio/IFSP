using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP02.Data;
using TP02.Models;

namespace TP02.Controllers
{
    public class BLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BL
        public async Task<IActionResult> Index()
        {
            return View(await _context.BLs.ToListAsync());
        }

        // GET: BL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var bl = await _context.BLs
                .Include(b => b.Containers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bl == null) return NotFound();

            return View(bl);
        }

        // GET: BL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BL/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Consignee,Navio")] BL bl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        // GET: BL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var bl = await _context.BLs.FindAsync(id);
            if (bl == null) return NotFound();

            return View(bl);
        }

        // POST: BL/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Consignee,Navio")] BL bl)
        {
            if (id != bl.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.BLs.Any(e => e.Id == bl.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        // GET: BL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var bl = await _context.BLs.FirstOrDefaultAsync(m => m.Id == id);
            if (bl == null) return NotFound();

            return View(bl);
        }

        // POST: BL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bl = await _context.BLs.FindAsync(id);
            var temContainer = await _context.Containers.AnyAsync(c => c.BLId == id);

            if (temContainer)
            {
                ModelState.AddModelError("", "Não é possível excluir: existem containers associados a este BL.");
                return View(bl);
            }

            if (bl != null) _context.BLs.Remove(bl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
