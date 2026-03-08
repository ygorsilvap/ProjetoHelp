using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Models
{
    public class MetaModel
    {
        public Guid Id { get; set; }
        public int CasosEncerrados { get; set; }
        public double SLA { get; set; }
        public double TaxaCSAT { get; set; }
        public double NotaCSAT { get; set; }

        public MetaModel(int casosEncerrados, double sla, double taxacsat, double notacsat)
        {
            Id = Guid.NewGuid();
            CasosEncerrados = casosEncerrados;
            SLA = sla;
            TaxaCSAT = taxacsat;
            NotaCSAT = notacsat;
        }

        public MetaModel(double sla, double taxacsat, double notacsat)
        {
            Id = Guid.NewGuid();
            SLA = sla;
            TaxaCSAT = taxacsat;
            NotaCSAT = notacsat;
        }
    }
}
