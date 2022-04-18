using CalculoJuros.WebApi.Services;
using Xunit;

namespace TesteProcessoSeletivo.Tests
{
    public class JurosServiceSpecs
    {

        [Fact]
        public void Calculo_do_juros_esta_correto()
        {
            // Arrange
            var service = new JurosService();

            // Act
            decimal result = service.CalcularJuros(
                valorInicial: 100m, 
                taxaDeJuros: 0.01m, 
                tempoEmMeses: 5);

            // Assert
            Assert.Equal(
                expected: 105.10m, 
                actual: result, 
                precision: 2);
        }
    }
}