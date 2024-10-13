using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;

[Table("payments")]
public class Payment
{
	public int Id { get; set; }
	public int member_id { get; set; }
	//[DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
	public DateTime? date { get; set; }
	public string? Status { get; set; }
	public string? payment_method { get; set; }
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
	public DateTime? Created_at { get; set; }
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
	public DateTime? Updated_at { get; set; }

}