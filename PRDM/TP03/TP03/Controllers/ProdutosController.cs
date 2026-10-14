using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP03.Data;
using TP03.Models;

namespace TP03.Controllers
{
    [Route("produtos")]
    public class ProdutosController : Controller
    {
        private readonly ArmazemContext _db;

        public ProdutosController(ArmazemContext db)
        {
            _db = db;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(string? busca)
        {
            var consulta = _db.Produtos.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(busca))
            {
                var termo = busca.Trim();
                consulta = consulta.Where(p => p.Nome.Contains(termo));
            }

            ViewData["Busca"] = busca;
            var produtos = await consulta.OrderBy(p => p.Nome).ToListAsync();
            return View(produtos);
        }

        [HttpGet("detalhes/{id:int}")]
        public async Task<IActionResult> Detalhes(int id)
        {
            var produto = await _db.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return produto is null ? NotFound() : View(produto);
        }

        [HttpGet("novo")]
        public IActionResult Criar()
        {
            return View(new Produto());
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(
            [Bind("Nome,Descricao,Preco,QuantidadeEstoque")] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            _db.Produtos.Add(produto);
            await _db.SaveChangesAsync();

            TempData["Sucesso"] = $"Produto \"{produto.Nome}\" cadastrado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:int}")]
        public async Task<IActionResult> Editar(int id)
        {
            var produto = await _db.Produtos.FindAsync(id);
            return produto is null ? NotFound() : View(produto);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(
            int id,
            [Bind("Id,Nome,Descricao,Preco,QuantidadeEstoque")] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            try
            {
                _db.Update(produto);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Produtos.AnyAsync(p => p.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            TempData["Sucesso"] = $"Produto \"{produto.Nome}\" atualizado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var produto = await _db.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return produto is null ? NotFound() : View(produto);
        }

        [HttpPost("excluir/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var produto = await _db.Produtos.FindAsync(id);
            if (produto is null)
            {
                return NotFound();
            }

            _db.Produtos.Remove(produto);
            await _db.SaveChangesAsync();

            TempData["Sucesso"] = $"Produto \"{produto.Nome}\" excluído.";
            return RedirectToAction(nameof(Index));
        }
    }
}
