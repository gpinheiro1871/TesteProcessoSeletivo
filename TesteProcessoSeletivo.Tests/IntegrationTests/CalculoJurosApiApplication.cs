using CalculoJuros.WebApi.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;

namespace TesteProcessoSeletivo.Tests.IntegrationTests;

public class CalculoJurosApiApplication : WebApplicationFactory<Program>
{
    private readonly Mock<ITaxaJurosService> taxaJurosServiceStub;

    public CalculoJurosApiApplication()
    {
        taxaJurosServiceStub = new Mock<ITaxaJurosService>();

        taxaJurosServiceStub.Setup(x => x.ObterTaxaDeJuros(It.IsAny<string>())).ReturnsAsync(0.01m);
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(ITaxaJurosService));
            services.TryAddSingleton(taxaJurosServiceStub.Object);
        });

        return base.CreateHost(builder);
    }
}
