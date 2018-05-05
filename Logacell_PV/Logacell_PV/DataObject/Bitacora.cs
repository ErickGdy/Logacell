using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.DataObject
{
    public class Bitacora
    {
        public string empleado { get; set; }
        public DateTime fecha { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut  { get; set; }
}
}
