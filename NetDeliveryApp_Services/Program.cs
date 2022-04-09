using NetDeliveryAppAplicacao;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppData.Repositorio;
using NetDeliveryAppDominio.Interfaces.Repositorios;
using NetDeliveryAppDominio.Interfaces.Aplicacao;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NetDeliveryAppContext>();

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IAcrescimoRepository, AcrescimoRepository>();
builder.Services.AddTransient<IBebidaRepository, BebidaRepository>();
builder.Services.AddTransient<IHamburguerRepository, HamburguerRepository>();

builder.Services.AddTransient<IClienteAplicacao, ClienteAplicacao>();
builder.Services.AddTransient<IAcrescimoAplicacao, AcrescimoAplicacao>();
builder.Services.AddTransient<IBebidaAplicacao, BebidaAplicacao>();
builder.Services.AddTransient<IEnderecoAplicacao, EnderecoAplicacao>();
builder.Services.AddTransient<IHamburguerAplicacao, HamburguerAplicacao>();
builder.Services.AddTransient<IPedidoAplicacao, PedidoAplicacao>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();