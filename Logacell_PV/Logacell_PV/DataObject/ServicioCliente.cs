using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class ServicioCliente
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int servicio { get; set; }
        public string cliente { get; set; }
        public string presupuesto { get; set; }
    }
}
