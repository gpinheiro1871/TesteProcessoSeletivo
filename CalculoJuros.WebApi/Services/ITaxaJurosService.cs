namespace CalculoJuros.WebApi.Services;

public interface ITaxaJurosService
{
    public Task<decimal> ObterTaxaDeJuros(string path);
}