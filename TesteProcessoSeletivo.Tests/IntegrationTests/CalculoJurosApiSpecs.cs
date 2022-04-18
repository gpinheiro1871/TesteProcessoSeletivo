using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TesteProcessoSeletivo.Tests.IntegrationTests;

public class CalculoJurosApiSpecs
{
    [Fact]
    public async Task Calculo_de_juros_retorna_valor_correto()
    {
        // Arrange
        await using var app = new CalculoJurosApiApplication();

        var query = new Dictionary<string, string?>()
        {
            ["valorinicial"] = "100",
            ["meses"] = "5"
        };

        var uri = QueryHelpers.AddQueryString("/calculajuros", query);

        var client = app.CreateClient();

        // Act
        var response = await client.GetAsync(uri);
        var juros = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal("105.1", juros);
    }
}
