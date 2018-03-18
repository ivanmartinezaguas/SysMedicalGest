using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class GeneradorSimpleJs
    {
        public static void generarSimpleJs(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Js";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add(string.Format("//atributos del objecto {0}",nombreLowet));
            lineasDocumento.Add(string.Format("var {0} = new Object();", nombreLowet));
            lineasDocumento.Add(string.Format("function cargarDatos({0})", nombreLowet));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("$('#PanelID{0}').show();",nombreTablaAClase));
            foreach (DatosColumna item in listadoColumnas)
            {
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                    case "money":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                    case "numeric":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                    case "smallint":
                    case "tinyint":
                    case "int":
                        if (item.nombreColumna == "id")
                        {
                            lineasDocumento.Add(string.Format("$('#txtId{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        }
                        else
                        {
                            lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        }
                        break;
                    case "ntext":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                    case "varchar":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                    case "datetime":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                    case "float":
                    case "real":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                    case "bigint":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                    case "bit":
                        lineasDocumento.Add(string.Format("$('#txt{2}{0}').val({1}.{2});", nombreTablaAClase, nombreLowet, item.nombreColumna));
                        break;
                }

            }
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add("function croosModalClick()");
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("cargarLista{0}();",nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function btn{0}_NuevoClick()",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("loadUrlModal('Nueva {0}', 'frm{0}_Nuevo.aspx', croosModalClick);",nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function btn{0}_GuardarClick()",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("if (validarCampos())");
            lineasDocumento.Add("{");
            foreach (DatosColumna item in listadoColumnas)
            {
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                    case "money":
                       
                        
                            lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        

                        break;
                    case "numeric":


                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));

                        break;
                    case "smallint":
                    case "tinyint":
                    case "int":
                        if (item.nombreColumna == "id")
                        {
                            lineasDocumento.Add(string.Format("{0}.{1} = 0;", nombreLowet, item.nombreColumna));
                        } else if (item.nombreColumna == "usuarioId")
                        {
                            lineasDocumento.Add(string.Format("{0}.{1} = getLocalStorageNavegator(\"{1}\");", nombreLowet, item.nombreColumna));
                        }
                        else
                        {
                            lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        }

                        break;
                    case "ntext":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                    case "varchar":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "datetime":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "float":
                    case "real":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "bigint":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "bit":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                }

            }
            lineasDocumento.Add(string.Format("var url = \"/WebMethods/{0}.aspx/guardar\";", nombreLowet));
            lineasDocumento.Add(string.Format("enviarComoParametros(url, {0}, OnSuccesSave{1});", nombreLowet, nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function btn{0}_EditarClick()", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("if (validarCampos())");
            lineasDocumento.Add("{");
            foreach (DatosColumna item in listadoColumnas)
            {
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                    case "money":


                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));


                        break;
                    case "numeric":


                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));

                        break;
                    case "smallint":
                    case "tinyint":
                    case "int":
                        if (item.nombreColumna == "id")
                        {
                            lineasDocumento.Add(string.Format("{0}.{1} = $('#txtId{2}').val();", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        }
                        else if (item.nombreColumna == "usuarioId")
                        {
                            lineasDocumento.Add(string.Format("{0}.{1} = getLocalStorageNavegator(\"{1}\");", nombreLowet, item.nombreColumna));
                        }
                        else
                        {
                            lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        }

                        break;
                    case "ntext":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                    case "varchar":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "datetime":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "float":
                    case "real":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "bigint":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                    case "bit":
                        lineasDocumento.Add(string.Format("{0}.{1} = $('#txt{1}{2}').val() ;", nombreLowet, item.nombreColumna, nombreTablaAClase));
                        break;
                }

            }
            lineasDocumento.Add(string.Format("var url = \"/WebMethods/{0}.aspx/guardar\";", nombreLowet));
            lineasDocumento.Add(string.Format("enviarComoParametros(url, {0}, OnSuccesSave{1});", nombreLowet, nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function OnSuccesSave{0}(response)", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("if ((response.error == null ? \"\" : response.error) != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("tipoAlerta(response.error, response.tipoAlerta, \"#boxMessagesCrud\");");
            lineasDocumento.Add("return;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("if (response.error == '')");
            lineasDocumento.Add("{");
            lineasDocumento.Add("tipoAlerta('Registro Guardado con exito', 'success', \"#boxMessagesCrud\");");
            lineasDocumento.Add("return;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");

            lineasDocumento.Add(string.Format("function btn{0}_Editar(id)",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format(" loadUrlModal('Editar {0}', ('frm{0}_Editar.aspx?id=' + id), croosModalClick);", nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function btn{0}_Eliminar(id)",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("// get txn id from current table row");
            lineasDocumento.Add("var heading = 'Eliminar Registro';");
            lineasDocumento.Add("var question = '¿Desea eliminar el registro?.';");
            lineasDocumento.Add("var cancelButtonTxt = 'No';");
            lineasDocumento.Add("var okButtonTxt = 'Yes';");
            lineasDocumento.Add("var callback = function ()");
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("{0}.id = id;",nombreLowet));
            lineasDocumento.Add(string.Format("{0}.usuarioId = getLocalStorageNavegator(\"usuarioId\");", nombreLowet));
            lineasDocumento.Add(string.Format("var url = \"/WebMethods/{0}.aspx/eliminar\";", nombreLowet));
            lineasDocumento.Add(string.Format("enviarComoParametros(url, {0}, OnSuccesDelete{1});", nombreLowet,nombreTablaAClase));
            lineasDocumento.Add("}");

            lineasDocumento.Add("confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function OnSuccesDelete{0}(response)",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("if ((response.error == null ? \"\" : response.error) != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("tipoAlerta(response.error, response.tipoAlerta, \"#boxMessages\");");
            lineasDocumento.Add("return;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("if (response.error == '')");
            lineasDocumento.Add("{");
            lineasDocumento.Add("tipoAlerta('Registro Eliminado con Exito.', 'success', \"#boxMessages\");");
            lineasDocumento.Add(string.Format("cargarLista{0}();",nombreTablaAClase));
            lineasDocumento.Add("return;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            //sigue metodo get listaAplicaciones web
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function getLista{0}(registroPartida, totalAExtraer, callbackFucntion)", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("{0}.registroPartida = registroPartida;",nombreLowet));
            lineasDocumento.Add(string.Format("{0}.totalAExtraer = totalAExtraer;", nombreLowet));
            lineasDocumento.Add(string.Format("{0}.usuarioId = getLocalStorageNavegator(\"usuarioId\");", nombreLowet));
            lineasDocumento.Add(string.Format("var url = \"/WebMethods/{0}.aspx/getLista{1}\";",nombreLowet,nombreTablaAClase));
            lineasDocumento.Add(string.Format("enviarComoParametros(url, {0}, callbackFucntion);",nombreLowet));
            lineasDocumento.Add("}");
            //validarCampos
            lineasDocumento.Add("function validarCampos()");
            lineasDocumento.Add("{");

            foreach (DatosColumna item in listadoColumnas)
            {
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                    case "money":

                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");


                        break;
                    case "numeric":


                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");

                        break;
                    case "smallint":
                    case "tinyint":
                    case "int":
                        if (item.nombreColumna == "id")
                        {
                            lineasDocumento.Add("");
                            lineasDocumento.Add(string.Format("if ($('#txtId{0}').val()==0)", nombreLowet, item.nombreColumna));
                            lineasDocumento.Add("{");
                            lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                            lineasDocumento.Add("return false;");
                            lineasDocumento.Add("};");
                        }
                        else if (item.nombreColumna == "usuarioId")
                        {
                            
                        }
                        else
                        {
                            lineasDocumento.Add("");
                            lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna)); 
                            lineasDocumento.Add("{");
                            lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                            lineasDocumento.Add("return false;");
                            lineasDocumento.Add("};");
                        }

                        break;
                    case "ntext":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                    case "varchar":
                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");
                        break;
                    case "datetime":
                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");
                        break;
                    case "float":
                    case "real":
                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");
                        break;
                    case "bigint":
                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");
                        break;
                    case "bit":
                        lineasDocumento.Add("");
                        lineasDocumento.Add(string.Format("if ($('#txt{1}{0}').val()==0)", nombreTablaAClase, item.nombreColumna));
                        lineasDocumento.Add("{");
                        lineasDocumento.Add(string.Format("tipoAlerta('El campo {0} no puede ir vacío.', 'warning', \"#boxMessagesCrud\");", item.nombreColumna));
                        lineasDocumento.Add("return false;");
                        lineasDocumento.Add("};");
                        break;
                }

            }
            lineasDocumento.Add("return true;");
            lineasDocumento.Add("}");
            //cargarLista
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("function cargarLista{0}()",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("table = $('#gridLista{0}');",nombreTablaAClase));
            lineasDocumento.Add("");
            lineasDocumento.Add("if ($.fn.dataTable.isDataTable(table))");
            lineasDocumento.Add("{");
            lineasDocumento.Add("table.DataTable();");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add("table.DataTable(");
            lineasDocumento.Add("{");
            lineasDocumento.Add("serverSide: true,");
            lineasDocumento.Add("ordering: false,");
            lineasDocumento.Add("searching: false,");
            lineasDocumento.Add("processing: true,");
            lineasDocumento.Add("destroy:true,");
            lineasDocumento.Add("language: {");
            lineasDocumento.Add("\"processing\": \"Actualizando Datos\"");
            lineasDocumento.Add("},");
            lineasDocumento.Add("ajax: function (data, callback, settings)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("var out = [];");
            lineasDocumento.Add(string.Format("var lst{0};",nombreTablaAClase));
            lineasDocumento.Add("var totalRegistros = 0;");
            lineasDocumento.Add("var totalRegistrosFiltrados = 0;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("getLista{0}(data.start, data.length, function (response)",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("if ((response.error == null ? \"\" : response.error) != \"\")");
            lineasDocumento.Add("{");
            lineasDocumento.Add("tipoAlerta(response.error, response.tipoAlerta, \"#boxMessages\");");
            lineasDocumento.Add("return;");
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add("if (response.error == '')");
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("lst{0} = eval(\"(\" + response.getCadena + \")\");",nombreTablaAClase));
            lineasDocumento.Add("totalRegistros = response.totalRegistros;");
            lineasDocumento.Add("totalRegistrosFiltrados = response.totalRegistrosFiltrados;");
            lineasDocumento.Add(string.Format("for (var i = 0; i < lst{0}.length; i++)",nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("var etiquetaEditar = \"<a onclick='btn{0}_Editar(\" + lst{0}[i].id + \")'  class='fa fa-edit'><a>\";",nombreTablaAClase));
            lineasDocumento.Add(string.Format("var etiquetaEliminar = \" <a class='fa fa-minus' onclick='btn{0}_Eliminar(\" + lst{0}[i].id + \")'><a>\";", nombreTablaAClase));
            lineasDocumento.Add(string.Format("out.push([etiquetaEditar + etiquetaEliminar, lst{0}[i].nombre, lst{0}[i].descripcion]);",nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("");
            lineasDocumento.Add("setTimeout(callback(");
            lineasDocumento.Add("{");
            lineasDocumento.Add("draw: data.draw,");
            lineasDocumento.Add("data: out,");
            lineasDocumento.Add("recordsTotal: totalRegistros,");
            lineasDocumento.Add("recordsFiltered: totalRegistros");
            lineasDocumento.Add("}), 50);");
            lineasDocumento.Add("}");
            lineasDocumento.Add("});");
            lineasDocumento.Add("}");
            lineasDocumento.Add("});");
            lineasDocumento.Add("}");



            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\" + nombreTablaAClase + ".js", lineasDocumento);
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

        private static string getLowerName(string nombreTablasAClase)
        {
            string caracterInicial = nombreTablasAClase.Remove(1).ToLower();
            return caracterInicial + nombreTablasAClase.Substring(1, nombreTablasAClase.Length - 1);
        }
    }
}
