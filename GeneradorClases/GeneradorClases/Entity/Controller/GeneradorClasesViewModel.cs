using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class GeneradorClasesViewModel
    {

        public static void generarClasesViewModel(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Modelo";
            string nombreClaseViewModel = getNombreClase(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("using System;");
            lineasDocumento.Add("using System.Collections.Generic;");            
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Entity.Model", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public class {0}", nombreClaseViewModel));
            lineasDocumento.Add("{");

            foreach (DatosColumna item in listadoColumnas)
            {
                string isNulable = item.esNulable == "1" ? "?" : "";
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                    case "money":
                        lineasDocumento.Add(string.Format("public decimal{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "numeric":
                        lineasDocumento.Add(string.Format("public double{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "smallint":
                    case "tinyint":
                    case "int":
                        lineasDocumento.Add(string.Format("public int{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "ntext":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                    case "varchar":
                        lineasDocumento.Add(string.Format("public string {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "datetime":
                        lineasDocumento.Add(string.Format("public DateTime{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "float":
                    case "real":
                        lineasDocumento.Add(string.Format("public float{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "bigint":
                        lineasDocumento.Add(string.Format("public long{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                    case "bit":
                        lineasDocumento.Add(string.Format("public bool{1} {0}", item.nombreColumna, isNulable) + "{get;set;}");
                        break;
                }
            }

            lineasDocumento.Add("}");
            lineasDocumento.Add("}");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreClaseViewModel + ".cs", lineasDocumento);
        }

        private static string getNombreClase(string nombreTablasAClase)
        {
            string caracterInicial = nombreTablasAClase.Remove(0).ToUpper();
            return caracterInicial + nombreTablasAClase + "ViewModel";    
            
        }
    }
}
