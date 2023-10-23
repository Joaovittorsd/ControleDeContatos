using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
	public class ContatoRepositorio : IContatoRepositorio
	{
		private readonly BancoContext _context;

		public ContatoRepositorio(BancoContext bancoContext)
		{
			_context = bancoContext;
		}

		public ContatoModel BuscarPorId(int id)
		{
			return _context.Contatos.FirstOrDefault(x => x.Id == id);
		}

		public List<ContatoModel> BuscarTodos(int usuarioId)
		{
			return _context.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
		}

		public ContatoModel Adicionar(ContatoModel contato)
		{
			_context.Contatos.Add(contato);
			_context.SaveChanges();

			return contato;
		}

		public ContatoModel Atualizar(ContatoModel contato)
		{
			ContatoModel contatoDB = BuscarPorId(contato.Id);

			if (contatoDB == null) throw new Exception("Houve um error na atualização do contato!");

			contatoDB.Nome = contato.Nome;
			contatoDB.Email = contato.Email;
			contatoDB.Celular = contato.Celular;

			_context.Contatos.Update(contatoDB);
			_context.SaveChanges();

			return contatoDB;
		}

		public bool Apagar(int id)
		{
			ContatoModel contatoDB = BuscarPorId(id);

			if (contatoDB == null) throw new Exception("Houve um error na deleção do contato!");

			_context.Contatos.Remove(contatoDB);
			_context.SaveChanges();

			return true;
		}
	}
}
