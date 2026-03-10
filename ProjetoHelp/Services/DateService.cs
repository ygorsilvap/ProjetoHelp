using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class DateService
    {
        public DateTime IntervaloSemanal()
        {
            DateTime inicioSemana = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            while (!inicioSemana.DayOfWeek.ToString().Equals("Monday"))
            {
                inicioSemana = inicioSemana.AddDays(-1);
            }

            return inicioSemana;
        }

        public DateTime IntervaloMensal()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public DateTime IntervaloTrimestral()
        {
            DateTime inicioTrimestre = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            while (inicioTrimestre.Month % 3 != 0 && inicioTrimestre.Month != 1)
            {
                inicioTrimestre = inicioTrimestre.AddMonths(-1);
            }
            if (inicioTrimestre.Month == 12)
                inicioTrimestre = inicioTrimestre.AddMonths(-3);

            return new DateTime(inicioTrimestre.Year, inicioTrimestre.Month, 1);
        }

        public DateTime IntervaloAnual()
        {
            return new DateTime(DateTime.Now.Year, 1, 1);
        }
    }
}
