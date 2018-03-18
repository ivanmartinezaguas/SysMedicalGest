using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Model
{
    public class ConecionServidorViewModel
    {
        public int id { get; set; }
        public string nombreConeccion { get; set; }
        public string servidor { get; set; }
        public string baseDatos { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
