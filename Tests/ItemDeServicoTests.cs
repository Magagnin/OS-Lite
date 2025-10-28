using Xunit;
using OSLite.Domain;
using OSLite.Domain.ValueObjects;

namespace OSLite.Tests
{
    public class ItemDeServicoTests
    {
        [Fact]
        public void DeveCriarItemCorretamente()
        {
            var item = new ItemDeServico("Troca de bateria", new Money(150));
            Assert.Equal("Troca de bateria", item.Descricao);
            Assert.Equal(150, item.Preco.Valor);
        }
    }
}

