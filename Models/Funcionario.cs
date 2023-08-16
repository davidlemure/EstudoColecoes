// Chamar classe de uma pasta diferente
using System;
using System.Collections;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes.Models;
    public class Funcionario
    {
        //Progração aqui

        //V PROP + TAB - atalho para criar propriedades
        // int, string, DateTime, decimal, sao classes de variaveis

        public int Id { get; set; } 

        // com string é necessário colocar " = "";" ou " = string.Empty;"
        public string Nome { get; set; } = "";

        public string Cpf { get; set; } = string.Empty;

        public TipoFuncionarioEnum TipoFuncionario  { get; set; }

        public DateTime DataAdmissao{ get; set; }

        public decimal Salario { get; set; }

        public void ReajustaSalario()
        
        {
            Salario = Salario + (Salario * 10/100);
        }

        public string ExibirPeriodoExperiencia()
        
        // em programação se conta do 0
        {
            string periodoExperiencia = string.Format("Períodos de Experiência: {0} até {1}", DataAdmissao, DataAdmissao.AddMonths(3));
            return periodoExperiencia;
        }

        public decimal CalcularDescontoVT(decimal percentual)

        {
            decimal desconto = this.Salario * percentual/100;
            return desconto;
        }

        private int ContarCaracteres(string dado)

        {
            return dado.Length;
        }

        public bool ValidarCpf()
        {
            if(ContarCaracteres (Cpf) == 11)
                return true;
            else 
                return false;
        }
        // referenciar CPF com string pra evitar erros
        


        











    }
