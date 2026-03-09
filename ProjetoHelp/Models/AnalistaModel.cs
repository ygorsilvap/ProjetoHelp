using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Models
{
    public class AnalistaModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public EquipeModel Equipe { get; set; }
        public CargoModel Cargo { get; set; }
        public MetaModel Meta { get; set; }
        public List<TicketModel> Tickets { get; set; }

        public AnalistaModel()
        {
            Id = Guid.NewGuid();
            Tickets = new List<TicketModel>();
        }
        public AnalistaModel(string nome, string uf, EquipeModel equipe, CargoModel cargo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            UF = uf;
            Equipe = equipe;
            Cargo = cargo;
            Meta = cargo.MetaPadrao;
            Tickets = new List<TicketModel>();
        }

        public AnalistaModel(string nome, string uf, EquipeModel equipe, CargoModel cargo, List<TicketModel> tickets)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            UF = uf;
            Equipe = equipe;
            Cargo = cargo;
            Meta = cargo.MetaPadrao;
            Tickets = tickets;
        }
    }
}
