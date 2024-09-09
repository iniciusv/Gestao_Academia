using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Academia.Repository;

public class AlunoRepository : IAlunoRepository
{
	private readonly AcademiaContext _context;

	public AlunoRepository(AcademiaContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Students>> GetAllAsync()
	{
		return await _context.Students.ToListAsync();
	}

	public async Task<Students> GetByIdAsync(int id)
	{
		return await _context.Students.FindAsync(id);
	}

	public async Task AddAsync(Students aluno)
	{
		_context.Students.Add(aluno);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Students aluno)
	{
		_context.Entry(aluno).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var aluno = await _context.Students.FindAsync(id);
		if (aluno != null)
		{
			_context.Students.Remove(aluno);
			await _context.SaveChangesAsync();
		}
	}
}
