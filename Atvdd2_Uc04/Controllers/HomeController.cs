using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atvdd2_Uc04.Models;

namespace Atvdd2_Uc04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.TestarConexao(); // invocando o metodo de testar conexao que exibe mensagem no console de conexao realizada
            return View();
        }

        public IActionResult Privacy()
        {
            PacotesTuristicosRepository Pacotes = new PacotesTuristicosRepository();
            Pacotes.TestarConexaoPacotes();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
