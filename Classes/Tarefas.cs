using System;


namespace To_Do_List.Classes {
    public class Tarefas {
        public string Tarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }

        public Tarefas(string tarefa, string descricao, DateTime dataHora) {
            Tarefa = tarefa ?? string.Empty; // Garante que não seja nulo
            Descricao = descricao ?? string.Empty; // Garante que não seja nulo
            DataHora = dataHora;
        }

        public Tarefas() { }
    }
}
