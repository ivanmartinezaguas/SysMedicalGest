using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class GenerarClasesPatterState
    {
        public static void generarClases(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, List<string> listEstadosRegistro, List<string> listOperaciones, ref string error)
        {
            generarIfactory(nombreTablaAClase, listEstadosRegistro, direccionDestino);
            generarIstatePrincipal(nombreProyecto, nombreTablaAClase, listOperaciones, direccionDestino);
            generarIstateEstados(nombreProyecto, nombreTablaAClase, listEstadosRegistro, listOperaciones, direccionDestino);
        }

        private static void generarIstateEstados(string nombreProyecto, string nombreTablaAClase, List<string> listEstadosRegistro, List<string> listOperaciones, string direccionDestino)
        {
            foreach (string item in listEstadosRegistro)
            {
                if (!Directory.Exists(direccionDestino))
                {
                    System.IO.Directory.CreateDirectory(direccionDestino);
                }

                string directorioModelo = direccionDestino + "\\Controller";
                string nombreClaseState = getNombreClaseState(nombreTablaAClase);
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
                    lineasDocumento.Add(string.Format("public class {0}_{1}:{0}", nombreClaseState,item));
                    lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("private const string nombreEstado = \"{0}\";",item));
                        foreach (string op in listOperaciones)
                        {
                            lineasDocumento.Add(string.Format("Result {0}(ref {1} registro)",op, nombreTablaAClase));
                            lineasDocumento.Add("{");
                            lineasDocumento.Add("Result resul = new Result();");
                            lineasDocumento.Add("resul.error = \"No se puede realizar esta operación en el estado actual del registro\";");
                            lineasDocumento.Add("return resul;");
                            lineasDocumento.Add("}");
                        }
                       
                    lineasDocumento.Add("}");
                lineasDocumento.Add("}");

                if (!Directory.Exists(directorioModelo))
                {
                    System.IO.Directory.CreateDirectory(directorioModelo);
                }

                File.WriteAllLines(directorioModelo + "\\" + nombreClaseState + "_" + item + ".cs", lineasDocumento);
            }
        }

        private static void generarIstatePrincipal(string nombreProyecto, string nombreTablaAClase, List<string> listEstadosRegistro, string direccionDestino)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Controller";
            string nombreClaseState = getNombreClaseState(nombreTablaAClase);
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
            lineasDocumento.Add(string.Format("public interface {0}", nombreClaseState));
            lineasDocumento.Add("{");
            foreach (string item in listEstadosRegistro)
            {
                lineasDocumento.Add("");
                lineasDocumento.Add(string.Format("Result {0} (ref {1} registro);", item, nombreTablaAClase));
                lineasDocumento.Add("");
            }
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreClaseState + ".cs", lineasDocumento);
        }

        private static void generarIfactory(string nombreTablaAClase, List<string> listEstadosRegistro, string direccionDestino)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Controller";
            string nombreClaseState = getNombreClaseState(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("");
            //
            lineasDocumento.Add(string.Format("public static {0} create{1}(string state)", nombreClaseState, nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("switch (state)");
            lineasDocumento.Add("{");
            foreach (string item in listEstadosRegistro)
            {
                lineasDocumento.Add(string.Format("case \"{0}\":", item));
                lineasDocumento.Add(string.Format("return {0}_{1}();", nombreClaseState, item));

            }
            lineasDocumento.Add("default:");
            lineasDocumento.Add("return null;");

            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            //


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + "IFACTORY" + ".cs", lineasDocumento);
        }

        private static string getNombreClaseState(string nombreTablasAClase)
        {
            string caracterInicial = nombreTablasAClase.Remove(0).ToUpper();

            return "ISTATE" + caracterInicial + nombreTablasAClase;
        }

    }
}
