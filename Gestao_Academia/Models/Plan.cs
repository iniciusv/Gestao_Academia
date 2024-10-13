using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Academia.Models;


[Table("plans")]
public class Plan
{
	[Key]
	public long Id { get; set; }  // 'id' como chave primária.

	[Column("member_id")]
	[ForeignKey("Member")]  // Definindo a relação com a tabela 'members'.
	public long MemberId { get; set; }  // Mapeando explicitamente 'member_id' para esta propriedade.

	[Column("plan_type")]
	public string PlanType { get; set; }  // 'plan_type' do tipo varchar(255).

	[Column("start_date")]
	[DataType(DataType.Date)]
	public DateTime StartDate { get; set; }  // 'start_date' como data.

	[Column("end_date")]
	[DataType(DataType.Date)]
	public DateTime EndDate { get; set; }  // 'end_date' como data.

	[Column("status", TypeName = "varchar(10)")]
	public string Status { get; set; }  // 'status' como string para representar o enum.


	[DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
	[Column("created_at")]
	public DateTime CreatedAt { get; set; }  // Propriedade gerenciada pelo sistema, não inclusa em 'fillable'.
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
	[Column("updated_at")]
	public DateTime UpdatedAt { get; set; }  // Propriedade gerenciada pelo sistema, não inclusa em 'fillable'.

	// Propriedade de navegação para a entidade relacionada 'Member'.
	public virtual Member Member { get; set; }
}

// Enumeração para o campo 'status'
public enum PlanStatus
{
	Active,
	Inactive
}
