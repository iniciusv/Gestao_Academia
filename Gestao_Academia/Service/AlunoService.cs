using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Academia.Service;

public class AlunoService
{
	private readonly IAlunoRepository Repository;

	public AlunoService(IAlunoRepository repository)
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

	public async Task CadastrarAsync(Students aluno)
	{
		await Repository.AddAsync(aluno);
	}

	public async Task EditarAsync(Students aluno)
	{
		await Repository.UpdateAsync(aluno);
	}

	public async Task DeletarAsync(int id)
	{
		await Repository.DeleteAsync(id);
	}
}
