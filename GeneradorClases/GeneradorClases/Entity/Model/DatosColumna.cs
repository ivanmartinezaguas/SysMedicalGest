using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Model
{
    public class DatosColumna
    {
        public string nombreColumna { set; get; }
        public string tipoDatoColumna { set; get; }
        public string esNulable { set; get; }
        public int prec { set; get; }
        public int xscale { set; get; }
    }
}
