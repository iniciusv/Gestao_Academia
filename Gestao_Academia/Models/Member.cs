using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestao_Academia.Models;

[Table("members")]
public class Member
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }  // Mapeia para 'id', bigint(20) unsigned, autoincrement

	[Required]
	[MaxLength(100)]
	public string Name { get; set; }  // Mapeia para 'name', varchar(100)

	[Required]
	[MaxLength(100)]
	[Column("email")]
	[EmailAddress]
	public string Email { get; set; }  // Mapeia para 'email', varchar(100), com restrição de e-mail válido

	[Required]
	[MaxLength(11)]
	[Column("cpf")]
	public string CPF { get; set; }  // Mapeia para 'cpf', char(11)

	[Required]
	[MaxLength(11)]
	[Column("phone")]
	public string Phone { get; set; }  // Mapeia para 'phone', char(11)

	[Column("date_of_birth")]
	[DataType(DataType.Date)]
	public DateTime? DateOfBirth { get; set; }  // Mapeia para 'date_of_birth', date, pode ser null

	[Column("gender")]
	public Gender Gender { get; set; }  // Mapeia para 'gender', enum('male', 'female', 'other')

	public DateTime CreatedAt { get; set; }  // Mapeia para 'created_at', timestamp

	public DateTime UpdatedAt { get; set; }  // Mapeia para 'updated_at', timestamp
}

public enum Gender
{
	Male,
	Female,
	Other
}
