using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllAsync();
    Task<Payment> GetByIdAsync(int id);
    Task AddAsync(Payment payment);
    Task<bool> UpdateAsync(Payment payment);
    Task<bool> DeleteAsync(int id);
}