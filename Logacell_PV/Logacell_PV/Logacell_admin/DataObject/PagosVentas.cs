using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_Admin.DataObject
{
    public class Pagos
    {
        public string id { get; set; }
        public string folio { get; set; }
        public string formaPago { get; set; }
        public double pago { get; set; }
        public string concepto { get; set; }

    }
}
