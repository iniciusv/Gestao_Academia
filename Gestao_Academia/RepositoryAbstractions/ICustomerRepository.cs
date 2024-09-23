using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;

public interface ICustomerRepository{
	Task<IEnumerable<Customer>> GetAllAsync();
	Task<Customer> GetByIdAsync(int id);
	Task AddAsync(Customer customer);
	Task UpdateAsync(Customer customer);
	Task DeleteAsync(int id);
}