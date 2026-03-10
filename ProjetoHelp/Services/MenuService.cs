using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    //https://stackoverflow.com/questions/53234070/what-is-the-correct-way-of-making-a-console-menu
    public class MenuService
    {
        private static AnalistaService _analistaService;
        private static EquipeService _equipeService;

        public static List<MenuModel> menuIndicadores, menuGestaoMetas, menuGestaoEquipe, menuGestaoAnalistas;

        public MenuService(AnalistaService analistaService, EquipeService equipeService)
        {
            _analistaService = analistaService;
            _equipeService = equipeService;
        }


        public static List<MenuModel> menuPrincipal = new List<MenuModel>
        { new MenuModel(1, "Indicadores", MenuIndicadores),
          new MenuModel(2, "Gestão de Metas", MenuGestaoMetas),
          new MenuModel(3, "Gestão da Equipe", MenuGestaoEquipe),
          new MenuModel(4, "Gestão dos Analistas", MenuGestaoAnalistas),
          new MenuModel(3, "Agenda de feriados", AgendaFeriados)
        };


        //Métodos Menu Principal
        public static void MenuIndicadores()
        {
            Console.WriteLine("Menu Indicadores");

            menuIndicadores = new List<MenuModel>
            { new MenuModel(1, "Indicadores da equipe", MenuIndicadoresEquipe),
              new MenuModel(2, "Indicadores por analista", MenuIndicadoresAnalista),
              new MenuModel(3, "Ranking da equipe", MenuRanking)
            };

            ImprimeMenu(menuIndicadores);
        }
        public static void MenuGestaoMetas()
        {
            Console.WriteLine("Menu Gestão de Metas");

            menuIndicadores = new List<MenuModel>
            { new MenuModel(1, "Visualizar Metas Definidas", MostrarDefinicaoMetas),
              new MenuModel(2, "Editar metas", EditarMetas)
            };
            ImprimeMenu(menuGestaoMetas);
        }
        public static void MenuGestaoEquipe()
        {
            Console.WriteLine("Menu Gestão da Equipe");

            menuGestaoEquipe = new List<MenuModel>
            { new MenuModel(1, "Visualizar Equipe", MostrarEquipe),
              new MenuModel(2, "Editar Equipe", EditarEquipe),
              new MenuModel(3, "Agenda de férias da equipe", MostrarAgendaFeriasEquipe),
            };

            ImprimeMenu(menuGestaoEquipe);
        }
        public static void MenuGestaoAnalistas()
        {
            Console.WriteLine("\nMenu Gestão dos Analistas\n");

            menuGestaoAnalistas = new List<MenuModel>
            { new MenuModel(1, "Visualizar Analistas", MostrarAnalistas),
              new MenuModel(2, "Cadastrar novo analista", CadastrarAnalista),
              new MenuModel(3, "Remover Cadastro", RemoverAnalista),
              new MenuModel(4, "Registrar Falta", RegistrarFaltaAnalista),
              new MenuModel(5, "Solicitar Férias", SolicitarFeriasAnalista),
              new MenuModel(6, "Agenda de férias", AgendaFeriasAnalista)
            };

            ImprimeMenu(menuGestaoAnalistas);
        }
        public static void AgendaFeriados()
        {
            Console.WriteLine("Menu Calendário");
        }

        //Métodos Menu Indicadores
        public static void MenuIndicadoresEquipe()
        {
            Console.WriteLine("Menu Indicadores da Equipe");

            //ImprimeMenu(menuPeriodoIndicadores);
        }
        public static void MenuIndicadoresAnalista()
        {
            Console.WriteLine("\nMenu Indicadores por Analista");

            _analistaService.GerarIndicadoresAnalista();

            ImprimeMenu(menuIndicadores);
        }
        public static void MenuRanking()
        {
            Console.WriteLine("Menu Ranking da Equipe");

        List<MenuModel> menuPeriodoRanking = new List<MenuModel>
        { new MenuModel(1, "Ranking da semana", MostrarIndicadores),
          new MenuModel(2, "Ranking do mês", MostrarIndicadores),
          new MenuModel(3, "Ranking do trimestre", MostrarIndicadores),
          new MenuModel(4, "Ranking do ano", MostrarIndicadores),
        };

        ImprimeMenu(menuPeriodoRanking);
        }
        public static void MostrarIndicadores()
        {
            Console.WriteLine("Exibindo indicadores...");
        }

        //Métodos Menu Gestão de Metas
        public static void MostrarDefinicaoMetas()
        {
            Console.WriteLine("Exibindo metas definidas...");
        }
        public static void EditarMetas()
        {
            Console.WriteLine("Editando metas...");
        }

        //Métodos Menu Gestão da Equipe
        public static void MostrarEquipe()
        {
            _equipeService.MostrarEquipes();
            ImprimeMenu(menuGestaoEquipe);
        }
        public static void EditarEquipe()
        {
            Console.WriteLine("Editando equipe...");
        }
        public static void MostrarAgendaFeriasEquipe()
        {
            Console.WriteLine("Exibindo agenda de férias da equipe...");
        }

        //Métodos Menu Gestão dos Analistas
        public static void MostrarAnalistas()
        {
            _analistaService.MostrarAnalistas();
            ImprimeMenu(menuGestaoAnalistas);
        }
        public static void CadastrarAnalista()
        {
            _analistaService.CadastrarAnalista();
            ImprimeMenu(menuGestaoAnalistas);
        }
        public static void RemoverAnalista()
        {
            _analistaService.RemoverAnalista();
            ImprimeMenu(menuGestaoAnalistas);
        }
        public static void RegistrarFaltaAnalista()
        {
            Console.WriteLine("Registrando falta do analista...");
        }
        public static void SolicitarFeriasAnalista()
        {
            Console.WriteLine("Solicitando férias para o analista...");
        }
        public static void AgendaFeriasAnalista()
        {
            Console.WriteLine("Exibindo agenda de férias dos analistas...");
        }

        //Outros Métodos
        public static void ImprimeMenu(List<MenuModel> menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Id} - {item.Nome}");
            }
            Console.Write("\nSelecione uma opção ou digite '0' para retornar ao menu principal: ");

            int opcao = int.Parse(Console.ReadLine());

            if(opcao == 0)
            {
                ImprimeMenu(menuPrincipal);
                return;
            }

            MenuModel menuSelecionado = menu.FirstOrDefault(m => m.Id == opcao);

            if (menuSelecionado == null)
            {
                Console.WriteLine("\nOpção inválida.\n");
                ImprimeMenu(menu);
                return;
            }
            
            menuSelecionado.Acao();
        }
    }
}
