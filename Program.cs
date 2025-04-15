using LojaProdutos.Data;
using LojaProdutos.Services.Categoria;
using LojaProdutos.Services.Produtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Adiciona o DataContext como um servi�o que pode ser injetado em outras partes do sistema
builder.Services.AddDbContext<DataContext>(options =>
{
    // Configura o contexto para usar o SQL Server, pegando a string de conex�o chamada "DefaultConnection"
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<ICategoriaInterface, CategoriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
