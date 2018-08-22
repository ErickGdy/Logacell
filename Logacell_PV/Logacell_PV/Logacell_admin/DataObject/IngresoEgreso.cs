using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_Admin.DataObject
{
    public class IngresoEgreso
    {

        public int id { get; set; }
        public string tipo { get; set; }
        public string Empleado { get; set; }
        public double pago { get; set; }
        public string concepto { get; set; }
        public int idPV { get; set; }
        public DateTime fecha { get; set; }

    }
}
