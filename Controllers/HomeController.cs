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

        public IActionResult Produto()
        {
            return View();
        }

        public IActionResult Promocao()
        {
            return View();
        }
        public IActionResult Clientes()
        {
            return View();
        }

        public IActionResult RegistroCliente(Coral request)
        {
            var cliente = _dataContext.MVC_Clientes.FirstOrDefault(x => x.nome == request.cpf);
            if (cliente != null)
            {
                return BadRequest("Cliente já existe");
            }
            Coral newCliente = new Coral
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

        public IActionResult RegistroProduto(Projeto request)
        {
            var produto = _dataContext.MVC_Produtos.FirstOrDefault(x => x.nome == request.categoria);

            if (produto != null)
            {
                return BadRequest("Produto já existe");
            }
            Projeto newProduto = new Projeto
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

        public IActionResult RegistroPromocao(Localizacao request) 
        { 
            var promocao = _dataContext.MVC_Promocoes.FirstOrDefault(x => x.produto == request.nome_promocao);
            if (promocao != null)
            {
                return BadRequest("Promoção já existe");
            }
            Localizacao newPromocao = new Localizacao
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
        public IActionResult ClientesCadastrados()
        {
            List<Coral> clientes = _dataContext.MVC_Clientes.ToList();
            return View("ClientesCadastrados", clientes);
        }

        public IActionResult ProdutosCadastrados()
        {
            List<Projeto> produtos = _dataContext.MVC_Produtos.ToList();
            return View("ProdutosCadastrados", produtos);
        }


        public IActionResult PromocoesCadastradas()
        {
            List<Localizacao> promocoes = _dataContext.MVC_Promocoes.ToList();
            return View("PromocoesCadastradas", promocoes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
