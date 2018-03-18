using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class GenerarTrazabilidad
    {
        public static void generarTrazabilidad( string nombreTabla, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Trasabilidad";            
            List<string> lineasDocumento = new List<string>();
            lineasDocumento.Add(string.Format("/****** Object:  Table [dbo].[{0}]    Script Date:{1} ******/", nombreTabla, DateTime.Now));
            lineasDocumento.Add(string.Format("CREATE TABLE [dbo].[{0}]", nombreTabla));
            lineasDocumento.Add("(");
            foreach (DatosColumna item in listadoColumnas)
            {
                string isNulable = item.esNulable == "1" ? "null" : "not null";
                switch (item.tipoDatoColumna.ToLower())
                {
                    case "decimal":
                        lineasDocumento.Add(string.Format("[{0}][decimal] ({1},{2}) {3}", item.nombreColumna, item.prec,item.xscale,isNulable) + ",");
                        break;
                    case "money":
                        lineasDocumento.Add(string.Format("[{0}][money]", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "numeric":
                        lineasDocumento.Add(string.Format("[{0}][numeric] ({1},{2}) {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "smallint":
                        lineasDocumento.Add(string.Format("[{0}][smallint] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "tinyint":
                        lineasDocumento.Add(string.Format("[{0}][tinyint] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "int":
                        lineasDocumento.Add(string.Format("[{0}][int] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "ntext":
                        lineasDocumento.Add(string.Format("[{0}][ntext] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "nvarchar":
                        lineasDocumento.Add(string.Format("[{0}][nvarchar]({1}) {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "char":
                        lineasDocumento.Add(string.Format("[{0}][char]({1}) {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "nchar":
                        lineasDocumento.Add(string.Format("[{0}][nchar]({1}) {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "varchar":
                        lineasDocumento.Add(string.Format("[{0}][varchar]({1}) {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "datetime":
                        lineasDocumento.Add(string.Format("[{0}][datetime] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "float":
                        lineasDocumento.Add(string.Format("[{0}][float] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "real":
                        lineasDocumento.Add(string.Format("[{0}][real] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "bigint":
                        lineasDocumento.Add(string.Format("[{0}][bigint] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                    case "bit":
                        lineasDocumento.Add(string.Format("[{0}][bit] {3}", item.nombreColumna, item.prec, item.xscale, isNulable) + ",");
                        break;
                }
            }
            lineasDocumento.Add(string.Format("[idTrasabilidad] [int] IDENTITY(1,1) not null,"));
            lineasDocumento.Add(string.Format("[userNameBd] [varchar](100) not null,"));
            lineasDocumento.Add(string.Format("[fechaHora] [datetime] not null default(getdate()),"));
            lineasDocumento.Add(string.Format("[operacion] [varchar](100) not null default('')"));
            lineasDocumento.Add(")");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreTabla + ".sql", lineasDocumento);
        }
        public static void generarDesencadenadoresInsert(string nombreTabla, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Desencadenadores";
            List<string> lineasDocumento = new List<string>();
            lineasDocumento.Add(string.Format("CREATE TRIGGER [dbo].[TR_INSERT_{0}]", nombreTabla, DateTime.Now));
            lineasDocumento.Add(string.Format("ON [dbo].[{0}] AFTER INSERT", nombreTabla));            
            lineasDocumento.Add("AS");
            lineasDocumento.Add("BEGIN");
            lineasDocumento.Add("    if exists (SELECT 1 from inserted) BEGIN");
            lineasDocumento.Add(string.Format("        insert into MoldeTrasabilidad.dbo.{0}", nombreTabla));
            lineasDocumento.Add("        (");
            string selectcolumnas = "        ";
            string insertcolumnas = "        ";
            if (listadoColumnas.Count != 0)
            {                
                foreach (DatosColumna item in listadoColumnas)
                {
                    insertcolumnas += string.Format("{0},", item.nombreColumna);                    
                }
                selectcolumnas = insertcolumnas.Substring(0,insertcolumnas.Length-1);                
                insertcolumnas += "userNameBd,";
                insertcolumnas += "fechaHora,";
                insertcolumnas += "operacion";
                lineasDocumento.Add(insertcolumnas);
            }
            lineasDocumento.Add("        )");

            selectcolumnas += ",suser_name(),";
            selectcolumnas += "getdate(),";
            selectcolumnas += "'insert'";

            lineasDocumento.Add("        select");
            lineasDocumento.Add(string.Format("        {0}", selectcolumnas));
            lineasDocumento.Add("        from inserted");
            lineasDocumento.Add("    end");
            lineasDocumento.Add("end");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreTabla + "_Insert.sql", lineasDocumento);
        }
        public static void generarDesencadenadoresUpdate(string nombreTabla, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Desencadenadores";
            List<string> lineasDocumento = new List<string>();
            lineasDocumento.Add(string.Format("CREATE TRIGGER [dbo].[TR_UPDATE_{0}]", nombreTabla, DateTime.Now));
            lineasDocumento.Add(string.Format("ON [dbo].[{0}] AFTER UPDATE", nombreTabla));
            lineasDocumento.Add("AS");
            lineasDocumento.Add("BEGIN");
            lineasDocumento.Add("    if exists (SELECT 1 from inserted) BEGIN");
            lineasDocumento.Add(string.Format("        insert into MoldeTrasabilidad.dbo.{0}", nombreTabla));
            lineasDocumento.Add("        (");
            string selectcolumnas = "        ";
            string insertcolumnas = "        ";
            if (listadoColumnas.Count != 0)
            {
                foreach (DatosColumna item in listadoColumnas)
                {
                    insertcolumnas += string.Format("{0},", item.nombreColumna);
                }
                selectcolumnas = insertcolumnas.Substring(0, insertcolumnas.Length - 1);
                insertcolumnas += "userNameBd,";
                insertcolumnas += "fechaHora,";
                insertcolumnas += "operacion";
                lineasDocumento.Add(insertcolumnas);
            }
            lineasDocumento.Add("        )");

            selectcolumnas += ",suser_name(),";
            selectcolumnas += "getdate(),";
            selectcolumnas += "'Editing'";

            lineasDocumento.Add("        select");
            lineasDocumento.Add(string.Format("        {0}", selectcolumnas));
            lineasDocumento.Add("        from inserted");
            lineasDocumento.Add("    end");
            lineasDocumento.Add("end");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreTabla + "_Update.sql", lineasDocumento);
        }
        public static void generarDesencadenadoresDelete(string nombreTabla, List<DatosColumna> listadoColumnas, string direccionDestino, ref string error)
        {
            if (!Directory.Exists(direccionDestino))
            {
                System.IO.Directory.CreateDirectory(direccionDestino);
            }

            string directorioModelo = direccionDestino + "\\Desencadenadores";
            List<string> lineasDocumento = new List<string>();
            lineasDocumento.Add(string.Format("CREATE TRIGGER [dbo].[TR_DELETE_{0}]", nombreTabla, DateTime.Now));
            lineasDocumento.Add(string.Format("ON [dbo].[{0}] AFTER DELETE", nombreTabla));
            lineasDocumento.Add("AS");
            lineasDocumento.Add("BEGIN");
            lineasDocumento.Add("    if exists (SELECT 1 from deleted) BEGIN");
            lineasDocumento.Add(string.Format("        insert into MoldeTrasabilidad.dbo.{0}", nombreTabla));
            lineasDocumento.Add("        (");
            string selectcolumnas = "        ";
            string insertcolumnas = "        ";
            if (listadoColumnas.Count != 0)
            {
                foreach (DatosColumna item in listadoColumnas)
                {
                    insertcolumnas += string.Format("{0},", item.nombreColumna);
                }
                selectcolumnas = insertcolumnas.Substring(0, insertcolumnas.Length - 1);
                insertcolumnas += "userNameBd,";
                insertcolumnas += "fechaHora,";
                insertcolumnas += "operacion";
                lineasDocumento.Add(insertcolumnas);
            }
            lineasDocumento.Add("        )");

            selectcolumnas += ",suser_name(),";
            selectcolumnas += "getdate(),";
            selectcolumnas += "'Deleting'";

            lineasDocumento.Add("        select");
            lineasDocumento.Add(string.Format("        {0}", selectcolumnas));
            lineasDocumento.Add("        from deleted");
            lineasDocumento.Add("    end");
            lineasDocumento.Add("end");

            if (!Directory.Exists(directorioModelo))
            {
                System.IO.Directory.CreateDirectory(directorioModelo);
            }

            File.WriteAllLines(directorioModelo + "\\" + nombreTabla + "_Deleting.sql", lineasDocumento);
        }
    }
}
