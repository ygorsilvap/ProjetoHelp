using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Models
{
    public class EquipeModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<AnalistaModel> Analistas { get; set; }
        public MetaModel Meta { get; set; }

        public EquipeModel(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Analistas = new List<AnalistaModel>();
            Meta = new MetaModel(92, 35, 90);
        }
    }
}
