using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Academia.Repository;

public class PlanRepository : IPlanRepository{
	private readonly GymContext Context;

	public PlanRepository(GymContext context){
		Context = context;
	}

	public async Task<IEnumerable<Plan>> GetAllAsync(){
		return await Context.Plan.ToListAsync();
	}

	public async Task<Plan> GetByIdAsync(int id){
		return await Context.Plan.FindAsync(id)
			?? throw new InvalidOperationException($"Customer with ID {id} not found.");
	}	
	
	public async Task AddAsync(Plan plan){
		plan.Created_at = DateTime.Now;
		Context.Plan.Add(plan);
		await Context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Plan plan){
		plan.Updated_at = DateTime.Now;
		Context.Entry(plan).State = EntityState.Modified;
		await Context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id){
		var plan = await Context.Plan.FindAsync(id);
		
		if (plan != null){
			Context.Plan.Remove(plan);
			await Context.SaveChangesAsync();
		}
	}

	public async Task<IEnumerable<Plan>> GetByCustomerIdAsync(int customerId){
        return await Context.Plan
            .Where(p => p.IdCustomer == customerId)
            .ToListAsync();
    }
}
