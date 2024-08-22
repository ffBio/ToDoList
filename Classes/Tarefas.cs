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
        public double Hora;

        public Tarefas(string tarefa, string descricao, double hora) {
            Tarefa = tarefa;
            Descricao = descricao;
            Hora = hora; 
        }

        public Tarefas(){}
        
        internal class Construtores{
            public static void Executar() {
                var listaDeTarefas = new List<Tarefas>();

                // Define uma variável para controle do loop.
                int afazeres = 1;

                while(afazeres > 0) {
                    // Cria uma nova instância de Tarefas.
                    var tarefa = new Tarefas();

                    // Solicita e armazena os detalhes da tarefa.
                    Console.WriteLine("Digite a sua tarefa: ");
                    tarefa.Tarefa = Console.ReadLine();
                    Console.WriteLine("O que deve ser feito?: ");
                    tarefa.Descricao = Console.ReadLine();
                    Console.WriteLine("Horário a ser cumprido: ");
                    tarefa.Hora = double.Parse(Console.ReadLine());

                    // Adiciona a tarefa à lista.
                    listaDeTarefas.Add(tarefa);

                    // Pergunta ao usuário se deseja adicionar mais tarefas.
                    Console.WriteLine("Deseja adicionar outra tarefa? (1 - Sim, 0 - Não)");
                    afazeres = int.Parse(Console.ReadLine());         
                }
                ExibirTarefas(listaDeTarefas);
            }
            public static void ExibirTarefas(List<Tarefas> listaDeTarefas) {
                // Verifica se a lista está vazia.
                if(listaDeTarefas.Count == 0) {
                    Console.WriteLine("Nenhuma tarefa encontrada.");
                    return;
                }

                // Itera sobre cada tarefa na lista e exibe suas propriedades.
                foreach(var tarefa in listaDeTarefas) {
                    Console.WriteLine("Tarefa: " + tarefa.Tarefa);
                    Console.WriteLine("Descrição: " + tarefa.Descricao);
                    Console.WriteLine("Horário: " + tarefa.Hora);
                    Console.WriteLine("----------------------");
                }
            }

        }
    }
}
