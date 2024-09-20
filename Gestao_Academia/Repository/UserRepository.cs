using Gestao_Academia.Models;
using Gestao_Academia.RepositoryAbstractions;
namespace Gestao_Academia.Repository;
public class UserRepository : IUserRepository{
	private readonly GymContext Context;

	public UserRepository(GymContext context){
		Context = context;
	}

	public Users FindByUsername(string username){
    	return Context.Users.FirstOrDefault(user => user.Name == username) 
				?? throw new InvalidOperationException($"User with username '{username}' not found.");
	}

}
