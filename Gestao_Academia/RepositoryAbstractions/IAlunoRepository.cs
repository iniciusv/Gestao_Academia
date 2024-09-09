using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;

public interface IAlunoRepository
{
	Task<IEnumerable<Students>> GetAllAsync();
	Task<Students> GetByIdAsync(int id);
	Task AddAsync(Students aluno);
	Task UpdateAsync(Students aluno);
	Task DeleteAsync(int id);
}