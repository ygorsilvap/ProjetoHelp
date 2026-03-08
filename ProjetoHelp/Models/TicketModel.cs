using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjetoHelp.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataEncerramento { get; set; }
        public string Prioridade { get; set; }
        public bool RespostaCSAT { get; set; }
        public int? NotaCSAT { get; set; }
    }
}
