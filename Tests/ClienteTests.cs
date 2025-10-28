using Xunit;
using OSLite.Domain;
using OSLite.Domain.ValueObjects;

namespace OSLite.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void DeveAdicionarOrdemAoCliente()
        {
            var cliente = new Cliente("João", new Email("joao@teste.com"));
            var ordem = new OrdemDeServico();

            cliente.AdicionarOrdem(ordem);

            Assert.Single(cliente.Ordens);
            Assert.Equal(cliente, ordem.Cliente);
        }
    }
}

