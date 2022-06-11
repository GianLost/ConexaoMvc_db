using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atvdd2_Uc04.Models;
using Microsoft.AspNetCore.Http;

namespace Atvdd2_Uc04.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        public IActionResult ListarPacks(int Id)
        {

            PacotesTuristicosRepository ptr = new PacotesTuristicosRepository();
            return View(ptr.ListarPacotes(Id));
            
        }

        public IActionResult ExcluirPacks(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");// retorna para açao login da controller usuario
            }

            PacotesTuristicosRepository Pacotes = new PacotesTuristicosRepository();
            PacotesTuristicos PacotesEncontrados = Pacotes.BuscarPacotesPorId(Id);

            Pacotes.RemoverPacotes(PacotesEncontrados);

            return RedirectToAction("ListarPacks");
        }

        public IActionResult CadastrarPacks()
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");// retorna para açao login da controller usuario
            }

            return View();
        }

        [HttpPost]

        public IActionResult CadastrarPacks(PacotesTuristicos Pacotes)
        {

            PacotesTuristicosRepository Packs = new PacotesTuristicosRepository();
            Packs.InserirPacotes(Pacotes);

            ViewData["mensagem"] = "Pacote de viagem cadastrado com sucesso";
            return View();
        }

        public IActionResult AlterarPacks(int pct)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") != null)
            {
                PacotesTuristicosRepository pack = new PacotesTuristicosRepository();
                PacotesTuristicos PacoteEncontrado = pack.BuscarPacotesPorId(pct);

                return View(PacoteEncontrado);
            }
            return RedirectToAction("Login", "Usuario");// retorna para açao login da controller usuario

        }

        [HttpPost]
        public IActionResult AlterarPacks(PacotesTuristicos Pct)
        {


            PacotesTuristicosRepository Packs = new PacotesTuristicosRepository();
            Packs.AterarPacotes(Pct);

            return RedirectToAction("ListarPacks");
        }
    }
}