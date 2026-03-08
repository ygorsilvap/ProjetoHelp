using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Models
{
    public class CargoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public MetaModel MetaPadrao { get; set; }

        public CargoModel(string nome, MetaModel metaPadrao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            MetaPadrao = metaPadrao;
        }
    }
}
