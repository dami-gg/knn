namespace KNN
{
    partial class VentanaIgnorarAtributos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected System.Collections.ArrayList ListaIgnorados = new System.Collections.ArrayList();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaIgnorarAtributos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxLista = new System.Windows.Forms.TextBox();
            this.boxAtributo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.anadirAtributo = new System.Windows.Forms.Button();
            this.quitarAtributo = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.verAtributos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxLista);
            this.groupBox1.Location = new System.Drawing.Point(18, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de atributos desactivados:";
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
            // boxAtributo
            // 
            this.boxAtributo.Location = new System.Drawing.Point(91, 251);
            this.boxAtributo.Name = "boxAtributo";
            this.boxAtributo.Size = new System.Drawing.Size(100, 20);
            this.boxAtributo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Atributo";
            // 
            // anadirAtributo
            // 
            this.anadirAtributo.Location = new System.Drawing.Point(63, 307);
            this.anadirAtributo.Name = "anadirAtributo";
            this.anadirAtributo.Size = new System.Drawing.Size(92, 37);
            this.anadirAtributo.TabIndex = 3;
            this.anadirAtributo.Text = "Añadir";
            this.anadirAtributo.UseVisualStyleBackColor = true;
            this.anadirAtributo.Click += new System.EventHandler(this.AnadirIgnorado);
            // 
            // quitarAtributo
            // 
            this.quitarAtributo.Location = new System.Drawing.Point(217, 307);
            this.quitarAtributo.Name = "quitarAtributo";
            this.quitarAtributo.Size = new System.Drawing.Size(92, 37);
            this.quitarAtributo.TabIndex = 4;
            this.quitarAtributo.Text = "Quitar";
            this.quitarAtributo.UseVisualStyleBackColor = true;
            this.quitarAtributo.Click += new System.EventHandler(this.QuitarIgnorado);
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cerrar.Location = new System.Drawing.Point(139, 373);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(92, 37);
            this.Cerrar.TabIndex = 5;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            // 
            // verAtributos
            // 
            this.verAtributos.Location = new System.Drawing.Point(243, 242);
            this.verAtributos.Name = "verAtributos";
            this.verAtributos.Size = new System.Drawing.Size(92, 37);
            this.verAtributos.TabIndex = 6;
            this.verAtributos.Text = "Ver atributos";
            this.verAtributos.UseVisualStyleBackColor = true;
            this.verAtributos.Click += new System.EventHandler(this.verAtributos_Click);
            // 
            // VentanaIgnorarAtributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(376, 422);
            this.Controls.Add(this.verAtributos);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.quitarAtributo);
            this.Controls.Add(this.anadirAtributo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxAtributo);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaIgnorarAtributos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desactivar atributos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox boxLista;
        private System.Windows.Forms.TextBox boxAtributo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button anadirAtributo;
        private System.Windows.Forms.Button quitarAtributo;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button verAtributos;
    }
}