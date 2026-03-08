using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class APIService
    {
        
        public async void LerDadosAnalistas()
        {
            string casosEncerrados = await File.ReadAllTextAsync(@"C:\Users\ygor\source\repos\ProjetoHelp\ProjetoHelp\Data\tickets_mock_2026_.json");
            
            List<TicketResponseModel> casos = System.Text.Json.JsonSerializer.Deserialize<List<TicketResponseModel>>(casosEncerrados);

            AnalistaService analistaService = new AnalistaService();
            analistaService.ImportarDadosAnalistas(casos);
        }

        public async void LerBaseFeriados2026()
        {
            string feriados = await File.ReadAllTextAsync(@"C:\Users\ygor\source\repos\ProjetoHelp\ProjetoHelp\MockData\feriados.json");

            //Console.WriteLine(feriados);
        }
    }
}
