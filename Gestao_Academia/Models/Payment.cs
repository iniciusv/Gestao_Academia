namespace Gestao_Academia.Models;
public class Payment{
	public int Id { get; set; }
	public int IdCustomer { get; set; }
	public int Year { get; set; }
	public int Month { get; set; }
	public int Status { get; set; }
	public Customer? Customer { get; set; }
}