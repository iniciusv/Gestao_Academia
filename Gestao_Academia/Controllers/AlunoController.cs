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
	public IActionResult Listar()
	{
		var alunos = AlunoService.Listar();
		return Ok(alunos);
	}

	[HttpGet("{id}")]
	public IActionResult Detalhes(int id)
	{
		var aluno = AlunoService.Obter(id);
		return aluno != null ? Ok(aluno) : NotFound();
	}

	[HttpPost]
	public IActionResult Criar([FromBody] Aluno aluno)
	{
		AlunoService.Cadastrar(aluno);
		return CreatedAtAction(nameof(Detalhes), new { id = aluno.Id }, aluno);
	}

	[HttpPut("{id}")]
	public IActionResult Editar(int id, [FromBody] Aluno aluno)
	{
		if (id != aluno.Id)
		{
			return BadRequest();
		}

		AlunoService.Editar(aluno);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public IActionResult Deletar(int id)
	{
		AlunoService.Deletar(id);
		return NoContent();
	}
}
