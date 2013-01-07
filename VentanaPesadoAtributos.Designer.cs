namespace KNN
{
    partial class VentanaPesadoAtributos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected System.Collections.ArrayList ListaPesos = new System.Collections.ArrayList();

        protected System.Collections.ArrayList ListaAtributos = new System.Collections.ArrayList();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPesadoAtributos));
            this.Cerrar = new System.Windows.Forms.Button();
            this.cambiarPeso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.boxAtributo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxLista = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxPeso = new System.Windows.Forms.TextBox();
            this.botonMismoPeso = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cerrar.Location = new System.Drawing.Point(147, 394);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(92, 37);
            this.Cerrar.TabIndex = 12;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            // 
            // cambiarPeso
            // 
            this.cambiarPeso.Location = new System.Drawing.Point(231, 268);
            this.cambiarPeso.Name = "cambiarPeso";
            this.cambiarPeso.Size = new System.Drawing.Size(92, 37);
            this.cambiarPeso.TabIndex = 10;
            this.cambiarPeso.Text = "Cambiar";
            this.cambiarPeso.UseVisualStyleBackColor = true;
            this.cambiarPeso.Click += new System.EventHandler(this.cambiarPeso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Atributo";
            // 
            // boxAtributo
            // 
            this.boxAtributo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.boxAtributo.Location = new System.Drawing.Point(86, 257);
            this.boxAtributo.Name = "boxAtributo";
            this.boxAtributo.Size = new System.Drawing.Size(100, 20);
            this.boxAtributo.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxLista);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(25, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 210);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesos actuales de los atributos";
            // 
            // boxLista
            // 
            this.boxLista.BackColor = System.Drawing.Color.WhiteSmoke;
            this.boxLista.Location = new System.Drawing.Point(18, 33);
            this.boxLista.Multiline = true;
            this.boxLista.Name = "boxLista";
            this.boxLista.ReadOnly = true;
            this.boxLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxLista.Size = new System.Drawing.Size(299, 158);
            this.boxLista.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Peso";
            // 
            // boxPeso
            // 
            this.boxPeso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.boxPeso.Location = new System.Drawing.Point(86, 293);
            this.boxPeso.Name = "boxPeso";
            this.boxPeso.Size = new System.Drawing.Size(100, 20);
            this.boxPeso.TabIndex = 14;
            // 
            // botonMismoPeso
            // 
            this.botonMismoPeso.Location = new System.Drawing.Point(130, 336);
            this.botonMismoPeso.Name = "botonMismoPeso";
            this.botonMismoPeso.Size = new System.Drawing.Size(126, 37);
            this.botonMismoPeso.TabIndex = 15;
            this.botonMismoPeso.Text = "Mismo peso para todos (versión por defecto)";
            this.botonMismoPeso.UseVisualStyleBackColor = true;
            this.botonMismoPeso.Click += new System.EventHandler(this.botonMismoPeso_Click);
            // 
            // VentanaPesadoAtributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(386, 454);
            this.Controls.Add(this.botonMismoPeso);
            this.Controls.Add(this.boxPeso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.cambiarPeso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxAtributo);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaPesadoAtributos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesado de atributos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button cambiarPeso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxAtributo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox boxLista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxPeso;
        private System.Windows.Forms.Button botonMismoPeso;
    }
}