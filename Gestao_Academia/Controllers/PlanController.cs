//using Gestao_Academia.Models;
//using Gestao_Academia.Service;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;  // Importante para usar [Authorize]

//[ApiController]
//[Route("[controller]")]
//public class PlanController : ControllerBase
//{
//	private readonly PlanService PlanService;

//	public PlansController(PlanService planService)
//	{
//		PlanService = planService;
//	}

//	[Authorize]
//	[HttpGet]
//	public async Task<IActionResult> GetPlans()
//	{
//		var plans = await PlanService.ListarAsync();
//		return Ok(plans);
//	}

//	[Authorize]
//	[HttpGet("{id}")]
//	public IActionResult Get(int id)
//	{
//		var plan = PlanService.GetAsync(id);
//		return plan != null ? Ok(plan) : NotFound();
//	}

//	[Authorize]
//	[HttpPost]
//	public IActionResult Add([FromBody] Students plan)
//	{
//		PlanService.AddAsync(plan);
//		return CreatedAtAction(nameof(Get), new { id = plan.Id }, plan);
//	}

//	[Authorize]
//	[HttpPut("{id}")]
//	public IActionResult Update(int id, [FromBody] Students plan)
//	{
//		if (id != plan.Id)
//		{
//			return BadRequest();
//		}

//		PlanService.UpdateAsync(plan);
//		return NoContent();
//	}

//	[Authorize]
//	[HttpDelete("{id}")]
//	public IActionResult Delete(int id)
//	{
//		PlanService.DeleteAsync(id);
//		return NoContent();
//	}

//	[Authorize]
//	[HttpGet("TestDatabaseConnection")]
//	public async Task<IActionResult> TestDatabaseConnection()
//	{
//		try
//		{
//			var plans = await PlanService.ListAsync();
//			return Ok(plans);
//		}
//		catch (Exception ex)
//		{
//			return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
//		}
//	}
//}
