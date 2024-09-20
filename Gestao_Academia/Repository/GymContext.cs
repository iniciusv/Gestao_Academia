using Gestao_Academia.Models;
using Microsoft.EntityFrameworkCore;

public class GymContext : DbContext{
	public DbSet<Customer> Customer { get; set; }
	public DbSet<Payment> Payment { get; set; }
	public DbSet<Plan> Plan { get; set; }
	public DbSet<Users> Users { get; set; }

	public GymContext(DbContextOptions<GymContext> options) : base(options){
		try{
			this.Database.OpenConnection();
			this.Database.CloseConnection();
		}
		catch (Exception ex){
			Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder){
		// Model customization goes here if necessary
	}
}