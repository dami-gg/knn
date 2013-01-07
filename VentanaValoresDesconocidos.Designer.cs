namespace KNN
{
    partial class VentanaValoresDesconocidos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private string opcion = "";

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaValoresDesconocidos));
            this.Cerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkMediana = new System.Windows.Forms.CheckBox();
            this.checkMedia = new System.Windows.Forms.CheckBox();
            this.checkEliminacion = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cerrar.Location = new System.Drawing.Point(164, 268);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(92, 37);
            this.Cerrar.TabIndex = 8;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkMediana);
            this.groupBox1.Controls.Add(this.checkMedia);
            this.groupBox1.Controls.Add(this.checkEliminacion);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(27, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 210);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones:";
            // 
            // checkMediana
            // 
            this.checkMediana.AutoSize = true;
            this.checkMediana.Location = new System.Drawing.Point(19, 142);
            this.checkMediana.Name = "checkMediana";
            this.checkMediana.Size = new System.Drawing.Size(337, 43);
            this.checkMediana.TabIndex = 2;
            this.checkMediana.Text = "Asignación al valor desconocido del valor de la mediana (atributos\r\nnuméricos) o " +
                "de la moda (atributos cualitativos) de los valores de\r\nese atributo en el resto " +
                "de ejemplos de su misma clase";
            this.checkMediana.UseVisualStyleBackColor = true;
            this.checkMediana.CheckedChanged += new System.EventHandler(this.checkMediana_CheckedChanged);
            // 
            // checkMedia
            // 
            this.checkMedia.AutoSize = true;
            this.checkMedia.Location = new System.Drawing.Point(19, 84);
            this.checkMedia.Name = "checkMedia";
            this.checkMedia.Size = new System.Drawing.Size(325, 56);
            this.checkMedia.TabIndex = 1;
            this.checkMedia.Text = "Asignación al valor desconocido del valor de la media (atributos\r\nnuméricos) o de" +
                " la moda (atributos cualitativos) de los valores\r\nde ese atributo en el resto de" +
                " ejemplos de su misma clase\r\n\r\n";
            this.checkMedia.UseVisualStyleBackColor = true;
            this.checkMedia.CheckedChanged += new System.EventHandler(this.checkMedia_CheckedChanged);
            // 
            // checkEliminacion
            // 
            this.checkEliminacion.AutoSize = true;
            this.checkEliminacion.Location = new System.Drawing.Point(19, 40);
            this.checkEliminacion.Name = "checkEliminacion";
            this.checkEliminacion.Size = new System.Drawing.Size(315, 17);
            this.checkEliminacion.TabIndex = 0;
            this.checkEliminacion.Text = "Eliminación de ejemplos que presenten valores desconocidos";
            this.checkEliminacion.UseVisualStyleBackColor = true;
            this.checkEliminacion.CheckedChanged += new System.EventHandler(this.checkEliminacion_CheckedChanged);
            // 
            // VentanaValoresDesconocidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(420, 322);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaValoresDesconocidos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tratamiento de valores desconocidos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkMediana;
        private System.Windows.Forms.CheckBox checkMedia;
        private System.Windows.Forms.CheckBox checkEliminacion;
    }
}