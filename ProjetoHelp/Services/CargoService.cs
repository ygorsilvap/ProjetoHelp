using ProjetoHelp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoHelp.Services
{
    public class CargoService
    {
        public List<CargoModel> cargos = new List<CargoModel>
        {
            new CargoModel("JR I", new MetaModel(50, 80, 25, 92)),
            new CargoModel("JR II", new MetaModel(60, 85, 30, 94)),
            new CargoModel("PL I", new MetaModel(80, 90, 35, 92)),
            new CargoModel("PL II", new MetaModel(88, 92, 40, 92)),
            new CargoModel("SR I", new MetaModel(88, 95, 45, 92)),
            new CargoModel("SR II", new MetaModel(90, 98, 50, 92))
        };

    }
}
