namespace KNN
{
    partial class VentanaPesadoCasos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private string tipoPesado = "";

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPesadoCasos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkOrden = new System.Windows.Forms.CheckBox();
            this.checkInversamente = new System.Windows.Forms.CheckBox();
            this.Cerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkOrden);
            this.groupBox1.Controls.Add(this.checkInversamente);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(26, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de pesado:";
            // 
            // checkOrden
            // 
            this.checkOrden.AutoSize = true;
            this.checkOrden.Location = new System.Drawing.Point(30, 91);
            this.checkOrden.Name = "checkOrden";
            this.checkOrden.Size = new System.Drawing.Size(160, 17);
            this.checkOrden.TabIndex = 1;
            this.checkOrden.Text = "Según el orden de vecindad";
            this.checkOrden.UseVisualStyleBackColor = true;
            this.checkOrden.CheckedChanged += new System.EventHandler(this.checkOrden_CheckedChanged);
            // 
            // checkInversamente
            // 
            this.checkInversamente.AutoSize = true;
            this.checkInversamente.Location = new System.Drawing.Point(30, 52);
            this.checkInversamente.Name = "checkInversamente";
            this.checkInversamente.Size = new System.Drawing.Size(216, 17);
            this.checkInversamente.TabIndex = 0;
            this.checkInversamente.Text = "Inversamente proporcional a la distancia";
            this.checkInversamente.UseVisualStyleBackColor = true;
            this.checkInversamente.CheckedChanged += new System.EventHandler(this.checkInversamente_CheckedChanged);
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cerrar.Location = new System.Drawing.Point(116, 212);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(92, 37);
            this.Cerrar.TabIndex = 6;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // VentanaPesadoCasos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(325, 274);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaPesadoCasos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesado de casos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkOrden;
        private System.Windows.Forms.CheckBox checkInversamente;
        private System.Windows.Forms.Button Cerrar;
    }
}