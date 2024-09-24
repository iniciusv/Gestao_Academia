using Gestao_Academia.Models;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService PaymentService;

    public PaymentController(PaymentService paymentService)
    {
        PaymentService = paymentService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetPayments()
    {
        var payments = await PaymentService.GetAllPaymentsAsync();
        return Ok(payments);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var payment = PaymentService.GetPaymentByIdAsync(id);
        return payment != null ? Ok(payment) : NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Payment payment)
    {
        await PaymentService.AddPaymentAsync(payment);
        return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Payment payment)
    {
        if (id != payment.Id)
        {
            return BadRequest();
        }

        await PaymentService.UpdatePaymentAsync(payment);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await PaymentService.DeletePaymentByIdAsync(id);
        return NoContent();
    }

    [Authorize]
    [HttpGet("TestDatabaseConnection")]
    public async Task<IActionResult> TestDatabaseConnection()
    {
        try
        {
            var payments = await PaymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao acessar o banco de dados: {ex.Message}");
        }
    }
}