using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase{
	private readonly CustomerService CustomerService;

	public CustomersController(CustomerService customerService){
		CustomerService = customerService;
	}

	[Authorize]
	[HttpGet]
	public async Task<IActionResult> GetCustomers(){
		var customers = await CustomerService.ListCustomerAsync();
		return Ok(customers);
	}

	[Authorize]
	[HttpGet("{id}")]
	public IActionResult Details(int id){
		var customer = CustomerService.GetCustomerByIdAsync(id);
		return customer != null ? Ok(customer) : NotFound();
	}

	[Authorize]
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] Customer customer){
		await CustomerService.AddCustomerAsync(customer);
		return CreatedAtAction(nameof(Details), new { id = customer.Id }, customer);
	}

	[Authorize]
	[HttpPut("{id}")]
	public async Task<IActionResult> Edit(int id, [FromBody] Customer customer){
		if (id != customer.Id){
			return BadRequest();
		}

		await CustomerService.EditCustomerAsync(customer);
		return NoContent();
	}

	[Authorize]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id){
		await CustomerService.DeleteCustomerByIdAsync(id);
		return NoContent();
	}

	[Authorize]
	[HttpGet("TestDatabaseConnection")]
	public async Task<IActionResult> TestDatabaseConnection(){
		try{
			var customers = await CustomerService.ListCustomerAsync();
			return Ok(customers);
		}
		catch (Exception ex){
			return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
		}
	}
}