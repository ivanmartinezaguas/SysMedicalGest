using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class MetodosGeneralesController
    {
        public static List<vSysDataBaseViewModel> getListaBaseDatos(string nombreServidor, string nombreUsuario, string contrasena, ref string error)
        {
            string cadenaConeccion = string.Format("Data Source={0};Initial Catalog=master;Persist Security Info=True;User ID={1};Password={2}", nombreServidor, nombreUsuario, contrasena);
            using (SqlConnection con = new SqlConnection(cadenaConeccion))
            {
                try
                {
                    con.Open();
                    con.Close();
                    return vSysDataBaseController.getListConeccionesServidor();
                }
                catch (Exception ex)
                {
                    error = "No se puede Realizar Conección con el servidor de Base datos " + ex.Message;
                    return new List<vSysDataBaseViewModel>();
                }
            }
        }

        public static List<string> getListaTablasBaseDatos(string nombreServidor, string baseDatos, string nombreUsuario, string contrasena, ref string error)
        {
            string cadenaConeccion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", nombreServidor, baseDatos, nombreUsuario, contrasena);
            List<string> listaTablas = new List<string>();
            using (SqlConnection con = new SqlConnection(cadenaConeccion))
            {
                try
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand(string.Format("select name from  {0}.sys.objects where type = 'u' order by name", baseDatos), con);
                    SqlDataReader reader = comand.ExecuteReader();
                    while (reader.Read())
                    {
                        listaTablas.Add(reader["name"].ToString());
                    }
                    con.Close();

                    return listaTablas;
                }
                catch (Exception ex)
                {
                    error = "No se puede Realizar Conección con el servidor de Base datos " + ex.Message;
                    return new List<string>();
                }
            }
        }

        internal static List<DatosColumna> getColumnasTablaBaseDato(string nombreServidor, string baseDatos, string nombreUsuario, string contrasena, string tabla, ref string error)
        {
            string cadenaConeccion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", nombreServidor, baseDatos, nombreUsuario, contrasena);
            List<DatosColumna> listaDatosColumna = new List<DatosColumna>();
            using (SqlConnection con = new SqlConnection(cadenaConeccion))
            {
                try
                {
                    con.Open();
                    SqlCommand comand = new SqlCommand(string.Format("select syscolumns.name AS nombreColumna , systypes.name AS tipoDatoColumna , syscolumns.isnullable  as esNulable , syscolumns.prec ,  syscolumns.xscale FROM     {0}.dbo.syscolumns INNER JOIN {0}.dbo.sysobjects ON syscolumns.id = sysobjects.id INNER JOIN {0}.dbo.systypes ON systypes.xtype = syscolumns.xtype where  sysobjects.name = '{1}'", baseDatos, tabla), con);
                    SqlDataReader reader = comand.ExecuteReader();
                    while (reader.Read())
                    {
                        DatosColumna dtC = new DatosColumna();
                        dtC.nombreColumna = reader["nombreColumna"].ToString();
                        dtC.tipoDatoColumna = reader["tipoDatoColumna"].ToString();
                        dtC.esNulable = reader["esNulable"].ToString();
                        dtC.prec = int.Parse(reader["prec"].ToString());
                        dtC.xscale = int.Parse( reader["xscale"].ToString());
                        listaDatosColumna.Add(dtC);
                    }
                    con.Close();

                    return listaDatosColumna;
                }
                catch (Exception ex)
                {
                    error = "No se puede Realizar Conección con el servidor de Base datos " + ex.Message;
                    return new List<DatosColumna>();
                }
            }
        }
    }
}
