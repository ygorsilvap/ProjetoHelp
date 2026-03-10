using ProjetoHelp.Models;
using ProjetoHelp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class EquipeService
    {
        private Colecoes _colecoes;

        public EquipeService(Colecoes colecoes)
        {
            _colecoes = colecoes;
        }

        public void MostrarEquipes()
        {
            Console.WriteLine("\nLista de Equipes.\n");
            foreach (var equipe in _colecoes.equipes)
            {
                Console.WriteLine($"{equipe.Nome} - {equipe.Analistas.Count} analistas.\n");
            }

            Console.Write("Digite o nome de uma equipe para mais detalhes, ou digite '0' para retornar: ");
            string opcao = Console.ReadLine();

            if(opcao != "0")
            {
                while(string.IsNullOrEmpty(opcao) || !_colecoes.equipes.Any(e => e.Nome.Equals(opcao, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Opção inválida.\n");
                    Console.Write("Digite o nome de uma equipe para mais detalhes, ou digite '0' para retornar: ");
                    opcao = Console.ReadLine();
                }

                EquipeModel equipeSelecionada = _colecoes.equipes.FirstOrDefault(e => e.Nome.Equals(opcao, StringComparison.OrdinalIgnoreCase));

                foreach (var analista in equipeSelecionada.Analistas)
                {
                    Console.WriteLine($"{analista.Nome} - {analista.UF}, {analista.Cargo.Nome}.\n");
                }
            }
        }
    }
}
