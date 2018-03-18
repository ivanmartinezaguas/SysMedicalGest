using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorClases.Entity.Controller
{
    public class vSysDataBaseController
    {

        public static List<vSysDataBaseViewModel> getListConeccionesServidor()
        {
            using (MapWorldSystemEntities entity = new MapWorldSystemEntities())
            {
                var listVBaseDatos = from l in entity.vSysDataBase select new vSysDataBaseViewModel() { database_id =  l.database_id , create_date = l.create_date, name = l.name};
                return listVBaseDatos.ToList();
            }
        }

    }
}
