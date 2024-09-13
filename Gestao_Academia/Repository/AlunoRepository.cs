using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Academia.Repository;

public class AlunoRepository : IAlunoRepository
{
	private readonly AcademiaContext Context;

	public AlunoRepository(AcademiaContext context)
	{
		Context = context;
	}

	public async Task<IEnumerable<Students>> GetAllAsync()
	{
		return await Context.Students.ToListAsync();
	}

	public async Task<Students> GetByIdAsync(int id)
	{
		return await Context.Students.FindAsync(id);
	}

	public async Task AddAsync(Students aluno)
	{
		Context.Students.Add(aluno);
		await Context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Students aluno)
	{
		Context.Entry(aluno).State = EntityState.Modified;
		await Context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var aluno = await Context.Students.FindAsync(id);
		if (aluno != null)
		{
			Context.Students.Remove(aluno);
			await Context.SaveChangesAsync();
		}
	}
}
