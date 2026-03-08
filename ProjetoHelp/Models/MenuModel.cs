using System;
using System.Collections.Generic;
using System.Text;

//https://stackoverflow.com/questions/53234070/what-is-the-correct-way-of-making-a-console-menu

namespace ProjetoHelp.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Action Acao { get; set; }

        public MenuModel(int id, string nome, Action acao)
        {
            Id = id;
            Nome = nome;
            Acao = acao;
        }
    }

}
