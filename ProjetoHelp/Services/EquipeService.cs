using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class EquipeService
    {
        public List<EquipeModel> equipes = new List<EquipeModel>
        {
            new EquipeModel("Alpha"),
            new EquipeModel("Delta"),
            new EquipeModel("Fox"),
            new EquipeModel("Gamma")
        };

        public void MostrarEquipe()
        {
            Console.WriteLine("\nLista de Equipes.\n");
            foreach (var equipe in equipes)
            {
                Console.WriteLine($"{equipe.Nome} - {equipe.Analistas.Count} analistas.\n");
            }
        }
    }
}
