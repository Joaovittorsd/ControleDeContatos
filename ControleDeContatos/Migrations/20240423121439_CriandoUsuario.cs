using ControleDeContatos.Helper;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoUsuario : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var senha = Criptografia.GerarHash("1234");

			migrationBuilder.InsertData("Usuarios", new string[] { "Nome", "Login", "Email", "Perfil", "Senha", "DataCadastro" },
				new object[] { "Administrador", "admin", "xpto@xpto.com", 1, senha, DateTime.Now }
				);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DELETE FROM Usuarios");
		}
	}
}
