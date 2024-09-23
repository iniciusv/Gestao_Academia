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
		Context.Plan.Add(plan);
		await Context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Plan plan){
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
}
