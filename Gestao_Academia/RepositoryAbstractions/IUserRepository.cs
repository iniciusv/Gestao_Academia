using Gestao_Academia.Models;

namespace Gestao_Academia.RepositoryAbstractions;
public interface IUserRepository{
	Users FindByUsername(string username);
}
