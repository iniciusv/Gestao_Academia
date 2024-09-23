using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("users")]
public class Users{
	public long Id { get; set; }
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }
	public DateTime? Email_verified_at { get; set; }
	public string? Remember_token { get; set; }
	public DateTime? Created_at { get; set; }
	public DateTime? Updated_at { get; set; }
}
