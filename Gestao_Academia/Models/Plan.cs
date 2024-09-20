using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("plan")]
public class Plan
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
}