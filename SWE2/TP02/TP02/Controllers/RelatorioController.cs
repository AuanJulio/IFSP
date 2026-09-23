using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP02.Data;

namespace TP02.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Relatorio
        public async Task<IActionResult> Index()
        {
            var lista = await _context.BLs
                .Include(b => b.Containers)
                .OrderBy(b => b.Numero)
                .ToListAsync();

            return View(lista);
        }
    }
}
