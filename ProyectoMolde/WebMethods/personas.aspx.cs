using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Threading.Tasks;
using ControlUsuarios.Entity.Model;
using ControlUsuarios.Entity.Controller;
using System.Web;

namespace ProyectoMolde.WebMethods
{
    public partial class personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Result getListaPersonas(int registroPartida, int totalAExtraer, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            int totalRegistros = 0;
            List<PersonasViewModel> lst = new List<PersonasViewModel>();
            try
            {
                PersonasController pc = new PersonasController();
                lst = pc.getListaPersonas();
                totalRegistros = lst.Count();
                totalAExtraer = (lst.Count() - registroPartida) < totalAExtraer ? (lst.Count() - registroPartida) : totalAExtraer;
            }
            catch (Exception e)
            {
                return new Result() { error = e.Message, id = 0, tipoAlerta = "warning" };
            }
            return new Result() { error = "", getCadena = new JavaScriptSerializer().Serialize(lst.GetRange(registroPartida, totalAExtraer)), totalRegistros = totalRegistros };
        }

        [WebMethod(EnableSession = true)]
        public static Result guardar(int id, int documentoIdentidadId, int municipioId, int grupoSanguineoId, int sexoId, int municipioExpedicionId, int? barrioId, int estadoCivilId, int usuarioId, decimal estatura, decimal peso, long telefonoFijo, long telefonoCelular, string numeroDocumento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direcccion, string correo, DateTime fechaNacimiento, DateTime fechaExpedicionCedula)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }
            Personas objEntity = new Personas();
            objEntity.fechaNacimiento = fechaNacimiento;
            objEntity.fechaExpedicionCedula = fechaExpedicionCedula;
            objEntity.id = id;
            objEntity.documentoIdentidadId = documentoIdentidadId;
            objEntity.municipioId = municipioId;
            objEntity.grupoSanguineoId = grupoSanguineoId;
            objEntity.sexoId = sexoId;
            objEntity.municipioExpedicionId = municipioExpedicionId;
            objEntity.barrioId = barrioId;
            objEntity.estadoCivilId = estadoCivilId;
            objEntity.usuarioId = usuarioId;
            objEntity.estatura = estatura;
            objEntity.peso = peso;
            objEntity.telefonoFijo = telefonoFijo;
            objEntity.telefonoCelular = telefonoCelular;
            objEntity.numeroDocumento = numeroDocumento;
            objEntity.primerNombre = primerNombre;
            objEntity.segundoNombre = segundoNombre;
            objEntity.primerApellido = primerApellido;
            objEntity.segundoApellido = segundoApellido;
            objEntity.direcccion = direcccion;
            objEntity.correo = correo;
            try
            {
                PersonasController pc = new PersonasController();
                return pc.guardarPersonas(objEntity);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
        [WebMethod(EnableSession = true)]
        public static Result eliminar(int id, int usuarioId)
        {
            Result r = ValidateSession.validarSession(usuarioId, HttpContext.Current.Session["usuarioId"]);
            if (r.error != "")
            {
                return r;
            }

            try
            {
                PersonasController pc = new PersonasController();
                return pc.eliminarPersonas(id, usuarioId);
            }
            catch (Exception ex)
            {
                return new Result() { error = ex.Message, id = 0, tipoAlerta = "warning" };
            }
        }
    }
}
