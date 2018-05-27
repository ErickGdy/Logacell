using Logacell.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_PV.DataObject
{
    public class Compra
    {

        public int id { get; set; }
        public List<Producto> productos { get; set; }
        public string Empleado { get; set; }
        public double total { get; set; }
        public int idPV { get; set; }
        public DateTime fecha { get; set; }

    }
}
