using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
	private readonly CustomerService CustomerService;

	public CustomerController(CustomerService customerService)
	{
		CustomerService = customerService;
	}

	//[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetStudents()
	{
		var alunos = await CustomerService.ListarAsync();
		return Ok(alunos);
	}

	//[Authorize]
	[HttpGet("{id}")]
	public async Task<IActionResult> Detail(int id)
	{
		var aluno = await CustomerService.ObterAsync(id);
		return aluno != null ? Ok(aluno) : NotFound();
	}


	//[Authorize]
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] Customer students)
	{
		await CustomerService.CreateAsync(students);
		return CreatedAtAction(nameof(Detail), new { id = students.Id }, students);
	}

	//[Authorize]
	[HttpPut("{id}")]
	public async Task<IActionResult> Edit(int id, [FromBody] Customer students)
	{
		if (id != students.Id)
		{
			return BadRequest("O ID do aluno não corresponde ao ID fornecido.");
		}

		var result = await CustomerService.EditarAsync(students);
		if (result)
		{
			return NoContent();
		}
		else
		{
			return NotFound("Aluno não encontrado.");
		}
	}

	//[Authorize]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await CustomerService.DeleteAsync(id);
		if (result)
		{
			return NoContent();
		}
		else
		{
			return NotFound("Aluno não encontrado.");
		}
	}
}
