namespace KNN
{
    partial class VentanaMostrarAtributos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaMostrarAtributos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxAtributos = new System.Windows.Forms.TextBox();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxAtributos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de atributos:";
            // 
            // boxAtributos
            // 
            this.boxAtributos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.boxAtributos.Location = new System.Drawing.Point(17, 29);
            this.boxAtributos.Multiline = true;
            this.boxAtributos.Name = "boxAtributos";
            this.boxAtributos.ReadOnly = true;
            this.boxAtributos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxAtributos.Size = new System.Drawing.Size(325, 224);
            this.boxAtributos.TabIndex = 0;
            // 
            // botonCerrar
            // 
            this.botonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCerrar.Location = new System.Drawing.Point(155, 301);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(92, 37);
            this.botonCerrar.TabIndex = 1;
            this.botonCerrar.Text = "Cerrar";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // VentanaMostrarAtributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(388, 350);
            this.Controls.Add(this.botonCerrar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaMostrarAtributos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atributos del sistema";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonCerrar;
        private System.Windows.Forms.TextBox boxAtributos;
    }
}