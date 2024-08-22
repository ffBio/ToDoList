using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Classes {
    internal class Tarefas {
        public string Tarefa;
        public string Descricao;
        public DateTime DataHora;

        public Tarefas(string tarefa, string descricao, double hora, DateTime dataHora) {
            Tarefa = tarefa;
            Descricao = descricao;
            DataHora = dataHora;
        }

        public Tarefas(){}

        internal class Construtores {
            public static void Executar() {
                var listaDeTarefas = new List<Tarefas>();
                int afazeres = 1;

                while(afazeres > 0) {
                    var tarefa = new Tarefas();

                    // Solicita e armazena a data e hora da tarefa.
                    Console.WriteLine("Quando deve ser feito (dd/MM/yyyy HH:mm): ");
                    string dataInput = Console.ReadLine();
                    if(DateTime.TryParseExact(dataInput, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime dataHora)) {
                        tarefa.DataHora = dataHora;
                    } else {
                        Console.WriteLine("Data ou hora inválida! Por favor, tente novamente.");
                        continue; // Reinicia o loop para permitir uma nova tentativa.
                    }

                    // Solicita e armazena os detalhes da tarefa.
                    Console.WriteLine("Digite a sua tarefa: ");
                    tarefa.Tarefa = Console.ReadLine();
                    Console.WriteLine("O que deve ser feito: ");
                    tarefa.Descricao = Console.ReadLine();

                    // Adiciona a tarefa à lista.
                    listaDeTarefas.Add(tarefa);

                    // Pergunta ao usuário se deseja adicionar mais tarefas.
                    Console.WriteLine("Deseja adicionar outra tarefa? (1 - Sim, 0 - Não)");
                    afazeres = int.Parse(Console.ReadLine());
                }

                ExibirTarefas(listaDeTarefas);
            }

            public static void ExibirTarefas(List<Tarefas> listaDeTarefas) {
                if(listaDeTarefas.Count == 0) {
                    Console.WriteLine("Nenhuma tarefa encontrada.");
                    return;
                }

                foreach(var tarefa in listaDeTarefas) {
                    Console.WriteLine($"Data e Hora: {tarefa.DataHora:dd/MM/yyyy HH:mm}");
                    Console.WriteLine("Tarefa: " + tarefa.Tarefa);
                    Console.WriteLine("Descrição: " + tarefa.Descricao);
                    Console.WriteLine("----------------------");
                }
            }
        }
    }
}