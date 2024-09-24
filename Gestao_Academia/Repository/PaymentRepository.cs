using Dapper;
using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Gestao_Academia.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly GymContext Context;
    private readonly IDbConnection Connection;

    public PaymentRepository(GymContext context, IDbConnection connection)
    {
        Context = context;
        this.Connection = connection;
    }
    // Exemplo de método usando Dapper
    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        string sql = "SELECT * FROM payments";
        return await Connection.QueryAsync<Payment>(sql);
    }


    public async Task<Payment> GetByIdAsync(int id)
    {
        string sql = "SELECT * FROM payments WHERE id = @Id";
        return await Connection.QuerySingleOrDefaultAsync<Payment>(sql, new { Id = id });
    }

    public async Task AddAsync(Payment payment)
    {
        Context.Payment.Add(payment);
        await Context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Payment payment)
    {
        var existingStudent = await Context.Payment.FindAsync(payment.Id);
        if (existingStudent == null)
        {
            return false;
        }

        Context.Entry(existingStudent).CurrentValues.SetValues(payment);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var payment = await Context.Payment.FindAsync(id);
        if (payment == null)
        {
            return false;
        }

        Context.Payment.Remove(payment);
        await Context.SaveChangesAsync();
        return true;
    }

}
