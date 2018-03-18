using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class PersonasController
    {
        MoldeEntities entity = new MoldeEntities();

        public MoldeEntities getEntity()
        {
            return entity;
        }
        public List<PersonasViewModel> getListaPersonas()
        {

            var l = from personas in entity.Personas
                    select new PersonasViewModel { fechaNacimiento = personas.fechaNacimiento, fechaExpedicionCedula = personas.fechaExpedicionCedula, id = personas.id, documentoIdentidadId = personas.documentoIdentidadId, municipioId = personas.municipioId, grupoSanguineoId = personas.grupoSanguineoId, sexoId = personas.sexoId, municipioExpedicionId = personas.municipioExpedicionId, usuarioId = personas.usuarioId, barrioId = personas.barrioId, estatura = personas.estatura, peso = personas.peso, estadoCivilId = personas.estadoCivilId, telefonoFijo = personas.telefonoFijo, telefonoCelular = personas.telefonoCelular, numeroDocumento = personas.numeroDocumento, primerNombre = personas.primerNombre, segundoNombre = personas.segundoNombre, primerApellido = personas.primerApellido, segundoApellido = personas.segundoApellido, direcccion = personas.direcccion, correo = personas.correo };
            return l.ToList();

        }

        public static PersonasViewModel getPersonas()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from personas in entity.Personas
                        select new PersonasViewModel { fechaNacimiento = personas.fechaNacimiento, fechaExpedicionCedula = personas.fechaExpedicionCedula, id = personas.id, documentoIdentidadId = personas.documentoIdentidadId, municipioId = personas.municipioId, grupoSanguineoId = personas.grupoSanguineoId, sexoId = personas.sexoId, municipioExpedicionId = personas.municipioExpedicionId, usuarioId = personas.usuarioId, barrioId = personas.barrioId, estatura = personas.estatura, peso = personas.peso, estadoCivilId = personas.estadoCivilId, telefonoFijo = personas.telefonoFijo, telefonoCelular = personas.telefonoCelular, numeroDocumento = personas.numeroDocumento, primerNombre = personas.primerNombre, segundoNombre = personas.segundoNombre, primerApellido = personas.primerApellido, segundoApellido = personas.segundoApellido, direcccion = personas.direcccion, correo = personas.correo };
                return l.SingleOrDefault();
            }
        }

        public Result guardarPersonas(Personas registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }


            if (existeRegistro(registro.id))
            {
                result = ValidateSession.validarOperacionesForm("Personas", "Editar", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                int personasId = registro.id;
                Personas registroEditar = entity.Personas.Where(x => x.id == personasId).SingleOrDefault();
                entity.Entry(registroEditar).CurrentValues.SetValues(registro);
                try
                {
                    entity.SaveChanges();
                    return new Result { error = "" };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }
            else
            {
                result = ValidateSession.validarOperacionesForm("Personas", "Nuevo", registro.usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                entity.Personas.Add(registro);
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = registro.id };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }
            }

        }

        private Result validarAtributos(Personas registro)
        {
            return new Result() { error = "" };
        }
        public bool existeRegistro(int personasId)
        {
            if (entity.Personas.Where(x => x.id == personasId).Count() > 0)
                return true;
            return false;

        }
        public Result eliminarPersonas(int personasId, int usuarioId)
        {

            if (existeRegistro(personasId))
            {
                Result result = new Result() { error = "" };
                result = ValidateSession.validarOperacionesForm("Personas", "Eliminar", usuarioId);
                if (result.error != null && result.error != "")
                {
                    return result;
                }
                Personas registroEliminar = entity.Personas.Where(x => x.id == personasId).SingleOrDefault();
                entity.Personas.Remove(registroEliminar);
                MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Personas", "Eliminado", usuarioId, "AplicacionMolde");
                try
                {
                    entity.SaveChanges();
                    return new Result { error = result.error, id = personasId };
                }
                catch (Exception e)
                {
                    return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                }

            }
            return new Result { error = "" };
        }
    }
}
