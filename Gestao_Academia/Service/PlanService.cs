using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Academia.Service;

public class PlanService{
	private readonly IPlanRepository Repository;

	public PlanService(IPlanRepository repository){
		Repository = repository;
	}

	public async Task<List<Plan>> GetAllPlansAsync(){
		var Plans = await Repository.GetAllAsync();
		return Plans.ToList();
	}

	public async Task<Plan> GetPlanByIdAsync(int id){
		return await Repository.GetByIdAsync(id);
	}

	public async Task AddPlanForNewCustomerAsync(int customerId, string planType){
    	var existingPlans = await Repository.GetByCustomerIdAsync(customerId);

		if (existingPlans.Any()){
			throw new InvalidOperationException($"Customer with ID {customerId} already has a plan.");
		}
    
		var newPlan = new Plan{
			IdCustomer = customerId,
			Plan_Type = planType,
			Start_Date = DateTime.Now,
			End_Date = null,
			Status = PlanStatusEnum.Active,
			Created_at = DateTime.Now
		};

    	await Repository.AddAsync(newPlan);
	}

	public async Task UpdatePlanAsync(int customerId, string? newPlanType = null, bool cancelPlan = false){
    
    	var existingPlans = await Repository.GetByCustomerIdAsync(customerId);
    	var currentPlan = existingPlans.FirstOrDefault(p => p.Status == PlanStatusEnum.Active) ?? throw new InvalidOperationException($"Customer with ID {customerId} does not have an active plan to update.");
        
		if (cancelPlan){
			currentPlan.Status = PlanStatusEnum.Inactive;
			currentPlan.End_Date = DateTime.Now;
			currentPlan.Updated_at = DateTime.Now;
		} else if (!string.IsNullOrEmpty(newPlanType)){
			currentPlan.Plan_Type = newPlanType;
			currentPlan.Updated_at = DateTime.Now;
		}
		else{
			throw new ArgumentException("Either provide a new plan type or set the cancelPlan flag to true.");
		}

    	await Repository.UpdateAsync(currentPlan);
	}

	public async Task DeletePlanByIdAsync(int id){
		await Repository.DeleteAsync(id);
	}
}
