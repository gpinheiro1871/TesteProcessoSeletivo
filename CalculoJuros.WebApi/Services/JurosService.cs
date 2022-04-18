namespace CalculoJuros.WebApi.Services;

public class JurosService : IJurosService
{
    public decimal CalcularJuros(decimal valorInicial, decimal taxaDeJuros, int tempoEmMeses)
    {
        // valorInicial * (1 + taxaDeJuros) ^ tempoEmMeses

        var juros = (double) valorInicial * Math.Pow((double)(1 + taxaDeJuros), tempoEmMeses);

        return (decimal) juros;
    }
}