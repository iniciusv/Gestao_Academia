using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("plan")]
public class Plan{
	public int Id { get; set; }
 	public int IdCustomer { get; set; }
	public string? Plan_Type { get; set; }
 	public DateTime? Start_Date { get; set; }
  	public DateTime? End_Date { get; set; }
   	public Enum? Status { get;set }
 	public DateTime? Created_at { get; set; }
  	public DateTime? Updated_at { get; set; }
}
