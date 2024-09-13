using Microsoft.AspNetCore.Mvc;
using nextia_challenge.Models;
using nextia_challenge.Data;

namespace nextia_challenge.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly DataContext _dataContext;

        public LoginController(ILogger<LoginController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Coral request)
        {
            var cliente = _dataContext.MVC_Clientes.FirstOrDefault(x => x.nome == request.cpf);
            if (cliente == null)
            {
                return BadRequest("Cliente já cadastrado");
            }

            return View();
        }
    }
}
