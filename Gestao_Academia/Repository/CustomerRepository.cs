using Dapper;
using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Gestao_Academia.Repository;

public class CustomerRepository : ICustomerRepository
{
	private readonly GymContext Context;
	private readonly IDbConnection Connection;

	public CustomerRepository(GymContext context, IDbConnection connection)
	{
		Context = context;
		this.Connection = connection;
	}
	// Exemplo de método usando Dapper
	public async Task<IEnumerable<Customer>> GetAllAsync()
	{
		string sql = "SELECT * FROM students";
		return await Connection.QueryAsync<Customer>(sql);
	}


	public async Task<Customer> GetByIdAsync(int id)
	{
		string sql = "SELECT * FROM students WHERE id = @Id";
		return await Connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });
	}

	public async Task AddAsync(Customer customer)
	{
		Context.Customer.Add(customer);
		await Context.SaveChangesAsync();
	}

	public async Task<bool> UpdateAsync(Customer customer)
	{
		var existingStudent = await Context.Customer.FindAsync(customer.Id);
		if (existingStudent == null)
		{
			return false;
		}

		Context.Entry(existingStudent).CurrentValues.SetValues(customer);
		await Context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var customer = await Context.Customer.FindAsync(id);
		if (customer == null)
		{
			return false;
		}

		Context.Customer.Remove(customer);
		await Context.SaveChangesAsync();
		return true;
	}

}
