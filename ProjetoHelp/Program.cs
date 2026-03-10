using ProjetoHelp.Data;
using ProjetoHelp.Models;
using ProjetoHelp.Services;

namespace ProjetoHelp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Colecoes colecoes = new Colecoes();
            DateService dateService = new DateService();
            EquipeService equipeService = new EquipeService(colecoes);
            CargoService cargoService = new CargoService();
            APIService apiService = new APIService();
            AnalistaService analistaService = new AnalistaService(apiService, dateService, colecoes);
            MenuService menuService = new MenuService(analistaService, equipeService);

            analistaService.ImportarDadosAnalistas();

            MenuService.ImprimeMenu(MenuService.menuPrincipal);
        }
    }
}
