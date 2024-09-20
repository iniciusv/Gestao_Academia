using Gestao_Academia.Service;
using Microsoft.AspNetCore.Mvc;
namespace Gestao_Academia.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase{
	private readonly AuthenticationService AuthenticationService;

	public AuthenticationController(AuthenticationService authenticationService){
		AuthenticationService = authenticationService;
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] LoginModel login){
		if (AuthenticationService.ValidateUser(login.Username!, login.Password!))
		{
			var token = AuthenticationService.GenerateJwtToken(login.Username!);
			return Ok(new { Token = token });
		}
		return Unauthorized();
	}
}

public class LoginModel{
	public string? Username { get; set; }
	public string? Password { get; set; }
}
