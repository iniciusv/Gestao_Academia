using Gestao_Academia.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container.
builder.Services.AddControllersWithViews();

// Adiciona o serviço Swagger gerador, definindo 1 ou mais documentos Swagger
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

builder.Services.AddScoped<AlunoService>();
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
