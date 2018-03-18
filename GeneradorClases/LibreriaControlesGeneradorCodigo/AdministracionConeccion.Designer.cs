namespace LibreriaControlesGeneradorCodigo
{
    partial class AdministracionConeccion
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtContrasenaConeccion = new System.Windows.Forms.TextBox();
            this.lblContrasenaConeccion = new System.Windows.Forms.Label();
            this.txtUsuarioConeccion = new System.Windows.Forms.TextBox();
            this.lblUsuarioConeccion = new System.Windows.Forms.Label();
            this.cmbBaseDatos = new System.Windows.Forms.ComboBox();
            this.lblBaseDatos = new System.Windows.Forms.Label();
            this.txtNombreServidor = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.txtNombreConeccion = new System.Windows.Forms.TextBox();
            this.lblNombreConeccion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtContrasenaConeccion
            // 
            this.txtContrasenaConeccion.Location = new System.Drawing.Point(195, 59);
            this.txtContrasenaConeccion.Name = "txtContrasenaConeccion";
            this.txtContrasenaConeccion.PasswordChar = '*';
            this.txtContrasenaConeccion.Size = new System.Drawing.Size(306, 20);
            this.txtContrasenaConeccion.TabIndex = 2;
            this.txtContrasenaConeccion.UseSystemPasswordChar = true;
            // 
            // lblContrasenaConeccion
            // 
            this.lblContrasenaConeccion.AutoSize = true;
            this.lblContrasenaConeccion.Location = new System.Drawing.Point(3, 59);
            this.lblContrasenaConeccion.Name = "lblContrasenaConeccion";
            this.lblContrasenaConeccion.Size = new System.Drawing.Size(186, 13);
            this.lblContrasenaConeccion.TabIndex = 18;
            this.lblContrasenaConeccion.Text = "Contraseña del Usuario de Conección";
            // 
            // txtUsuarioConeccion
            // 
            this.txtUsuarioConeccion.Location = new System.Drawing.Point(195, 32);
            this.txtUsuarioConeccion.Name = "txtUsuarioConeccion";
            this.txtUsuarioConeccion.Size = new System.Drawing.Size(306, 20);
            this.txtUsuarioConeccion.TabIndex = 1;
            // 
            // lblUsuarioConeccion
            // 
            this.lblUsuarioConeccion.AutoSize = true;
            this.lblUsuarioConeccion.Location = new System.Drawing.Point(3, 33);
            this.lblUsuarioConeccion.Name = "lblUsuarioConeccion";
            this.lblUsuarioConeccion.Size = new System.Drawing.Size(112, 13);
            this.lblUsuarioConeccion.TabIndex = 16;
            this.lblUsuarioConeccion.Text = "Usuario de Conección";
            // 
            // cmbBaseDatos
            // 
            this.cmbBaseDatos.FormattingEnabled = true;
            this.cmbBaseDatos.Location = new System.Drawing.Point(195, 109);
            this.cmbBaseDatos.Name = "cmbBaseDatos";
            this.cmbBaseDatos.Size = new System.Drawing.Size(306, 21);
            this.cmbBaseDatos.TabIndex = 4;
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Location = new System.Drawing.Point(3, 109);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(77, 13);
            this.lblBaseDatos.TabIndex = 14;
            this.lblBaseDatos.Text = "Base de Datos";
            // 
            // txtNombreServidor
            // 
            this.txtNombreServidor.Location = new System.Drawing.Point(195, 85);
            this.txtNombreServidor.Name = "txtNombreServidor";
            this.txtNombreServidor.Size = new System.Drawing.Size(306, 20);
            this.txtNombreServidor.TabIndex = 3;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(3, 85);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(103, 13);
            this.lblServidor.TabIndex = 12;
            this.lblServidor.Text = "Nombre del Servidor";
            // 
            // txtNombreConeccion
            // 
            this.txtNombreConeccion.Location = new System.Drawing.Point(195, 6);
            this.txtNombreConeccion.Name = "txtNombreConeccion";
            this.txtNombreConeccion.Size = new System.Drawing.Size(306, 20);
            this.txtNombreConeccion.TabIndex = 0;
            // 
            // lblNombreConeccion
            // 
            this.lblNombreConeccion.AutoSize = true;
            this.lblNombreConeccion.Location = new System.Drawing.Point(3, 6);
            this.lblNombreConeccion.Name = "lblNombreConeccion";
            this.lblNombreConeccion.Size = new System.Drawing.Size(124, 13);
            this.lblNombreConeccion.TabIndex = 10;
            this.lblNombreConeccion.Text = "Nombre de la Conección";
            // 
            // AdministracionConeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtContrasenaConeccion);
            this.Controls.Add(this.lblContrasenaConeccion);
            this.Controls.Add(this.txtUsuarioConeccion);
            this.Controls.Add(this.lblUsuarioConeccion);
            this.Controls.Add(this.cmbBaseDatos);
            this.Controls.Add(this.lblBaseDatos);
            this.Controls.Add(this.txtNombreServidor);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.txtNombreConeccion);
            this.Controls.Add(this.lblNombreConeccion);
            this.Name = "AdministracionConeccion";
            this.Size = new System.Drawing.Size(509, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContrasenaConeccion;
        private System.Windows.Forms.Label lblContrasenaConeccion;
        private System.Windows.Forms.TextBox txtUsuarioConeccion;
        private System.Windows.Forms.Label lblUsuarioConeccion;
        private System.Windows.Forms.ComboBox cmbBaseDatos;
        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.TextBox txtNombreServidor;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtNombreConeccion;
        private System.Windows.Forms.Label lblNombreConeccion;

    }
}
