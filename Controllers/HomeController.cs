using Microsoft.AspNetCore.Mvc;
using nextia_challenge.Models;
using System.Diagnostics;
using nextia_challenge.Data;

namespace nextia_challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RegistroCliente(Cliente request)
        {
            var cliente = _dataContext.MVC_Clientes.FirstOrDefault(x => x.nome == request.cpf);
            if (cliente != null)
            {
                return BadRequest("Cliente já existe");
            }
            Cliente newCliente = new Cliente
            {
                Id = request.Id,
                nome = request.nome,
                cpf = request.cpf,
                email = request.email,
                senha = request.senha,
                genero = request.genero,
                dt_nascimento = request.dt_nascimento,
                telefone = request.telefone,
            };
            _dataContext.Add(newCliente);
            _dataContext.SaveChanges();
            return View();
        }

        public IActionResult RegistroProduto(Produto request)
        {
            var produto = _dataContext.MVC_Produtos.FirstOrDefault(x => x.nome == request.categoria);

            if (produto != null)
            {
                return BadRequest("Produto já existe");
            }
            Produto newProduto = new Produto
            {
                Id = request.Id,
                nome = request.nome,
                categoria = request.categoria,
                valor = request.valor,
            };
            _dataContext.Add(newProduto);
            _dataContext.SaveChanges();
            return View();
        }

        public IActionResult Promocao(Promocao request)
        {
            var promocao = _dataContext.MVC_Promocoes.FirstOrDefault(x => x.produto == request.nome_promocao);

            if (promocao != null)
            {
                return BadRequest("Promocao já existe");
            }
            Promocao newPromocao = new Promocao
            {
                Id = request.Id,
                produto = request.produto,
                nome_promocao = request.nome_promocao,
                dt_inicio = request.dt_inicio,
                dt_final = request.dt_final,
            };
            _dataContext.Add(newPromocao);
            _dataContext.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
