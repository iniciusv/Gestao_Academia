namespace Gestao_Academia.Models;

public class Aluno
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string CPF { get; set; }
	public string Telefone { get; set; }
	public int StatusPagamento { get; set; }

	public List<Pagamento> Pagamentos { get; set; }

	public Aluno()
	{
		Pagamentos = new List<Pagamento>();
	}
}