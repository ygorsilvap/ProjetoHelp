using ProjetoHelp.Data;
using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoHelp.Services
{
    public class AnalistaService
    {
        private CargoService _cargoService;
        private EquipeService _equipeService;
        private APIService _apiService;

        public List<AnalistaModel> analistas = new List<AnalistaModel>();

        public Estados estados = new Estados();

        public AnalistaService(CargoService cargoService, EquipeService equipeService, APIService apiService)
        {
            _cargoService = cargoService;
            _equipeService = equipeService;
            _apiService = apiService;
        }

        public void MostrarAnalistas()
        {
            Console.WriteLine("\nLista de Analistas.\n");

            foreach (var analista in analistas)
            {
                Console.WriteLine($"{analista.Nome} - {analista.UF}, {analista.Cargo.Nome}, Equipe {analista.Equipe.Nome}.\n");
            }
        }

        public void CadastrarAnalista()
        {
            Console.WriteLine("\nCadastro de Novo Analista.\n");
            AnalistaModel novoAnalista = new AnalistaModel();

            Console.Write("Nome: ");
            novoAnalista.Nome = Console.ReadLine();

            Console.Write("\nUF(sigla): ");
            string uf = Console.ReadLine();
            while (string.IsNullOrEmpty(uf) || uf.Length != 2)
            {
                Console.WriteLine("\nEstado inválido. Tente novamente.\n");
                Console.Write("UF(sigla): ");
                uf = Console.ReadLine();
            }
            novoAnalista.UF = uf.ToUpper();

            Console.Write("\nCargo: ");
            string cargo = Console.ReadLine();

            while (string.IsNullOrEmpty(cargo) || !_cargoService.cargos.Any(c => c.Nome.Equals(cargo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nCargo inválido. Tente novamente.\n");
                Console.Write("Cargo: ");
                cargo = Console.ReadLine();
            }
            novoAnalista.Cargo = _cargoService.cargos.FirstOrDefault(c => c.Nome.Equals(cargo, StringComparison.OrdinalIgnoreCase));

            Console.Write("\nEquipe: ");
            string equipe = Console.ReadLine();

            while (string.IsNullOrEmpty(equipe) || !_equipeService.equipes.Any(e => e.Nome.Equals(equipe, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nEquipe inválida. Tente novamente.\n");
                Console.Write("Equipe: ");
                equipe = Console.ReadLine();
            }
            novoAnalista.Equipe = _equipeService.equipes.FirstOrDefault(e => e.Nome.Equals(equipe, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nNome: {novoAnalista.Nome}");
            Console.WriteLine($"UF: {novoAnalista.UF}");
            Console.WriteLine($"Cargo: {novoAnalista.Cargo.Nome}");
            Console.WriteLine($"Equipe: {novoAnalista.Equipe.Nome}");
            Console.Write("\nConfirmar cadastro(S/N)? ");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                analistas.Add(novoAnalista);

                EquipeModel equipeAnalista = _equipeService.equipes.FirstOrDefault(e => e.Nome.Equals(novoAnalista.Equipe.Nome, StringComparison.OrdinalIgnoreCase));
                equipeAnalista.Analistas.Add(novoAnalista);

                Console.WriteLine("\nAnalista cadastrado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("\nCadastro cancelado.\n");
            }
        }

        public void RemoverAnalista()
        {
            Console.WriteLine("Digite o nome do analista a ser removido: ");
            string nome = Console.ReadLine();

            while (string.IsNullOrEmpty(nome) || !analistas.Any(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nAnalista não encontrado. Tente novamente.\n");
                Console.Write("Digite o nome do analista a ser removido: ");
                nome = Console.ReadLine();
            }

            Console.WriteLine($"\nTem certeza que deseja remover o analista {nome}? (S/N)");
            string resposta = Console.ReadLine();

            if (resposta.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                var analistaRemovido = analistas.FirstOrDefault(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                EquipeModel equipeAnalista = _equipeService.equipes.FirstOrDefault(e => e.Nome.Equals(analistaRemovido.Equipe.Nome, StringComparison.OrdinalIgnoreCase));

                //analistas.RemoveAll(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                equipeAnalista.Analistas.Remove(analistaRemovido);
                analistas.Remove(analistaRemovido);


                Console.WriteLine($"\nAnalista {nome} removido com sucesso!\n");
            }
        }

        public void ImportarDadosAnalistas()
        {
            List<TicketResponseModel> json = _apiService.LerDadosAnalistas();

            foreach (var item in json)
            {
                if(!analistas.Any(n => n.Nome.Equals(item.Analista)))
                {
                    string estado = estados.UF[new Random().Next(estados.UF.Count)];
                    CargoModel cargo = _cargoService.cargos[new Random().Next(_cargoService.cargos.Count)];
                    EquipeModel equipe = _equipeService.equipes[new Random().Next(_equipeService.equipes.Count)];

                    AnalistaModel analista = new AnalistaModel(item.Analista, estado, equipe, cargo, item.Tickets);

                    analistas.Add(analista);

                    EquipeModel equipeAnalista = _equipeService.equipes.FirstOrDefault(e => e.Nome.Equals(equipe.Nome, StringComparison.OrdinalIgnoreCase));
                    equipeAnalista.Analistas.Add(analista);
                }
            }

        }

        public void GerarIndicadoresAnalista()
        {
            Console.WriteLine("1 - Indicadores da semana");
            Console.WriteLine("2 - Indicadores do mês");
            Console.WriteLine("3 - Indicadores do trimestre");
            Console.WriteLine("4 - Indicadores do ano");
            int opcao = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do analista: ");
            string nome = Console.ReadLine();

            while (string.IsNullOrEmpty(nome) || !analistas.Any(a => a.Nome.StartsWith(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nAnalista não encontrado. Tente novamente.\n");
                Console.Write("Digite o nome do analista: ");
                nome = Console.ReadLine();
            }

            AnalistaModel analistaSelecionado = analistas.FirstOrDefault(a => a.Nome.StartsWith(nome, StringComparison.OrdinalIgnoreCase));

            MetaModel meta = analistaSelecionado.Meta;

            double sla = 0;
            double taxaCSAT = (meta.TaxaCSAT / analistaSelecionado.Tickets.Where(t => t.RespostaCSAT).Count()) * 100;
            double notaCSAT = analistaSelecionado.Tickets.Where(t => t.RespostaCSAT).Sum(t => t.NotaCSAT ?? 0) / analistaSelecionado.Tickets.Where(t => t.RespostaCSAT).Count();

            MetaModel atingimento = new MetaModel(analistaSelecionado.Tickets.Count, sla, taxaCSAT, notaCSAT);

            Console.WriteLine($"\nIndicadores do analista {analistaSelecionado.Nome}:\n");
            Console.WriteLine($"Casos Encerrados: {atingimento.CasosEncerrados}");
            Console.WriteLine($"SLA: {atingimento.SLA}%");
            Console.WriteLine($"Taxa CSAT: {atingimento.TaxaCSAT.ToString("F2")}%");
            Console.WriteLine($"Nota CSAT: {atingimento.NotaCSAT}\n");
        }
    }
}
