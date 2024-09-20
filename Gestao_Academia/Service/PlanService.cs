using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Academia.Service;

public class PlanService
{
	private readonly IPlanRepository Repository;

	public PlanService(IPlanRepository repository)
	{
		Repository = repository;
	}

	public async Task<List<Plan>> GetAllAsync()
	{
		var Plans = await Repository.GetAllAsync();
		return Plans.ToList();
	}

	public async Task<Plan> GetByIdAsync(int id)
	{
		return await Repository.GetByIdAsync(id);
	}

	public async Task AddAsync(Plan Plan)
	{
		await Repository.AddAsync(Plan);
	}

	public async Task UpdateAsync(Plan Plan)
	{
		await Repository.UpdateAsync(Plan);
	}

	public async Task DeleteAsync(int id)
	{
		await Repository.DeleteAsync(id);
	}
}
