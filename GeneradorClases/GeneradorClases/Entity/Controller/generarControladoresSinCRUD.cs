using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class generarControladoresSinCRUD
    {
        public static void generarClasesController(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Controller";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string listadoAtributosSelect = "";
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("using System;");
            lineasDocumento.Add("using System.Collections.Generic;");
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add(string.Format("using {0}.Entity.Model;", nombreProyecto));
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Entity.Controller", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public class {0}", nombreClaseController));
            lineasDocumento.Add("{");            
            lineasDocumento.Add(string.Format("public static List<{0}> getLista{1}()",nombreClaseViewModel, nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("using ({0} entity = new {0}())",nombreEntidad));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("var l = from {0} in entity.{1}", nombreTablaAClase.ToLower(),nombreTablaAClase));
            foreach (DatosColumna item in listadoColumnas)
            {
                listadoAtributosSelect += string.Format("{0}={1}.{0},", item.nombreColumna, nombreTablaAClase.ToLower());
            }
            listadoAtributosSelect = listadoAtributosSelect.Remove(listadoAtributosSelect.Length-1);
            lineasDocumento.Add(string.Format("select new {0}", nombreClaseViewModel) + "{" + listadoAtributosSelect + "};");
            lineasDocumento.Add("return l.ToList();");            
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("public static {0} get{1}()", nombreClaseViewModel, nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("using ({0} entity = new {0}())", nombreEntidad));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("var l = from {0} in entity.{1}", nombreTablaAClase.ToLower(), nombreTablaAClase));                       
            lineasDocumento.Add(string.Format("select new {0}", nombreClaseViewModel) + "{" + listadoAtributosSelect + "};");
            lineasDocumento.Add("return l.SingleOrDefault();");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreClaseController + ".cs", lineasDocumento);
        }

        private static string getNombreClaseController(string nombreTablasAClase)
        {
            string caracterInicial = nombreTablasAClase.Remove(0).ToUpper();
            return caracterInicial + nombreTablasAClase + "Controller";
        }

        private static string getNombreClaseModel(string nombreTablasAClase)
        {
            string caracterInicial = nombreTablasAClase.Remove(0).ToUpper();
            return caracterInicial + nombreTablasAClase + "ViewModel";            
        }
    }
}
