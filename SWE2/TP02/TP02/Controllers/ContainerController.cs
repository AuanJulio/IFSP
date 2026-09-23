using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02.Data;
using TP02.Models;

namespace TP02.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContainerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Container
        public async Task<IActionResult> Index()
        {
            var containers = _context.Containers.Include(c => c.BL);
            return View(await containers.ToListAsync());
        }

        // GET: Container/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (container == null) return NotFound();

            return View(container);
        }

        // GET: Container/Create
        public IActionResult Create()
        {
            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero");
            return View();
        }

        // POST: Container/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Tipo,Tamanho,BLId")] Container container)
        {
            if (ModelState.IsValid)
            {
                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        // GET: Container/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers.FindAsync(id);
            if (container == null) return NotFound();

            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        // POST: Container/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Tipo,Tamanho,BLId")] Container container)
        {
            if (id != container.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Containers.Any(e => e.Id == container.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BLId"] = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        // GET: Container/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (container == null) return NotFound();

            return View(container);
        }

        // POST: Container/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container != null) _context.Containers.Remove(container);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
