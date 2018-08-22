using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_Admin.DataObject
{
    public class Producto
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public string modelo { get; set; }
        public string precio { get; set; }
        public string marca { get; set; }
        public int cantidad { get; set; }
    }
}
