//atributos del objecto personas
var personas = new Object();
function cargarDatos(personas) {
    $('#PanelIDPersonas').show();
    $('#txtIdPersonas').val(personas.id);
    $('#txtdocumentoIdentidadIdPersonas').val(personas.documentoIdentidadId);
    $('#txtmunicipioIdPersonas').val(personas.municipioId);
    $('#txtgrupoSanguineoIdPersonas').val(personas.grupoSanguineoId);
    $('#txtsexoIdPersonas').val(personas.sexoId);
    $('#txtmunicipioExpedicionIdPersonas').val(personas.municipioExpedicionId);
    $('#txtusuarioIdPersonas').val(personas.usuarioId);
    $('#txtbarrioIdPersonas').val(personas.barrioId);
    $('#txtestaturaPersonas').val(personas.estatura);
    $('#txtpesoPersonas').val(personas.peso);
    $('#txtestadoCivilIdPersonas').val(personas.estadoCivilId);
    $('#txttelefonoFijoPersonas').val(personas.telefonoFijo);
    $('#txttelefonoCelularPersonas').val(personas.telefonoCelular);
    $('#txtnumeroDocumentoPersonas').val(personas.numeroDocumento);
    $('#txtprimerNombrePersonas').val(personas.primerNombre);
    $('#txtsegundoNombrePersonas').val(personas.segundoNombre);
    $('#txtprimerApellidoPersonas').val(personas.primerApellido);
    $('#txtsegundoApellidoPersonas').val(personas.segundoApellido);
    $('#txtdirecccionPersonas').val(personas.direcccion);
    $('#txtcorreoPersonas').val(personas.correo);
}

function croosModalClick() {
    cargarListaPersonas();
}

function btnPersonas_NuevoClick() {
    loadUrlModal('Nueva Personas', 'frmPersonas_Nuevo.aspx', croosModalClick);
}

function btnPersonas_GuardarClick() {
    if (validarCampos()) {
        personas.id = 0;
        personas.documentoIdentidadId = $('#txtdocumentoIdentidadIdPersonas').val();
        personas.municipioId = $('#txtmunicipioIdPersonas').val();
        personas.grupoSanguineoId = $('#txtgrupoSanguineoIdPersonas').val();
        personas.sexoId = $('#txtsexoIdPersonas').val();
        personas.municipioExpedicionId = $('#txtmunicipioExpedicionIdPersonas').val();
        personas.usuarioId = getLocalStorageNavegator("usuarioId");
        personas.barrioId = $('#txtbarrioIdPersonas').val();
        personas.estatura = $('#txtestaturaPersonas').val();
        personas.peso = $('#txtpesoPersonas').val();
        personas.estadoCivilId = $('#txtestadoCivilIdPersonas').val();
        personas.telefonoFijo = $('#txttelefonoFijoPersonas').val();
        personas.telefonoCelular = $('#txttelefonoCelularPersonas').val();
        personas.numeroDocumento = $('#txtnumeroDocumentoPersonas').val();
        personas.primerNombre = $('#txtprimerNombrePersonas').val();
        personas.segundoNombre = $('#txtsegundoNombrePersonas').val();
        personas.primerApellido = $('#txtprimerApellidoPersonas').val();
        personas.segundoApellido = $('#txtsegundoApellidoPersonas').val();
        personas.direcccion = $('#txtdirecccionPersonas').val();
        personas.correo = $('#txtcorreoPersonas').val();
        var url = "/WebMethods/personas.aspx/guardar";
        enviarComoParametros(url, personas, OnSuccesSavePersonas);
    }
}

function btnPersonas_EditarClick() {
    if (validarCampos()) {
        personas.id = $('#txtIdPersonas').val();
        personas.documentoIdentidadId = $('#txtdocumentoIdentidadIdPersonas').val();
        personas.municipioId = $('#txtmunicipioIdPersonas').val();
        personas.grupoSanguineoId = $('#txtgrupoSanguineoIdPersonas').val();
        personas.sexoId = $('#txtsexoIdPersonas').val();
        personas.municipioExpedicionId = $('#txtmunicipioExpedicionIdPersonas').val();
        personas.usuarioId = getLocalStorageNavegator("usuarioId");
        personas.barrioId = $('#txtbarrioIdPersonas').val();
        personas.estatura = $('#txtestaturaPersonas').val();
        personas.peso = $('#txtpesoPersonas').val();
        personas.estadoCivilId = $('#txtestadoCivilIdPersonas').val();
        personas.telefonoFijo = $('#txttelefonoFijoPersonas').val();
        personas.telefonoCelular = $('#txttelefonoCelularPersonas').val();
        personas.numeroDocumento = $('#txtnumeroDocumentoPersonas').val();
        personas.primerNombre = $('#txtprimerNombrePersonas').val();
        personas.segundoNombre = $('#txtsegundoNombrePersonas').val();
        personas.primerApellido = $('#txtprimerApellidoPersonas').val();
        personas.segundoApellido = $('#txtsegundoApellidoPersonas').val();
        personas.direcccion = $('#txtdirecccionPersonas').val();
        personas.correo = $('#txtcorreoPersonas').val();
        var url = "/WebMethods/personas.aspx/guardar";
        enviarComoParametros(url, personas, OnSuccesSavePersonas);
    }
}

function OnSuccesSavePersonas(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessagesCrud");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Guardado con exito', 'success', "#boxMessagesCrud");
        return;
    }
}

function btnPersonas_Editar(id) {
    loadUrlModal('Editar Personas', ('frmPersonas_Editar.aspx?id=' + id), croosModalClick);
}

function btnPersonas_Eliminar(id) {
    // get txn id from current table row
    var heading = 'Eliminar Registro';
    var question = '¿Desea eliminar el registro?.';
    var cancelButtonTxt = 'No';
    var okButtonTxt = 'Yes';
    var callback = function () {
        personas.id = id;
        personas.usuarioId = getLocalStorageNavegator("usuarioId");
        var url = "/WebMethods/personas.aspx/eliminar";
        enviarComoParametros(url, personas, OnSuccesDeletePersonas);
    }
    confirm(heading, question, cancelButtonTxt, okButtonTxt, callback);
}

function OnSuccesDeletePersonas(response) {
    if ((response.error == null ? "" : response.error) != "") {
        tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
        return;
    }
    if (response.error == '') {
        tipoAlerta('Registro Eliminado con Exito.', 'success', "#boxMessages");
        cargarListaPersonas();
        return;
    }
}

function getListaPersonas(registroPartida, totalAExtraer, callbackFucntion) {
    personas.registroPartida = registroPartida;
    personas.totalAExtraer = totalAExtraer;
    personas.usuarioId = getLocalStorageNavegator("usuarioId");
    var url = "/WebMethods/personas.aspx/getListaPersonas";
    enviarComoParametros(url, personas, callbackFucntion);
}
function validarCampos() {

    if ($('#txtIdpersonas').val() == 0) {
        tipoAlerta('El campo id no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdocumentoIdentidadIdPersonas').val() == 0) {
        tipoAlerta('El campo documentoIdentidadId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtmunicipioIdPersonas').val() == 0) {
        tipoAlerta('El campo municipioId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtgrupoSanguineoIdPersonas').val() == 0) {
        tipoAlerta('El campo grupoSanguineoId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtsexoIdPersonas').val() == 0) {
        tipoAlerta('El campo sexoId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtmunicipioExpedicionIdPersonas').val() == 0) {
        tipoAlerta('El campo municipioExpedicionId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtbarrioIdPersonas').val() == 0) {
        tipoAlerta('El campo barrioId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtestaturaPersonas').val() == 0) {
        tipoAlerta('El campo estatura no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtpesoPersonas').val() == 0) {
        tipoAlerta('El campo peso no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtestadoCivilIdPersonas').val() == 0) {
        tipoAlerta('El campo estadoCivilId no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txttelefonoFijoPersonas').val() == 0) {
        tipoAlerta('El campo telefonoFijo no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txttelefonoCelularPersonas').val() == 0) {
        tipoAlerta('El campo telefonoCelular no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtnumeroDocumentoPersonas').val() == 0) {
        tipoAlerta('El campo numeroDocumento no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtprimerNombrePersonas').val() == 0) {
        tipoAlerta('El campo primerNombre no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtsegundoNombrePersonas').val() == 0) {
        tipoAlerta('El campo segundoNombre no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtprimerApellidoPersonas').val() == 0) {
        tipoAlerta('El campo primerApellido no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtsegundoApellidoPersonas').val() == 0) {
        tipoAlerta('El campo segundoApellido no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtdirecccionPersonas').val() == 0) {
        tipoAlerta('El campo direcccion no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };

    if ($('#txtcorreoPersonas').val() == 0) {
        tipoAlerta('El campo correo no puede ir vacío.', 'warning', "#boxMessagesCrud");
        return false;
    };
    return true;
}

function cargarListaPersonas() {
    table = $('#gridListaPersonas');

    if ($.fn.dataTable.isDataTable(table)) {
        table.DataTable();
    }

    table.DataTable(
    {
        serverSide: true,
        ordering: false,
        searching: false,
        processing: true,
        destroy: true,
        language: {
            "processing": "Actualizando Datos"
        },
        ajax: function (data, callback, settings) {
            var out = [];
            var lstPersonas;
            var totalRegistros = 0;
            var totalRegistrosFiltrados = 0;

            getListaPersonas(data.start, data.length, function (response) {
                if ((response.error == null ? "" : response.error) != "") {
                    tipoAlerta(response.error, response.tipoAlerta, "#boxMessages");
                    return;
                }

                if (response.error == '') {
                    lstPersonas = eval("(" + response.getCadena + ")");
                    totalRegistros = response.totalRegistros;
                    totalRegistrosFiltrados = response.totalRegistrosFiltrados;
                    for (var i = 0; i < lstPersonas.length; i++) {
                        var etiquetaEditar = "<a onclick='btnPersonas_Editar(" + lstPersonas[i].id + ")'  class='fa fa-edit'><a>";
                        var etiquetaEliminar = " <a class='fa fa-minus' onclick='btnPersonas_Eliminar(" + lstPersonas[i].id + ")'><a>";
                        out.push([etiquetaEditar + etiquetaEliminar, lstPersonas[i].nombre, lstPersonas[i].descripcion]);
                    }

                    setTimeout(callback(
                    {
                        draw: data.draw,
                        data: out,
                        recordsTotal: totalRegistros,
                        recordsFiltered: totalRegistros
                    }), 50);
                }
            });
        }
    });
}
