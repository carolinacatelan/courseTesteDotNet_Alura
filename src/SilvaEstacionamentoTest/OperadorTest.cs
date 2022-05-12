using SilvaEstacionamento;
using Xunit;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;


namespace SilvaEstacionamentoTest
{
    public class OperadorTest
    {
        
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;
        private Operador operador;
        public OperadorTest(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Operador Noturno";
        }

         [Fact]
        public void ValidaAlteracaoNomeOperador()
        {
            var fichaOperador = operador.ToString();

            Assert.Contains("Operador", fichaOperador);

        }
    }
}
       
