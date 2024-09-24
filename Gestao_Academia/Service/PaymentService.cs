using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Academia.Service;

public class PaymentService
{
    private readonly IPaymentRepository Repository;

    public PaymentService(IPaymentRepository repository)
    {
        Repository = repository;
    }

    public async Task<List<Payment>> ListarAsync()
    {
        var payments = await Repository.GetAllAsync();
        return payments.ToList();
    }

    public async Task<Payment> ObterAsync(int id)
    {
        return await Repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Payment payment)
    {
        await Repository.AddAsync(payment);
    }

    public async Task<bool> EditarAsync(Payment payment)
    {
        return await Repository.UpdateAsync(payment);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await Repository.DeleteAsync(id);
    }

}
