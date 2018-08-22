using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell_Admin.DataObject
{
    public class Traspaso
    {
        public int id { get; set; }
        public int producto { get; set; }
        public int cantidad { get; set; }
        public int idOrigen { get; set; }
        public int idDestino { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }

    }
}
