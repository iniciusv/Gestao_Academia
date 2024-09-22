using Gestao_Academia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

public class AcademiaContext : DbContext
{
	public DbSet<Students> Students { get; set; }
	public DbSet<Pagamento> Pagamentos { get; set; }
	public DbSet<Users> Users { get; set; }

	public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
	{
		Database.OpenConnection();
		try
		{
			Database.EnsureCreated();
		}
		catch (Exception ex)
		{
			Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
		}
		finally
		{
			Database.CloseConnection();
		}
	}

	// Método para executar consultas SQL diretas
	public async Task<List<T>> ExecuteSqlQuery<T>(string sql, Dictionary<string, object> parameters, Func<DbDataReader, T> map)
	{
		using (var command = Database.GetDbConnection().CreateCommand())
		{
			command.CommandText = sql;
			// Adicionando parâmetros ao comando
			if (parameters != null)
			{
				foreach (var param in parameters)
				{
					var dbParameter = command.CreateParameter();
					dbParameter.ParameterName = param.Key;
					dbParameter.Value = param.Value ?? DBNull.Value;
					command.Parameters.Add(dbParameter);
				}
			}

			Database.OpenConnection();
			using (var result = await command.ExecuteReaderAsync())
			{
				var entities = new List<T>();
				while (await result.ReadAsync())
				{
					entities.Add(map(result));
				}
				return entities;
			}
		}
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Customizações do modelo vão aqui
	}
}
