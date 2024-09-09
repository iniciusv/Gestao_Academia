using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
	private readonly AlunoService AlunoService;

	public AlunosController(AlunoService alunoService)
	{
		AlunoService = alunoService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAlunos()
	{
		var alunos = await AlunoService.ListarAsync();
		return Ok(alunos); // Isso garante que o resultado é retornado, não a Task
	}

	[HttpGet("{id}")]
	public IActionResult Detalhes(int id)
	{
		var aluno = AlunoService.ObterAsync(id);
		return aluno != null ? Ok(aluno) : NotFound();
	}

	[HttpPost]
	public IActionResult Criar([FromBody] Students aluno)
	{
		AlunoService.CadastrarAsync(aluno);
		return CreatedAtAction(nameof(Detalhes), new { id = aluno.Id }, aluno);
	}

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

	[HttpDelete("{id}")]
	public IActionResult Deletar(int id)
	{
		AlunoService.DeletarAsync(id);
		return NoContent();
	}

	[HttpGet("TestDatabaseConnection")]
	public async Task<IActionResult> TestDatabaseConnection()
	{
		try
		{
			var alunos = await AlunoService.ListarAsync();
			return Ok(alunos); // Se isso funcionar, a conexão está boa
		}
		catch (Exception ex)
		{
			return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
		}
	}


}
