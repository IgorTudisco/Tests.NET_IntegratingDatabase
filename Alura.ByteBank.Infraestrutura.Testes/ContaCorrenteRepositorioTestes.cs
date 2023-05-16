using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio? _repositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var servicos = new ServiceCollection();
            servicos.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servicos.BuildServiceProvider();
            _repositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestaAtualizaSaldoDeDeterminadaConta()
        {
            // Arrange
            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            // Act
            var atualizado = _repositorio.Atualizar(1, conta);

            // Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInserirUmaNovaContaCorrenteNoBancoDeDados()
        {
            // Arragen
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Igor",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Desenvolvedor",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador= Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua Das Flores, 246",
                    Numero = 111
                }            
            };

            // Act
            var retorno = _repositorio.Adicionar(conta);

            // Assert
            Assert.True(retorno);

        }

        [Fact]
        public void TestaConsultaTodosPix()
        {
            // Arragen
            var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
            var pix = new PixDTO() { Chave = guid, Saldo = 10 };

            var pixRepositorioMock = new Mock<IPixRepositorio>();
            pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixRepositorioMock.Object;

            // Act
            var saldo = mock.consultaPix(guid).Saldo;

            // Assert
            Assert.Equal(10, saldo);
        }

    }
}
