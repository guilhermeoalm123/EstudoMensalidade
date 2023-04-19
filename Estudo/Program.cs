using Dominio.Interface;
using Dominio.Repositorio;
using Dominio.Servicos.Pessoas;
using Dominio.Servicos.Mensalidade;
using Dominio.Servicos.Pagamento;
using Estudo.Servico;
using Estudo.Servico.Interface;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using Repositorio.Entidades;
using System;
using Dominio.Servicos.Kanban;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Aplica��o
builder.Services.AddScoped<IServicoAplicacaoPessoas, ServicoAplicacaoPessoas>();
builder.Services.AddScoped<IServicoAplicacaoMensalidade, ServicoAplicacaoMensalidade>();
builder.Services.AddScoped<IServicoAplicacaoPagamento, ServicoAplicacaoPagamento>();
builder.Services.AddScoped<IServicoAplicacaoKanban, ServicoAplicacaoKanban>();

//Dominio
builder.Services.AddScoped<IServicoPessoas, ServicoPessoas>();
builder.Services.AddScoped<IServicoMensalidade, ServicoMensalidade>();
builder.Services.AddScoped<IServicoPagamento, ServicoPagamento>();
builder.Services.AddScoped<IServicoKanban, ServicoKanban>();


//Repositorio
builder.Services.AddScoped<IRepositorioPessoas, RepositorioPessoas>();
builder.Services.AddScoped<IRepositorioMensalidade, RepositorioMensalidade>();
builder.Services.AddScoped<IRepositorioPagamento, RepositorioPagamento>();
builder.Services.AddScoped<IRepositorioKanban, RepositorioKanban>();


//builder.Services.AddDbContext<Repositorio.Contexto.ApplicationDbContext>(options =>
//options.UseSqlServer("server=.;DataBase=teste;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False"));

builder.Services.AddDbContext<Repositorio.Contexto.ApplicationDbContext>(options =>
{
	options.UseSqlServer("server=.;DataBase=teste;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();

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