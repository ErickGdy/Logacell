using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class PuntoVenta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direcion { get; set; }
        public string telefono { get; set; }
        public string activo { get; set; }
        public string usuario { get; set; }
        public string prefijo { get; set; }
    }
}
