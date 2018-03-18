namespace GeneradorClases
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarCodigosFunetesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarTrazabilidadYDesencadenadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.generarCodigosFunetesToolStripMenuItem,
            this.generarTrazabilidadYDesencadenadoresToolStripMenuItem,
            this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(81, 20);
            this.fileMenu.Text = "&Administrar";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.newToolStripMenuItem.Text = "Administrar Conecciones";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // generarCodigosFunetesToolStripMenuItem
            // 
            this.generarCodigosFunetesToolStripMenuItem.Name = "generarCodigosFunetesToolStripMenuItem";
            this.generarCodigosFunetesToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.generarCodigosFunetesToolStripMenuItem.Text = "Generar Codigos Funetes";
            this.generarCodigosFunetesToolStripMenuItem.Click += new System.EventHandler(this.generarCodigosFunetesToolStripMenuItem_Click);
            // 
            // generarTrazabilidadYDesencadenadoresToolStripMenuItem
            // 
            this.generarTrazabilidadYDesencadenadoresToolStripMenuItem.Name = "generarTrazabilidadYDesencadenadoresToolStripMenuItem";
            this.generarTrazabilidadYDesencadenadoresToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.generarTrazabilidadYDesencadenadoresToolStripMenuItem.Text = "Generar Trazabilidad y Desencadenadores";
            this.generarTrazabilidadYDesencadenadoresToolStripMenuItem.Click += new System.EventHandler(this.generarTrazabilidadYDesencadenadoresToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // generarSimpleFormYWebMethodBoosTrapToolStripMenuItem
            // 
            this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem.Name = "generarSimpleFormYWebMethodBoosTrapToolStripMenuItem";
            this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem.Size = new System.Drawing.Size(316, 22);
            this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem.Text = "Generar Simple Form y WebMethod BoosTrap";
            this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem.Click += new System.EventHandler(this.generarSimpleFormYWebMethodBoosTrapToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem generarCodigosFunetesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarTrazabilidadYDesencadenadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarSimpleFormYWebMethodBoosTrapToolStripMenuItem;
    }
}



