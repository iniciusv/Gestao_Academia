using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("students")]
public class Customer
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string? CPF { get; set; }
	public string? Phone { get; set; }
	// public DateTime? Date_Birth { get; set; } //
    // public string Gender { get; set; } //
    // public DateTime? Created_at { get; set; } //
	// public DateTime? Updated_at { get; set; } //
}