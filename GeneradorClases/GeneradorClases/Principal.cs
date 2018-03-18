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
    public partial class Principal : Form
    {
        private int childFormNumber = 0;

        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmListadoAdministracionConecciones childForm = new frmListadoAdministracionConecciones();
            childForm.MdiParent = this;
            childForm.Text = "Administracion Conecciones " ;
            childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void generarCodigosFunetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneradorCodigos childForm = new frmGeneradorCodigos();
            childForm.MdiParent = this;
            childForm.Text = "Generador Codigos ";
            childFormNumber++;
            childForm.Show();
        }

        private void generarTrazabilidadYDesencadenadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneradorTrazabilidadDesencadenadores childForm = new frmGeneradorTrazabilidadDesencadenadores();
            childForm.MdiParent = this;
            childForm.Text = "Generador Trazabilidad y Desencadenadores ";
            childFormNumber++;
            childForm.Show();
        }

        private void generarSimpleFormYWebMethodBoosTrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneradorFronEndAndWebMethod childForm = new frmGeneradorFronEndAndWebMethod();
            childForm.MdiParent = this;
            childForm.Text = "Simple Form boosstrap y WebMethos";
            childFormNumber++;
            childForm.Show();
        }
    }
}
