using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class SolicitudServicio
    {
        public string Folio { get; set; }
        public string nombreCliente { get; set; }
        public string telefonoCliente { get; set; }
        public string total { get; set; }
        public string anticipo { get; set; }
        public string pendiente { get; set; }
        public List<ServicioCliente> servicios { get; set; }




    }
}
