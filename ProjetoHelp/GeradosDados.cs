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

//var feriados2026 = new HashSet<DateTime>
//{
//    new DateTime(2026,1,1),
//    new DateTime(2026,2,17),
//    new DateTime(2026,4,3),
//    new DateTime(2026,4,21),
//    new DateTime(2026,5,1),
//    new DateTime(2026,6,4),
//    new DateTime(2026,9,7),
//    new DateTime(2026,10,12),
//    new DateTime(2026,11,2),
//    new DateTime(2026,11,15),
//    new DateTime(2026,12,25)
//};

//var prioridades = new[] { "Baixo", "Medio", "Alto" };

//Random rand = new();

//bool EhDiaUtil(DateTime data)
//{
//    return data.DayOfWeek != DayOfWeek.Saturday &&
//           data.DayOfWeek != DayOfWeek.Sunday &&
//           !feriados2026.Contains(data.Date);
//}

//DateTime RandomDate()
//{
//    DateTime date;

//    do
//    {
//        date = new DateTime(2026, 1, 1).AddDays(rand.Next(365));
//    }
//    while (!EhDiaUtil(date));

//    return date;
//}

//DateTime AdicionarDiasUteis(DateTime data, int dias)
//{
//    int adicionados = 0;

//    while (adicionados < dias)
//    {
//        data = data.AddDays(1);

//        if (EhDiaUtil(data))
//            adicionados++;
//    }

//    return data;
//}

//DateTime GerarEncerramento(DateTime abertura, string prioridade, double multiplicador)
//{
//    int diasBase = prioridade switch
//    {
//        "Alto" => rand.Next(0, 2),
//        "Medio" => rand.Next(1, 4),
//        "Baixo" => rand.Next(3, 8),
//        _ => 2
//    };

//    int diasAjustados = (int)Math.Round(diasBase * multiplicador);

//    return AdicionarDiasUteis(abertura, diasAjustados);
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
//    int qtdTickets = rand.Next(50, 101);

//    var tickets = new List<object>();

//    for (int i = 0; i < qtdTickets; i++)
//    {
//        var abertura = RandomDate();
//        var Prioridade = prioridades[rand.Next(prioridades.Length)];

//        var encerramento = GerarEncerramento(
//            abertura,
//            Prioridade,
//            analista.MultiplicadorTempo
//        );

//        bool respondeu = rand.Next(100) < analista.ProbRespostaCsat;

//        tickets.Add(new
//        {
//            Id = Guid.NewGuid(),
//            //DataAbertura = abertura.ToString("dd/MM/yyyy"),
//            DataAbertura = abertura,
//            DataEncerramento = encerramento,
//            Prioridade,
//            RespostaCSAT = respondeu,
//            NotaCSAT = GerarNota(respondeu, analista.ProbNota5)
//        });
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
//    "C:\\Users\\ygor\\source\\repos\\ProjetoHelp\\ProjetoHelp\\MockData\\tickets_mock_2026_.json",
//    json
//);

//Console.WriteLine("JSON gerado com sucesso.");

//record PerfilAnalista(
//    string Nome,
//    double MultiplicadorTempo,
//    int ProbRespostaCsat,
//    int ProbNota5
//);