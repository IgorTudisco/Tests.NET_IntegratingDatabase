using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {

        private readonly IAgenciaRepositorio? _repositorio;
        public AgenciaRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestaRemoverInformacaoDeDeterminadaAgencia()
        {
            // Arragen
            // Act
            var atualizado = _repositorio.Excluir(3);

            // Assert
            Assert.True(atualizado);

        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            // Arragen
            // Act
            // Assert
            Assert.Throws<Exception>(
                () => _repositorio.ObterPorId(33)
            );
        }

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            // Arrange
            var agencia = new Agencia()
            {
                Nome = "Agencia de Todos",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua De Todos Nós",
                Numero = 1542
            };

            var repositorioMock = new ByteBankRepositorio();

            // Act
            var adicionar = repositorioMock.AdicionarAgencia(agencia);

            // Assert
            Assert.True(adicionar);

        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            // Arragen
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            // Act
            var list = mock.BuscarAgencias();

            // Assert
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
        }

    }
}
