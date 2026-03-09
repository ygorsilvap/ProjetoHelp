using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class APIService
    {
        
        public List<TicketResponseModel> LerDadosAnalistas()
        {
            string casosEncerrados = File.ReadAllText(@"C:\Users\ygor\source\repos\ProjetoHelp\ProjetoHelp\Data\tickets_mock_2026.json");
            
            List<TicketResponseModel> casos = System.Text.Json.JsonSerializer.Deserialize<List<TicketResponseModel>>(casosEncerrados);

            return casos;
        }

        public void LerBaseFeriados2026()
        {
            string feriados = File.ReadAllText(@"C:\Users\ygor\source\repos\ProjetoHelp\ProjetoHelp\Data\feriados.json");

            //Console.WriteLine(feriados);
        }
    }
}
