using Microsoft.AspNetCore.Mvc;
using nextia_challenge.DTOs;
using nextia_challenge.Models;
using nextia_challenge.Repository.Interface;

namespace nextia_challenge.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteRepository.GetAllClientesAsync();
            return View(clientes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistroClienteDTO registroCliente)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente
                {
                    nome = registroCliente.nome,
                    cpf = registroCliente.cpf,
                    email = registroCliente.email,
                    senha = registroCliente.senha,
                    genero = registroCliente.genero,
                    dt_nascimento = registroCliente.dt_nascimento,
                    telefone = registroCliente.telefone
                };

                await _clienteRepository.AddClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(registroCliente);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var dto = new RegistroClienteDTO
            {
                nome = cliente.nome,
                cpf = cliente.cpf,
                email = cliente.email,
                genero = cliente.genero,
                dt_nascimento = cliente.dt_nascimento,
                telefone = cliente.telefone
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistroClienteDTO dto)
        {

            if (ModelState.IsValid)
            {
                var cliente = new Cliente
                {
                    Id = id,
                    nome = dto.nome,
                    cpf = dto.cpf,
                    email = dto.email,
                    senha = dto.senha,
                    genero = dto.genero,
                    dt_nascimento = dto.dt_nascimento,
                    telefone = dto.telefone
                };

                await _clienteRepository.UpdateClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
