using Xunit;
using OSLite.Domain;
using OSLite.Domain.Enums;
using OSLite.Domain.ValueObjects;
using OSLite.Exceptions;

namespace OSLite.Tests
{
    public class OrdemDeServicoTests
    {
        [Fact]
        public void DeveCalcularTotalCorretamente()
        {
            var os = new OrdemDeServico();
            os.AdicionarItem(new ItemDeServico("Troca de tela", new Money(200)));
            os.AdicionarItem(new ItemDeServico("Formatação", new Money(100)));

            Assert.Equal(300, os.Total.Valor);
        }

        [Fact]
        public void DevePermitirTransicaoCorretaDeStatus()
        {
            var os = new OrdemDeServico();
            os.Iniciar();
            os.Concluir();

            Assert.Equal(StatusOS.Concluida, os.Status);
        }

        [Fact]
        public void NaoDevePermitirAdicionarItemComOSIniciada()
        {
            var os = new OrdemDeServico();
            os.Iniciar();

            Assert.Throws<StatusInvalidoException>(() =>
                os.AdicionarItem(new ItemDeServico("Limpeza", new Money(50))));
        }
    }
}

