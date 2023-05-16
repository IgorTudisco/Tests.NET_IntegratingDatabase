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
        public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
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

    }
}
