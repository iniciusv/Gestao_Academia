using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;  // Importante para usar [Authorize]

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
	private readonly AlunoService AlunoService;

	public StudentsController(AlunoService alunoService)
	{
		AlunoService = alunoService;
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetStudents()
	{
		var alunos = await AlunoService.ListarAsync();
		return Ok(alunos);
	}

	[Authorize]
	[HttpGet("{id}")]
	public IActionResult Detail(int id)
	{
		var aluno = AlunoService.ObterAsync(id);
		return aluno != null ? Ok(aluno) : NotFound();
	}

	[Authorize]
	[HttpPost]
	public IActionResult Create([FromBody] Students aluno)
	{
		AlunoService.CadastrarAsync(aluno);
		return CreatedAtAction(nameof(Detail), new { id = aluno.Id }, aluno);
	}

	[Authorize]
	[HttpPut("{id}")]
	public IActionResult Edit(int id, [FromBody] Students aluno)
	{
		if (id != aluno.Id)
		{
			return BadRequest();
		}

		AlunoService.EditarAsync(aluno);
		return NoContent();
	}

	[Authorize]
	[HttpDelete("{id}")]
	public IActionResult Deletar(int id)
	{
		AlunoService.DeletarAsync(id);
		return NoContent();
	}

	[Authorize]
	[HttpGet("TestDatabaseConnection")]
	public async Task<IActionResult> TestDatabaseConnection()
	{
		try
		{
			var students = await AlunoService.ListarAsync();
			return Ok(students);
		}
		catch (Exception ex)
		{
			return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
		}
	}
}
