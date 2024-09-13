namespace Gestao_Academia.Models;
public class Pagamento
{
	public int Id { get; set; }
	public int IdAluno { get; set; }
	public int Ano { get; set; }
	public int Mes { get; set; }
	public int Status { get; set; }
	public Students Aluno { get; set; }
}
