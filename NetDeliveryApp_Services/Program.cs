using NetDeliveryAppAplicacao;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppData.Repositorio;
using NetDeliveryAppDominio.Interfaces.Repositorios;
using NetDeliveryAppDominio.Interfaces.Aplicacao;

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
