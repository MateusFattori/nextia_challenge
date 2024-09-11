using Microsoft.AspNetCore.Mvc;
using nextia_challenge.DTOs;
using nextia_challenge.Models;
using nextia_challenge.Repository.Interface;

namespace nextia_challenge.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.GetAllProdutosAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistroProdutoDTO registroProduto)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto
                {
                    nome = registroProduto.Nome,
                    categoria = registroProduto.categoria,
                    valor = registroProduto.valor
                };

                await _produtoRepository.AddProdutoAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(registroProduto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            var dto = new RegistroProdutoDTO
            {
                Nome = produto.nome,
                categoria = produto.categoria,
                valor = produto.valor
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistroProdutoDTO dto)
        {

            if (ModelState.IsValid)
            {
                var produto = new Produto
                {
                    Id = id,
                    nome = dto.Nome,
                    categoria = dto.categoria,
                    valor = dto.valor
                };

                await _produtoRepository.UpdateProdutoAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoRepository.DeleteProdutoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
