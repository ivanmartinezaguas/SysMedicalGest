using GeneradorClases.Entity.Controller;
using GeneradorClases.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorClases
{
    public partial class frmGeneradorCodigos : Form
    {
        List<string> listaEstados = new List<string>();
        List<string> listaOperacionesPatron = new List<string>();
        public frmGeneradorCodigos()
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
            foreach (string item in listOpciones.CheckedItems)
            {
                if (item == "ClasesViewModel")
                {
                    GeneradorClasesViewModel.generarClasesViewModel(txtNombreProyeco.Text, txtNombreEntidad.Text, cmbTabla.SelectedItem.ToString(), (dtColumnas.DataSource as List<DatosColumna>), txtDirectorioDestino.Text, ref error);
                }

                if (item == "Controlador Sin CRUD")
                {
                    generarControladoresSinCRUD.generarClasesController(txtNombreProyeco.Text, txtNombreEntidad.Text, cmbTabla.SelectedItem.ToString(), (dtColumnas.DataSource as List<DatosColumna>), txtDirectorioDestino.Text, ref error);
                }

                if (item == "Controlador Con CRUD")
                {
                    GenerarControladoresConCRUD.generarClasesController(txtNombreProyeco.Text, txtNombreEntidad.Text, cmbTabla.SelectedItem.ToString(), (dtColumnas.DataSource as List<DatosColumna>), txtDirectorioDestino.Text, ref error);
                }

                if (item == "PatterState")
                {
                    if (listaEstados.Count < 1)
                    {
                        MessageBox.Show("Defina los estados que puede tener el patron.");
                        return;
                    }
                    GenerarClasesPatterState.generarClases(txtNombreProyeco.Text, txtNombreEntidad.Text, cmbTabla.SelectedItem.ToString(), (dtColumnas.DataSource as List<DatosColumna>), txtDirectorioDestino.Text, listaEstados, listaOperacionesPatron, ref error); ;
                }
            }

            MessageBox.Show("Proceso de Generación Completado.");
        }

        private void btnEstados_Click(object sender, EventArgs e)
        {
            foreach (string item in listOpciones.CheckedItems)
            {
                if (item == "PatterState")
                {
                    frmEstadosPatron frmEstados = new frmEstadosPatron(ref listaEstados);
                    DialogResult res = frmEstados.ShowDialog();
                }
            }
        }

        private void cmbConecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConecionServidorViewModel model = (cmbConecciones.SelectedItem as ConecionServidorViewModel);
            string error = "";
            cmbTabla.DataSource = MetodosGeneralesController.getListaTablasBaseDatos(model.servidor, model.baseDatos, model.usuario, model.contrasena, ref error);
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
            ConecionServidorViewModel model = (cmbConecciones.SelectedItem as ConecionServidorViewModel);
            string error = "";
            dtColumnas.DataSource = MetodosGeneralesController.getColumnasTablaBaseDato(model.servidor, model.baseDatos, model.usuario, model.contrasena, cmbTabla.SelectedItem.ToString(), ref error);

        }

        private void btnOperacionesPatronState_Click(object sender, EventArgs e)
        {
            foreach (string item in listOpciones.CheckedItems)
            {
                if (item == "PatterState")
                {
                    frmEstadosPatron frmEstados = new frmEstadosPatron(ref listaOperacionesPatron);
                    frmEstados.Text = "Operaciones del Patron";
                    DialogResult res = frmEstados.ShowDialog();
                }
            }
        }
        private void frmGeneradorCodigos_Load(object sender, EventArgs e)
        {

        }
    }
}