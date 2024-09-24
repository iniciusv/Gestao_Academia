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

    public async Task<List<Payment>> GetAllPaymentsAsync()
    {
        var Payments = await Repository.GetAllAsync();
        return Payments.ToList();
    }

    public async Task<Payment> GetPaymentByIdAsync(int id)
    {
        return await Repository.GetByIdAsync(id);
    }

    public async Task AddPaymentAsync(Payment Payment)
    {
        await Repository.AddAsync(Payment);
    }

    public async Task UpdatePaymentAsync(Payment Payment)
    {
        await Repository.UpdateAsync(Payment);
    }

    public async Task DeletePaymentByIdAsync(int id)
    {
        await Repository.DeleteAsync(id);
    }
}
