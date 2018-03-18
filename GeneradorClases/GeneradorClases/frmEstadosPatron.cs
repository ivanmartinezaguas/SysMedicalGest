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
    public partial class frmEstadosPatron : Form
    {
        List<string> listadoEstados = null;
        public frmEstadosPatron(ref List<string> listadoEstados)
        {
            InitializeComponent();
            this.listadoEstados = listadoEstados;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!listadoEstados.Contains(txtEstado.Text))
            {
                listBoxEstados.Items.Add(txtEstado.Text);
                listadoEstados.Add(txtEstado.Text);
            }
        }
    }
}
