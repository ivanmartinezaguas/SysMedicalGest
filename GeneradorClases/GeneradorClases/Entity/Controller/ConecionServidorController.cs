using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class ConecionServidorController
    {
        public static List<ConecionServidorViewModel> getListConeccionesServidor()
        {
            using (MapWorldSystemEntities entity = new MapWorldSystemEntities()) 
            {
                var listConeccionServidor = from l in entity.ConecionServidores select new ConecionServidorViewModel(){ id = l.id, baseDatos = l.baseDatos , contrasena = l.contrasena, nombreConeccion = l.nombreConeccion, servidor = l.servidor , usuario = l.usuario};
                return listConeccionServidor.ToList();
            }
        }

        public static void eliminarConeccion(int id)
        {
            using (MapWorldSystemEntities entity = new MapWorldSystemEntities())
            {
                entity.Entry(entity.ConecionServidores.First(x => x.id == id)).State = System.Data.Entity.EntityState.Deleted;
                entity.SaveChanges();
            }
        }

        public static ConecionServidorViewModel getConeccionServidor(int id)
        {
            using (MapWorldSystemEntities entity = new MapWorldSystemEntities())
            {
                var listConeccionServidor = from l in entity.ConecionServidores where l.id == id select new ConecionServidorViewModel() { id = l.id, baseDatos = l.baseDatos, contrasena = l.contrasena, nombreConeccion = l.nombreConeccion, servidor = l.servidor, usuario = l.usuario };
                return listConeccionServidor.FirstOrDefault();
            }
        }


        public static void guardar(ConecionServidores model, ref string error)
        {
            using (MapWorldSystemEntities entity = new MapWorldSystemEntities())
            {
                entity.ConecionServidores.Add(model);
                try
                {
                    entity.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
                
            }
        }


        internal static void Actualizar(ConecionServidores model, ref string error)
        {
            using (MapWorldSystemEntities entity = new MapWorldSystemEntities())
            {   
                entity.Entry(model).State = System.Data.Entity.EntityState.Modified;

                try
                {
                    entity.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

            }
        }
    }
}
