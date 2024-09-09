using Gestao_Academia.Models;

namespace Gestao_Academia.Service;

public class AlunoService
{
	private List<Aluno> Alunos = new List<Aluno>();

	public AlunoService()
	{
		Alunos.Add(new Aluno { Id = 1, Nome = "João Silva", Email = "joao@example.com", CPF = "12345678901", Telefone = "11999999999", StatusPagamento = 1 });
		Alunos.Add(new Aluno { Id = 2, Nome = "Maria Souza", Email = "maria@example.com", CPF = "98765432109", Telefone = "11988888888", StatusPagamento = 0 });
	}

	public List<Aluno> Listar()
	{
		return Alunos;
	}

	public Aluno Obter(int id)
	{
		return Alunos.FirstOrDefault(a => a.Id == id);
	}

	public void Cadastrar(Aluno aluno)
	{
		Alunos.Add(aluno);
	}

	public void Editar(Aluno aluno)
	{
		var index = Alunos.FindIndex(a => a.Id == aluno.Id);
		if (index != -1)
		{
			Alunos[index] = aluno;
		}
	}

	public void Deletar(int id)
	{
		var aluno = Alunos.FirstOrDefault(a => a.Id == id);
		if (aluno != null)
		{
			Alunos.Remove(aluno);
		}
	}
}
