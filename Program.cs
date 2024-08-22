using System;
using System.Collections.Generic;
using To_Do_List.Classes;
using static To_Do_List.Classes.Tarefas;



namespace To_Do_List{
    class Program {
        static void Main(string [ ] args) {
            var central = new CentralLista(new Dictionary<string, Action>() {
                //Fundamentos
                {"Lista", Construtores.Executar},
            });
            central.SelecionarEExecutar();
        }
    }
}