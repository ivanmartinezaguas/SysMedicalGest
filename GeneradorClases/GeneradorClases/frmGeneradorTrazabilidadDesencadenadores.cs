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
    public partial class frmGeneradorTrazabilidadDesencadenadores : Form
    {
        public frmGeneradorTrazabilidadDesencadenadores()
        {
            InitializeComponent();
            cargarConecciones();
        }

        private void cargarConecciones()
        {
            cmbConecciones.DataSource = ConecionServidorController.getListConeccionesServidor();
            cmbConecciones.ValueMember = "id";
            cmbConecciones.DisplayMember = "nombreConeccion";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string error = "";
            ConecionServidorViewModel model = (cmbConecciones.SelectedItem as ConecionServidorViewModel);
            List<string> listTablas = MetodosGeneralesController.getListaTablasBaseDatos(model.servidor, model.baseDatos, model.usuario, model.contrasena, ref error);
            foreach (string item in listOpciones.CheckedItems)
            {   
                if (item == "GenerarTablas")
                {
                    if (cmbTabla.SelectedItem.ToString() == "Todos los Elementos")
                    {
                        foreach (string nombreTabla in listTablas)
                        {
                            List<DatosColumna> listCol = MetodosGeneralesController.getColumnasTablaBaseDato(model.servidor, model.baseDatos, model.usuario, model.contrasena, nombreTabla, ref error);
                            GenerarTrazabilidad.generarTrazabilidad(nombreTabla, listCol, txtDirectorioDestino.Text, ref error);
                        }
                    }
                    else 
                    {
                        List<DatosColumna> listCol = MetodosGeneralesController.getColumnasTablaBaseDato(model.servidor, model.baseDatos, model.usuario, model.contrasena, cmbTabla.SelectedItem.ToString(), ref error);
                        GenerarTrazabilidad.generarTrazabilidad(cmbTabla.SelectedItem.ToString(), listCol, txtDirectorioDestino.Text, ref error);
                    }
                }

                if (item == "GenerarDesencadenadores")
                {
                    if (cmbTabla.SelectedItem.ToString() == "Todos los Elementos")
                    {
                        foreach (string nombreTabla in listTablas)
                        {
                            List<DatosColumna> listCol = MetodosGeneralesController.getColumnasTablaBaseDato(model.servidor, model.baseDatos, model.usuario, model.contrasena, nombreTabla, ref error);
                            GenerarTrazabilidad.generarDesencadenadoresInsert(nombreTabla, listCol, txtDirectorioDestino.Text, ref error);
                            GenerarTrazabilidad.generarDesencadenadoresUpdate(nombreTabla, listCol, txtDirectorioDestino.Text, ref error);
                            GenerarTrazabilidad.generarDesencadenadoresDelete(nombreTabla, listCol, txtDirectorioDestino.Text, ref error);
                        }
                    }
                    else
                    {
                        List<DatosColumna> listCol = MetodosGeneralesController.getColumnasTablaBaseDato(model.servidor, model.baseDatos, model.usuario, model.contrasena, cmbTabla.SelectedItem.ToString(), ref error);
                        GenerarTrazabilidad.generarDesencadenadoresInsert(cmbTabla.SelectedItem.ToString(), listCol, txtDirectorioDestino.Text, ref error);
                        GenerarTrazabilidad.generarDesencadenadoresUpdate(cmbTabla.SelectedItem.ToString(), listCol, txtDirectorioDestino.Text, ref error);
                        GenerarTrazabilidad.generarDesencadenadoresDelete(cmbTabla.SelectedItem.ToString(), listCol, txtDirectorioDestino.Text, ref error);
                    }
                }
            }

            MessageBox.Show("Proceso de Generación Completado.");
        }

        private void cmbConecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConecionServidorViewModel model = (cmbConecciones.SelectedItem as ConecionServidorViewModel);
            string error = "";            
            List<string> listTablas = MetodosGeneralesController.getListaTablasBaseDatos(model.servidor, model.baseDatos, model.usuario, model.contrasena, ref error);
            listTablas.Add("Todos los Elementos");
            cmbTabla.DataSource = listTablas;
        }

        private void btnCambiarDirectorio_Click(object sender, EventArgs e)
        {
            DialogResult result = fDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fDialog.SelectedPath))
            {
                txtDirectorioDestino.Text = fDialog.SelectedPath;
            }
        }

        private void cmbTabla_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
