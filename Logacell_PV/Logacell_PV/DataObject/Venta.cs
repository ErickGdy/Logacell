using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class Venta
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string total { get; set; }
        public string metodoPago { get; set; }
        public int puntoVenta { get; set; }
        public List<DetalleVenta> productos { get; set; }
    }
}
