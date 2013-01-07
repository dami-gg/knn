namespace KNN
{
    partial class VentanaAmpliarConjunto
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected string textoIntroducido = "";

        protected string tipoDatosCjto = "";

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaAmpliarConjunto));
            this.Anadir = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.boxAmpliar = new System.Windows.Forms.TextBox();
            this.TextoOcultoAlEscribir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Anadir
            // 
            this.Anadir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Anadir.Location = new System.Drawing.Point(109, 298);
            this.Anadir.Name = "Anadir";
            this.Anadir.Size = new System.Drawing.Size(92, 37);
            this.Anadir.TabIndex = 3;
            this.Anadir.Text = "Añadir";
            this.Anadir.UseVisualStyleBackColor = true;
            this.Anadir.Click += new System.EventHandler(this.Anadir_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(265, 298);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(92, 37);
            this.Cancelar.TabIndex = 4;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // boxAmpliar
            // 
            this.boxAmpliar.AcceptsReturn = true;
            this.boxAmpliar.Location = new System.Drawing.Point(54, 100);
            this.boxAmpliar.Multiline = true;
            this.boxAmpliar.Name = "boxAmpliar";
            this.boxAmpliar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxAmpliar.Size = new System.Drawing.Size(351, 181);
            this.boxAmpliar.TabIndex = 5;
            // 
            // TextoOcultoAlEscribir
            // 
            this.TextoOcultoAlEscribir.AutoSize = true;
            this.TextoOcultoAlEscribir.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextoOcultoAlEscribir.Location = new System.Drawing.Point(108, 23);
            this.TextoOcultoAlEscribir.Name = "TextoOcultoAlEscribir";
            this.TextoOcultoAlEscribir.Size = new System.Drawing.Size(244, 52);
            this.TextoOcultoAlEscribir.TabIndex = 6;
            this.TextoOcultoAlEscribir.Text = "Ejemplo:\r\n\r\n(atributo1, atributo2, atributo3, ..., atributoM, clase)\r\n(atributo1," +
                " atributo2, atributo3, ..., atributoM, clase)";
            // 
            // VentanaAmpliarConjunto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(465, 363);
            this.Controls.Add(this.TextoOcultoAlEscribir);
            this.Controls.Add(this.boxAmpliar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Anadir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaAmpliarConjunto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir nuevos casos al conjunto de entrenamiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Anadir;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.TextBox boxAmpliar;
        private System.Windows.Forms.Label TextoOcultoAlEscribir;
    }
}