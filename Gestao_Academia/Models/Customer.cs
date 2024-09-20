using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("customer")]
public class Customer{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? Cpf { get; set; }
	public string? Phone { get; set; }
}