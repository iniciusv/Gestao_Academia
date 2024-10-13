using Gestao_Academia.Repository;
using Gestao_Academia.RepositoryAbstractions;
using Gestao_Academia.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
		};
	});

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Digite 'Bearer [espa�o] e ent�o seu token JWT.' Exemplo: 'Bearer 12345abcdef'"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] {}
		}
	});
});

builder.Services.AddDbContext<GymContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)))
);

builder.Services.AddScoped<IDbConnection>(db => new MySqlConnection(
	builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<PlanService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<PaymentService>();

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
	// Ativa o middleware para servir o Swagger gerado como um endpoint JSON.
	app.UseSwagger();
	// Ativa o middleware para servir o swagger-ui.
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
		c.RoutePrefix = string.Empty; // Configura o Swagger UI na raiz da aplica��o
	});
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
