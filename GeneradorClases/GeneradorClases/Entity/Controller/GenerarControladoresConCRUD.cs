using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class GenerarControladoresConCRUD
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
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add(string.Format("using {0}.Entity.Model;", nombreProyecto));
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Entity.Controller", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public class {0}", nombreClaseController));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public static List<{0}> getLista{1}()", nombreClaseViewModel, nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("using ({0} entity = new {0}())", nombreEntidad));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("var l = from {0} in entity.{1}", nombreTablaAClase.ToLower(), nombreTablaAClase));
            foreach (DatosColumna item in listadoColumnas)
            {
                listadoAtributosSelect += string.Format("{0}={1}.{0},", item.nombreColumna, nombreTablaAClase.ToLower());
            }
            listadoAtributosSelect = listadoAtributosSelect.Remove(listadoAtributosSelect.Length - 1);
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

            lineasDocumento.Add("");
            //guardar
            lineasDocumento.Add(string.Format("public static Result guardar{0}({0} registro)", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("Result result = new Result() { error = \"\" };");
            lineasDocumento.Add("result = validarAtributos(registro);");
            lineasDocumento.Add("if (result.error != null && result.error != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return result;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("using ({0} entity = new {0}())", nombreEntidad));
            lineasDocumento.Add("{");
            lineasDocumento.Add("if (existeRegistro(registro.id))");
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("result = ValidateSession.validarOperacionesForm(\"{0}\", \"Editar\", registro.usuarioId);", nombreTablaAClase));
            lineasDocumento.Add("if (result.error != null && result.error != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return result;");
            lineasDocumento.Add("}");
            lineasDocumento.Add(string.Format("int {0}Id = registro.id;", nombreTablaAClase.ToLower()));
            lineasDocumento.Add(string.Format("{0} registroEditar = entity.{0}.Where(x => x.id == {1}Id).SingleOrDefault();", nombreTablaAClase, nombreTablaAClase.ToLower()));
            lineasDocumento.Add("entity.Entry(registroEditar).CurrentValues.SetValues(registro);");
            lineasDocumento.Add("try");
            lineasDocumento.Add("{");
            lineasDocumento.Add("entity.SaveChanges();");
            lineasDocumento.Add("return new Result { error = \"\" };");
            lineasDocumento.Add("}");
            lineasDocumento.Add("catch (Exception e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return new Result{ error = e.Message, id = 0 , tipoAlerta = \"warning\" };");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("else");
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("result = ValidateSession.validarOperacionesForm(\"{0}\", \"Nuevo\", registro.usuarioId);", nombreTablaAClase));
            lineasDocumento.Add("if (result.error != null && result.error != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return result;");
            lineasDocumento.Add("}");
            lineasDocumento.Add(string.Format("entity.{0}.Add(registro);", nombreTablaAClase));
            lineasDocumento.Add("try");
            lineasDocumento.Add("{");
            lineasDocumento.Add("entity.SaveChanges();");
            lineasDocumento.Add("return new Result { error = result.error, id = registro.id };");
            lineasDocumento.Add("}");
            lineasDocumento.Add("catch (Exception e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return new Result{ error = e.Message, id = 0 , tipoAlerta = \"warning\" };");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            //fin guardar
            lineasDocumento.Add("");
            //validar
            lineasDocumento.Add(string.Format("private static Result validarAtributos({0} registro)", nombreTablaAClase));
            lineasDocumento.Add("{");
            foreach (DatosColumna item in listadoColumnas)
            {
                lineasDocumento.Add(string.Format("if(registro.{0} == \"\")", item.nombreColumna));
                lineasDocumento.Add("{");
                lineasDocumento.Add("return new Result { error = \"Texto Validación\" , tipoAlerta =\"warning\"};");
                lineasDocumento.Add("}");
            }
            lineasDocumento.Add("return new Result() { error = \"\" };");
            lineasDocumento.Add("}");
            //finvalidar
            //Existe
            lineasDocumento.Add(string.Format("public static bool existeRegistro(int {0}Id)", nombreTablaAClase.ToLower()));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("using ({0} entity = new {0}())", nombreEntidad));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("if (entity.{0}.Where(x => x.id == {1}Id).Count() > 0)", nombreTablaAClase, nombreTablaAClase.ToLower()));
            lineasDocumento.Add("return true;");
            lineasDocumento.Add("return false;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            //finExiste
            //eliminar
            lineasDocumento.Add(string.Format("public static Result eliminar{0}(int {1}Id , int usuarioId)", nombreTablaAClase, nombreTablaAClase.ToLower()));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("using ({0} entity = new {0}())", nombreEntidad));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("if (existeRegistro({0}Id))", nombreTablaAClase.ToLower()));
            lineasDocumento.Add("{");
            lineasDocumento.Add("Result result = new Result() { error = \"\" };");
            lineasDocumento.Add(string.Format("result = ValidateSession.validarOperacionesForm(\"{0}\", \"Eliminar\", usuarioId);", nombreTablaAClase));
            lineasDocumento.Add("if (result.error != null && result.error != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return result;");
            lineasDocumento.Add("}");
            lineasDocumento.Add(string.Format("{0} registroEliminar = entity.{0}.Where(x => x.id == {1}Id).SingleOrDefault();", nombreTablaAClase, nombreTablaAClase.ToLower()));
            lineasDocumento.Add(string.Format("entity.{0}.Remove(registroEliminar);", nombreTablaAClase));
            lineasDocumento.Add(string.Format("MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), \"{0}\", \"Eliminado\", usuarioId, \"AplicacionMolde\");", nombreTablaAClase));
            lineasDocumento.Add("try");
            lineasDocumento.Add("{");
            lineasDocumento.Add("entity.SaveChanges();");
            lineasDocumento.Add("return new Result {"+ string.Format( "error = result.error, id = {0}Id ", nombreTablaAClase.ToLower())+ "};");
            lineasDocumento.Add("}");
            lineasDocumento.Add("catch (Exception e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("return new Result{ error = e.Message, id = 0 , tipoAlerta = \"warning\" };");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("return new Result { error = \"\" };");
            lineasDocumento.Add("}");
            //fin eliminar
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
