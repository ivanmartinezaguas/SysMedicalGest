using GeneradorClases.Entity.Controller;
using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorClases
{
    public partial class frmAdministracionConeccion_Nuevo : Form
    {
        public frmAdministracionConeccion_Nuevo()
        {
            InitializeComponent();
            administracionConeccion1.getTxtNombreServidor().Leave += txtNombreServidor_Leave;
        }

        private void frmAdministracionConeccion_Nuevo_Load(object sender, EventArgs e)
        {

        }

        private void txtNombreServidor_Leave(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                List<vSysDataBaseViewModel> listBaseDatos = MetodosGeneralesController.getListaBaseDatos(administracionConeccion1.getTxtNombreServidor().Text, administracionConeccion1.getTxtUsuarioConeccion().Text, administracionConeccion1.getTxtContrasenaConeccion().Text, ref error);
                administracionConeccion1.getCmbBaseDatos().DataSource = listBaseDatos;
                administracionConeccion1.getCmbBaseDatos().ValueMember = "database_id";
                administracionConeccion1.getCmbBaseDatos().DisplayMember = "name";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (administracionConeccion1.getTxtNombreConeccion().Text == "")
            {
                MessageBox.Show("Digite el nombre de la conección.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (administracionConeccion1.getTxtUsuarioConeccion().Text == "")
            {
                MessageBox.Show("Digite el usuario de la conección.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (administracionConeccion1.getTxtContrasenaConeccion().Text == "")
            {
                MessageBox.Show("Digite la contraseña del usuario.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (administracionConeccion1.getTxtNombreServidor().Text == "")
            {
                MessageBox.Show("Digite el nombre del servidor.", "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            
            ConecionServidores model = new ConecionServidores();
            model.id = 0;
            model.nombreConeccion = administracionConeccion1.getTxtNombreConeccion().Text;
            model.usuario = administracionConeccion1.getTxtUsuarioConeccion().Text;
            model.contrasena = administracionConeccion1.getTxtContrasenaConeccion().Text;
            model.servidor = administracionConeccion1.getTxtNombreServidor().Text;
            model.baseDatos = (administracionConeccion1.getCmbBaseDatos().SelectedItem as vSysDataBaseViewModel).name;
            string error = "";
            ConecionServidorController.guardar(model, ref error);

            if (error != "") 
            {
                MessageBox.Show(error, "Administracion de Conecciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
