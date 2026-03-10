using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    //https://stackoverflow.com/questions/674857/should-i-use-appdomain-currentdomain-basedirectory-or-system-environment-current
    public class APIService
    {
        public string caminhoJson = $"{AppDomain.CurrentDomain.BaseDirectory.Substring(0, 57)}Data";
        
        public List<TicketResponseModel> LerDadosAnalistas()
        {
            string casosEncerrados = File.ReadAllText($"{caminhoJson}\\tickets_mock_2026.json");

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
