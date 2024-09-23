using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Academia.Service;

public class CustomerService
{
	private readonly ICustomerRepository Repository;

	public CustomerService(ICustomerRepository repository)
	{
		Repository = repository;
	}

	public async Task<List<Customer>> ListarAsync()
	{
		var alunos = await Repository.GetAllAsync();
		return alunos.ToList();
	}

	public async Task<Customer> ObterAsync(int id)
	{
		return await Repository.GetByIdAsync(id);
	}

	public async Task CreateAsync(Customer customer)
	{
		await Repository.AddAsync(customer);
	}

	public async Task<bool> EditarAsync(Customer customer)
	{
		return await Repository.UpdateAsync(customer);
	}

	public async Task<bool> DeleteAsync(int id)
	{
		return await Repository.DeleteAsync(id);
	}

}
