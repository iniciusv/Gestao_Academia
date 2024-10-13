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

	//[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetPlans()
	{
		var plans = await PlanService.GetAllPlansAsync();
		return Ok(plans);
	}



	//[Authorize]
	[HttpGet("{id}")]
	public IActionResult Get(int id){
		var plan = PlanService.GetPlanByIdAsync(id);
		return plan != null ? Ok(plan) : NotFound();
	}

	//[Authorize]
	[HttpPost]
	public async Task<IActionResult> Add([FromBody] Plan plan){
		await PlanService.AddPlanAsync(plan);
		return CreatedAtAction(nameof(Get), new { id = plan.Id }, plan);
	}

	//[Authorize]
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(long id, [FromBody] Plan plan){
		if (id != plan.Id){
			return BadRequest();
		}

		await PlanService.UpdatePlanAsync(plan);
		return NoContent();
	}

	//[Authorize]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id){
		await PlanService.DeletePlanByIdAsync(id);
		return NoContent();
	}

	//[Authorize]
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