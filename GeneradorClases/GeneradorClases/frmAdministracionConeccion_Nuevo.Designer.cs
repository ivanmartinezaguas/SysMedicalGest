namespace GeneradorClases
{
    partial class frmAdministracionConeccion_Nuevo
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
            this.administracionConeccion1 = new LibreriaControlesGeneradorCodigo.AdministracionConeccion();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // administracionConeccion1
            // 
            this.administracionConeccion1.Location = new System.Drawing.Point(2, 1);
            this.administracionConeccion1.Name = "administracionConeccion1";
            this.administracionConeccion1.Size = new System.Drawing.Size(509, 141);
            this.administracionConeccion1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 148);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmAdministracionConeccion_Nuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 180);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.administracionConeccion1);
            this.Name = "frmAdministracionConeccion_Nuevo";
            this.Text = "Ingreso de Datos";
            this.Load += new System.EventHandler(this.frmAdministracionConeccion_Nuevo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LibreriaControlesGeneradorCodigo.AdministracionConeccion administracionConeccion1;
        private System.Windows.Forms.Button btnGuardar;

    }
}