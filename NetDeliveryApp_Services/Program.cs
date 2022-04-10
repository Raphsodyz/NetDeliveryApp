using NetDeliveryAppAplicacao;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppData.Contexto;
using NetDeliveryAppData.Repositorio;
using NetDeliveryAppDominio.Interfaces.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NetDeliveryAppContext>();

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IAcrescimoRepository, AcrescimoRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutosRepository>();

builder.Services.AddTransient<IClienteAplicacao, ClienteAplicacao>();
builder.Services.AddTransient<IAcrescimoAplicacao, AcrescimoAplicacao>();
builder.Services.AddTransient<ICategoriaAplicacao, CategoriaAplicacao>();
builder.Services.AddTransient<IEnderecoAplicacao, EnderecoAplicacao>();
builder.Services.AddTransient<IProdutoAplicacao, ProdutoAplicacao>();
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