using Dapper;
using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Gestao_Academia.Repository;

public class StudentsRepository : IStudentsRepository
{
	private readonly AcademiaContext Context;
	private readonly IDbConnection Connection;

	public StudentsRepository(AcademiaContext context, IDbConnection connection)
	{
		Context = context;
		this.Connection = connection;
	}
	// Exemplo de método usando Dapper
	public async Task<IEnumerable<Students>> GetAllAsync()
	{
		string sql = "SELECT * FROM students";
		return await Connection.QueryAsync<Students>(sql);
	}


	public async Task<Students> GetByIdAsync(int id)
	{
		string sql = "SELECT * FROM students WHERE id = @Id";
		return await Connection.QuerySingleOrDefaultAsync<Students>(sql, new { Id = id });
	}

	public async Task AddAsync(Students aluno)
	{
		Context.Students.Add(aluno);
		await Context.SaveChangesAsync();
	}

	public async Task<bool> UpdateAsync(Students aluno)
	{
		var existingStudent = await Context.Students.FindAsync(aluno.Id);
		if (existingStudent == null)
		{
			return false;
		}

		Context.Entry(existingStudent).CurrentValues.SetValues(aluno);
		await Context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var aluno = await Context.Students.FindAsync(id);
		if (aluno == null)
		{
			return false;
		}

		Context.Students.Remove(aluno);
		await Context.SaveChangesAsync();
		return true;
	}

}
