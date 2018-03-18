namespace GeneradorClases
{
    partial class frmListadoAdministracionConecciones
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dtListaAdminConecciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nombreConeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreServidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtListaAdminConecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dtListaAdminConecciones
            // 
            this.dtListaAdminConecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListaAdminConecciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.btnEditar,
            this.btnEliminar,
            this.nombreConeccion,
            this.nombreServidor,
            this.baseDatos,
            this.usuario});
            this.dtListaAdminConecciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtListaAdminConecciones.Location = new System.Drawing.Point(0, 44);
            this.dtListaAdminConecciones.Name = "dtListaAdminConecciones";
            this.dtListaAdminConecciones.Size = new System.Drawing.Size(563, 209);
            this.dtListaAdminConecciones.TabIndex = 1;
            this.dtListaAdminConecciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListaAdminConecciones_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.HeaderText = "Editar";
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnEditar.Width = 50;
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "Eliminar";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnEliminar.Width = 50;
            // 
            // nombreConeccion
            // 
            this.nombreConeccion.DataPropertyName = "nombreConeccion";
            this.nombreConeccion.HeaderText = "Nombre Conección";
            this.nombreConeccion.Name = "nombreConeccion";
            // 
            // nombreServidor
            // 
            this.nombreServidor.DataPropertyName = "servidor";
            this.nombreServidor.HeaderText = "Nombre Servidor";
            this.nombreServidor.Name = "nombreServidor";
            // 
            // baseDatos
            // 
            this.baseDatos.DataPropertyName = "baseDatos";
            this.baseDatos.HeaderText = "Base de Datos";
            this.baseDatos.Name = "baseDatos";
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            // 
            // frmListadoAdministracionConecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 253);
            this.Controls.Add(this.dtListaAdminConecciones);
            this.Controls.Add(this.btnNuevo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListadoAdministracionConecciones";
            this.Text = "Administración de Conecciones";
            ((System.ComponentModel.ISupportInitialize)(this.dtListaAdminConecciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dtListaAdminConecciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreConeccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreServidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
    }
}