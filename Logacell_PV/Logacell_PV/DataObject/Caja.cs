using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class Caja
    {
        public int id { get; set; }
        public int puntoVenta { get; set; }
        public decimal fondoInicial { get; set; }
        public decimal fondoActual { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
    }
}
