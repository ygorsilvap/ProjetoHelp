using ProjetoHelp.Models;
using ProjetoHelp.Services;

namespace ProjetoHelp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();

            MenuService.ImprimeMenu(menuService.menuPrincipal);
        }
    }
}
