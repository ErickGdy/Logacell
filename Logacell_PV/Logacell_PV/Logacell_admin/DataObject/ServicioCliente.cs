using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_Admin.DataObject
{
    public class ServicioCliente
    {
        public int id { get; set; }
        public string folio { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string presupuesto { get; set; }
        public string contrasena { get; set; }
        public string patron { get; set; }
        public bool pila { get; set; }
        public bool tapa { get; set; }
        public bool memoria { get; set; }
        public bool chip { get; set; }
        public string IMEI { get; set; }

    }
}
