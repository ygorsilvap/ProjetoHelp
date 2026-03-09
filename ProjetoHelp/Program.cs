using ProjetoHelp.Data;
using ProjetoHelp.Models;
using ProjetoHelp.Services;
using System.Net.Http.Json;

namespace ProjetoHelp
{
    public class Program
    {
        static void Main(string[] args)
        {
            EquipeService equipeService = new EquipeService();
            CargoService cargoService = new CargoService();
            APIService apiService = new APIService();
            AnalistaService analistaService = new AnalistaService(cargoService, equipeService, apiService);
            MenuService menuService = new MenuService(analistaService, equipeService);

            //Estados estados = new Estados();

            analistaService.ImportarDadosAnalistas();

            MenuService.ImprimeMenu(MenuService.menuPrincipal);
        }
    }
}
