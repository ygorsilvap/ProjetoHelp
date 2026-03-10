//using System.Text.Json;

//var analistas = new List<PerfilAnalista>
//{
//    new("Leandro Peixoto", 0.7, 35, 85),
//    new("Vitor Henrique Martins", 1.0, 45, 70),
//    new("Camila Rodrigues Ferreira", 1.0, 40, 70),
//    new("Lucas Almeida Costa", 1.3, 25, 60),
//    new("Mariana Duarte Lopes", 0.8, 55, 75),
//    new("Gabriel Teixeira Ramos", 1.0, 75, 65),
//    new("Fernanda Carvalho Batista", 0.7, 60, 85),
//    new("Rafael Gonçalves Pereira", 1.4, 20, 55)
//};

//Random rand = new();

//DateTime RandomDateMes(int mes)
//{
//    int diasNoMes = DateTime.DaysInMonth(2026, mes);
//    int dia = rand.Next(1, diasNoMes + 1);

//    return new DateTime(2026, mes, dia);
//}

//bool DiaUtil(DateTime data)
//{
//    return data.DayOfWeek != DayOfWeek.Saturday &&
//           data.DayOfWeek != DayOfWeek.Sunday;
//}

//DateTime AdicionarDiasUteis(DateTime data, int dias)
//{
//    int adicionados = 0;

//    while (adicionados < dias)
//    {
//        data = data.AddDays(1);

//        if (DiaUtil(data))
//            adicionados++;
//    }

//    return data;
//}

//string GerarPrioridade()
//{
//    int chance = rand.Next(100);

//    if (chance < 50) return "Baixo";
//    if (chance < 85) return "Medio";
//    return "Alto";
//}

//DateTime GerarEncerramento(DateTime abertura, string prioridade, double multiplicador)
//{
//    int baseDias = prioridade switch
//    {
//        "Alto" => rand.Next(1, 4),
//        "Medio" => rand.Next(3, 7),
//        _ => rand.Next(5, 10)
//    };

//    int diasAjustados = (int)Math.Round(baseDias * multiplicador);

//    if (diasAjustados < 1)
//        diasAjustados = 1;

//    return AdicionarDiasUteis(abertura, diasAjustados);
//}

//int TicketsNoMes(int mes)
//{
//    if (mes == 3 || mes == 8 || mes == 11)
//        return rand.Next(90, 140); // pico

//    if (mes == 12)
//        return rand.Next(30, 60); // baixo

//    return rand.Next(50, 100);
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
//        int qtdTicketsMes = TicketsNoMes(mes);

//        for (int i = 0; i < qtdTicketsMes; i++)
//        {
//            var abertura = RandomDateMes(mes);

//            var prioridade = GerarPrioridade();

//            var encerramento = GerarEncerramento(
//                abertura,
//                prioridade,
//                analista.MultiplicadorTempo
//            );

//            bool respondeu =
//                rand.Next(100) < analista.ProbRespostaCsat;

//            tickets.Add(new
//            {
//                Id = Guid.NewGuid(),
//                DataAbertura = abertura,
//                DataEncerramento = encerramento,
//                Prioridade = prioridade,
//                RespostaCSAT = respondeu,
//                NotaCSAT = GerarNota(respondeu, analista.ProbNota5)
//            });
//        }
//    }

//    var ticketsOrdenados = tickets
//        .OrderBy(t => ((dynamic)t).DataEncerramento)
//        .ToList();

//    resultado.Add(new
//    {
//        analista = analista.Nome,
//        tickets = ticketsOrdenados
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