using SilvaEstacionamento;
using SilvaEstacionamento.SilvaEstacionamentoModelos;
using SilvaEstacionamentoModelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace SilvaEstacionamentoTest
{
    public class VeiculoTeste
    {
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;
        private Operador operador;
        public VeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
            operador = new Operador();
            operador.Nome = "Operador Noturno";
        }

        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarCom10()
        {
            veiculo.Acelerar(10);

            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]
        [Trait("Propriedade", "Proprietário")]
        public void TestaNomeProprietarioVeiculoComDoisCaracteres()
        {
            string nomeProprietarioComDoisCaracteres = "Ab";
            
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Proprietario = nomeProprietarioComDoisCaracteres
            );
        }

        [Fact]
        public void TestaQuantidadeCaracteresPlacaVeiculo()
        { 
            string placa = "Ab";
        
            Assert.Throws<System.FormatException>(
            
                () => new Veiculo().Placa=placa
            );
        }

        [Fact]
        public void TestaQuartoCaractereDaPlaca()
        {
            string placa = "ASDF8888";
            
            Assert.Throws<System.FormatException>(
                
                () => new Veiculo().Placa = placa
            );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        { 
            string placa = "ASDF8888";
            var mensagem = Assert.Throws<System.FormatException>(
                
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        /*[Fact]
        public void TestaMensagemDeExcecaoDoQuintoCaracteresDaPlaca()
        {
            string placa = "ASGKH458";
            var mensagem = Assert.Throws<System.FormatException>(

                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O quinto caracteres deve ser um número", mensagem.Message);
        }*/

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFreiarCom10()
        {
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaAlteraDadosVeiculoDeUmDeterminadoVeiculoComBaseNaPlaca()
        {
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            var veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = "José Silva";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";     
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto"; //Alterado
            veiculoAlterado.Modelo = "Opala";


            var alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            Assert.Equal(alterado.Cor,veiculoAlterado.Cor);

        }
    }
}
