using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace To_Do_List.Classes {
    public class GerenciadorDeTarefas {
        private List<Tarefas> listaDeTarefas;

        public GerenciadorDeTarefas() {
            listaDeTarefas = new List<Tarefas>();
        }

        public void AdicionarTarefa(Tarefas tarefa) {
            listaDeTarefas.Add(tarefa);
        }

        public void RemoverTarefa(Tarefas tarefa) {
            listaDeTarefas.Remove(tarefa);
        }

        public void ExibirTarefas() {
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

        public void SalvarTarefas(string caminho) {
            var json = JsonConvert.SerializeObject(listaDeTarefas, Formatting.Indented);
            File.WriteAllText(caminho, json);
        }

        public void CarregarTarefas(string caminho) {
            if(File.Exists(caminho)) {
                var json = File.ReadAllText(caminho);
                listaDeTarefas = JsonConvert.DeserializeObject<List<Tarefas>>(json) ?? new List<Tarefas>();
            } else {
                Console.WriteLine("Arquivo de tarefas não encontrado.");
            }
        }

        // Novo método para encontrar tarefa pela descrição
        public Tarefas EncontrarTarefaPorDescricao(string descricao) {
            return listaDeTarefas.Find(t => t.Descricao == descricao);
        }
    }
}