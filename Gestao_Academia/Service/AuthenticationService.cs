using Gestao_Academia.RepositoryAbstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Gestao_Academia.Repository;

namespace Gestao_Academia.Service;

public class AuthenticationService{
	private readonly IConfiguration Configuration;
	private readonly IUserRepository UserRepository;

	public AuthenticationService(IConfiguration configuration, IUserRepository userRepository){
		Configuration = configuration;
		UserRepository = userRepository;
	}

	public string GenerateJwtToken(string username){
		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, username)
		};

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]!));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: Configuration["Jwt:Issuer"],
			audience: Configuration["Jwt:Audience"],
			claims: claims,
			expires: DateTime.Now.AddHours(1),
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	public bool ValidateUser(string username, string password){
		var user = UserRepository.FindByUsername(username);
		if (user != null)
		{
			return user.Password == password; // Compare passwords directly
		}
		return false;
	}
}