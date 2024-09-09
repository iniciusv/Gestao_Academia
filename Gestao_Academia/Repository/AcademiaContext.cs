using Gestao_Academia.Models;
using Microsoft.EntityFrameworkCore;

public class AcademiaContext : DbContext
{
	public DbSet<Students> Students { get; set; }
	public DbSet<Pagamento> Pagamentos { get; set; }

	public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
	{
		// Tenta abrir a conexão com o banco de dados para testar a configuração
		try
		{
			this.Database.OpenConnection();
			this.Database.CloseConnection();
		}
		catch (Exception ex)
		{
			// Loga a exceção ou trata o erro de conexão
			Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Configurações do modelo e relações vão aqui
	}
}
