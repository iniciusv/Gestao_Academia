using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Academia.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly GymContext Context;

    public PaymentRepository(GymContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await Context.Payment.ToListAsync();
    }

    public async Task<Payment> GetByIdAsync(int id)
    {
        return await Context.Payment.FindAsync(id)
            ?? throw new InvalidOperationException($"Customer with ID {id} not found.");
    }

    public async Task AddAsync(Payment payment)
    {
        Context.Payment.Add(payment);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
        Context.Entry(payment).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var payment = await Context.Payment.FindAsync(id);

        if (payment != null)
        {
            Context.Payment.Remove(payment);
            await Context.SaveChangesAsync();
        }
    }
}
