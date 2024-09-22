using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;

public interface IStudentsRepository
{
	Task<IEnumerable<Students>> GetAllAsync();
	Task<Students> GetByIdAsync(int id);
	Task AddAsync(Students aluno);
	Task<bool> UpdateAsync(Students aluno);
	Task<bool> DeleteAsync(int id);

}