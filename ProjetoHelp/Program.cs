using ProjetoHelp.Models;
using ProjetoHelp.Services;
using System.Net.Http.Json;

namespace ProjetoHelp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();
            EquipeService equipeService = new EquipeService();
            AnalistaService analistaService = new AnalistaService();

            APIService apiService = new APIService();

            apiService.LerDadosAnalistas();

            //Carregar dados mockados


            MenuService.ImprimeMenu(MenuService.menuPrincipal);
        }
    }
}
