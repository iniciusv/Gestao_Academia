using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;

public interface IPlanRepository
{
	Task<IEnumerable<Plan>> GetAllAsync();
	Task<Plan> GetByIdAsync(int id);
	Task AddAsync(Plan plan);
	Task UpdateAsync(Plan plan);
	Task DeleteAsync(int id);
}