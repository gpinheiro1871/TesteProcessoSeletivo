using CalculoJuros.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ITaxaJurosService, TaxaJurosService>();
builder.Services.AddTransient<ITaxaJurosService, TaxaJurosService>();
builder.Services.AddTransient<IJurosService, JurosService>();

var app = builder.Build();

var taxaJurosPath = app.Configuration.GetValue<string>("TaxaDeJurosPath");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/calculajuros",
    async (IJurosService calculoService, ITaxaJurosService taxaService,
    decimal valorInicial, int meses) =>
    {
        decimal taxaDeJuros = await taxaService.ObterTaxaDeJuros(taxaJurosPath);

        decimal juros = calculoService.CalcularJuros(valorInicial, taxaDeJuros, meses);

        decimal response = Math.Truncate(juros * 100) / 100;

        return Results.Ok(response);
    })
    .Produces<decimal>(StatusCodes.Status200OK);

app.MapGet("/showmethecode", () =>
    {
        throw new NotImplementedException();
    });

app.Run();

// Adicionar visibilidade para o projeto de testes
public partial class Program { }