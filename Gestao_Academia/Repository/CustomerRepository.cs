using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Academia.Repository;

public class CustomerRepository : ICustomerRepository{
	private readonly GymContext Context;

	public CustomerRepository(GymContext context){
		Context = context;
	}

	public async Task<IEnumerable<Customer>> GetAllAsync(){
		return await Context.Customer.ToListAsync();
	}

	public async Task<Customer> GetByIdAsync(int id){
    	return await Context.Customer.FindAsync(id) 
			?? throw new InvalidOperationException($"Customer with ID {id} not found.");
	}	

	public async Task AddAsync(Customer customer){
		Context.Customer.Add(customer);
		await Context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Customer customer){
		Context.Entry(customer).State = EntityState.Modified;
		await Context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int customerId){
		var customer = await Context.Customer.FindAsync(customerId);
		
		if (customer != null){
			Context.Customer.Remove(customer);
			await Context.SaveChangesAsync();
		}
	}
}