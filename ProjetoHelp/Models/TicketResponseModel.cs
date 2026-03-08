using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjetoHelp.Models
{
    public class TicketResponseModel
    {
        [JsonPropertyName("analista")]
        public string Analista { get; set; }
        [JsonPropertyName("tickets")]
        public List<TicketModel> Tickets { get; set; }
    }
}
