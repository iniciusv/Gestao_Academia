using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;

public interface ICustomerRepository
{
	Task<IEnumerable<Customer>> GetAllAsync();
	Task<Customer> GetByIdAsync(int id);
	Task AddAsync(Customer customer);
	Task<bool> UpdateAsync(Customer customer);
	Task<bool> DeleteAsync(int id);
}