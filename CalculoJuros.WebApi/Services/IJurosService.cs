namespace CalculoJuros.WebApi.Services;

public interface IJurosService
{
    public decimal CalcularJuros(decimal valorInicial, decimal taxaDeJuros, int tempoEmMeses);
}