using Microsoft.AspNetCore.Mvc;
using nextia_challenge.DTOs;
using nextia_challenge.Models;
using nextia_challenge.Repository.Interface;

namespace nextia_challenge.Controllers
{
    public class PromocaoController : Controller
    {
        private readonly IPromocaoRepository _promocaoRepository;

        public PromocaoController(IPromocaoRepository promocaoRepository)
        {
            _promocaoRepository = promocaoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var promocoes = await _promocaoRepository.GetAllPromocoesAsync();
            return View(promocoes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var promocao = await _promocaoRepository.GetPromocaoByIdAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            return View(promocao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PromocaoDTO promocaoDto)
        {
            if (ModelState.IsValid)
            {
                var promocao = new Promocao
                {
                    produto = promocaoDto.produto,
                    nome_promocao = promocaoDto.nome_promocao,
                    dt_inicio = promocaoDto.dt_inicio,
                    dt_final = promocaoDto.dt_final
                };

                await _promocaoRepository.AddPromocaoAsync(promocao);
                return RedirectToAction(nameof(Index));
            }
            return View(promocaoDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var promocao = await _promocaoRepository.GetPromocaoByIdAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            var dto = new PromocaoDTO
            {
                produto = promocao.produto,
                nome_promocao = promocao.nome_promocao,
                dt_inicio = promocao.dt_inicio,
                dt_final = promocao.dt_final
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PromocaoDTO dto)
        {

            if (ModelState.IsValid)
            {
                var promocao = new Promocao
                {
                    Id = id,
                    produto = dto.produto,
                    nome_promocao = dto.nome_promocao,
                    dt_inicio = dto.dt_inicio,
                    dt_final = dto.dt_final
                };

                await _promocaoRepository.UpdatePromocaoAsync(promocao);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var promocao = await _promocaoRepository.GetPromocaoByIdAsync(id);
            if (promocao == null)
            {
                return NotFound();
            }
            return View(promocao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _promocaoRepository.DeletePromocaoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
