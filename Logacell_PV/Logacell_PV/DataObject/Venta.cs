using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class Venta
    {
        public string id { get; set; }
        public DateTime fecha { get; set; }
        public double total { get; set; }
        public int puntoVenta { get; set; }
        public string vendedor { get; set; }
        public List<DetalleVenta> productos { get; set; }
        public List<Pagos> pagos { get; set; }
    }
}
