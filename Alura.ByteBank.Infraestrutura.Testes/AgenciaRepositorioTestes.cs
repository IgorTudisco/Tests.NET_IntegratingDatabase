using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
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

    }
}
