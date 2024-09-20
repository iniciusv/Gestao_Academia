using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Academia.Service;

public class CustomerService{
	private readonly ICustomerRepository Repository;

	public CustomerService(ICustomerRepository repository){
		Repository = repository;
	}

	public async Task<List<Customer>> ListCustomerAsync(){
		var customers = await Repository.GetAllAsync();
		return customers.ToList();
	}

	public async Task<Customer> GetCustomerByIdAsync(int id){
		return await Repository.GetByIdAsync(id);
	}

	public async Task AddCustomerAsync(Customer customer){
		await Repository.AddAsync(customer);
	}

	public async Task EditCustomerAsync(Customer customer){
		await Repository.UpdateAsync(customer);
	}

	public async Task DeleteCustomerByIdAsync(int id){
		await Repository.DeleteAsync(id);
	}
}