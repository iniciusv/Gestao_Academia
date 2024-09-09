using Gestao_Academia.Repository;
using Gestao_Academia.RepositoryAbstractions;
using Gestao_Academia.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container.
builder.Services.AddControllersWithViews();

// Adiciona o serviço Swagger gerador, definindo 1 ou mais documentos Swagger
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});


builder.Services.AddDbContext<AcademiaContext>(options =>
	options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21)))
);


builder.Services.AddScoped<AlunoService>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

var app = builder.Build();



// Configura o pipeline de requisições HTTP.
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
		c.RoutePrefix = string.Empty; // Configura o Swagger UI na raiz da aplicação
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
