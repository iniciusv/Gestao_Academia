using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("payments")]
public class Payment{
	public int Id { get; set; }
	public int IdCustomer { get; set; }
	public DateTime Year { get; set; }
    // public int Month { get; set; }
    public string Status { get; set; }
    public string Method { get; set; } // Payment Method
    public DateTime? Created_at { get; set; } //
    public DateTime? Updated_at { get; set; } //
    // public Customer? Customer { get; set; }
}