using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class AbonoCredito
    {
        public int id { get; set; }
        public string cliente { get; set; }
        public int abono { get; set; }
        public string empleado { get; set; }
        public DateTime fecha { get; set; }
        public int puntoVenta { get; set; }
    }
}
