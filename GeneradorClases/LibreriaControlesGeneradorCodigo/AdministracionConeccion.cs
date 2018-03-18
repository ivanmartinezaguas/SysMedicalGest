using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaControlesGeneradorCodigo
{
    public partial class AdministracionConeccion : UserControl
    {
     

        public AdministracionConeccion()
        {
            InitializeComponent();
        }

        public TextBox getTxtContrasenaConeccion()
        {
            return txtContrasenaConeccion;
        }

        public TextBox getTxtUsuarioConeccion()
        {
            return txtUsuarioConeccion;
        }

        public ComboBox getCmbBaseDatos()
        {
            return cmbBaseDatos;
        }

        public TextBox getTxtNombreServidor()
        {
            return txtNombreServidor;
        }

        public TextBox getTxtNombreConeccion()
        {
           return txtNombreConeccion;
        }

        public void txtNombreServidor_Leave(object sender, EventArgs e)
        {

        }
    }
}
