//using System.Text.Json;

//var analistas = new List<PerfilAnalista>
//{
//    new("Leandro Peixoto", 0.7, 90, 85),
//    new("Vitor Henrique Martins", 1.0, 80, 70),
//    new("Camila Rodrigues Ferreira", 1.0, 75, 70),
//    new("Lucas Almeida Costa", 1.3, 70, 60),
//    new("Mariana Duarte Lopes", 0.8, 85, 75),
//    new("Gabriel Teixeira Ramos", 1.0, 80, 65),
//    new("Fernanda Carvalho Batista", 0.7, 88, 85),
//    new("Rafael Gonçalves Pereira", 1.4, 65, 55)
//};

//Random rand = new();

//DateTime RandomDateMes(int mes)
//{
//    int diasNoMes = DateTime.DaysInMonth(2026, mes);
//    int dia = rand.Next(1, diasNoMes + 1);

//    return new DateTime(2026, mes, dia);
//}

//DateTime GerarEncerramento(DateTime abertura)
//{
//    int dias = rand.Next(1, 11); // 1 a 10 dias

//    return abertura.AddDays(dias);
//}

//int? GerarNota(bool respondeu, int probNota5)
//{
//    if (!respondeu) return null;

//    int chance = rand.Next(100);

//    if (chance < probNota5)
//        return 5;

//    return rand.Next(1, 5);
//}

//var resultado = new List<object>();

//foreach (var analista in analistas)
//{
//    var tickets = new List<object>();

//    for (int mes = 1; mes <= 12; mes++)
//    {
//        int qtdTicketsMes = rand.Next(50, 101);

//        for (int i = 0; i < qtdTicketsMes; i++)
//        {
//            var abertura = RandomDateMes(mes);
//            var encerramento = GerarEncerramento(abertura);

//            bool respondeu = rand.Next(100) < analista.ProbRespostaCsat;

//            tickets.Add(new
//            {
//                Id = Guid.NewGuid(),
//                DataAbertura = abertura,
//                DataEncerramento = encerramento,
//                RespostaCSAT = respondeu,
//                NotaCSAT = GerarNota(respondeu, analista.ProbNota5)
//            });
//        }
//    }

//    resultado.Add(new
//    {
//        analista = analista.Nome,
//        tickets
//    });
//}

//var json = JsonSerializer.Serialize(resultado, new JsonSerializerOptions
//{
//    WriteIndented = true
//});

//File.WriteAllText(
//    "C:\\Users\\ygor\\source\\repos\\ProjetoHelp\\ProjetoHelp\\Data\\tickets_mock_2026.json",
//    json
//);

//Console.WriteLine("JSON gerado com sucesso.");

//record PerfilAnalista(
//    string Nome,
//    double MultiplicadorTempo,
//    int ProbRespostaCsat,
//    int ProbNota5
//);