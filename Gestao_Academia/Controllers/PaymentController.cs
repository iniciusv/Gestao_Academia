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

    //[Authorize]
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var payments = await PaymentService.ListarAsync();
        return Ok(payments);
    }

    //[Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        var payment = await PaymentService.ObterAsync(id);
        return payment != null ? Ok(payment) : NotFound();
    }

    //[Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Payment payments)
    {
        await PaymentService.CreateAsync(payments);
        return CreatedAtAction(nameof(Detail), new { id = payments.Id }, payments);
    }

    //[Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, [FromBody] Payment payments)
    {
        if (id != payments.Id)
        {
            return BadRequest("O ID do payment não corresponde ao ID fornecido.");
        }

        var result = await PaymentService.EditarAsync(payments);
        if (result)
        {
            return NoContent();
        }
        else
        {
            return NotFound("Aluno não encontrado.");
        }
    }

    //[Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await PaymentService.DeleteAsync(id);
        if (result)
        {
            return NoContent();
        }
        else
        {
            return NotFound("Aluno não encontrado.");
        }
    }
}
