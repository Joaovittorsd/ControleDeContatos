﻿using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUsuarioRepositorio _usuarioRepositorio;
		private readonly ISessao _sessao;
		private readonly IEmail _email;
		public LoginController(IUsuarioRepositorio usuarioRepositorio,
								ISessao sessao,
								IEmail email)
		{
			_usuarioRepositorio = usuarioRepositorio;
			_sessao = sessao;
			_email = email;
		}

		public IActionResult Index()
		{
			// Se o usuário estiver logado, redirecionar para a home.
			if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

			return View();
		}

		public IActionResult RedefinirSenha()
		{
			return View();
		}

		public IActionResult Sair()
		{
			_sessao.RemoverSessaoUsuario();

			return RedirectToAction("Index", "Login");
		}

		[HttpPost]
		public IActionResult Entrar(LoginModel loginModel)
		{

			try
			{
				if (ModelState.IsValid)
				{

					UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

					if (usuario != null)
					{
						if (usuario.SenhaValida(loginModel.Senha))
						{
							_sessao.CriarSessaoDoUsuario(usuario);
							return RedirectToAction("Index", "Home");
						}

						TempData["MensagemErro"] = "Senha do usuário é inválida.";
					}

					TempData["MensagemErro"] = "Usuário e/ou senha inválido(s). Por favor, tente novamente.";
				}

				return View("index");
			}
			catch (Exception erro)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. datalhe do erro: {erro.Message}";
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult EnviarLink(RedefinirSenhaModel redefinirSenhaModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

					if (usuario != null)
					{
						string novaSenha = usuario.GerarNovaSenha();
						string mensagem = $"Sua nova senha é: {novaSenha}";

						bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de contatos - Nova Senha", mensagem);

						if (emailEnviado)
						{
							_usuarioRepositorio.Atualizar(usuario);
							TempData["MensagemSucesso"] = "Enviamos para seu e-mail cadastrado uma nova senha, verifique a caixa de spam.";
						}
						else
						{
							TempData["MensagemErro"] = "Não conseguimos enviar o e-mail. Por favor, tente novamente.";
						}

						return RedirectToAction("Index", "Login");
					}

					TempData["MensagemErro"] = "Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
				}

				return View("index");
			}
			catch (Exception erro)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamente. datalhe do erro: {erro.Message}";
				return RedirectToAction("Index");
			}
		}
	}
}
