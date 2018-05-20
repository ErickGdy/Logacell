using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class PagosVentas
    {
        public string id { get; set; }
        public string idVenta { get; set; }
        public string formaPago { get; set; }
        public double pago { get; set; }

    }
}
