using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class GeneradorCrudBoostrap
    {
        public static void generarListarAspx(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add(string.Format("<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/Forms/frmMasterPage.Master\" AutoEventWireup=\"true\" CodeBehind=\"frmLista{0}.aspx.cs\" Inherits=\"{1}.Forms.frmLista{0}\" %>", nombreTablaAClase, nombreProyecto));
            lineasDocumento.Add("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" runat=\"server\">");
            lineasDocumento.Add("</asp:Content>");
            lineasDocumento.Add("<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"contenPlaceDocument\" runat=\"server\">");
            lineasDocumento.Add("<br />");
            lineasDocumento.Add("<div class=\"row\">");
            lineasDocumento.Add("<div class=\"panel panel-primary\">");
            lineasDocumento.Add("<div class=\"panel-heading\">");
            lineasDocumento.Add(string.Format("Listado {0}", nombreTablaAClase));
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("<div class=\"panel-body\">");
            lineasDocumento.Add("<div class=\"col-sm-5 col-md-5 col-lg-1\">");
            lineasDocumento.Add(string.Format("<button  id=\"btn{0}_Nuevo\" onclick=\"btn{0}_NuevoClick()\" type=\"button\" class=\"btn btn-default\">Nuevo</button>", nombreTablaAClase));
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("<br />");
            lineasDocumento.Add("<!-- /.row -->");
            lineasDocumento.Add("<div class=\"row\">");
            lineasDocumento.Add("<div class=\"col-lg-12\">");
            lineasDocumento.Add(string.Format("<table id=\"gridLista{0}\" class=\"display\" cellspacing=\"0\" width=\"100%\">", nombreTablaAClase));
            lineasDocumento.Add("<thead>");
            lineasDocumento.Add("<tr>");
            lineasDocumento.Add("<th>#</th>");
            foreach (DatosColumna item in listadoColumnas)
            {
                lineasDocumento.Add(string.Format("<th>{0}</th>", item.nombreColumna));
            }
            lineasDocumento.Add("</tr>");
            lineasDocumento.Add("</thead>");
            lineasDocumento.Add("</table>");
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("<!-- /.col-lg-12 -->");
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("<!-- /.row -->");
            lineasDocumento.Add("</asp:Content>");
            lineasDocumento.Add("<asp:Content ID=\"Content3\" ContentPlaceHolderID=\"footerScripst\" runat=\"server\">");
            lineasDocumento.Add(string.Format("<script src=\"../Js/Forms/{0}.js\"></script>", nombreTablaAClase));
            lineasDocumento.Add("<script>");
            lineasDocumento.Add(string.Format("cargarLista{0}();", nombreTablaAClase));
            lineasDocumento.Add("</script>");
            lineasDocumento.Add("</asp:Content>");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frmLista" + nombreTablaAClase + ".aspx", lineasDocumento);
        }

        public static void generarListarAspxDesig(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("// <auto-generated>");
            lineasDocumento.Add("//     Este código fue generado por herramienta.");
            lineasDocumento.Add("//");
            lineasDocumento.Add("//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si");
            lineasDocumento.Add("//     se regenera el código.");
            lineasDocumento.Add("// </auto-generated>");
            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms)", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class {0}", nombreLowet));
            lineasDocumento.Add("{");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frmLista" + nombreTablaAClase + ".aspx.designer.cs", lineasDocumento);
        }

        public static void generarListarMethodCs(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);

            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("using System;");
            lineasDocumento.Add("using System.Collections.Generic;");
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add("using System.Web.Script.Serialization;");
            lineasDocumento.Add("using System.Web.Services;");
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frmLista{0} : System.Web.UI.Page", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("protected void Page_Load(object sender, EventArgs e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frmLista" + nombreTablaAClase + ".aspx.cs", lineasDocumento);
        }


        public static void generarAscx(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add(string.Format("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"frm{0}.ascx.cs\" Inherits=\"{1}.Forms.frm{0}\" %>", nombreTablaAClase, nombreProyecto));
            lineasDocumento.Add("<div class=\"row\">");
            lineasDocumento.Add("<div class=\"col-sm-6\">");
            lineasDocumento.Add(string.Format("<div id=\"PanelID{0}\" hidden=\"hidden\">",nombreTablaAClase));
            lineasDocumento.Add(string.Format("<label id=\"lblId{0}\">Id</label>", nombreTablaAClase));
            lineasDocumento.Add(string.Format("<input id=\"txtId{0}\" disabled class=\"form-control\" />", nombreTablaAClase));
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("</div>");
            lineasDocumento.Add("</div>");
            foreach (DatosColumna item in listadoColumnas)
            {
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                    case "money":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>",item.nombreColumna,nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"txt{0}{1}\" type=\"number\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "numeric":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"txt{0}{1}\" type=\"number\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "smallint":
                    case "tinyint":
                    case "int":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"txt{0}{1}\" type=\"number\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "ntext":
                    case "nvarchar":
                    case "char":
                    case "nchar":
                    case "varchar":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"txt{0}{1}\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "datetime":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"lbl{0}{1}\" type=\"date\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "float":
                    case "real":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"txt{0}{1}\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "bigint":
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add(string.Format("<label id=\"lbl{0}{1}\">{0}</label>", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add(string.Format("<input id=\"txt{0}{1}\" class=\"form-control\">", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                    case "bit":
                        lineasDocumento.Add("<!-- Utilice check o Radio -->");
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add("<label>");                                              
                        lineasDocumento.Add(string.Format("<input id=\"ch{0}{1}\" type=\"checkbox\" value=\"\"/> {0}",item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</label>");
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("<!-- Utilice check o Radio -->");
                        lineasDocumento.Add("<div class=\"row\">");
                        lineasDocumento.Add("<div class=\"col-sm-6\">");
                        lineasDocumento.Add("<label>");                        
                        lineasDocumento.Add(string.Format("<input id=\"op{0}{1}\" type=\"radio\" value=\"\"/> {0}", item.nombreColumna, nombreTablaAClase));
                        lineasDocumento.Add("</label>");
                        lineasDocumento.Add("</div>");
                        lineasDocumento.Add("</div>");
                        break;
                }

            }




            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + ".ascx", lineasDocumento);
        }

        public static void generarAscxDesig(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("// <auto-generated>");
            lineasDocumento.Add("//     Este código fue generado por herramienta.");
            lineasDocumento.Add("//");
            lineasDocumento.Add("//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si");
            lineasDocumento.Add("//     se regenera el código.");
            lineasDocumento.Add("// </auto-generated>");
            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms)", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frm{0}", nombreLowet));
            lineasDocumento.Add("{");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + ".ascx.designer.cs", lineasDocumento);
        }

        public static void generarAscxCs(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);

            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("using System;");
            lineasDocumento.Add("using System.Collections.Generic;");
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add("using System.Web.Script.Serialization;");
            lineasDocumento.Add("using System.Web.Services;");
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frm{0} : System.Web.UI.UserControl", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("protected void Page_Load(object sender, EventArgs e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + ".ascx.cs", lineasDocumento);
        }


        public static void generarNuevoAspx(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add(string.Format("<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/Forms/frmCrudMaster.Master\" AutoEventWireup=\"true\" CodeBehind=\"frm{0}_Nuevo.aspx.cs\" Inherits=\"{1}.Forms.frm{0}_Nuevo\" %>", nombreTablaAClase, nombreProyecto));
            lineasDocumento.Add(string.Format("<%@ Register Src=\"~/Forms/frm{0}.ascx\" TagPrefix=\"uc1\" TagName=\"frm{0}\"%>", nombreTablaAClase));
            lineasDocumento.Add("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" runat=\"server\">");
            lineasDocumento.Add(string.Format("<script src=\"../Js/Forms/{0}.js\"></script>",nombreTablaAClase));
            lineasDocumento.Add("</asp:Content>");
            lineasDocumento.Add("<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"contenPlaceDocument\" runat=\"server\">");
            lineasDocumento.Add(string.Format("<uc1:frm{0} runat=\"server\" ID=\"frm{0}\" />",nombreTablaAClase));
            lineasDocumento.Add("<br />");
            lineasDocumento.Add(string.Format("<a id=\"btn{0}_Guardar\" onclick=\"btn{0}_GuardarClick()\" class=\"btn btn-success\">Guardar</a>", nombreTablaAClase));
            lineasDocumento.Add("</asp:Content>");
            lineasDocumento.Add("<asp:Content ID=\"Content3\" ContentPlaceHolderID=\"ContentPlaceFoot\" runat=\"server\">");
            lineasDocumento.Add("</asp:Content>");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + "_Nuevo.aspx", lineasDocumento);
        }

        public static void generarNuevoAspxDesig(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("// <auto-generated>");
            lineasDocumento.Add("//     Este código fue generado por herramienta.");
            lineasDocumento.Add("//");
            lineasDocumento.Add("//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si");
            lineasDocumento.Add("//     se regenera el código.");
            lineasDocumento.Add("// </auto-generated>");
            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms)", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frm{0}_Nuevo", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("protected global::ProyectoMolde.Forms.frm{0} frm{0};",nombreTablaAClase)); 
        lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + "_Nuevo.aspx.designer.cs", lineasDocumento);
        }

        public static void generarNuevoAspxCs(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);

            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("using System;");
            lineasDocumento.Add("using System.Collections.Generic;");
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add("using System.Web.Script.Serialization;");
            lineasDocumento.Add("using System.Web.Services;");
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frm{0}_Nuevo : System.Web.UI.Page", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("protected void Page_Load(object sender, EventArgs e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + "_Nuevo.aspx.cs", lineasDocumento);
        }


        public static void generarEditarAspx(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add(string.Format("<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/Forms/frmCrudMaster.Master\" AutoEventWireup=\"true\" CodeBehind=\"frm{0}_Editar.aspx.cs\" Inherits=\"{1}.Forms.frm{0}_Editar\" %>", nombreTablaAClase, nombreProyecto));
            lineasDocumento.Add(string.Format("<%@ Register Src=\"~/Forms/frm{0}.ascx\" TagPrefix=\"uc1\" TagName=\"frm{0}\"%>", nombreTablaAClase));
            lineasDocumento.Add("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" runat=\"server\">");
            lineasDocumento.Add(string.Format("<script src=\"../Js/Forms/{0}.js\"></script>", nombreTablaAClase));
            lineasDocumento.Add("</asp:Content>");
            lineasDocumento.Add("<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"contenPlaceDocument\" runat=\"server\">");
            lineasDocumento.Add(string.Format("<uc1:frm{0} runat=\"server\" ID=\"frm{0}\" />", nombreTablaAClase));
            lineasDocumento.Add("<br />");
            lineasDocumento.Add(string.Format("<a id=\"btn{0}_Editar\" onclick=\"btn{0}_EditarClick()\" class=\"btn btn-success\">Editar</a>", nombreTablaAClase));
            lineasDocumento.Add("</asp:Content>");
            lineasDocumento.Add("<asp:Content ID=\"Content3\" ContentPlaceHolderID=\"ContentPlaceFoot\" runat=\"server\">");

            lineasDocumento.Add("<script>");
            lineasDocumento.Add(string.Format("<% string {0}IdString = Request.QueryString[\"id\"];",nombreLowet));
            lineasDocumento.Add(string.Format("int {0}Id = 0;",nombreLowet));
            lineasDocumento.Add(string.Format("int.TryParse({0}IdString, out {0}Id);",nombreLowet));
            lineasDocumento.Add(string.Format("string json{0} = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlUsuarios.Entity.Controller.{0}Controller.get{0}({1}Id)); %>", nombreTablaAClase,nombreLowet));
            lineasDocumento.Add(string.Format("{1} = <%= json{0} %> ", nombreTablaAClase, nombreLowet));
            lineasDocumento.Add(string.Format("console.log({0});",  nombreLowet));
            lineasDocumento.Add(string.Format("cargarDatos({0});", nombreLowet));
            lineasDocumento.Add(string.Format("</script>", nombreLowet));

            lineasDocumento.Add("</asp:Content>");

      

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + "_Editar.aspx", lineasDocumento);
        }

        public static void generarEditarAspxDesig(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);
            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("// <auto-generated>");
            lineasDocumento.Add("//     Este código fue generado por herramienta.");
            lineasDocumento.Add("//");
            lineasDocumento.Add("//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si");
            lineasDocumento.Add("//     se regenera el código.");
            lineasDocumento.Add("// </auto-generated>");
            lineasDocumento.Add("//------------------------------------------------------------------------------");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms)", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frm{0}_Editar", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("protected global::ProyectoMolde.Forms.frm{0} frm{0};", nombreTablaAClase));
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + "_Editar.aspx.designer.cs", lineasDocumento);
        }

        public static void generarEditarAspxCs(string nombreProyecto, string nombreEntidad, string nombreTablaAClase, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Forms";
            string nombreClaseController = getNombreClaseController(nombreTablaAClase);
            string nombreClaseViewModel = getNombreClaseModel(nombreTablaAClase);
            string nombreLowet = getLowerName(nombreTablaAClase);

            List<string> lineasDocumento = new List<string>();

            lineasDocumento.Add("using System;");
            lineasDocumento.Add("using System.Collections.Generic;");
            lineasDocumento.Add("using System.Linq;");
            lineasDocumento.Add("using System.Text;");
            lineasDocumento.Add("using System.Web.Script.Serialization;");
            lineasDocumento.Add("using System.Web.Services;");
            lineasDocumento.Add("using System.Threading.Tasks;");
            lineasDocumento.Add("");
            lineasDocumento.Add(string.Format("namespace {0}.Forms", nombreProyecto));
            lineasDocumento.Add("{");
            lineasDocumento.Add(string.Format("public partial class frm{0}_Editar : System.Web.UI.Page", nombreTablaAClase));
            lineasDocumento.Add("{");
            lineasDocumento.Add("protected void Page_Load(object sender, EventArgs e)");
            lineasDocumento.Add("{");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");
            lineasDocumento.Add("}");


            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }
            File.WriteAllLines(directorioModelo + "\\frm" + nombreTablaAClase + "_Editar.aspx.cs", lineasDocumento);
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
