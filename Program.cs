using System;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    class Program
    {
        private const int V = 4;
        static List<Funcionario> lista = new List<Funcionario>();

        public int Salario { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public object Nome { get; private set; }

        static void Main(string[] args)
        {
            ExemplosListasColecoes();
        }

        // a) Método ObterPorNome
        public static void ObterPorNome(string nome)
        {
            List<Funcionario> funcionariosEncontrados = lista.FindAll(x => x.Nome.ToLower().Contains(nome.ToLower()));

            if (funcionariosEncontrados.Count > 0)
            {
                Console.WriteLine("Funcionários encontrados com o nome digitado:");
                foreach (var funcionario in funcionariosEncontrados)
                {
                    Console.WriteLine($"Nome: {funcionario.Nome}\nId: {funcionario.Id}\nCpf: {funcionario.Cpf} \nSalario: {funcionario.Salario} \nData de admissao {funcionario.DataAdmissao} \nTipo de funcionario: {funcionario.TipoFuncionario}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário encontrado com o nome digitado.");
            }
        }

        // b) Método ObterFuncionariosRecentes
        public static List<Funcionario> ObterFuncionariosRecentes(List<Funcionario> funcionarios)
        {
            funcionarios.RemoveAll(funcionario => funcionario.Id < 4);
            funcionarios.Sort((f1, f2) => f2.Salario.CompareTo(f1.Salario));
            return funcionarios;
        }

        // c) Método ObterEstatisticas
        public static void ObterEstatisticas(List<Funcionario> funcionarios)
        {
            decimal totalSalarios = 0;
            foreach (var funcionario in funcionarios)
            {
                totalSalarios += funcionario.Salario;
            }
            Console.WriteLine($"Quantidade de funcionários: {funcionarios.Count}");
            Console.WriteLine($"Somatório de salários: {totalSalarios:C}");
        }

        // d) Método ValidarSalarioAdmissao
        public bool ValidarSalarioAdmissao()
        {
            if (Salario == 0 || DataAdmissao < DateTime.Now)
            {
                Console.WriteLine("Salário não pode ser zero ou data de admissão não pode ser anterior à data atual.");
                return false;
            }
            return true;
        }

        // e) Método ValidarNome
        public bool ValidarNome(string Nome)
        {
            if (Nome.Length < 2)
            {
                Console.WriteLine("Nome deve ter pelo menos 2 caracteres.");
                return false;
            }
            return true;
        }


        // f) Método ObterPorTipo
        public static List<Funcionario> ObterPorTipo(List<Funcionario> funcionarios, TipoFuncionarioEnum tipo)
        {
            List<Funcionario> funcionariosPorTipo = new List<Funcionario>();
            foreach (var funcionario in funcionarios)
            {
                if (funcionario.TipoFuncionario == tipo)
                {
                    funcionariosPorTipo.Add(funcionario);
                }
            }
            return funcionariosPorTipo;
        }
        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);

        }

        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void ObterPorId(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);
            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
        }


        public static void ObterPorSalario(decimal valor)
        {
            lista = lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
        }


        public static void Ordenar()
        {
            lista = lista.OrderBy(x => x.Nome).ToList();
            ExibirLista();
        }

        public static void ContarFuncionarios()
        {
            int qtd = lista.Count();
            Console.WriteLine($"Existem {qtd} funcionários");
        }

        public static void SomarSalarios()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é {0:c2", somatorio));
        }

        public static void ExibirAprendizes()
        {
            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            ExibirLista();
        }

        public static void BuscarPorNomeAProximado()
        {
            lista = lista.FindAll(x => x.Nome.ToLower().Contains("ronaldo"));
            ExibirLista();
        }

        public static void BuscarPorCpfRemover()
        {
            Funcionario fBusca = lista.Find(x => x.Cpf == "01987654321");
            lista.Remove(fBusca);
            Console.WriteLine($"Personagem removido: {fBusca.Nome} \nLista Atualizada: \n");
            ExibirLista();
        }


        public static void RemoverIdMenor4()
        {
            lista.RemoveAll(x => x.Id < 4);
            ExibirLista();
        }
        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            }

            else if (f.Salario == 0)
            {
                Console.WriteLine("Valor do salário não pode ser 0");
                return;
            }

            else
            {
                lista.Add(f);
                ExibirLista();
            }

        }

        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("==================================================");
            CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("--------------------Exercicios--------------------");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("==================================================");
                Console.WriteLine("1 - Obter por nome");
                Console.WriteLine("2 - Obter funcionarios recentes");
                Console.WriteLine("3 - Obter estatisticas");
                Console.WriteLine("4 - Validar salario admissao");
                Console.WriteLine("5 - Validar nome");
                Console.WriteLine("6 - Obter por tipo");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");
                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do funcionário que voce deseja buscar");
                        string nomeBusca = Console.ReadLine(); // Ler o nome digitado pelo usuário
                        ObterPorNome(nomeBusca);
                        break;

                    case 2:
                        List<Funcionario> funcionariosFiltrados = ObterFuncionariosRecentes(lista); // Passa a lista para o método

                        foreach (var funcionario in funcionariosFiltrados)
                        {
                            Console.WriteLine($"Nome: {funcionario.Nome}, Salário: R${funcionario.Salario}");
                        }

                        break;

                    case 3:

                        ObterEstatisticas(lista);
                        break;
                    
                    case 4:

                    ValidarSalarioAdmissao();
        {




                }

            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }
        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Renato Augusto";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

    }
}

// See https://aka.ms/new-console-template for more information

