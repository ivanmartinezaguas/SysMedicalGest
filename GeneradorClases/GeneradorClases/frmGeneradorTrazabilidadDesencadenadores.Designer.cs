namespace GeneradorClases
{
    partial class frmGeneradorTrazabilidadDesencadenadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCambiarDirectorio = new System.Windows.Forms.Button();
            this.txtDirectorioDestino = new System.Windows.Forms.TextBox();
            this.lblDireccionDatos = new System.Windows.Forms.Label();
            this.listOpciones = new System.Windows.Forms.CheckedListBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cmbTabla = new System.Windows.Forms.ComboBox();
            this.lblTablas = new System.Windows.Forms.Label();
            this.cmbConecciones = new System.Windows.Forms.ComboBox();
            this.lblNombreConeccion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCambiarDirectorio
            // 
            this.btnCambiarDirectorio.Location = new System.Drawing.Point(374, 66);
            this.btnCambiarDirectorio.Name = "btnCambiarDirectorio";
            this.btnCambiarDirectorio.Size = new System.Drawing.Size(116, 23);
            this.btnCambiarDirectorio.TabIndex = 27;
            this.btnCambiarDirectorio.Text = "Cambiar Directorio";
            this.btnCambiarDirectorio.UseVisualStyleBackColor = true;
            this.btnCambiarDirectorio.Click += new System.EventHandler(this.btnCambiarDirectorio_Click);
            // 
            // txtDirectorioDestino
            // 
            this.txtDirectorioDestino.Location = new System.Drawing.Point(156, 68);
            this.txtDirectorioDestino.Name = "txtDirectorioDestino";
            this.txtDirectorioDestino.Size = new System.Drawing.Size(212, 20);
            this.txtDirectorioDestino.TabIndex = 26;
            this.txtDirectorioDestino.Text = "C:\\GeneradorClases";
            // 
            // lblDireccionDatos
            // 
            this.lblDireccionDatos.AutoSize = true;
            this.lblDireccionDatos.Location = new System.Drawing.Point(12, 69);
            this.lblDireccionDatos.Name = "lblDireccionDatos";
            this.lblDireccionDatos.Size = new System.Drawing.Size(105, 13);
            this.lblDireccionDatos.TabIndex = 25;
            this.lblDireccionDatos.Text = "Directorio a Guardar:";
            // 
            // listOpciones
            // 
            this.listOpciones.FormattingEnabled = true;
            this.listOpciones.Items.AddRange(new object[] {
            "GenerarTablas",
            "GenerarDesencadenadores"});
            this.listOpciones.Location = new System.Drawing.Point(15, 97);
            this.listOpciones.Name = "listOpciones";
            this.listOpciones.Size = new System.Drawing.Size(475, 244);
            this.listOpciones.TabIndex = 23;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(12, 347);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(478, 23);
            this.btnGenerar.TabIndex = 22;
            this.btnGenerar.Text = "Generar Documentos";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cmbTabla
            // 
            this.cmbTabla.FormattingEnabled = true;
            this.cmbTabla.Location = new System.Drawing.Point(156, 41);
            this.cmbTabla.Name = "cmbTabla";
            this.cmbTabla.Size = new System.Drawing.Size(334, 21);
            this.cmbTabla.TabIndex = 20;
            this.cmbTabla.SelectedIndexChanged += new System.EventHandler(this.cmbTabla_SelectedIndexChanged);
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Location = new System.Drawing.Point(12, 44);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(100, 13);
            this.lblTablas.TabIndex = 19;
            this.lblTablas.Text = "Seleccione la tabla:";
            // 
            // cmbConecciones
            // 
            this.cmbConecciones.FormattingEnabled = true;
            this.cmbConecciones.Location = new System.Drawing.Point(156, 8);
            this.cmbConecciones.Name = "cmbConecciones";
            this.cmbConecciones.Size = new System.Drawing.Size(334, 21);
            this.cmbConecciones.TabIndex = 18;
            this.cmbConecciones.SelectedIndexChanged += new System.EventHandler(this.cmbConecciones_SelectedIndexChanged);
            // 
            // lblNombreConeccion
            // 
            this.lblNombreConeccion.AutoSize = true;
            this.lblNombreConeccion.Location = new System.Drawing.Point(12, 11);
            this.lblNombreConeccion.Name = "lblNombreConeccion";
            this.lblNombreConeccion.Size = new System.Drawing.Size(128, 13);
            this.lblNombreConeccion.TabIndex = 17;
            this.lblNombreConeccion.Text = "Seleccione la Conección:";
            // 
            // frmGeneradorTrazabilidadDesencadenadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 378);
            this.Controls.Add(this.btnCambiarDirectorio);
            this.Controls.Add(this.txtDirectorioDestino);
            this.Controls.Add(this.lblDireccionDatos);
            this.Controls.Add(this.listOpciones);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cmbTabla);
            this.Controls.Add(this.lblTablas);
            this.Controls.Add(this.cmbConecciones);
            this.Controls.Add(this.lblNombreConeccion);
            this.Name = "frmGeneradorTrazabilidadDesencadenadores";
            this.Text = "frmGeneradorTrazabilidadDesencadenadores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fDialog;
        private System.Windows.Forms.Button btnCambiarDirectorio;
        private System.Windows.Forms.TextBox txtDirectorioDestino;
        private System.Windows.Forms.Label lblDireccionDatos;
        private System.Windows.Forms.CheckedListBox listOpciones;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ComboBox cmbTabla;
        private System.Windows.Forms.Label lblTablas;
        private System.Windows.Forms.ComboBox cmbConecciones;
        private System.Windows.Forms.Label lblNombreConeccion;
    }
}