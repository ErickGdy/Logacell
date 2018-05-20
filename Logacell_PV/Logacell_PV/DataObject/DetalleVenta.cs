using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class DetalleVenta
    {
        public string folio { get; set; }
        public int idProducto { get; set; }
        public int cantidadProducto { get; set; }
        public double descuento { get; set; }
        public double total { get; set; }
    }
}
