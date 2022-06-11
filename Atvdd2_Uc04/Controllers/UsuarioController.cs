using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Atvdd2_Uc04.Models;

namespace Atvdd2_Uc04.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuarioSessao = ur.ValidarLogin(usuario);

            if (usuarioSessao == null)
            {
                // nao localizou o usuario
                ViewBag.mensagem = "Login ou senha incorretos!";
                return View();
            }
            else
            {
                //login localizado

                // Prepara mensagem
                ViewBag.mensagem = "Você está Logado!";

                // Registra na sessão os dados do usuario
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id); // so se rgistra nome e id na sessao
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);


                // Redirecionamento
                return View();
            }
        }

        public IActionResult Logout()
        {

            // Limpar acesso de dados
            HttpContext.Session.Clear();// Limpa todos os dados da sessao

            // Redirecionar
            return View("Login");
        }

        public IActionResult Lista(int Id)
        {

            // Fazendo validação que verifica se o usuario está logado
            /*if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");// retorna para açao login da controller usuario
            }*/

            UsuarioRepository ur = new UsuarioRepository();
            return View(ur.Listar(Id));
            

        }

        public IActionResult Excluir(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Index", "Home");// retorna para açao login da controller usuario
            }

            UsuarioRepository ur = new UsuarioRepository();
            Usuario cliente = ur.BuscarPorId(Id);

            ur.Remover(cliente);

            return RedirectToAction("Lista");
        }

        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario user)
        {

            UsuarioRepository ur = new UsuarioRepository();
            ur.Inserir(user);

            ViewData["mensagem"] = "Cadastro realizado com sucesso";
            return View();
        }

        public IActionResult Refazer(int Id)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");// retorna para açao login da controller usuario
            }

            UsuarioRepository ur = new UsuarioRepository();
            Usuario UsuarioEncontrado = ur.BuscarPorId(Id);

            return View(UsuarioEncontrado);
        }
        [HttpPost]
        public IActionResult Refazer(Usuario user)
        {

            UsuarioRepository ur = new UsuarioRepository();
            ur.Atualizar(user);

            ViewData["mensagem"] = "Usuario modificado com sucesso!!!";
            return RedirectToAction("Lista");
        }
    }
}