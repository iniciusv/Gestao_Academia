using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;

namespace Gestao_Academia.Service;

public class StudentsService
{
	private readonly IStudentsRepository Repository;

	public StudentsService(IStudentsRepository repository)
	{
		Repository = repository;
	}

	public async Task<List<Students>> ListarAsync()
	{
		var alunos = await Repository.GetAllAsync();
		return alunos.ToList();
	}

	public async Task<Students> ObterAsync(int id)
	{
		return await Repository.GetByIdAsync(id);
	}

	public async Task CreateAsync(Students aluno)
	{
		await Repository.AddAsync(aluno);
	}

	public async Task<bool> EditarAsync(Students aluno)
	{
		return await Repository.UpdateAsync(aluno);
	}

	public async Task<bool> DeleteAsync(int id)
	{
		return await Repository.DeleteAsync(id);
	}

}
