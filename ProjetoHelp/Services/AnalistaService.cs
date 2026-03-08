using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class AnalistaService
    {
        public List<AnalistaModel> analistas = new List<AnalistaModel>();
        public CargoService cargoService = new CargoService();
        public EquipeService equipeService = new EquipeService();

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

            while (string.IsNullOrEmpty(cargo) || !cargoService.cargos.Any(c => c.Nome.Equals(cargo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nCargo inválido. Tente novamente.\n");
                Console.Write("Cargo: ");
                cargo = Console.ReadLine();
            }
            novoAnalista.Cargo = cargoService.cargos.FirstOrDefault(c => c.Nome.Equals(cargo, StringComparison.OrdinalIgnoreCase));

            Console.Write("\nEquipe: ");
            string equipe = Console.ReadLine();

            while (string.IsNullOrEmpty(equipe) || !equipeService.equipes.Any(e => e.Nome.Equals(equipe, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nEquipe inválida. Tente novamente.\n");
                Console.Write("Equipe: ");
                equipe = Console.ReadLine();
            }
            novoAnalista.Equipe = equipeService.equipes.FirstOrDefault(e => e.Nome.Equals(equipe, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nNome: {novoAnalista.Nome}");
            Console.WriteLine($"UF: {novoAnalista.UF}");
            Console.WriteLine($"Cargo: {novoAnalista.Cargo.Nome}");
            Console.WriteLine($"Equipe: {novoAnalista.Equipe.Nome}");
            Console.Write("\nConfirmar cadastro(S/N)? ");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                analistas.Add(novoAnalista);
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

            if(resposta.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                analistas.RemoveAll(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"\nAnalista {nome} removido com sucesso!\n");
            }
        }
    }
}
