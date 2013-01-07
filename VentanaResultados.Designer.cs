namespace KNN
{
    partial class VentanaResultados
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Collections.ArrayList valoresGrafica = new System.Collections.ArrayList();

        private bool MostrarProbabilidades = false;

        private bool ActivarProbabilidades = false;

        private System.Collections.ArrayList clases = new System.Collections.ArrayList();

        private string tipoResultados = "";

        private string rutaGuardar = "";

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaResultados));
            this.Cerrar = new System.Windows.Forms.Button();
            this.cuadroResultados = new System.Windows.Forms.RichTextBox();
            this.grafica = new SoftwareFX.ChartFX.Lite.Chart();
            this.botonProbabilidades = new System.Windows.Forms.Button();
            this.boxKOptimo = new System.Windows.Forms.TextBox();
            this.labelKOptimo = new System.Windows.Forms.Label();
            this.guardarResultados = new System.Windows.Forms.SaveFileDialog();
            this.tipGuardar = new System.Windows.Forms.ToolTip(this.components);
            this.tipGrafica = new System.Windows.Forms.ToolTip(this.components);
            this.tipProbabilidades = new System.Windows.Forms.ToolTip(this.components);
            this.botonGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cerrar.Location = new System.Drawing.Point(390, 397);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(97, 37);
            this.Cerrar.TabIndex = 1;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            // 
            // cuadroResultados
            // 
            this.cuadroResultados.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cuadroResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadroResultados.Location = new System.Drawing.Point(31, 23);
            this.cuadroResultados.Name = "cuadroResultados";
            this.cuadroResultados.ReadOnly = true;
            this.cuadroResultados.Size = new System.Drawing.Size(289, 307);
            this.cuadroResultados.TabIndex = 2;
            this.cuadroResultados.Text = "";
            // 
            // grafica
            // 
            this.grafica.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grafica.BorderColor = System.Drawing.Color.Black;
            this.grafica.Location = new System.Drawing.Point(360, 23);
            this.grafica.Name = "grafica";
            this.grafica.Size = new System.Drawing.Size(320, 307);
            this.grafica.TabIndex = 0;
            this.tipGrafica.SetToolTip(this.grafica, "Doble clic para cambiar el tipo de gráfica");
            this.grafica.DoubleClick += new SoftwareFX.ChartFX.Lite.MouseEventHandlerX(this.grafica_DoubleClick);
            // 
            // botonProbabilidades
            // 
            this.botonProbabilidades.Location = new System.Drawing.Point(119, 345);
            this.botonProbabilidades.Name = "botonProbabilidades";
            this.botonProbabilidades.Size = new System.Drawing.Size(131, 27);
            this.botonProbabilidades.TabIndex = 3;
            this.botonProbabilidades.Text = "Mostrar probabilidades";
            this.tipProbabilidades.SetToolTip(this.botonProbabilidades, "Muestra las probabilidades de que cada caso pertenezca a la clase dada");
            this.botonProbabilidades.UseVisualStyleBackColor = true;
            this.botonProbabilidades.Click += new System.EventHandler(this.botonProbabilidades_Click);
            // 
            // boxKOptimo
            // 
            this.boxKOptimo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.boxKOptimo.Location = new System.Drawing.Point(518, 349);
            this.boxKOptimo.Name = "boxKOptimo";
            this.boxKOptimo.ReadOnly = true;
            this.boxKOptimo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.boxKOptimo.Size = new System.Drawing.Size(121, 20);
            this.boxKOptimo.TabIndex = 4;
            this.boxKOptimo.Visible = false;
            // 
            // labelKOptimo
            // 
            this.labelKOptimo.AutoSize = true;
            this.labelKOptimo.Location = new System.Drawing.Point(419, 352);
            this.labelKOptimo.Name = "labelKOptimo";
            this.labelKOptimo.Size = new System.Drawing.Size(93, 13);
            this.labelKOptimo.TabIndex = 5;
            this.labelKOptimo.Text = "Valor de K óptimo:";
            this.labelKOptimo.Visible = false;
            // 
            // tipGuardar
            // 
            this.tipGuardar.Tag = "";
            // 
            // tipGrafica
            // 
            this.tipGrafica.Tag = "";
            // 
            // tipProbabilidades
            // 
            this.tipProbabilidades.Tag = "";
            // 
            // botonGuardar
            // 
            this.botonGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botonGuardar.Image")));
            this.botonGuardar.Location = new System.Drawing.Point(31, 380);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(52, 54);
            this.botonGuardar.TabIndex = 8;
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // VentanaResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(720, 446);
            this.Controls.Add(this.botonGuardar);
            this.Controls.Add(this.labelKOptimo);
            this.Controls.Add(this.boxKOptimo);
            this.Controls.Add(this.botonProbabilidades);
            this.Controls.Add(this.grafica);
            this.Controls.Add(this.cuadroResultados);
            this.Controls.Add(this.Cerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaResultados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.RichTextBox cuadroResultados;
        private SoftwareFX.ChartFX.Lite.Chart grafica;
        private System.Windows.Forms.Button botonProbabilidades;
        private System.Windows.Forms.TextBox boxKOptimo;
        private System.Windows.Forms.Label labelKOptimo;
        private System.Windows.Forms.SaveFileDialog guardarResultados;
        private System.Windows.Forms.ToolTip tipGuardar;
        private System.Windows.Forms.ToolTip tipGrafica;
        private System.Windows.Forms.ToolTip tipProbabilidades;
        private System.Windows.Forms.Button botonGuardar;
    }
}