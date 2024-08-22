using System;
using To_Do_List.Classes;

namespace To_Do_List {
    class Program {
        static void Main(string [ ] args) {
            var gerenciador = new GerenciadorDeTarefas();
            bool continuar = true;

            while(continuar) {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Remover Tarefa");
                Console.WriteLine("3. Exibir Tarefas");
                Console.WriteLine("4. Salvar Tarefas");
                Console.WriteLine("5. Carregar Tarefas");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch(opcao) {
                    case "1":
                        AdicionarTarefa(gerenciador);
                        break;
                    case "2":
                        RemoverTarefa(gerenciador);
                        break;
                    case "3":
                        gerenciador.ExibirTarefas();
                        break;
                    case "4":
                        SalvarTarefas(gerenciador);
                        break;
                    case "5":
                        CarregarTarefas(gerenciador);
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void AdicionarTarefa(GerenciadorDeTarefas gerenciador) {
            Console.WriteLine("Digite a tarefa: ");
            var tarefaNome = Console.ReadLine() ?? string.Empty; // Garante que não seja nulo
            Console.WriteLine("Digite a descrição: ");
            var descricao = Console.ReadLine() ?? string.Empty; // Garante que não seja nulo
            Console.WriteLine("Digite a data e hora (dd/MM/yyyy HH:mm): ");
            var dataHoraInput = Console.ReadLine();

            if(DateTime.TryParseExact(dataHoraInput, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime dataHora)) {
                var tarefa = new Tarefas(tarefaNome, descricao, dataHora);
                gerenciador.AdicionarTarefa(tarefa);
            } else {
                Console.WriteLine("Data ou hora inválida. A tarefa não foi adicionada.");
            }
        }

        private static void RemoverTarefa(GerenciadorDeTarefas gerenciador) {
            Console.WriteLine("Digite a descrição da tarefa a ser removida: ");
            var descricao = Console.ReadLine() ?? string.Empty;

            var tarefaParaRemover = gerenciador.EncontrarTarefaPorDescricao(descricao);

            if(tarefaParaRemover != null) {
                gerenciador.RemoverTarefa(tarefaParaRemover);
                Console.WriteLine("Tarefa removida com sucesso.");
            } else {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        private static void SalvarTarefas(GerenciadorDeTarefas gerenciador) {
            Console.WriteLine("Digite o caminho para salvar o arquivo (ex: tarefas.json): ");
            var caminho = Console.ReadLine() ?? string.Empty;
            if(!string.IsNullOrEmpty(caminho)) {
                gerenciador.SalvarTarefas(caminho);
                Console.WriteLine("Tarefas salvas com sucesso.");
            } else {
                Console.WriteLine("Caminho inválido.");
            }
        }

        private static void CarregarTarefas(GerenciadorDeTarefas gerenciador) {
            Console.WriteLine("Digite o caminho do arquivo para carregar as tarefas (ex: tarefas.json): ");
            var caminho = Console.ReadLine() ?? string.Empty;
            if(!string.IsNullOrEmpty(caminho)) {
                gerenciador.CarregarTarefas(caminho);
                Console.WriteLine("Tarefas carregadas com sucesso.");
            } else {
                Console.WriteLine("Caminho inválido.");
            }
        }
    }
}
