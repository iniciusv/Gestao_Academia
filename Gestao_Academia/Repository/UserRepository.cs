using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
namespace Gestao_Academia.Repository;
public class UserRepository : IUserRepository
{
	private readonly AcademiaContext Context;

	public UserRepository(AcademiaContext context)
	{
		Context = context;
	}

	public Users FindByUsername(string username) => Context.Users.FirstOrDefault(user => user.Name == username);
}
