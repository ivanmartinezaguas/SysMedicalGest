using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlUsuarios.Entity.Model;
using System.Threading.Tasks;

namespace ControlUsuarios.Entity.Controller
{
    public class DoctoresController
    {
        MoldeEntities entity = new MoldeEntities();


        public MoldeEntities getEntity()
        {
            return entity;
        }


        public List<DoctoresViewModel> getListaDoctores(string valorBuscado)
        {
            switch (valorBuscado)
            {
                case "":
                    var l = from doctores in entity.Doctores
                            select new DoctoresViewModel
                            {
                                id = doctores.id,
                                idPersonas = doctores.idPersonas,
                                usuarioId = doctores.usuarioId,
                                telefonoCorporacion = doctores.telefonoCorporacion,
                                registroUnico = doctores.registroUnico,
                                especialidad = doctores.especialidad,
                                direccionLaboral = doctores.direccionLaboral
                            };

                    return l.ToList();
                    break;

                default:  var lu = from doctores in entity.Doctores
                                   where doctores.Personas.primerNombre.Contains(valorBuscado)||doctores.Personas.segundoNombre.Contains(valorBuscado)
                                  select new DoctoresViewModel
                                  {
                                      id = doctores.id,
                                      idPersonas = doctores.idPersonas,
                                      usuarioId = doctores.usuarioId,
                                      telefonoCorporacion = doctores.telefonoCorporacion,
                                      registroUnico = doctores.registroUnico,
                                      especialidad = doctores.especialidad,
                                      direccionLaboral = doctores.direccionLaboral
                                  };


                      return lu.ToList();
                    break;
            }

        }

        public  DoctoresViewModel getDoctores()
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                var l = from doctores in entity.Doctores
                        select new DoctoresViewModel { id = doctores.id, idPersonas = doctores.idPersonas, usuarioId = doctores.usuarioId, telefonoCorporacion = doctores.telefonoCorporacion, registroUnico = doctores.registroUnico, especialidad = doctores.especialidad, direccionLaboral = doctores.direccionLaboral };
                return l.SingleOrDefault();
            }
        }

        public static Result guardarDoctores(Doctores registro)
        {
            Result result = new Result() { error = "" };
            result = validarAtributos(registro);
            if (result.error != null && result.error != "")
            {
                return result;
            }

            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(registro.id))
                {
                    result = ValidateSession.validarOperacionesForm("Doctores", "Editar", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    int doctoresId = registro.id;
                    Doctores registroEditar = entity.Doctores.Where(x => x.id == doctoresId).SingleOrDefault();
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
                    result = ValidateSession.validarOperacionesForm("Doctores", "Nuevo", registro.usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    entity.Doctores.Add(registro);
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
        }

        private static Result validarAtributos(Doctores registro)
        {
            if (registro.id == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.idPersonas == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.usuarioId == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.telefonoCorporacion == 0)
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.registroUnico == "")
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.especialidad == "")
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            if (registro.direccionLaboral == "")
            {
                return new Result { error = "Texto Validación", tipoAlerta = "warning" };
            }
            return new Result() { error = "" };
        }
        public static bool existeRegistro(int doctoresId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (entity.Doctores.Where(x => x.id == doctoresId).Count() > 0)
                    return true;
                return false;
            }
        }
        public static Result eliminarDoctores(int doctoresId, int usuarioId)
        {
            using (MoldeEntities entity = new MoldeEntities())
            {
                if (existeRegistro(doctoresId))
                {
                    Result result = new Result() { error = "" };
                    result = ValidateSession.validarOperacionesForm("Doctores", "Eliminar", usuarioId);
                    if (result.error != null && result.error != "")
                    {
                        return result;
                    }
                    Doctores registroEliminar = entity.Doctores.Where(x => x.id == doctoresId).SingleOrDefault();
                    entity.Doctores.Remove(registroEliminar);
                    MoldeTrasabilidad.trasabilidadObject((registroEliminar as object), "Doctores", "Eliminado", usuarioId, "AplicacionMolde");
                    try
                    {
                        entity.SaveChanges();
                        return new Result { error = result.error, id = doctoresId };
                    }
                    catch (Exception e)
                    {
                        return new Result { error = e.Message, id = 0, tipoAlerta = "warning" };
                    }
                }
            }
            return new Result { error = "" };
        }
    }
}
