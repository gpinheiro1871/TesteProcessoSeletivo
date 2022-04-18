namespace CalculoJuros.WebApi.Services;

internal class TaxaJurosService : ITaxaJurosService
{
    private readonly HttpClient client;

    public TaxaJurosService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<decimal> ObterTaxaDeJuros(string path)
    {
        HttpResponseMessage response = await client.GetAsync(path);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException();
        }

        var taxaDeJuros = await response.Content
            .ReadFromJsonAsync<decimal>();

        return taxaDeJuros;
    }
}