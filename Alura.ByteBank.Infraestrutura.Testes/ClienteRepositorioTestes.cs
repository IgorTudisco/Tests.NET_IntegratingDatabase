using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio? _repositorio;
        public ClienteRepositorioTestes()
        {
            // Arrange
            var serviço = new ServiceCollection();
            serviço.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = serviço.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {

            // Act
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            List<Cliente> listaClientes = _repositorio.ObterTodos();
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
            // Assert
            Assert.NotNull(listaClientes);
            Assert.Equal(3, listaClientes.Count);
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            // Arragen
            // Act
            Cliente cliente = _repositorio.ObterPorId(1);
            // Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientPorVariosId(int id)
        {
            // Arrage
            // Act
            Cliente cliente = _repositorio.ObterPorId(id);
            // Assert
            Assert.NotNull(cliente);
        }

    }
}
