using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_Admin.DataObject
{
    public class CreditoCliente
    {
        public string cliente { get; set; }
        public int limiteCredito { get; set; }
        public int deuda { get; set; }
        public int pendiente { get; set; }
}
}
