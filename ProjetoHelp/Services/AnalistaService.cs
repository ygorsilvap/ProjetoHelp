using ProjetoHelp.Data;
using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoHelp.Services
{
    public class AnalistaService
    {
        private APIService _apiService;
        private DateService _dateService;
        private Colecoes _colecoes;

        public AnalistaService(APIService apiService, DateService dateService, Colecoes colecoes)
        {
            _apiService = apiService;
            _colecoes = colecoes;
            _dateService = dateService;
        }

        public void MostrarAnalistas()
        {
            Console.WriteLine("\nLista de Analistas.\n");

            foreach (var analista in _colecoes.analistas)
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

            while (string.IsNullOrEmpty(cargo) || !_colecoes.cargos.Any(c => c.Nome.Equals(cargo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nCargo inválido. Tente novamente.\n");
                Console.Write("Cargo: ");
                cargo = Console.ReadLine();
            }
            novoAnalista.Cargo = _colecoes.cargos.FirstOrDefault(c => c.Nome.Equals(cargo, StringComparison.OrdinalIgnoreCase));

            Console.Write("\nEquipe: ");
            string equipe = Console.ReadLine();

            while (string.IsNullOrEmpty(equipe) || !_colecoes.equipes.Any(e => e.Nome.Equals(equipe, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nEquipe inválida. Tente novamente.\n");
                Console.Write("Equipe: ");
                equipe = Console.ReadLine();
            }
            novoAnalista.Equipe = _colecoes.equipes.FirstOrDefault(e => e.Nome.Equals(equipe, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nNome: {novoAnalista.Nome}");
            Console.WriteLine($"UF: {novoAnalista.UF}");
            Console.WriteLine($"Cargo: {novoAnalista.Cargo.Nome}");
            Console.WriteLine($"Equipe: {novoAnalista.Equipe.Nome}");
            Console.Write("\nConfirmar cadastro(S/N)? ");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                _colecoes.analistas.Add(novoAnalista);

                EquipeModel equipeAnalista = _colecoes.equipes.FirstOrDefault(e => e.Nome.Equals(novoAnalista.Equipe.Nome, StringComparison.OrdinalIgnoreCase));
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

            while (string.IsNullOrEmpty(nome) || !_colecoes.analistas.Any(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nAnalista não encontrado. Tente novamente.\n");
                Console.Write("Digite o nome do analista a ser removido: ");
                nome = Console.ReadLine();
            }

            Console.WriteLine($"\nTem certeza que deseja remover o analista {nome}? (S/N)");
            string resposta = Console.ReadLine();

            if (resposta.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                var analistaRemovido = _colecoes.analistas.FirstOrDefault(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                EquipeModel equipeAnalista = _colecoes.equipes.FirstOrDefault(e => e.Nome.Equals(analistaRemovido.Equipe.Nome, StringComparison.OrdinalIgnoreCase));

                //analistas.RemoveAll(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
                equipeAnalista.Analistas.Remove(analistaRemovido);
                _colecoes.analistas.Remove(analistaRemovido);


                Console.WriteLine($"\nAnalista {nome} removido com sucesso!\n");
            }
        }

        public void ImportarDadosAnalistas()
        {
            List<TicketResponseModel> json = _apiService.LerDadosAnalistas();

            foreach (var item in json)
            {
                if(!_colecoes.analistas.Any(n => n.Nome.Equals(item.Analista)))
                {
                    string estado = Estados.UF[new Random().Next(Estados.UF.Count)];
                    CargoModel cargo = _colecoes.cargos[new Random().Next(_colecoes.cargos.Count)];
                    EquipeModel equipe = _colecoes.equipes[new Random().Next(_colecoes.equipes.Count)];

                    AnalistaModel analista = new AnalistaModel(item.Analista, estado, equipe, cargo, item.Tickets);

                    _colecoes.analistas.Add(analista);

                    EquipeModel equipeAnalista = _colecoes.equipes.FirstOrDefault(e => e.Nome.Equals(equipe.Nome, StringComparison.OrdinalIgnoreCase));
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

            while (string.IsNullOrEmpty(nome) || !_colecoes.analistas.Any(a => a.Nome.StartsWith(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nAnalista não encontrado. Tente novamente.\n");
                Console.Write("Digite o nome do analista: ");
                nome = Console.ReadLine();
            }

            AnalistaModel analistaSelecionado = _colecoes.analistas.FirstOrDefault(a => a.Nome.StartsWith(nome, StringComparison.OrdinalIgnoreCase));

            CalculaAtingimentoAnalista(analistaSelecionado, opcao);
        }

        public void CalculaAtingimentoAnalista(AnalistaModel analista, int periodo)
        {
            MetaModel meta = analista.Meta;

            DateTime diaAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime periodoEscolhido;

            switch (periodo)
            {
                case 1:
                    periodoEscolhido = _dateService.IntervaloSemanal();
                    meta.CasosEncerrados /= 4;
                    break;
                case 2:
                    periodoEscolhido = _dateService.IntervaloMensal();
                    break;
                case 3:
                    periodoEscolhido = _dateService.IntervaloTrimestral();
                    meta.CasosEncerrados *= 3;
                    break;
                case 4:
                    periodoEscolhido = _dateService.IntervaloAnual();
                    meta.CasosEncerrados *= 12;
                    break;
                default:
                    return;
            }


            List<TicketModel> ticketsPeriodo = analista.Tickets.Where(t => t.DataEncerramento >= periodoEscolhido && t.DataEncerramento <= diaAtual).ToList();


            //Terminar cálculo de SLA, tornar a função mais generalizada para utilizar com equipes.
            //Console.WriteLine($"\nTotal de casos encerrados no período: {(ticketsPeriodo[0].DataEncerramento - ticketsPeriodo[0].DataAbertura)}\n");

            //List<TicketModel> ticketsEncerradosSLA = ticketsPeriodo.Where(t => t.DataAbertura - t.DataEncerramento).ToList();

            double atingimento = ((double)ticketsPeriodo.Count / meta.CasosEncerrados) * 100;

            double sla = 0;

            double taxaCSAT = (ticketsPeriodo.Where(t => t.RespostaCSAT).Count() / meta.TaxaCSAT) * 100;

            double notaCSAT = ticketsPeriodo.Where(t => t.RespostaCSAT).Count() > 1 ?
                ticketsPeriodo.Where(t => t.RespostaCSAT).Sum(t => t.NotaCSAT ?? 1) / ticketsPeriodo.Where(t => t.RespostaCSAT).Count() : 0;

            MetaModel indicadoresAnalista = new MetaModel(ticketsPeriodo.Count, sla, taxaCSAT, notaCSAT);

            Console.WriteLine($"\nPeríodo: {periodoEscolhido.ToShortDateString()} - {diaAtual.ToShortDateString()}");

            Console.WriteLine($"\nIndicadores do analista {analista.Nome}:\n");
            Console.WriteLine($"Casos Encerrados: {indicadoresAnalista.CasosEncerrados}/{analista.Meta.CasosEncerrados} - {atingimento.ToString("F2")}%");
            Console.WriteLine($"SLA: {indicadoresAnalista.SLA}%");
            Console.WriteLine($"Taxa CSAT: {indicadoresAnalista.TaxaCSAT.ToString("F2")}%");
            Console.WriteLine($"Nota CSAT: {indicadoresAnalista.NotaCSAT}\n");
        }
    }
}
