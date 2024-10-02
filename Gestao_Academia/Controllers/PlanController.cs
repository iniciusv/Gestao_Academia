using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class PlanController : ControllerBase{
	private readonly PlanService PlanService;

	public PlanController(PlanService planService){
		PlanService = planService;
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetPlans(){
		var plans = await PlanService.GetAllPlansAsync();
		return Ok(plans);
	}

	[Authorize]
	[HttpGet("{id}")]
	public IActionResult Get(int id){
		var plan = PlanService.GetPlanByIdAsync(id);
		return plan != null ? Ok(plan) : NotFound();
	}

	[Authorize]
	[HttpPost]
	public async Task<IActionResult> Add(int customerId, [FromBody] string planType){
		try{
			await PlanService.AddPlanForNewCustomerAsync(customerId, planType);
			return Ok($"Plano {planType} adicionado para o cliente {customerId}.");
		}
		catch (InvalidOperationException ex){
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpPut("{customerId}")]
	public async Task<IActionResult> Update(int customerId, [FromBody] string? newPlanType, bool cancelPlan = false){
		try{
			await PlanService.UpdatePlanAsync(customerId, newPlanType, cancelPlan);
			return NoContent();
		}
		catch (InvalidOperationException ex){
			return BadRequest(ex.Message);
		}
		catch (ArgumentException ex){
			return BadRequest(ex.Message);
		}
	}

	[Authorize]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id){
		await PlanService.DeletePlanByIdAsync(id);
		return NoContent();
	}

	[Authorize]
	[HttpGet("TestDatabaseConnection")]
	public async Task<IActionResult> TestDatabaseConnection(){
		try
		{
			var plans = await PlanService.GetAllPlansAsync();
			return Ok(plans);
		}
		catch (Exception ex)
		{
			return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
		}
	}
}