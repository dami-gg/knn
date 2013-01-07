namespace KNN
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private KVecinos APLICACION = new KVecinos();

        /// <summary>
        /// Variables para controlar la introducción de datos
        /// </summary>
        private bool seLeyoConjuntoEntrenamiento = false;

        private bool seLeyeronAtributos = false;

        private bool seLeyoK = false;

        private bool seLeyoC = false;

        private bool seLeyoQ = false;

        private bool seLeyeronCasosClasificar = false;

        private bool seLeyoValorRechazo = false;

        private bool seSeleccionoDistanciaVectores = false;

        private bool seSeleccionoDistanciaCadenas = false;

        private bool seSeleccionoDistanciaConjuntos = false;

        private bool seSeleccionoDistanciaEspacioBase = false;

        private bool seCambioTipoNormalizacion = false;
        
        private string textoIntroducido = "";

        private string tipoNormalizacion = "[0,1]";

        private bool seCambioNormAAlgunos = false;

        private double aInt = 0;

        private double bInt = 1;

        private bool guardarSinMostrar = false;

        private System.Collections.ArrayList ClasesCasos = new System.Collections.ArrayList();

        private string modoEjecucion = "Normal";

        private string path = "";

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.imagen = new System.Windows.Forms.PictureBox();
            this.textoIntroduccion = new System.Windows.Forms.RichTextBox();
            this.tabCadenas = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboDistanciasCadenas = new System.Windows.Forms.ComboBox();
            this.labelCCad = new System.Windows.Forms.Label();
            this.boxCCad = new System.Windows.Forms.TextBox();
            this.botonPesadoCasosCadenas = new System.Windows.Forms.Button();
            this.textRechazoCad = new System.Windows.Forms.Label();
            this.boxRechazoCad = new System.Windows.Forms.TextBox();
            this.checkRechazoCad = new System.Windows.Forms.CheckBox();
            this.toolStripCad = new System.Windows.Forms.ToolStrip();
            this.botonMenuCargarDataCad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuCargarCasesCad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuGuardarCad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuClasificarCad = new System.Windows.Forms.ToolStripButton();
            this.menuStripCad = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.casosAClasificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.clasificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.pesadoDeCasosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.modoDeValidacionCruzadaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contenidoDeLaAyudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelKCad = new System.Windows.Forms.Label();
            this.cuadroKCadenas = new System.Windows.Forms.TextBox();
            this.botonClasificarCadenas = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCadenas = new System.Windows.Forms.TextBox();
            this.tabConjuntos = new System.Windows.Forms.TabPage();
            this.cuadroEspacioBase = new System.Windows.Forms.GroupBox();
            this.comboDistanciasEspacioBase = new System.Windows.Forms.ComboBox();
            this.labelCConj = new System.Windows.Forms.Label();
            this.boxCConj = new System.Windows.Forms.TextBox();
            this.textRechazoConj = new System.Windows.Forms.Label();
            this.boxRechazoConj = new System.Windows.Forms.TextBox();
            this.checkRechazoConj = new System.Windows.Forms.CheckBox();
            this.labelKConj = new System.Windows.Forms.Label();
            this.cuadroKConjuntos = new System.Windows.Forms.TextBox();
            this.botonPesadoCasosConjuntos = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboDistanciasConjuntos = new System.Windows.Forms.ComboBox();
            this.botonClasificarConjuntos = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxConjuntos = new System.Windows.Forms.TextBox();
            this.toolStripConj = new System.Windows.Forms.ToolStrip();
            this.botonMenuCargarDataConj = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuCargarCasesConj = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuGuardarConj = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuClasificar = new System.Windows.Forms.ToolStripButton();
            this.menuStripConj = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripMenuItem();
            this.casosAClasificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.clasificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.pesadoDeCasosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.modoDeValidacionCruzadaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contenidoDeLaAyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabVectores = new System.Windows.Forms.TabPage();
            this.labelCVect = new System.Windows.Forms.Label();
            this.boxCVect = new System.Windows.Forms.TextBox();
            this.botonPesadoCasosVectores = new System.Windows.Forms.Button();
            this.checkRegresion = new System.Windows.Forms.CheckBox();
            this.textRechazoVect = new System.Windows.Forms.Label();
            this.boxRechazoVect = new System.Windows.Forms.TextBox();
            this.checkRechazoVect = new System.Windows.Forms.CheckBox();
            this.botonPesadoAtributosVectores = new System.Windows.Forms.Button();
            this.groupBoxNormalizacion = new System.Windows.Forms.GroupBox();
            this.comboTipoNormVect = new System.Windows.Forms.ComboBox();
            this.labelNormalizar = new System.Windows.Forms.Label();
            this.boxBVect = new System.Windows.Forms.TextBox();
            this.labelBVect = new System.Windows.Forms.Label();
            this.boxAVect = new System.Windows.Forms.TextBox();
            this.labelAVect = new System.Windows.Forms.Label();
            this.comboNormalizacionVect = new System.Windows.Forms.ComboBox();
            this.toolStripVect = new System.Windows.Forms.ToolStrip();
            this.botonMenuCargarNames = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuCargarDataVect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuCargarCasesVect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuGuardarVect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.botonMenuClasificarVect = new System.Windows.Forms.ToolStripButton();
            this.menuStripVect = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCargarNames = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCargarData = new System.Windows.Forms.ToolStripMenuItem();
            this.casosAClasificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.clasificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarClasesYAtributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignorarAtributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pesadoDeAtributosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesadoDeCasosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tratamientoDeValoresDesconocidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformarAtributosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.modoDeValidacionCruzadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelKVect = new System.Windows.Forms.Label();
            this.cuadroKVectores = new System.Windows.Forms.TextBox();
            this.botonClasificarVectores = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boxQ = new System.Windows.Forms.TextBox();
            this.rotuloQ = new System.Windows.Forms.Label();
            this.comboDistanciasVectores = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxVectores = new System.Windows.Forms.TextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cargarNames = new System.Windows.Forms.OpenFileDialog();
            this.cargarData = new System.Windows.Forms.OpenFileDialog();
            this.tipInformacion = new System.Windows.Forms.ToolTip(this.components);
            this.cargarCases = new System.Windows.Forms.OpenFileDialog();
            this.guardarResultados = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.tabControl.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).BeginInit();
            this.tabCadenas.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStripCad.SuspendLayout();
            this.menuStripCad.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabConjuntos.SuspendLayout();
            this.cuadroEspacioBase.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.toolStripConj.SuspendLayout();
            this.menuStripConj.SuspendLayout();
            this.tabVectores.SuspendLayout();
            this.groupBoxNormalizacion.SuspendLayout();
            this.toolStripVect.SuspendLayout();
            this.menuStripVect.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPrincipal);
            this.tabControl.Controls.Add(this.tabCadenas);
            this.tabControl.Controls.Add(this.tabConjuntos);
            this.tabControl.Controls.Add(this.tabVectores);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(812, 535);
            this.tabControl.TabIndex = 7;
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.tabPrincipal.Controls.Add(this.richTextBox1);
            this.tabPrincipal.Controls.Add(this.imagen);
            this.tabPrincipal.Controls.Add(this.textoIntroduccion);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Size = new System.Drawing.Size(804, 509);
            this.tabPrincipal.TabIndex = 2;
            this.tabPrincipal.Text = "Inicio";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(82, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(641, 41);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "Entorno de clasificación basada en la proximidad";
            // 
            // imagen
            // 
            this.imagen.BackColor = System.Drawing.Color.Lavender;
            this.imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagen.Image = ((System.Drawing.Image)(resources.GetObject("imagen.Image")));
            this.imagen.Location = new System.Drawing.Point(440, 136);
            this.imagen.Name = "imagen";
            this.imagen.Size = new System.Drawing.Size(281, 254);
            this.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imagen.TabIndex = 2;
            this.imagen.TabStop = false;
            // 
            // textoIntroduccion
            // 
            this.textoIntroduccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.textoIntroduccion.Cursor = System.Windows.Forms.Cursors.Cross;
            this.textoIntroduccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textoIntroduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoIntroduccion.Location = new System.Drawing.Point(0, 0);
            this.textoIntroduccion.Name = "textoIntroduccion";
            this.textoIntroduccion.ReadOnly = true;
            this.textoIntroduccion.Size = new System.Drawing.Size(804, 509);
            this.textoIntroduccion.TabIndex = 1;
            this.textoIntroduccion.Text = resources.GetString("textoIntroduccion.Text");
            // 
            // tabCadenas
            // 
            this.tabCadenas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.tabCadenas.Controls.Add(this.groupBox6);
            this.tabCadenas.Controls.Add(this.labelCCad);
            this.tabCadenas.Controls.Add(this.boxCCad);
            this.tabCadenas.Controls.Add(this.botonPesadoCasosCadenas);
            this.tabCadenas.Controls.Add(this.textRechazoCad);
            this.tabCadenas.Controls.Add(this.boxRechazoCad);
            this.tabCadenas.Controls.Add(this.checkRechazoCad);
            this.tabCadenas.Controls.Add(this.toolStripCad);
            this.tabCadenas.Controls.Add(this.menuStripCad);
            this.tabCadenas.Controls.Add(this.labelKCad);
            this.tabCadenas.Controls.Add(this.cuadroKCadenas);
            this.tabCadenas.Controls.Add(this.botonClasificarCadenas);
            this.tabCadenas.Controls.Add(this.groupBox3);
            this.tabCadenas.Location = new System.Drawing.Point(4, 22);
            this.tabCadenas.Name = "tabCadenas";
            this.tabCadenas.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadenas.Size = new System.Drawing.Size(804, 509);
            this.tabCadenas.TabIndex = 0;
            this.tabCadenas.Text = "Cadenas";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboDistanciasCadenas);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox6.Location = new System.Drawing.Point(459, 101);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(291, 53);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Distancia a aplicar:";
            // 
            // comboDistanciasCadenas
            // 
            this.comboDistanciasCadenas.FormattingEnabled = true;
            this.comboDistanciasCadenas.Items.AddRange(new object[] {
            "Levenshtein",
            "Hamming",
            "Lee"});
            this.comboDistanciasCadenas.Location = new System.Drawing.Point(36, 21);
            this.comboDistanciasCadenas.Name = "comboDistanciasCadenas";
            this.comboDistanciasCadenas.Size = new System.Drawing.Size(229, 21);
            this.comboDistanciasCadenas.TabIndex = 0;
            this.comboDistanciasCadenas.SelectedIndexChanged += new System.EventHandler(this.comboDistanciasCadenas_SelectedIndexChanged);
            // 
            // labelCCad
            // 
            this.labelCCad.AutoSize = true;
            this.labelCCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCCad.Location = new System.Drawing.Point(451, 349);
            this.labelCCad.Name = "labelCCad";
            this.labelCCad.Size = new System.Drawing.Size(222, 13);
            this.labelCCad.TabIndex = 29;
            this.labelCCad.Text = "Nº de subconjuntos en que dividir el principal:";
            this.labelCCad.Visible = false;
            // 
            // boxCCad
            // 
            this.boxCCad.Location = new System.Drawing.Point(679, 346);
            this.boxCCad.Name = "boxCCad";
            this.boxCCad.Size = new System.Drawing.Size(45, 20);
            this.boxCCad.TabIndex = 28;
            this.boxCCad.Visible = false;
            // 
            // botonPesadoCasosCadenas
            // 
            this.botonPesadoCasosCadenas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPesadoCasosCadenas.Location = new System.Drawing.Point(557, 226);
            this.botonPesadoCasosCadenas.Name = "botonPesadoCasosCadenas";
            this.botonPesadoCasosCadenas.Size = new System.Drawing.Size(96, 41);
            this.botonPesadoCasosCadenas.TabIndex = 23;
            this.botonPesadoCasosCadenas.Text = "Pesado de casos";
            this.tipInformacion.SetToolTip(this.botonPesadoCasosCadenas, "Muestra la ventana para asignar pesos a los casos");
            this.botonPesadoCasosCadenas.UseVisualStyleBackColor = true;
            this.botonPesadoCasosCadenas.Click += new System.EventHandler(this.botonPesadoCasosCadenas_Click);
            // 
            // textRechazoCad
            // 
            this.textRechazoCad.AutoSize = true;
            this.textRechazoCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRechazoCad.Location = new System.Drawing.Point(174, 458);
            this.textRechazoCad.Name = "textRechazoCad";
            this.textRechazoCad.Size = new System.Drawing.Size(174, 13);
            this.textRechazoCad.TabIndex = 22;
            this.textRechazoCad.Text = "si el número de votos es menor que";
            this.textRechazoCad.Visible = false;
            // 
            // boxRechazoCad
            // 
            this.boxRechazoCad.Location = new System.Drawing.Point(354, 455);
            this.boxRechazoCad.Name = "boxRechazoCad";
            this.boxRechazoCad.Size = new System.Drawing.Size(45, 20);
            this.boxRechazoCad.TabIndex = 21;
            this.boxRechazoCad.Visible = false;
            // 
            // checkRechazoCad
            // 
            this.checkRechazoCad.AutoSize = true;
            this.checkRechazoCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRechazoCad.Location = new System.Drawing.Point(51, 457);
            this.checkRechazoCad.Name = "checkRechazoCad";
            this.checkRechazoCad.Size = new System.Drawing.Size(130, 17);
            this.checkRechazoCad.TabIndex = 20;
            this.checkRechazoCad.Text = "Votación con rechazo";
            this.checkRechazoCad.UseVisualStyleBackColor = true;
            this.checkRechazoCad.CheckedChanged += new System.EventHandler(this.checkRechazo_CheckedChanged);
            // 
            // toolStripCad
            // 
            this.toolStripCad.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripCad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonMenuCargarDataCad,
            this.toolStripSeparator2,
            this.botonMenuCargarCasesCad,
            this.toolStripSeparator10,
            this.botonMenuGuardarCad,
            this.toolStripSeparator9,
            this.botonMenuClasificarCad});
            this.toolStripCad.Location = new System.Drawing.Point(3, 27);
            this.toolStripCad.Name = "toolStripCad";
            this.toolStripCad.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripCad.Size = new System.Drawing.Size(798, 25);
            this.toolStripCad.TabIndex = 18;
            this.toolStripCad.Text = "toolStrip2";
            // 
            // botonMenuCargarDataCad
            // 
            this.botonMenuCargarDataCad.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarDataCad.Image")));
            this.botonMenuCargarDataCad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarDataCad.Name = "botonMenuCargarDataCad";
            this.botonMenuCargarDataCad.Size = new System.Drawing.Size(193, 22);
            this.botonMenuCargarDataCad.Text = "Cargar conjunto de entrenamiento";
            this.botonMenuCargarDataCad.Click += new System.EventHandler(this.menuCargarData_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuCargarCasesCad
            // 
            this.botonMenuCargarCasesCad.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarCasesCad.Image")));
            this.botonMenuCargarCasesCad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarCasesCad.Name = "botonMenuCargarCasesCad";
            this.botonMenuCargarCasesCad.Size = new System.Drawing.Size(143, 22);
            this.botonMenuCargarCasesCad.Text = "Cargar casos a clasificar";
            this.botonMenuCargarCasesCad.Click += new System.EventHandler(this.menuCargarCases_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuGuardarCad
            // 
            this.botonMenuGuardarCad.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuGuardarCad.Image")));
            this.botonMenuGuardarCad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuGuardarCad.Name = "botonMenuGuardarCad";
            this.botonMenuGuardarCad.Size = new System.Drawing.Size(119, 22);
            this.botonMenuGuardarCad.Text = "Guardar resultados";
            this.botonMenuGuardarCad.ToolTipText = "Guardar resultados directamente en un fichero sin mostrarlos";
            this.botonMenuGuardarCad.Click += new System.EventHandler(this.botonMenuGuardar_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuClasificarCad
            // 
            this.botonMenuClasificarCad.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuClasificarCad.Image")));
            this.botonMenuClasificarCad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuClasificarCad.Name = "botonMenuClasificarCad";
            this.botonMenuClasificarCad.Size = new System.Drawing.Size(70, 22);
            this.botonMenuClasificarCad.Text = "Clasificar";
            this.botonMenuClasificarCad.ToolTipText = "Clasifica los nuevos casos en función de los parámetros elegidos";
            this.botonMenuClasificarCad.Click += new System.EventHandler(this.botonCalcularCadenas_Click);
            // 
            // menuStripCad
            // 
            this.menuStripCad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem9,
            this.ayudaToolStripMenuItem3});
            this.menuStripCad.Location = new System.Drawing.Point(3, 3);
            this.menuStripCad.Name = "menuStripCad";
            this.menuStripCad.Size = new System.Drawing.Size(798, 24);
            this.menuStripCad.TabIndex = 17;
            this.menuStripCad.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem5,
            this.toolStripSeparator13,
            this.clasificarToolStripMenuItem1,
            this.toolStripMenuItem8});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItem1.Text = "Archivo";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.casosAClasificarToolStripMenuItem});
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem2.Text = "Cargar";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem4.Text = "Conjunto de entrenamiento";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.menuCargarData_Click);
            // 
            // casosAClasificarToolStripMenuItem
            // 
            this.casosAClasificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("casosAClasificarToolStripMenuItem.Image")));
            this.casosAClasificarToolStripMenuItem.Name = "casosAClasificarToolStripMenuItem";
            this.casosAClasificarToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.casosAClasificarToolStripMenuItem.Text = "Casos a clasificar";
            this.casosAClasificarToolStripMenuItem.Click += new System.EventHandler(this.menuCargarCases_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem5.Text = "Guardar resultados";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.botonMenuGuardar_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(174, 6);
            // 
            // clasificarToolStripMenuItem1
            // 
            this.clasificarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("clasificarToolStripMenuItem1.Image")));
            this.clasificarToolStripMenuItem1.Name = "clasificarToolStripMenuItem1";
            this.clasificarToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.clasificarToolStripMenuItem1.Text = "Clasificar";
            this.clasificarToolStripMenuItem1.Click += new System.EventHandler(this.botonCalcularCadenas_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem8.Image")));
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem8.Text = "Salir";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2,
            this.toolStripMenuItem10,
            this.toolStripSeparator14,
            this.pesadoDeCasosToolStripMenuItem2,
            this.toolStripSeparator21,
            this.modoDeValidacionCruzadaToolStripMenuItem2});
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem9.Text = "Configurar";
            // 
            // mostrarConjuntoDeEntrenamientoToolStripMenuItem2
            // 
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("mostrarConjuntoDeEntrenamientoToolStripMenuItem2.Image")));
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2.Name = "mostrarConjuntoDeEntrenamientoToolStripMenuItem2";
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2.Size = new System.Drawing.Size(255, 22);
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2.Text = "Mostrar conjunto de entrenamiento";
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem2.Click += new System.EventHandler(this.mostrarConjuntoDeEntrenamientoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(255, 22);
            this.toolStripMenuItem10.Text = "Ampliar conjunto de entrenamiento";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(252, 6);
            // 
            // pesadoDeCasosToolStripMenuItem2
            // 
            this.pesadoDeCasosToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("pesadoDeCasosToolStripMenuItem2.Image")));
            this.pesadoDeCasosToolStripMenuItem2.Name = "pesadoDeCasosToolStripMenuItem2";
            this.pesadoDeCasosToolStripMenuItem2.Size = new System.Drawing.Size(255, 22);
            this.pesadoDeCasosToolStripMenuItem2.Text = "Pesado de casos";
            this.pesadoDeCasosToolStripMenuItem2.Click += new System.EventHandler(this.botonPesadoCasosCadenas_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(252, 6);
            // 
            // modoDeValidacionCruzadaToolStripMenuItem2
            // 
            this.modoDeValidacionCruzadaToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("modoDeValidacionCruzadaToolStripMenuItem2.Image")));
            this.modoDeValidacionCruzadaToolStripMenuItem2.Name = "modoDeValidacionCruzadaToolStripMenuItem2";
            this.modoDeValidacionCruzadaToolStripMenuItem2.Size = new System.Drawing.Size(255, 22);
            this.modoDeValidacionCruzadaToolStripMenuItem2.Text = "Modo de validación cruzada";
            this.modoDeValidacionCruzadaToolStripMenuItem2.Click += new System.EventHandler(this.modoDeValidacionCruzadaToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem3
            // 
            this.ayudaToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contenidoDeLaAyudaToolStripMenuItem1,
            this.acercaDeToolStripMenuItem2});
            this.ayudaToolStripMenuItem3.Name = "ayudaToolStripMenuItem3";
            this.ayudaToolStripMenuItem3.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem3.Text = "Ayuda";
            // 
            // contenidoDeLaAyudaToolStripMenuItem1
            // 
            this.contenidoDeLaAyudaToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("contenidoDeLaAyudaToolStripMenuItem1.Image")));
            this.contenidoDeLaAyudaToolStripMenuItem1.Name = "contenidoDeLaAyudaToolStripMenuItem1";
            this.contenidoDeLaAyudaToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.contenidoDeLaAyudaToolStripMenuItem1.Text = "Contenido de la ayuda";
            this.contenidoDeLaAyudaToolStripMenuItem1.Click += new System.EventHandler(this.ayudaToolStripMenuItem1_Click);
            // 
            // acercaDeToolStripMenuItem2
            // 
            this.acercaDeToolStripMenuItem2.Name = "acercaDeToolStripMenuItem2";
            this.acercaDeToolStripMenuItem2.Size = new System.Drawing.Size(193, 22);
            this.acercaDeToolStripMenuItem2.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem2.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // labelKCad
            // 
            this.labelKCad.AutoSize = true;
            this.labelKCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKCad.Location = new System.Drawing.Point(147, 402);
            this.labelKCad.Name = "labelKCad";
            this.labelKCad.Size = new System.Drawing.Size(59, 13);
            this.labelKCad.TabIndex = 16;
            this.labelKCad.Text = "Valor de K:";
            // 
            // cuadroKCadenas
            // 
            this.cuadroKCadenas.Location = new System.Drawing.Point(222, 399);
            this.cuadroKCadenas.Name = "cuadroKCadenas";
            this.cuadroKCadenas.Size = new System.Drawing.Size(45, 20);
            this.cuadroKCadenas.TabIndex = 15;
            // 
            // botonClasificarCadenas
            // 
            this.botonClasificarCadenas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClasificarCadenas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonClasificarCadenas.Location = new System.Drawing.Point(545, 420);
            this.botonClasificarCadenas.Name = "botonClasificarCadenas";
            this.botonClasificarCadenas.Size = new System.Drawing.Size(128, 51);
            this.botonClasificarCadenas.TabIndex = 14;
            this.botonClasificarCadenas.Text = "Clasificar";
            this.tipInformacion.SetToolTip(this.botonClasificarCadenas, "Clasifica los nuevos casos en función de los parámetros elegidos");
            this.botonClasificarCadenas.UseVisualStyleBackColor = true;
            this.botonClasificarCadenas.Click += new System.EventHandler(this.botonCalcularCadenas_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxCadenas);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox3.Location = new System.Drawing.Point(47, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 288);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nuevos casos a clasificar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(42, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 52);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ejemplo:\r\n\r\ncadena1 cadena2 cadena3 cadena(i-1)\r\ncadena(i) cadena(i+1)   ...    c" +
                "adenaC";
            // 
            // textBoxCadenas
            // 
            this.textBoxCadenas.AcceptsReturn = true;
            this.textBoxCadenas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCadenas.Location = new System.Drawing.Point(26, 98);
            this.textBoxCadenas.Multiline = true;
            this.textBoxCadenas.Name = "textBoxCadenas";
            this.textBoxCadenas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCadenas.Size = new System.Drawing.Size(267, 169);
            this.textBoxCadenas.TabIndex = 0;
            this.tipInformacion.SetToolTip(this.textBoxCadenas, "Cuadro de introducción de casos a clasificar");
            // 
            // tabConjuntos
            // 
            this.tabConjuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.tabConjuntos.Controls.Add(this.cuadroEspacioBase);
            this.tabConjuntos.Controls.Add(this.labelCConj);
            this.tabConjuntos.Controls.Add(this.boxCConj);
            this.tabConjuntos.Controls.Add(this.textRechazoConj);
            this.tabConjuntos.Controls.Add(this.boxRechazoConj);
            this.tabConjuntos.Controls.Add(this.checkRechazoConj);
            this.tabConjuntos.Controls.Add(this.labelKConj);
            this.tabConjuntos.Controls.Add(this.cuadroKConjuntos);
            this.tabConjuntos.Controls.Add(this.botonPesadoCasosConjuntos);
            this.tabConjuntos.Controls.Add(this.groupBox5);
            this.tabConjuntos.Controls.Add(this.botonClasificarConjuntos);
            this.tabConjuntos.Controls.Add(this.groupBox12);
            this.tabConjuntos.Controls.Add(this.toolStripConj);
            this.tabConjuntos.Controls.Add(this.menuStripConj);
            this.tabConjuntos.Location = new System.Drawing.Point(4, 22);
            this.tabConjuntos.Name = "tabConjuntos";
            this.tabConjuntos.Padding = new System.Windows.Forms.Padding(3);
            this.tabConjuntos.Size = new System.Drawing.Size(804, 509);
            this.tabConjuntos.TabIndex = 3;
            this.tabConjuntos.Text = "Conjuntos";
            // 
            // cuadroEspacioBase
            // 
            this.cuadroEspacioBase.Controls.Add(this.comboDistanciasEspacioBase);
            this.cuadroEspacioBase.ForeColor = System.Drawing.Color.Black;
            this.cuadroEspacioBase.Location = new System.Drawing.Point(459, 183);
            this.cuadroEspacioBase.Name = "cuadroEspacioBase";
            this.cuadroEspacioBase.Size = new System.Drawing.Size(291, 57);
            this.cuadroEspacioBase.TabIndex = 42;
            this.cuadroEspacioBase.TabStop = false;
            this.cuadroEspacioBase.Text = "Distancia del espacio base:";
            // 
            // comboDistanciasEspacioBase
            // 
            this.comboDistanciasEspacioBase.FormattingEnabled = true;
            this.comboDistanciasEspacioBase.Location = new System.Drawing.Point(31, 21);
            this.comboDistanciasEspacioBase.Name = "comboDistanciasEspacioBase";
            this.comboDistanciasEspacioBase.Size = new System.Drawing.Size(229, 21);
            this.comboDistanciasEspacioBase.TabIndex = 0;
            this.comboDistanciasEspacioBase.SelectedIndexChanged += new System.EventHandler(this.comboDistanciasEspacioBase_SelectedIndexChanged);
            this.comboDistanciasEspacioBase.Click += new System.EventHandler(this.comboDistanciasEspacioBase_Click);
            // 
            // labelCConj
            // 
            this.labelCConj.AutoSize = true;
            this.labelCConj.Location = new System.Drawing.Point(451, 352);
            this.labelCConj.Name = "labelCConj";
            this.labelCConj.Size = new System.Drawing.Size(222, 13);
            this.labelCConj.TabIndex = 41;
            this.labelCConj.Text = "Nº de subconjuntos en que dividir el principal:";
            this.labelCConj.Visible = false;
            // 
            // boxCConj
            // 
            this.boxCConj.Location = new System.Drawing.Point(679, 349);
            this.boxCConj.Name = "boxCConj";
            this.boxCConj.Size = new System.Drawing.Size(45, 20);
            this.boxCConj.TabIndex = 40;
            this.boxCConj.Visible = false;
            // 
            // textRechazoConj
            // 
            this.textRechazoConj.AutoSize = true;
            this.textRechazoConj.Location = new System.Drawing.Point(171, 453);
            this.textRechazoConj.Name = "textRechazoConj";
            this.textRechazoConj.Size = new System.Drawing.Size(174, 13);
            this.textRechazoConj.TabIndex = 38;
            this.textRechazoConj.Text = "si el número de votos es menor que";
            this.textRechazoConj.Visible = false;
            // 
            // boxRechazoConj
            // 
            this.boxRechazoConj.Location = new System.Drawing.Point(351, 450);
            this.boxRechazoConj.Name = "boxRechazoConj";
            this.boxRechazoConj.Size = new System.Drawing.Size(45, 20);
            this.boxRechazoConj.TabIndex = 37;
            this.boxRechazoConj.Visible = false;
            // 
            // checkRechazoConj
            // 
            this.checkRechazoConj.AutoSize = true;
            this.checkRechazoConj.Location = new System.Drawing.Point(47, 452);
            this.checkRechazoConj.Name = "checkRechazoConj";
            this.checkRechazoConj.Size = new System.Drawing.Size(130, 17);
            this.checkRechazoConj.TabIndex = 36;
            this.checkRechazoConj.Text = "Votación con rechazo";
            this.checkRechazoConj.UseVisualStyleBackColor = true;
            this.checkRechazoConj.CheckedChanged += new System.EventHandler(this.checkRechazo_CheckedChanged);
            // 
            // labelKConj
            // 
            this.labelKConj.AutoSize = true;
            this.labelKConj.Location = new System.Drawing.Point(147, 402);
            this.labelKConj.Name = "labelKConj";
            this.labelKConj.Size = new System.Drawing.Size(59, 13);
            this.labelKConj.TabIndex = 35;
            this.labelKConj.Text = "Valor de K:";
            // 
            // cuadroKConjuntos
            // 
            this.cuadroKConjuntos.Location = new System.Drawing.Point(222, 399);
            this.cuadroKConjuntos.Name = "cuadroKConjuntos";
            this.cuadroKConjuntos.Size = new System.Drawing.Size(45, 20);
            this.cuadroKConjuntos.TabIndex = 34;
            // 
            // botonPesadoCasosConjuntos
            // 
            this.botonPesadoCasosConjuntos.Location = new System.Drawing.Point(554, 268);
            this.botonPesadoCasosConjuntos.Name = "botonPesadoCasosConjuntos";
            this.botonPesadoCasosConjuntos.Size = new System.Drawing.Size(96, 41);
            this.botonPesadoCasosConjuntos.TabIndex = 31;
            this.botonPesadoCasosConjuntos.Text = "Pesado de casos";
            this.tipInformacion.SetToolTip(this.botonPesadoCasosConjuntos, "Muestra la ventana para asignar pesos a los casos");
            this.botonPesadoCasosConjuntos.UseVisualStyleBackColor = true;
            this.botonPesadoCasosConjuntos.Click += new System.EventHandler(this.botonPesadoCasosConjuntos_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboDistanciasConjuntos);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox5.Location = new System.Drawing.Point(459, 101);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(291, 53);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Distancia a aplicar:";
            // 
            // comboDistanciasConjuntos
            // 
            this.comboDistanciasConjuntos.FormattingEnabled = true;
            this.comboDistanciasConjuntos.Items.AddRange(new object[] {
            "Clásica",
            "Hausdorff",
            "Hausdorff mínima"});
            this.comboDistanciasConjuntos.Location = new System.Drawing.Point(36, 21);
            this.comboDistanciasConjuntos.Name = "comboDistanciasConjuntos";
            this.comboDistanciasConjuntos.Size = new System.Drawing.Size(229, 21);
            this.comboDistanciasConjuntos.TabIndex = 0;
            this.comboDistanciasConjuntos.SelectedIndexChanged += new System.EventHandler(this.comboDistanciasConjuntos_SelectedIndexChanged);
            this.comboDistanciasConjuntos.Click += new System.EventHandler(this.comboDistanciasConjuntos_Click);
            // 
            // botonClasificarConjuntos
            // 
            this.botonClasificarConjuntos.Location = new System.Drawing.Point(545, 419);
            this.botonClasificarConjuntos.Name = "botonClasificarConjuntos";
            this.botonClasificarConjuntos.Size = new System.Drawing.Size(128, 51);
            this.botonClasificarConjuntos.TabIndex = 21;
            this.botonClasificarConjuntos.Text = "Clasificar";
            this.tipInformacion.SetToolTip(this.botonClasificarConjuntos, "Clasifica los nuevos casos en función de los parámetros elegidos");
            this.botonClasificarConjuntos.UseVisualStyleBackColor = true;
            this.botonClasificarConjuntos.Click += new System.EventHandler(this.botonCalcularConjuntos_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label13);
            this.groupBox12.Controls.Add(this.textBoxConjuntos);
            this.groupBox12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox12.Location = new System.Drawing.Point(47, 89);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(332, 288);
            this.groupBox12.TabIndex = 20;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Nuevos casos a clasificar:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(38, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(243, 52);
            this.label13.TabIndex = 8;
            this.label13.Text = "Ejemplo:\r\n\r\n(elemento1, elemento2, elemento3, ..., elementoX)\r\n(elemento1, elemen" +
                "to2, elemento3, ..., elementoY)";
            // 
            // textBoxConjuntos
            // 
            this.textBoxConjuntos.AcceptsReturn = true;
            this.textBoxConjuntos.Location = new System.Drawing.Point(26, 98);
            this.textBoxConjuntos.Multiline = true;
            this.textBoxConjuntos.Name = "textBoxConjuntos";
            this.textBoxConjuntos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConjuntos.Size = new System.Drawing.Size(267, 169);
            this.textBoxConjuntos.TabIndex = 0;
            this.tipInformacion.SetToolTip(this.textBoxConjuntos, "Cuadro de introducción de casos a clasificar\r\n\r\nLos conjuntos introducidos deben " +
                    "almacenar, o bien todo números, o bien todo cadenas");
            // 
            // toolStripConj
            // 
            this.toolStripConj.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripConj.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonMenuCargarDataConj,
            this.toolStripSeparator17,
            this.botonMenuCargarCasesConj,
            this.toolStripSeparator18,
            this.botonMenuGuardarConj,
            this.toolStripSeparator19,
            this.botonMenuClasificar});
            this.toolStripConj.Location = new System.Drawing.Point(3, 27);
            this.toolStripConj.Name = "toolStripConj";
            this.toolStripConj.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripConj.Size = new System.Drawing.Size(798, 25);
            this.toolStripConj.TabIndex = 19;
            this.toolStripConj.Text = "toolStrip6";
            // 
            // botonMenuCargarDataConj
            // 
            this.botonMenuCargarDataConj.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarDataConj.Image")));
            this.botonMenuCargarDataConj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarDataConj.Name = "botonMenuCargarDataConj";
            this.botonMenuCargarDataConj.Size = new System.Drawing.Size(193, 22);
            this.botonMenuCargarDataConj.Text = "Cargar conjunto de entrenamiento";
            this.botonMenuCargarDataConj.Click += new System.EventHandler(this.menuCargarData_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuCargarCasesConj
            // 
            this.botonMenuCargarCasesConj.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarCasesConj.Image")));
            this.botonMenuCargarCasesConj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarCasesConj.Name = "botonMenuCargarCasesConj";
            this.botonMenuCargarCasesConj.Size = new System.Drawing.Size(143, 22);
            this.botonMenuCargarCasesConj.Text = "Cargar casos a clasificar";
            this.botonMenuCargarCasesConj.ToolTipText = "Cargar casos a clasificar\r\n\r\nLos conjuntos introducidos deben almacenar, o bien t" +
                "odo números, o bien todo cadenas";
            this.botonMenuCargarCasesConj.Click += new System.EventHandler(this.menuCargarCases_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuGuardarConj
            // 
            this.botonMenuGuardarConj.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuGuardarConj.Image")));
            this.botonMenuGuardarConj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuGuardarConj.Name = "botonMenuGuardarConj";
            this.botonMenuGuardarConj.Size = new System.Drawing.Size(119, 22);
            this.botonMenuGuardarConj.Text = "Guardar resultados";
            this.botonMenuGuardarConj.ToolTipText = "Guardar resultados directamente en un fichero sin mostrarlos";
            this.botonMenuGuardarConj.Click += new System.EventHandler(this.botonMenuGuardar_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuClasificar
            // 
            this.botonMenuClasificar.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuClasificar.Image")));
            this.botonMenuClasificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuClasificar.Name = "botonMenuClasificar";
            this.botonMenuClasificar.Size = new System.Drawing.Size(70, 22);
            this.botonMenuClasificar.Text = "Clasificar";
            this.botonMenuClasificar.ToolTipText = "Clasifica los nuevos casos en función de los parámetros elegidos";
            this.botonMenuClasificar.Click += new System.EventHandler(this.botonCalcularConjuntos_Click);
            // 
            // menuStripConj
            // 
            this.menuStripConj.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem37,
            this.toolStripMenuItem43,
            this.ayudaToolStripMenuItem2});
            this.menuStripConj.Location = new System.Drawing.Point(3, 3);
            this.menuStripConj.Name = "menuStripConj";
            this.menuStripConj.Size = new System.Drawing.Size(798, 24);
            this.menuStripConj.TabIndex = 18;
            this.menuStripConj.Text = "menuStrip6";
            // 
            // toolStripMenuItem37
            // 
            this.toolStripMenuItem37.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem38,
            this.toolStripMenuItem40,
            this.toolStripSeparator12,
            this.clasificarToolStripMenuItem,
            this.toolStripMenuItem42});
            this.toolStripMenuItem37.Name = "toolStripMenuItem37";
            this.toolStripMenuItem37.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItem37.Text = "Archivo";
            // 
            // toolStripMenuItem38
            // 
            this.toolStripMenuItem38.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem39,
            this.casosAClasificarToolStripMenuItem1});
            this.toolStripMenuItem38.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem38.Image")));
            this.toolStripMenuItem38.Name = "toolStripMenuItem38";
            this.toolStripMenuItem38.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem38.Text = "Cargar";
            // 
            // toolStripMenuItem39
            // 
            this.toolStripMenuItem39.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem39.Image")));
            this.toolStripMenuItem39.Name = "toolStripMenuItem39";
            this.toolStripMenuItem39.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem39.Text = "Conjunto de entrenamiento";
            this.toolStripMenuItem39.Click += new System.EventHandler(this.menuCargarData_Click);
            // 
            // casosAClasificarToolStripMenuItem1
            // 
            this.casosAClasificarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("casosAClasificarToolStripMenuItem1.Image")));
            this.casosAClasificarToolStripMenuItem1.Name = "casosAClasificarToolStripMenuItem1";
            this.casosAClasificarToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.casosAClasificarToolStripMenuItem1.Text = "Casos a clasificar";
            this.casosAClasificarToolStripMenuItem1.Click += new System.EventHandler(this.menuCargarCases_Click);
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem40.Image")));
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem40.Text = "Guardar resultados";
            this.toolStripMenuItem40.Click += new System.EventHandler(this.botonMenuGuardar_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(174, 6);
            // 
            // clasificarToolStripMenuItem
            // 
            this.clasificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clasificarToolStripMenuItem.Image")));
            this.clasificarToolStripMenuItem.Name = "clasificarToolStripMenuItem";
            this.clasificarToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clasificarToolStripMenuItem.Text = "Clasificar";
            this.clasificarToolStripMenuItem.Click += new System.EventHandler(this.botonCalcularConjuntos_Click);
            // 
            // toolStripMenuItem42
            // 
            this.toolStripMenuItem42.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem42.Image")));
            this.toolStripMenuItem42.Name = "toolStripMenuItem42";
            this.toolStripMenuItem42.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem42.Text = "Salir";
            this.toolStripMenuItem42.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // toolStripMenuItem43
            // 
            this.toolStripMenuItem43.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1,
            this.toolStripMenuItem44,
            this.toolStripSeparator11,
            this.pesadoDeCasosToolStripMenuItem1,
            this.toolStripSeparator20,
            this.modoDeValidacionCruzadaToolStripMenuItem1});
            this.toolStripMenuItem43.Name = "toolStripMenuItem43";
            this.toolStripMenuItem43.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem43.Text = "Configurar";
            // 
            // mostrarConjuntoDeEntrenamientoToolStripMenuItem1
            // 
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("mostrarConjuntoDeEntrenamientoToolStripMenuItem1.Image")));
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1.Name = "mostrarConjuntoDeEntrenamientoToolStripMenuItem1";
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1.Size = new System.Drawing.Size(255, 22);
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1.Text = "Mostrar conjunto de entrenamiento";
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem1.Click += new System.EventHandler(this.mostrarConjuntoDeEntrenamientoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem44
            // 
            this.toolStripMenuItem44.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem44.Image")));
            this.toolStripMenuItem44.Name = "toolStripMenuItem44";
            this.toolStripMenuItem44.Size = new System.Drawing.Size(255, 22);
            this.toolStripMenuItem44.Text = "Ampliar conjunto de entrenamiento";
            this.toolStripMenuItem44.Click += new System.EventHandler(this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(252, 6);
            // 
            // pesadoDeCasosToolStripMenuItem1
            // 
            this.pesadoDeCasosToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("pesadoDeCasosToolStripMenuItem1.Image")));
            this.pesadoDeCasosToolStripMenuItem1.Name = "pesadoDeCasosToolStripMenuItem1";
            this.pesadoDeCasosToolStripMenuItem1.Size = new System.Drawing.Size(255, 22);
            this.pesadoDeCasosToolStripMenuItem1.Text = "Pesado de casos";
            this.pesadoDeCasosToolStripMenuItem1.Click += new System.EventHandler(this.botonPesadoCasosConjuntos_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(252, 6);
            // 
            // modoDeValidacionCruzadaToolStripMenuItem1
            // 
            this.modoDeValidacionCruzadaToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("modoDeValidacionCruzadaToolStripMenuItem1.Image")));
            this.modoDeValidacionCruzadaToolStripMenuItem1.Name = "modoDeValidacionCruzadaToolStripMenuItem1";
            this.modoDeValidacionCruzadaToolStripMenuItem1.Size = new System.Drawing.Size(255, 22);
            this.modoDeValidacionCruzadaToolStripMenuItem1.Text = "Modo de validación cruzada";
            this.modoDeValidacionCruzadaToolStripMenuItem1.Click += new System.EventHandler(this.modoDeValidacionCruzadaToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem2
            // 
            this.ayudaToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contenidoDeLaAyudaToolStripMenuItem,
            this.acercaDeToolStripMenuItem1});
            this.ayudaToolStripMenuItem2.Name = "ayudaToolStripMenuItem2";
            this.ayudaToolStripMenuItem2.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem2.Text = "Ayuda";
            // 
            // contenidoDeLaAyudaToolStripMenuItem
            // 
            this.contenidoDeLaAyudaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contenidoDeLaAyudaToolStripMenuItem.Image")));
            this.contenidoDeLaAyudaToolStripMenuItem.Name = "contenidoDeLaAyudaToolStripMenuItem";
            this.contenidoDeLaAyudaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.contenidoDeLaAyudaToolStripMenuItem.Text = "Contenido de la ayuda";
            this.contenidoDeLaAyudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem1_Click);
            // 
            // acercaDeToolStripMenuItem1
            // 
            this.acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            this.acercaDeToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.acercaDeToolStripMenuItem1.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem1.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // tabVectores
            // 
            this.tabVectores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.tabVectores.Controls.Add(this.labelCVect);
            this.tabVectores.Controls.Add(this.boxCVect);
            this.tabVectores.Controls.Add(this.botonPesadoCasosVectores);
            this.tabVectores.Controls.Add(this.checkRegresion);
            this.tabVectores.Controls.Add(this.textRechazoVect);
            this.tabVectores.Controls.Add(this.boxRechazoVect);
            this.tabVectores.Controls.Add(this.checkRechazoVect);
            this.tabVectores.Controls.Add(this.botonPesadoAtributosVectores);
            this.tabVectores.Controls.Add(this.groupBoxNormalizacion);
            this.tabVectores.Controls.Add(this.toolStripVect);
            this.tabVectores.Controls.Add(this.menuStripVect);
            this.tabVectores.Controls.Add(this.labelKVect);
            this.tabVectores.Controls.Add(this.cuadroKVectores);
            this.tabVectores.Controls.Add(this.botonClasificarVectores);
            this.tabVectores.Controls.Add(this.groupBox2);
            this.tabVectores.Controls.Add(this.groupBox1);
            this.tabVectores.Location = new System.Drawing.Point(4, 22);
            this.tabVectores.Name = "tabVectores";
            this.tabVectores.Padding = new System.Windows.Forms.Padding(3);
            this.tabVectores.Size = new System.Drawing.Size(804, 509);
            this.tabVectores.TabIndex = 1;
            this.tabVectores.Text = "Vectores";
            // 
            // labelCVect
            // 
            this.labelCVect.AutoSize = true;
            this.labelCVect.Location = new System.Drawing.Point(444, 404);
            this.labelCVect.Name = "labelCVect";
            this.labelCVect.Size = new System.Drawing.Size(222, 13);
            this.labelCVect.TabIndex = 26;
            this.labelCVect.Text = "Nº de subconjuntos en que dividir el principal:";
            this.labelCVect.Visible = false;
            // 
            // boxCVect
            // 
            this.boxCVect.Location = new System.Drawing.Point(671, 401);
            this.boxCVect.Name = "boxCVect";
            this.boxCVect.Size = new System.Drawing.Size(45, 20);
            this.boxCVect.TabIndex = 25;
            this.boxCVect.Visible = false;
            // 
            // botonPesadoCasosVectores
            // 
            this.botonPesadoCasosVectores.Location = new System.Drawing.Point(614, 340);
            this.botonPesadoCasosVectores.Name = "botonPesadoCasosVectores";
            this.botonPesadoCasosVectores.Size = new System.Drawing.Size(96, 41);
            this.botonPesadoCasosVectores.TabIndex = 23;
            this.botonPesadoCasosVectores.Text = "Pesado de casos";
            this.tipInformacion.SetToolTip(this.botonPesadoCasosVectores, "Muestra la ventana para asignar pesos a los casos");
            this.botonPesadoCasosVectores.UseVisualStyleBackColor = true;
            this.botonPesadoCasosVectores.Click += new System.EventHandler(this.botonPesadoCasosVectores_Click);
            // 
            // checkRegresion
            // 
            this.checkRegresion.AutoSize = true;
            this.checkRegresion.Location = new System.Drawing.Point(43, 435);
            this.checkRegresion.Name = "checkRegresion";
            this.checkRegresion.Size = new System.Drawing.Size(94, 17);
            this.checkRegresion.TabIndex = 20;
            this.checkRegresion.Text = "Usar regresión";
            this.tipInformacion.SetToolTip(this.checkRegresion, "Para poder usar regresión, las clases de los casos conocidos del conjunto de entr" +
                    "enamiento deben ser númericas\r\n");
            this.checkRegresion.UseVisualStyleBackColor = true;
            // 
            // textRechazoVect
            // 
            this.textRechazoVect.AutoSize = true;
            this.textRechazoVect.Location = new System.Drawing.Point(166, 469);
            this.textRechazoVect.Name = "textRechazoVect";
            this.textRechazoVect.Size = new System.Drawing.Size(174, 13);
            this.textRechazoVect.TabIndex = 19;
            this.textRechazoVect.Text = "si el número de votos es menor que";
            this.textRechazoVect.Visible = false;
            // 
            // boxRechazoVect
            // 
            this.boxRechazoVect.Location = new System.Drawing.Point(346, 465);
            this.boxRechazoVect.Name = "boxRechazoVect";
            this.boxRechazoVect.Size = new System.Drawing.Size(45, 20);
            this.boxRechazoVect.TabIndex = 18;
            this.boxRechazoVect.Visible = false;
            // 
            // checkRechazoVect
            // 
            this.checkRechazoVect.AutoSize = true;
            this.checkRechazoVect.Location = new System.Drawing.Point(43, 468);
            this.checkRechazoVect.Name = "checkRechazoVect";
            this.checkRechazoVect.Size = new System.Drawing.Size(130, 17);
            this.checkRechazoVect.TabIndex = 17;
            this.checkRechazoVect.Text = "Votación con rechazo";
            this.checkRechazoVect.UseVisualStyleBackColor = true;
            this.checkRechazoVect.CheckedChanged += new System.EventHandler(this.checkRechazo_CheckedChanged);
            // 
            // botonPesadoAtributosVectores
            // 
            this.botonPesadoAtributosVectores.Location = new System.Drawing.Point(487, 340);
            this.botonPesadoAtributosVectores.Name = "botonPesadoAtributosVectores";
            this.botonPesadoAtributosVectores.Size = new System.Drawing.Size(96, 41);
            this.botonPesadoAtributosVectores.TabIndex = 16;
            this.botonPesadoAtributosVectores.Text = "Pesado de atributos";
            this.tipInformacion.SetToolTip(this.botonPesadoAtributosVectores, "Muestra la ventana para asignar pesos a los atributos");
            this.botonPesadoAtributosVectores.UseVisualStyleBackColor = true;
            this.botonPesadoAtributosVectores.Click += new System.EventHandler(this.botonPesadoAtributosVectores_Click);
            // 
            // groupBoxNormalizacion
            // 
            this.groupBoxNormalizacion.Controls.Add(this.comboTipoNormVect);
            this.groupBoxNormalizacion.Controls.Add(this.labelNormalizar);
            this.groupBoxNormalizacion.Controls.Add(this.boxBVect);
            this.groupBoxNormalizacion.Controls.Add(this.labelBVect);
            this.groupBoxNormalizacion.Controls.Add(this.boxAVect);
            this.groupBoxNormalizacion.Controls.Add(this.labelAVect);
            this.groupBoxNormalizacion.Controls.Add(this.comboNormalizacionVect);
            this.groupBoxNormalizacion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBoxNormalizacion.Location = new System.Drawing.Point(451, 177);
            this.groupBoxNormalizacion.Name = "groupBoxNormalizacion";
            this.groupBoxNormalizacion.Size = new System.Drawing.Size(291, 148);
            this.groupBoxNormalizacion.TabIndex = 11;
            this.groupBoxNormalizacion.TabStop = false;
            this.groupBoxNormalizacion.Text = "Tipo de normalización:";
            // 
            // comboTipoNormVect
            // 
            this.comboTipoNormVect.FormattingEnabled = true;
            this.comboTipoNormVect.Items.AddRange(new object[] {
            "Todos los atributos",
            "Un atributo concreto y"});
            this.comboTipoNormVect.Location = new System.Drawing.Point(73, 112);
            this.comboTipoNormVect.Name = "comboTipoNormVect";
            this.comboTipoNormVect.Size = new System.Drawing.Size(192, 21);
            this.comboTipoNormVect.TabIndex = 16;
            this.comboTipoNormVect.Text = "Todos los atributos (Por defecto)";
            this.comboTipoNormVect.SelectedIndexChanged += new System.EventHandler(this.comboTipoNormVect_SelectedIndexChanged);
            this.comboTipoNormVect.Click += new System.EventHandler(this.comboTipoNormVect_Click);
            // 
            // labelNormalizar
            // 
            this.labelNormalizar.AutoSize = true;
            this.labelNormalizar.Location = new System.Drawing.Point(12, 115);
            this.labelNormalizar.Name = "labelNormalizar";
            this.labelNormalizar.Size = new System.Drawing.Size(56, 13);
            this.labelNormalizar.TabIndex = 11;
            this.labelNormalizar.Text = "Normalizar";
            // 
            // boxBVect
            // 
            this.boxBVect.Location = new System.Drawing.Point(188, 72);
            this.boxBVect.Name = "boxBVect";
            this.boxBVect.Size = new System.Drawing.Size(39, 20);
            this.boxBVect.TabIndex = 4;
            this.boxBVect.Visible = false;
            // 
            // labelBVect
            // 
            this.labelBVect.AutoSize = true;
            this.labelBVect.Location = new System.Drawing.Point(160, 75);
            this.labelBVect.Name = "labelBVect";
            this.labelBVect.Size = new System.Drawing.Size(22, 13);
            this.labelBVect.TabIndex = 3;
            this.labelBVect.Text = "b =";
            this.labelBVect.Visible = false;
            // 
            // boxAVect
            // 
            this.boxAVect.Location = new System.Drawing.Point(73, 72);
            this.boxAVect.Name = "boxAVect";
            this.boxAVect.Size = new System.Drawing.Size(39, 20);
            this.boxAVect.TabIndex = 2;
            this.boxAVect.Visible = false;
            // 
            // labelAVect
            // 
            this.labelAVect.AutoSize = true;
            this.labelAVect.Location = new System.Drawing.Point(44, 75);
            this.labelAVect.Name = "labelAVect";
            this.labelAVect.Size = new System.Drawing.Size(22, 13);
            this.labelAVect.TabIndex = 1;
            this.labelAVect.Text = "a =";
            this.labelAVect.Visible = false;
            // 
            // comboNormalizacionVect
            // 
            this.comboNormalizacionVect.FormattingEnabled = true;
            this.comboNormalizacionVect.Items.AddRange(new object[] {
            "Intervalo [0,1]",
            "Intervalo [a,b]",
            "Media cero y varianza unidad",
            "No normalizar"});
            this.comboNormalizacionVect.Location = new System.Drawing.Point(36, 35);
            this.comboNormalizacionVect.Name = "comboNormalizacionVect";
            this.comboNormalizacionVect.Size = new System.Drawing.Size(229, 21);
            this.comboNormalizacionVect.TabIndex = 0;
            this.comboNormalizacionVect.Text = "Intervalo [0,1] (Por defecto)";
            this.comboNormalizacionVect.SelectedIndexChanged += new System.EventHandler(this.comboNormalizacion_SelectedIndexChanged);
            // 
            // toolStripVect
            // 
            this.toolStripVect.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripVect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonMenuCargarNames,
            this.toolStripSeparator5,
            this.botonMenuCargarDataVect,
            this.toolStripSeparator6,
            this.botonMenuCargarCasesVect,
            this.toolStripSeparator4,
            this.botonMenuGuardarVect,
            this.toolStripSeparator1,
            this.botonMenuClasificarVect});
            this.toolStripVect.Location = new System.Drawing.Point(3, 27);
            this.toolStripVect.Name = "toolStripVect";
            this.toolStripVect.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripVect.Size = new System.Drawing.Size(798, 25);
            this.toolStripVect.TabIndex = 15;
            this.toolStripVect.Text = "toolStrip1";
            // 
            // botonMenuCargarNames
            // 
            this.botonMenuCargarNames.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarNames.Image")));
            this.botonMenuCargarNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarNames.Name = "botonMenuCargarNames";
            this.botonMenuCargarNames.Size = new System.Drawing.Size(147, 22);
            this.botonMenuCargarNames.Text = "Cargar clases y atributos";
            this.botonMenuCargarNames.Click += new System.EventHandler(this.menuCargarNamesVectores_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuCargarDataVect
            // 
            this.botonMenuCargarDataVect.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarDataVect.Image")));
            this.botonMenuCargarDataVect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarDataVect.Name = "botonMenuCargarDataVect";
            this.botonMenuCargarDataVect.Size = new System.Drawing.Size(193, 22);
            this.botonMenuCargarDataVect.Text = "Cargar conjunto de entrenamiento";
            this.botonMenuCargarDataVect.Click += new System.EventHandler(this.menuCargarData_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuCargarCasesVect
            // 
            this.botonMenuCargarCasesVect.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuCargarCasesVect.Image")));
            this.botonMenuCargarCasesVect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuCargarCasesVect.Name = "botonMenuCargarCasesVect";
            this.botonMenuCargarCasesVect.Size = new System.Drawing.Size(143, 22);
            this.botonMenuCargarCasesVect.Text = "Cargar casos a clasificar";
            this.botonMenuCargarCasesVect.Click += new System.EventHandler(this.menuCargarCases_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuGuardarVect
            // 
            this.botonMenuGuardarVect.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuGuardarVect.Image")));
            this.botonMenuGuardarVect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuGuardarVect.Name = "botonMenuGuardarVect";
            this.botonMenuGuardarVect.Size = new System.Drawing.Size(119, 22);
            this.botonMenuGuardarVect.Text = "Guardar resultados";
            this.botonMenuGuardarVect.ToolTipText = "Guardar resultados directamente en un fichero sin mostrarlos";
            this.botonMenuGuardarVect.Click += new System.EventHandler(this.botonMenuGuardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // botonMenuClasificarVect
            // 
            this.botonMenuClasificarVect.Image = ((System.Drawing.Image)(resources.GetObject("botonMenuClasificarVect.Image")));
            this.botonMenuClasificarVect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonMenuClasificarVect.Name = "botonMenuClasificarVect";
            this.botonMenuClasificarVect.Size = new System.Drawing.Size(70, 22);
            this.botonMenuClasificarVect.Text = "Clasificar";
            this.botonMenuClasificarVect.ToolTipText = "Clasifica los nuevos casos en función de los parámetros elegidos";
            this.botonMenuClasificarVect.Click += new System.EventHandler(this.botonCalcularVectores_Click);
            // 
            // menuStripVect
            // 
            this.menuStripVect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.opcionesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStripVect.Location = new System.Drawing.Point(3, 3);
            this.menuStripVect.Name = "menuStripVect";
            this.menuStripVect.Size = new System.Drawing.Size(798, 24);
            this.menuStripVect.TabIndex = 14;
            this.menuStripVect.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.toolStripSeparator8,
            this.clasificarToolStripMenuItem2,
            this.menuSalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCargarNames,
            this.menuCargarData,
            this.casosAClasificarToolStripMenuItem2});
            this.cargarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cargarToolStripMenuItem.Image")));
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cargarToolStripMenuItem.Text = "Cargar";
            // 
            // menuCargarNames
            // 
            this.menuCargarNames.Image = ((System.Drawing.Image)(resources.GetObject("menuCargarNames.Image")));
            this.menuCargarNames.Name = "menuCargarNames";
            this.menuCargarNames.Size = new System.Drawing.Size(217, 22);
            this.menuCargarNames.Text = "Clases y atributos";
            this.menuCargarNames.Click += new System.EventHandler(this.menuCargarNamesVectores_Click);
            // 
            // menuCargarData
            // 
            this.menuCargarData.Image = ((System.Drawing.Image)(resources.GetObject("menuCargarData.Image")));
            this.menuCargarData.Name = "menuCargarData";
            this.menuCargarData.Size = new System.Drawing.Size(217, 22);
            this.menuCargarData.Text = "Conjunto de entrenamiento";
            this.menuCargarData.Click += new System.EventHandler(this.menuCargarData_Click);
            // 
            // casosAClasificarToolStripMenuItem2
            // 
            this.casosAClasificarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("casosAClasificarToolStripMenuItem2.Image")));
            this.casosAClasificarToolStripMenuItem2.Name = "casosAClasificarToolStripMenuItem2";
            this.casosAClasificarToolStripMenuItem2.Size = new System.Drawing.Size(217, 22);
            this.casosAClasificarToolStripMenuItem2.Text = "Casos a clasificar";
            this.casosAClasificarToolStripMenuItem2.Click += new System.EventHandler(this.menuCargarCases_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.guardarToolStripMenuItem.Text = "Guardar resultados";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.botonMenuGuardar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(174, 6);
            // 
            // clasificarToolStripMenuItem2
            // 
            this.clasificarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("clasificarToolStripMenuItem2.Image")));
            this.clasificarToolStripMenuItem2.Name = "clasificarToolStripMenuItem2";
            this.clasificarToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
            this.clasificarToolStripMenuItem2.Text = "Clasificar";
            this.clasificarToolStripMenuItem2.Click += new System.EventHandler(this.botonCalcularVectores_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Image = ((System.Drawing.Image)(resources.GetObject("menuSalir.Image")));
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(177, 22);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarClasesYAtributosToolStripMenuItem,
            this.ignorarAtributosToolStripMenuItem,
            this.toolStripSeparator3,
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem,
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem,
            this.toolStripSeparator7,
            this.pesadoDeAtributosToolStripMenuItem,
            this.pesadoDeCasosToolStripMenuItem,
            this.toolStripSeparator16,
            this.tratamientoDeValoresDesconocidosToolStripMenuItem,
            this.transformarAtributosMenuItem,
            this.toolStripSeparator15,
            this.modoDeValidacionCruzadaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.opcionesToolStripMenuItem.Text = "Configurar";
            // 
            // mostrarClasesYAtributosToolStripMenuItem
            // 
            this.mostrarClasesYAtributosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostrarClasesYAtributosToolStripMenuItem.Image")));
            this.mostrarClasesYAtributosToolStripMenuItem.Name = "mostrarClasesYAtributosToolStripMenuItem";
            this.mostrarClasesYAtributosToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.mostrarClasesYAtributosToolStripMenuItem.Text = "Mostrar clases y atributos";
            this.mostrarClasesYAtributosToolStripMenuItem.Click += new System.EventHandler(this.mostrarClasesYAtributosToolStripMenuItem_Click);
            // 
            // ignorarAtributosToolStripMenuItem
            // 
            this.ignorarAtributosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ignorarAtributosToolStripMenuItem.Image")));
            this.ignorarAtributosToolStripMenuItem.Name = "ignorarAtributosToolStripMenuItem";
            this.ignorarAtributosToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.ignorarAtributosToolStripMenuItem.Text = "Desactivar atributos";
            this.ignorarAtributosToolStripMenuItem.Click += new System.EventHandler(this.ignorarAtributosToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // mostrarConjuntoDeEntrenamientoToolStripMenuItem
            // 
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mostrarConjuntoDeEntrenamientoToolStripMenuItem.Image")));
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem.Name = "mostrarConjuntoDeEntrenamientoToolStripMenuItem";
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem.Text = "Mostrar conjunto de entrenamiento";
            this.mostrarConjuntoDeEntrenamientoToolStripMenuItem.Click += new System.EventHandler(this.mostrarConjuntoDeEntrenamientoToolStripMenuItem_Click);
            // 
            // AmpliarConjuntoDeEntrenamientoToolStripMenuItem
            // 
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AmpliarConjuntoDeEntrenamientoToolStripMenuItem.Image")));
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem.Name = "AmpliarConjuntoDeEntrenamientoToolStripMenuItem";
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem.Text = "Ampliar conjunto de entrenamiento";
            this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem.Click += new System.EventHandler(this.AmpliarConjuntoDeEntrenamientoToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(305, 6);
            // 
            // pesadoDeAtributosToolStripMenuItem
            // 
            this.pesadoDeAtributosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pesadoDeAtributosToolStripMenuItem.Image")));
            this.pesadoDeAtributosToolStripMenuItem.Name = "pesadoDeAtributosToolStripMenuItem";
            this.pesadoDeAtributosToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.pesadoDeAtributosToolStripMenuItem.Text = "Pesado de atributos";
            this.pesadoDeAtributosToolStripMenuItem.Click += new System.EventHandler(this.botonPesadoAtributosVectores_Click);
            // 
            // pesadoDeCasosToolStripMenuItem
            // 
            this.pesadoDeCasosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pesadoDeCasosToolStripMenuItem.Image")));
            this.pesadoDeCasosToolStripMenuItem.Name = "pesadoDeCasosToolStripMenuItem";
            this.pesadoDeCasosToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.pesadoDeCasosToolStripMenuItem.Text = "Pesado de casos";
            this.pesadoDeCasosToolStripMenuItem.Click += new System.EventHandler(this.botonPesadoCasosVectores_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(305, 6);
            // 
            // tratamientoDeValoresDesconocidosToolStripMenuItem
            // 
            this.tratamientoDeValoresDesconocidosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tratamientoDeValoresDesconocidosToolStripMenuItem.Image")));
            this.tratamientoDeValoresDesconocidosToolStripMenuItem.Name = "tratamientoDeValoresDesconocidosToolStripMenuItem";
            this.tratamientoDeValoresDesconocidosToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.tratamientoDeValoresDesconocidosToolStripMenuItem.Text = "Tratamiento de valores desconocidos";
            this.tratamientoDeValoresDesconocidosToolStripMenuItem.Click += new System.EventHandler(this.tratamientoDeValoresDesconocidosToolStripMenuItem_Click);
            // 
            // transformarAtributosMenuItem
            // 
            this.transformarAtributosMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("transformarAtributosMenuItem.Image")));
            this.transformarAtributosMenuItem.Name = "transformarAtributosMenuItem";
            this.transformarAtributosMenuItem.Size = new System.Drawing.Size(308, 22);
            this.transformarAtributosMenuItem.Text = "Transformar atributos cualitativos a booleanos";
            this.transformarAtributosMenuItem.Click += new System.EventHandler(this.transformarAtributosMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(305, 6);
            // 
            // modoDeValidacionCruzadaToolStripMenuItem
            // 
            this.modoDeValidacionCruzadaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modoDeValidacionCruzadaToolStripMenuItem.Image")));
            this.modoDeValidacionCruzadaToolStripMenuItem.Name = "modoDeValidacionCruzadaToolStripMenuItem";
            this.modoDeValidacionCruzadaToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.modoDeValidacionCruzadaToolStripMenuItem.Text = "Modo de validación cruzada";
            this.modoDeValidacionCruzadaToolStripMenuItem.Click += new System.EventHandler(this.modoDeValidacionCruzadaToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayudaToolStripMenuItem1,
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ayudaToolStripMenuItem1
            // 
            this.ayudaToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ayudaToolStripMenuItem1.Image")));
            this.ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            this.ayudaToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.ayudaToolStripMenuItem1.Text = "Contenido de la ayuda";
            this.ayudaToolStripMenuItem1.Click += new System.EventHandler(this.ayudaToolStripMenuItem1_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // labelKVect
            // 
            this.labelKVect.AutoSize = true;
            this.labelKVect.Location = new System.Drawing.Point(122, 388);
            this.labelKVect.Name = "labelKVect";
            this.labelKVect.Size = new System.Drawing.Size(59, 13);
            this.labelKVect.TabIndex = 13;
            this.labelKVect.Text = "Valor de K:";
            // 
            // cuadroKVectores
            // 
            this.cuadroKVectores.Location = new System.Drawing.Point(194, 385);
            this.cuadroKVectores.Name = "cuadroKVectores";
            this.cuadroKVectores.Size = new System.Drawing.Size(45, 20);
            this.cuadroKVectores.TabIndex = 12;
            // 
            // botonClasificarVectores
            // 
            this.botonClasificarVectores.Location = new System.Drawing.Point(538, 440);
            this.botonClasificarVectores.Name = "botonClasificarVectores";
            this.botonClasificarVectores.Size = new System.Drawing.Size(128, 51);
            this.botonClasificarVectores.TabIndex = 11;
            this.botonClasificarVectores.Text = "Clasificar";
            this.tipInformacion.SetToolTip(this.botonClasificarVectores, "Clasifica los nuevos casos en función de los parámetros elegidos");
            this.botonClasificarVectores.UseVisualStyleBackColor = true;
            this.botonClasificarVectores.Click += new System.EventHandler(this.botonCalcularVectores_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxQ);
            this.groupBox2.Controls.Add(this.rotuloQ);
            this.groupBox2.Controls.Add(this.comboDistanciasVectores);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox2.Location = new System.Drawing.Point(451, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 85);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distancia a aplicar:";
            // 
            // boxQ
            // 
            this.boxQ.Location = new System.Drawing.Point(141, 55);
            this.boxQ.Name = "boxQ";
            this.boxQ.Size = new System.Drawing.Size(39, 20);
            this.boxQ.TabIndex = 18;
            this.boxQ.Visible = false;
            // 
            // rotuloQ
            // 
            this.rotuloQ.AutoSize = true;
            this.rotuloQ.Location = new System.Drawing.Point(112, 58);
            this.rotuloQ.Name = "rotuloQ";
            this.rotuloQ.Size = new System.Drawing.Size(22, 13);
            this.rotuloQ.TabIndex = 17;
            this.rotuloQ.Text = "q =";
            this.rotuloQ.Visible = false;
            // 
            // comboDistanciasVectores
            // 
            this.comboDistanciasVectores.FormattingEnabled = true;
            this.comboDistanciasVectores.Items.AddRange(new object[] {
            "Minkowski",
            "Euclidea",
            "Manhattan",
            "Chebychev",
            "Divergencia",
            "Camberra",
            "Del coseno",
            "Mahalanobis"});
            this.comboDistanciasVectores.Location = new System.Drawing.Point(36, 21);
            this.comboDistanciasVectores.Name = "comboDistanciasVectores";
            this.comboDistanciasVectores.Size = new System.Drawing.Size(229, 21);
            this.comboDistanciasVectores.TabIndex = 0;
            this.comboDistanciasVectores.SelectedIndexChanged += new System.EventHandler(this.comboDistanciasVectores_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxVectores);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(47, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 288);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevos casos a clasificar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(42, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 52);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ejemplo:\r\n\r\n(atributo1, atributo2, atributo3, ..., atributoM)\r\n(atributo1, atribu" +
                "to2, atributo3, ..., atributoM)";
            // 
            // textBoxVectores
            // 
            this.textBoxVectores.AcceptsReturn = true;
            this.textBoxVectores.Location = new System.Drawing.Point(26, 98);
            this.textBoxVectores.Multiline = true;
            this.textBoxVectores.Name = "textBoxVectores";
            this.textBoxVectores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxVectores.Size = new System.Drawing.Size(267, 169);
            this.textBoxVectores.TabIndex = 0;
            this.tipInformacion.SetToolTip(this.textBoxVectores, "Cuadro de introducción de casos a clasificar");
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(266, 64);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 169);
            this.vScrollBar1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 169);
            this.textBox1.TabIndex = 0;
            // 
            // cargarNames
            // 
            this.cargarNames.FileName = "cargarNames";
            // 
            // cargarData
            // 
            this.cargarData.FileName = "cargarData";
            // 
            // cargarCases
            // 
            this.cargarCases.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nº de subconjuntos en que dividir el principal:";
            this.label1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(668, 377);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 20);
            this.textBox2.TabIndex = 28;
            this.textBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(493, 341);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Validación cruzada";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 41);
            this.button1.TabIndex = 23;
            this.button1.Text = "Pesado de casos";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "si el número de votos es menor que";
            this.label4.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(334, 435);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(45, 20);
            this.textBox3.TabIndex = 21;
            this.textBox3.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(32, 438);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(130, 17);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "Votación con rechazo";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox1);
            this.groupBox8.Location = new System.Drawing.Point(457, 72);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(291, 53);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Distancia a aplicar:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Levenshtein",
            "Hamming",
            "Lee"});
            this.comboBox1.Location = new System.Drawing.Point(36, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Valor de K:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(185, 380);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(45, 20);
            this.textBox4.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(620, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 51);
            this.button2.TabIndex = 14;
            this.button2.Text = "Clasificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.textBox5);
            this.groupBox9.Location = new System.Drawing.Point(36, 72);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(332, 288);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Nuevos casos a clasificar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(42, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 52);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ejemplo:\r\n\r\ncadena1 cadena2 cadena3 cadena(i-1)\r\ncadena(i) cadena(i+1)   ...    c" +
                "adenaC";
            // 
            // textBox5
            // 
            this.textBox5.AcceptsReturn = true;
            this.textBox5.Location = new System.Drawing.Point(26, 98);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(267, 169);
            this.textBox5.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(430, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Nº de subconjuntos en que dividir el principal:";
            this.label9.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(668, 377);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(45, 20);
            this.textBox6.TabIndex = 28;
            this.textBox6.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(493, 341);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(116, 17);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "Validación cruzada";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(556, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 41);
            this.button3.TabIndex = 23;
            this.button3.Text = "Pesado de casos";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "si el número de votos es menor que";
            this.label10.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(334, 435);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(45, 20);
            this.textBox7.TabIndex = 21;
            this.textBox7.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(32, 438);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(130, 17);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.Text = "Votación con rechazo";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox2);
            this.groupBox10.Location = new System.Drawing.Point(457, 72);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(291, 53);
            this.groupBox10.TabIndex = 19;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Distancia a aplicar:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Levenshtein",
            "Hamming",
            "Lee"});
            this.comboBox2.Location = new System.Drawing.Point(36, 21);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(229, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(89, 383);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Valor de K:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(185, 380);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(45, 20);
            this.textBox8.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(620, 420);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 51);
            this.button4.TabIndex = 14;
            this.button4.Text = "Clasificar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label12);
            this.groupBox11.Controls.Add(this.textBox9);
            this.groupBox11.Location = new System.Drawing.Point(36, 72);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(332, 288);
            this.groupBox11.TabIndex = 10;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Nuevos casos a clasificar:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(42, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 52);
            this.label12.TabIndex = 7;
            this.label12.Text = "Ejemplo:\r\n\r\ncadena1 cadena2 cadena3 cadena(i-1)\r\ncadena(i) cadena(i+1)   ...    c" +
                "adenaC";
            // 
            // textBox9
            // 
            this.textBox9.AcceptsReturn = true;
            this.textBox9.Location = new System.Drawing.Point(26, 98);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox9.Size = new System.Drawing.Size(267, 169);
            this.textBox9.TabIndex = 0;
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "";
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(836, 559);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VentanaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entorno de clasificación basada en la proximidad";
            this.tabControl.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagen)).EndInit();
            this.tabCadenas.ResumeLayout(false);
            this.tabCadenas.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.toolStripCad.ResumeLayout(false);
            this.toolStripCad.PerformLayout();
            this.menuStripCad.ResumeLayout(false);
            this.menuStripCad.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabConjuntos.ResumeLayout(false);
            this.tabConjuntos.PerformLayout();
            this.cuadroEspacioBase.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.toolStripConj.ResumeLayout(false);
            this.toolStripConj.PerformLayout();
            this.menuStripConj.ResumeLayout(false);
            this.menuStripConj.PerformLayout();
            this.tabVectores.ResumeLayout(false);
            this.tabVectores.PerformLayout();
            this.groupBoxNormalizacion.ResumeLayout(false);
            this.groupBoxNormalizacion.PerformLayout();
            this.toolStripVect.ResumeLayout(false);
            this.toolStripVect.PerformLayout();
            this.menuStripVect.ResumeLayout(false);
            this.menuStripVect.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCadenas;
        private System.Windows.Forms.TabPage tabVectores;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.Button botonClasificarVectores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxVectores;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog cargarNames;
        private System.Windows.Forms.OpenFileDialog cargarData;
        private System.Windows.Forms.Label labelKVect;
        private System.Windows.Forms.TextBox cuadroKVectores;
        private System.Windows.Forms.MenuStrip menuStripVect;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuCargarNames;
        private System.Windows.Forms.ToolStripMenuItem menuCargarData;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AmpliarConjuntoDeEntrenamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignorarAtributosToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCadenas;
        private System.Windows.Forms.Label labelKCad;
        private System.Windows.Forms.TextBox cuadroKCadenas;
        private System.Windows.Forms.Button botonClasificarCadenas;
        private System.Windows.Forms.ToolStrip toolStripVect;
        private System.Windows.Forms.ToolStripButton botonMenuCargarNames;
        private System.Windows.Forms.ToolStripButton botonMenuCargarDataVect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStripCad;
        private System.Windows.Forms.ToolStripButton botonMenuCargarDataCad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.MenuStrip menuStripCad;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.RichTextBox textoIntroduccion;
        private System.Windows.Forms.ComboBox comboDistanciasVectores;
        private System.Windows.Forms.GroupBox groupBoxNormalizacion;
        private System.Windows.Forms.ComboBox comboNormalizacionVect;
        private System.Windows.Forms.TextBox boxAVect;
        private System.Windows.Forms.Label labelAVect;
        private System.Windows.Forms.ComboBox comboTipoNormVect;
        private System.Windows.Forms.Label labelNormalizar;
        private System.Windows.Forms.TextBox boxBVect;
        private System.Windows.Forms.Label labelBVect;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboDistanciasCadenas;
        private System.Windows.Forms.Button botonPesadoAtributosVectores;
        private System.Windows.Forms.TextBox boxQ;
        private System.Windows.Forms.Label rotuloQ;
        private System.Windows.Forms.CheckBox checkRechazoVect;
        private System.Windows.Forms.Label textRechazoVect;
        private System.Windows.Forms.TextBox boxRechazoVect;
        private System.Windows.Forms.Label textRechazoCad;
        private System.Windows.Forms.TextBox boxRechazoCad;
        private System.Windows.Forms.CheckBox checkRechazoCad;
        private System.Windows.Forms.CheckBox checkRegresion;
        private System.Windows.Forms.Button botonPesadoCasosVectores;
        private System.Windows.Forms.Button botonPesadoCasosCadenas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label labelCVect;
        private System.Windows.Forms.TextBox boxCVect;
        private System.Windows.Forms.Label labelCCad;
        private System.Windows.Forms.TextBox boxCCad;
        private System.Windows.Forms.ToolTip tipInformacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton botonMenuCargarCasesVect;
        private System.Windows.Forms.ToolStripButton botonMenuClasificarVect;
        private System.Windows.Forms.ToolStripButton botonMenuCargarCasesCad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton botonMenuClasificarCad;
        private System.Windows.Forms.OpenFileDialog cargarCases;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton botonMenuGuardarCad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton botonMenuGuardarVect;
        private System.Windows.Forms.SaveFileDialog guardarResultados;
        private System.Windows.Forms.TabPage tabConjuntos;
        private System.Windows.Forms.ToolStrip toolStripConj;
        private System.Windows.Forms.ToolStripButton botonMenuCargarDataConj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton botonMenuCargarCasesConj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton botonMenuGuardarConj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton botonMenuClasificar;
        private System.Windows.Forms.MenuStrip menuStripConj;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem37;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem38;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem39;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem40;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem42;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem43;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem44;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button botonClasificarConjuntos;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxConjuntos;
        private System.Windows.Forms.Button botonPesadoCasosConjuntos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboDistanciasConjuntos;
        private System.Windows.Forms.Label labelCConj;
        private System.Windows.Forms.TextBox boxCConj;
        private System.Windows.Forms.Label textRechazoConj;
        private System.Windows.Forms.TextBox boxRechazoConj;
        private System.Windows.Forms.CheckBox checkRechazoConj;
        private System.Windows.Forms.Label labelKConj;
        private System.Windows.Forms.TextBox cuadroKConjuntos;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem contenidoDeLaAyudaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem contenidoDeLaAyudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem casosAClasificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem casosAClasificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clasificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem casosAClasificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clasificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modoDeValidacionCruzadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoDeValidacionCruzadaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modoDeValidacionCruzadaToolStripMenuItem1;
        private System.Windows.Forms.PictureBox imagen;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ToolStripMenuItem mostrarConjuntoDeEntrenamientoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mostrarClasesYAtributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mostrarConjuntoDeEntrenamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem mostrarConjuntoDeEntrenamientoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem transformarAtributosMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem tratamientoDeValoresDesconocidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem pesadoDeCasosToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem pesadoDeCasosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem pesadoDeAtributosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesadoDeCasosToolStripMenuItem;
        private System.Windows.Forms.GroupBox cuadroEspacioBase;
        private System.Windows.Forms.ComboBox comboDistanciasEspacioBase;
            }
}

