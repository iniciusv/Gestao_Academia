using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
	private readonly StudentsService StudentsService;

	public StudentsController(StudentsService alunoService)
	{
		StudentsService = alunoService;
	}

	//[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetStudents()
	{
		var alunos = await StudentsService.ListarAsync();
		return Ok(alunos);
	}

	//[Authorize]
	[HttpGet("{id}")]
	public async Task<IActionResult> Detail(int id)
	{
		var aluno = await StudentsService.ObterAsync(id);
		return aluno != null ? Ok(aluno) : NotFound();
	}


	//[Authorize]
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] Students students)
	{
		await StudentsService.CreateAsync(students);
		return CreatedAtAction(nameof(Detail), new { id = students.Id }, students);
	}


	//[Authorize]
	[HttpPut("{id}")]
	public async Task<IActionResult> Edit(int id, [FromBody] Students students)
	{
		if (id != students.Id)
		{
			return BadRequest("O ID do aluno não corresponde ao ID fornecido.");
		}

		var result = await StudentsService.EditarAsync(students);
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
		var result = await StudentsService.DeleteAsync(id);
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
