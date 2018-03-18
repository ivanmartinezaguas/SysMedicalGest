using GeneradorClases.Entity.Controller;
using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorClases
{
    public partial class frmAdministracionConeccion_Editar : Form
    {
        int idRegistro = 0;
        public frmAdministracionConeccion_Editar(int idRegistro)
        {
            InitializeComponent();
            administracionConeccion2.getTxtNombreServidor().Leave += txtNombreServidor_Leave;
            this.idRegistro = idRegistro;
            cargarDatos();
        }

        private void cargarBasedatos()
        {
            string error = "";
            try
            {
                List<vSysDataBaseViewModel> listBaseDatos = MetodosGeneralesController.getListaBaseDatos(administracionConeccion2.getTxtNombreServidor().Text, administracionConeccion2.getTxtUsuarioConeccion().Text, administracionConeccion2.getTxtContrasenaConeccion().Text, ref error);
                administracionConeccion2.getCmbBaseDatos().DataSource = listBaseDatos;
                administracionConeccion2.getCmbBaseDatos().ValueMember = "database_id";
                administracionConeccion2.getCmbBaseDatos().DisplayMember = "name";
                if (error != "")
                {
                    MessageBox.Show(error, "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show(error, "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDatos()
        {
            ConecionServidorViewModel model = ConecionServidorController.getConeccionServidor(idRegistro);

            administracionConeccion2.getTxtNombreConeccion().Text = model.nombreConeccion;

            administracionConeccion2.getTxtUsuarioConeccion().Text = model.usuario;

            administracionConeccion2.getTxtContrasenaConeccion().Text = model.contrasena;

            administracionConeccion2.getTxtNombreServidor().Text = model.servidor;

            cargarBasedatos();

            foreach (vSysDataBaseViewModel item in administracionConeccion2.getCmbBaseDatos().Items)
            {
                if(item.name.ToLower() == model.baseDatos.ToLower())
                {
                    administracionConeccion2.getCmbBaseDatos().SelectedItem = item;
                }
            }
        }

        private void txtNombreServidor_Leave(object sender, EventArgs e)
        {

            cargarBasedatos();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (administracionConeccion2.getTxtNombreConeccion().Text == "")
            {
                MessageBox.Show("Digite el nombre de la conección.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (administracionConeccion2.getTxtUsuarioConeccion().Text == "")
            {
                MessageBox.Show("Digite el usuario de la conección.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (administracionConeccion2.getTxtContrasenaConeccion().Text == "")
            {
                MessageBox.Show("Digite la contraseña del usuario.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (administracionConeccion2.getTxtNombreServidor().Text == "")
            {
                MessageBox.Show("Digite el nombre del servidor.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            ConecionServidores model = new ConecionServidores();
            model.id = idRegistro ;
            model.nombreConeccion = administracionConeccion2.getTxtNombreConeccion().Text;
            model.usuario = administracionConeccion2.getTxtUsuarioConeccion().Text;
            model.contrasena = administracionConeccion2.getTxtContrasenaConeccion().Text;
            model.servidor = administracionConeccion2.getTxtNombreServidor().Text;
            model.baseDatos = (administracionConeccion2.getCmbBaseDatos().SelectedItem as vSysDataBaseViewModel).name ;
            string error = "";
            ConecionServidorController.Actualizar(model, ref error);

            if (error != "")
            {
                MessageBox.Show(error, "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
