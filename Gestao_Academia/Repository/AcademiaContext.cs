using Gestao_Academia.Models;
using Microsoft.EntityFrameworkCore;

public class AcademiaContext : DbContext
{
	public DbSet<Students> Students { get; set; }
	public DbSet<Pagamento> Pagamentos { get; set; }

	public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
	{
		try
		{
			this.Database.OpenConnection();
			this.Database.CloseConnection();
		}
		catch (Exception ex)
		{
			Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// TODO:
	}
}
