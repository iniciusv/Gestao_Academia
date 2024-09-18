using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;  // Importante para usar [Authorize]

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
	private readonly AlunoService AlunoService;

	public AlunosController(AlunoService alunoService)
	{
		AlunoService = alunoService;
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetAlunos()
	{
		var alunos = await AlunoService.ListarAsync();
		return Ok(alunos);
	}

	[Authorize]
	[HttpGet("{id}")]
	public IActionResult Detalhes(int id)
	{
		var aluno = AlunoService.ObterAsync(id);
		return aluno != null ? Ok(aluno) : NotFound();
	}

	[Authorize]
	[HttpPost]
	public IActionResult Criar([FromBody] Students aluno)
	{
		AlunoService.CadastrarAsync(aluno);
		return CreatedAtAction(nameof(Detalhes), new { id = aluno.Id }, aluno);
	}

	[Authorize]
	[HttpPut("{id}")]
	public IActionResult Editar(int id, [FromBody] Students aluno)
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
			var alunos = await AlunoService.ListarAsync();
			return Ok(alunos);
		}
		catch (Exception ex)
		{
			return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
		}
	}
}
