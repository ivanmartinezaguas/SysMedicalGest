using GeneradorClases.Entity.Controller;
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
    public partial class frmListadoAdministracionConecciones : Form
    {
        public frmListadoAdministracionConecciones()
        {
            InitializeComponent();
            cargarListaConecciones();
        }

        private void cargarListaConecciones()
        {
            dtListaAdminConecciones.DataSource = ConecionServidorController.getListConeccionesServidor();
            dtListaAdminConecciones.Columns["id"].Visible = false;
            dtListaAdminConecciones.Columns["contrasena"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAdministracionConeccion_Nuevo childForm = new frmAdministracionConeccion_Nuevo();            
            childForm.Text = "Nueva Conección ";            
            DialogResult res = childForm.ShowDialog();
            if (DialogResult.Cancel == res)
            {
                cargarListaConecciones();
            }
        }

        private void dtListaAdminConecciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex > -1 && e.ColumnIndex == dtListaAdminConecciones.Columns["btnEditar"].Index)
            {
                object idRegisro = null;
                idRegisro = dtListaAdminConecciones.Rows[e.RowIndex].Cells["id"].Value;

                if (idRegisro != null)
                {
                    frmAdministracionConeccion_Editar childForm = new frmAdministracionConeccion_Editar(int.Parse(idRegisro.ToString()));
                    
                    childForm.Text = "Editar Conección ";
                    DialogResult res = childForm.ShowDialog();
                    if (DialogResult.Cancel == res)
                    {
                        cargarListaConecciones();
                    }
                }

            }

            if (e.RowIndex > -1 && e.ColumnIndex == dtListaAdminConecciones.Columns["btnEliminar"].Index)
            {
               DialogResult res = MessageBox.Show("Esta seguro que desea eliminar este registro.","Administración de Conecciones",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
               if (DialogResult.Yes == res)
               {
                   // Retrieve the Employee object from the "Assigned To" cell.
                   object idRegisro = null;
                   idRegisro = dtListaAdminConecciones.Rows[e.RowIndex].Cells["id"].Value;

                   //Invoca metodo para eliminar registro
                   if (idRegisro != null)
                       ConecionServidorController.eliminarConeccion(int.Parse(idRegisro.ToString()));

                   cargarListaConecciones();
               }
            }
        }
    }
}
