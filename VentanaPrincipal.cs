using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace KNN
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }
                                                
        #region Parte común

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Borro la información de los cuadros de texto de la pestaña que abandono

            seLeyoConjuntoEntrenamiento = false;

            seLeyeronCasosClasificar = false;

            seLeyoK = false;

            seCambioTipoNormalizacion = false;

            tipoNormalizacion = "[0,1]";

            aInt = 0;

            bInt = 1;

            textoIntroducido = "";

            guardarSinMostrar = false;

            path = "";

            switch (APLICACION.verTab())
            {
                case "Vectores":

                    seLeyeronAtributos = false;

                    seSeleccionoDistanciaVectores = false;
                    
                    textBoxVectores.Text = "";

                    comboDistanciasVectores.Text = "";

                    if (boxQ.Visible)
                    {
                        boxQ.Text = "";

                        seLeyoQ = rotuloQ.Visible = boxQ.Visible = false;
                    }

                    comboNormalizacionVect.Text = "Intervalo [0,1] (Por defecto)";

                    if (comboTipoNormVect.Visible == false)
                    {
                        comboTipoNormVect.Visible = true;

                        labelNormalizar.Visible = true;
                    }

                    comboTipoNormVect.Text = "Todos los atributos (Por defecto)";
                    
                    if (boxAVect.Visible)
                    {
                        boxAVect.Text = boxBVect.Text = "";

                        boxAVect.Visible = boxBVect.Visible = labelAVect.Visible = labelBVect.Visible = false;
                    }

                    if (modoEjecucion == "Validación")
                    {
                        modoEjecucion = "Normal";

                        modoDeValidacionCruzadaToolStripMenuItem.Text = "Modo de validación cruzada";

                        boxCVect.Text = "";

                        seLeyoC = boxCVect.Visible = labelBVect.Visible = false;
                    }

                    if (checkRegresion.Checked) checkRegresion.Checked = false;

                    cuadroKVectores.Text = "";

                    if (checkRechazoVect.Checked)
                    {
                        boxRechazoVect.Text = "";

                        seLeyoValorRechazo = checkRechazoVect.Checked = textRechazoVect.Visible = boxRechazoVect.Visible = false;
                    }

                    // if (checkTransformar.Checked) checkTransformar.Checked = false;

                    if (transformarAtributosMenuItem.Text == "Deshacer transformación") transformarAtributosMenuItem.Text = "Transformar atributos cualitativos a booleanos";

                    break;

                case "Cadenas":

                    seSeleccionoDistanciaCadenas = false;
                    
                    textBoxCadenas.Text = "";

                    comboDistanciasCadenas.Text = "";

                    cuadroKCadenas.Text = "";

                    if (modoEjecucion == "Validación")
                    {
                        modoEjecucion = "Normal";

                        modoDeValidacionCruzadaToolStripMenuItem2.Text = "Modo de validación cruzada";

                        boxCCad.Text = "";

                        seLeyoC = boxCCad.Visible = labelCCad.Visible = false;
                    }
                    
                    if (checkRechazoCad.Checked)
                    {
                        boxRechazoCad.Text = "";

                        seLeyoValorRechazo = checkRechazoCad.Checked = textRechazoCad.Visible = boxRechazoCad.Visible = false;
                    }

                    break;

                case "Conjuntos":
                    
                    seSeleccionoDistanciaConjuntos = seSeleccionoDistanciaEspacioBase = false;
                                        
                    textBoxConjuntos.Text = "";

                    comboDistanciasConjuntos.Text = "";

                    comboDistanciasEspacioBase.Text = "";

                    cuadroKConjuntos.Text = "";

                    if (!cuadroEspacioBase.Enabled) cuadroEspacioBase.Enabled = true;
                                        
                    if (modoEjecucion == "Validación")
                    {
                        modoEjecucion = "Normal";

                        modoDeValidacionCruzadaToolStripMenuItem1.Text = "Modo de validación cruzada";

                        boxCConj.Text = "";

                        seLeyoC = boxCConj.Visible = labelCConj.Visible = false;
                    }
                    
                    if (checkRechazoConj.Checked)
                    {
                        boxRechazoConj.Text = "";

                        seLeyoValorRechazo = checkRechazoConj.Checked = textRechazoConj.Visible = boxRechazoConj.Visible = false;
                    }

                    break;

                default:

                    // Principal, no cambio nada

                    break;
            }

            // Y preparo lo necesario para la ejecución de la nueva pestaña
            
            if (tabControl.SelectedTab == tabVectores)
            {
                APLICACION.cambiarTabAbierta("Vectores", APLICACION.verTab());
            }

            else if (tabControl.SelectedTab == tabCadenas)
            {
                APLICACION.cambiarTabAbierta("Cadenas", APLICACION.verTab());
            }

            else if (tabControl.SelectedTab == tabConjuntos)
            {
                APLICACION.cambiarTabAbierta("Conjuntos", APLICACION.verTab());
            }

            else if (tabControl.SelectedTab == tabPrincipal)
            {
                APLICACION.cambiarTabAbierta("Principal", APLICACION.verTab());
            }
        }
                
        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void menuCargarData_Click(object sender, EventArgs e)
        {
            try
            {
                if (APLICACION.verTab() == "Vectores" && !seLeyeronAtributos)
                {
                    MessageBox.Show("Deben cargarse previamente los atributos para controlar la validez del conjunto de entrenamiento introducido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                } 
                
                if (path != "") cargarData.InitialDirectory = path;
                                
                else  cargarData.InitialDirectory = "C:\\";

                cargarData.Title = "Selecciona un archivo .data";
                cargarData.FileName = "";
                cargarData.Filter = "Archivos de datos (*.data)|*.data";

                // Comprobar que se carga un archivo correcto

                if (cargarData.ShowDialog() == DialogResult.OK)
                {
                    APLICACION.escribirRutaData(cargarData.FileName);

                    APLICACION.cambiarEstadoData(true);

                    if (path == "")
                    {
                        path = APLICACION.leerRutaData();

                        int i = path.Length - 1;

                        for (; path[i] != '\\'; i--) ;

                        path = path.Remove(i + 1);
                    }

                    APLICACION.LeerConjuntoEntrenamiento();

                    APLICACION.obtenerN();

                    seLeyoConjuntoEntrenamiento = true;

                    if (APLICACION.verTab() == "Conjuntos")
                    {
                        // Reseteo la parte de distancias ya que debo calcular cuáles puedo ofrecer

                        comboDistanciasConjuntos.Text = "";

                        seSeleccionoDistanciaConjuntos = false;

                        APLICACION.cambiarDistanciaACalcularConjuntos("");

                        comboDistanciasEspacioBase.Enabled = false;

                        seSeleccionoDistanciaEspacioBase = false;

                        APLICACION.cambiarDistanciaACalcularEspacioBase("");
                    }
                }

                else seLeyoConjuntoEntrenamiento = false;
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nEl archivo introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                seLeyoConjuntoEntrenamiento = false;
            }
        }

        private void menuCargarCases_Click(object sender, EventArgs e)
        {
            try
            {
                if (APLICACION.verTab() == "Vectores" && !seLeyeronAtributos)
                {
                    MessageBox.Show("Deben cargarse previamente los atributos para controlar la validez de los casos introducidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (path != "") cargarCases.InitialDirectory = path;

                else cargarCases.InitialDirectory = "C:\\"; 
                
                cargarCases.Title = "Selecciona un archivo .cases";
                cargarCases.FileName = "";
                cargarCases.Filter = "Archivos de texto (*.cases)|*.cases";

                // Comprobar que se carga un archivo correcto

                if (cargarCases.ShowDialog() == DialogResult.OK)
                {
                    APLICACION.escribirRutaTxt(cargarCases.FileName);

                    APLICACION.cambiarEstadoTxt(true);

                    if (path == "")
                    {
                        path = APLICACION.leerRutaTxt();
                        
                        int i = path.Length - 1;

                        for (; path[i] != '\\'; i--) ;

                        path = path.Remove(i + 1);
                    }

                    seLeyeronCasosClasificar = APLICACION.AlmacenarCasosClasificar("");

                    if (seLeyeronCasosClasificar)
                    {                        
                        switch (APLICACION.verTab())
                        {
                            case "Vectores":

                                if (modoEjecucion == "Validación")
                                {
                                    modoEjecucion = "Normal";

                                    labelCVect.Visible = boxCVect.Visible = textBoxVectores.ReadOnly = false;
                                }

                                break;

                            case "Cadenas":

                                if (modoEjecucion == "Validación")
                                {
                                    modoEjecucion = "Normal";

                                    labelCCad.Visible = boxCCad.Visible = textBoxCadenas.ReadOnly = false;
                                }

                                break;

                            case "Conjuntos":

                                if (modoEjecucion == "Validación")
                                {
                                    modoEjecucion = "Normal";

                                    labelCConj.Visible = boxCConj.Visible = textBoxConjuntos.ReadOnly = false;
                                }

                                break;
                        }

                        ActualizarCuadroCasosClasificar();
                    }

                    else
                    {
                        MessageBox.Show("Los nuevos casos a clasificar no se han cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        seLeyeronCasosClasificar = false;
                    }
                }

                else seLeyeronCasosClasificar = false;
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nEl archivo introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                seLeyoConjuntoEntrenamiento = false;
            }
        }

        /// <summary>
        /// Lee el valor de K y comprueba su validez
        /// </summary>
        /// <returns></returns>
        private bool LeerK()
        {
            string valorK = ""; ;
            
            switch (APLICACION.verTab())
            {
                case "Vectores":

                    valorK = cuadroKVectores.Text;

                    break;

                case "Cadenas":

                    valorK = cuadroKCadenas.Text;

                    break;

                case "Conjuntos":

                    valorK = cuadroKConjuntos.Text;

                    break;
            }
            
            if (String.IsNullOrEmpty(valorK))
            {
                MessageBox.Show("No se ha introducido un valor para K", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }
            
            if (!APLICACION.EsNumero(valorK))
            {
                MessageBox.Show("El valor de K introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }
            
            int valor = System.Convert.ToInt32(valorK);

            if (valor < 1)
            {
                MessageBox.Show("El valor de K introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            if (valor > APLICACION.verN())
            {
                MessageBox.Show("El valor de K no puede ser mayor que el número de muestras conocidas N", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            switch (APLICACION.verTab())
            {
                case "Vectores":

                    if (modoEjecucion == "Validación") APLICACION.almacenarKValidacion(valor);

                    else APLICACION.almacenarK(valor);

                    break;

                case "Cadenas":

                    if (modoEjecucion == "Validación") APLICACION.almacenarKValidacion(valor);

                    else APLICACION.almacenarK(valor);

                    break;

                case "Conjuntos":

                    if (modoEjecucion == "Validación") APLICACION.almacenarKValidacion(valor);

                    else APLICACION.almacenarK(valor);

                    break;
            }            
 
            return true;
        }

        /// <summary>
        /// Lee el valor de C de validación cruzada y comprueba su validez
        /// </summary>
        /// <returns></returns>
        private bool LeerC()
        {
            string valorC = ""; ;

            switch (APLICACION.verTab())
            {
                case "Vectores":

                    valorC = boxCVect.Text;

                    break;

                case "Cadenas":

                    valorC = boxCCad.Text;

                    break;

                case "Conjuntos":

                    valorC = boxCConj.Text;

                    break;
            }

            if (String.IsNullOrEmpty(valorC))
            {
                MessageBox.Show("No se ha introducido un valor para C", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            if (!APLICACION.EsNumero(valorC))
            {
                MessageBox.Show("El valor de C introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            int valor = System.Convert.ToInt32(valorC);

            if (valor < 1)
            {
                MessageBox.Show("El valor de C introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            if (valor >= APLICACION.verN())
            {
                MessageBox.Show("El valor de C debe ser menor que el número de muestras conocidas N", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            APLICACION.almacenarC(valor);

            return true;
        }

        /// <summary>
        /// Lee el valor de Q para la distancia de Minkowski y comprueba su validez
        /// </summary>
        /// <returns></returns>
        private bool LeerQ()
        {
            if (comboDistanciasVectores.Text == "Minkowski")
            {
                string valorQ = boxQ.Text;

                if (String.IsNullOrEmpty(valorQ))
                {
                    MessageBox.Show("No se ha introducido un valor para q", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                if (!APLICACION.EsNumero(valorQ))
                {
                    MessageBox.Show("El valor de q introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                double valor = System.Convert.ToDouble(boxQ.Text);

                if (valor <= 0)
                {
                    MessageBox.Show("El valor de q introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                APLICACION.almacenarQ(valor);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Lee el valor por debajo del cuál se rechazan las clases obtenidas y comprueba su validez
        /// </summary>
        /// <returns></returns>
        private bool LeerValorRechazo()
        {
            string valorRechazo = ""; ;

            switch (APLICACION.verTab())
            {
                case "Vectores":

                    valorRechazo = boxRechazoVect.Text;

                    break;

                case "Cadenas":

                    valorRechazo = boxRechazoCad.Text;

                    break;

                case "Conjuntos":

                    valorRechazo = boxRechazoConj.Text;

                    break;
            }

            if (String.IsNullOrEmpty(valorRechazo))
            {
                MessageBox.Show("No se ha introducido un valor para el rechazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            if (!APLICACION.EsNumero(valorRechazo))
            {
                MessageBox.Show("El valor de rechazo introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            int valor = System.Convert.ToInt32(valorRechazo);

            if (valor < 0)
            {
                MessageBox.Show("El valor de rechazo introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }

            APLICACION.cambiarValorRechazo(valor);

            return true;
        }

        private void MostrarResultados(string control)
        {
            string ruta = "";
            
            if (ClasesCasos.Count == 0)
            {
                MessageBox.Show("El programa no ha funcionado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }   

            VentanaResultados Resultados = new VentanaResultados(ClasesCasos, control, path);

            if (Resultados.ShowDialog() == DialogResult.OK)
            {
                ruta = Resultados.verRutaGuardar();

                APLICACION.escribirRutaGuardar(ruta);

                APLICACION.GuardarResultados();
            }  
        }

        /// <summary>
        /// Actualiza el contenido del cuadro de casos a clasificar cuando se introducen por fichero .txt
        /// </summary>
        private void ActualizarCuadroCasosClasificar()
        {
            string texto = APLICACION.verListaCasosClasificar();

            switch (APLICACION.verTab())
            {
                case "Vectores":

                    textBoxVectores.Text = texto;

                    break;

                case "Cadenas":

                    textBoxCadenas.Text = texto;

                    break;

                case "Conjuntos":

                    textBoxConjuntos.Text = texto;

                    break;
            }
        }

        private void AmpliarConjuntoDeEntrenamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!seLeyoConjuntoEntrenamiento)
                {
                    MessageBox.Show("Debe cargarse previamente el conjunto de entrenamiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }
                
                string casosAmpliacion = "";

                VentanaAmpliarConjunto NuevosCasos = new VentanaAmpliarConjunto(APLICACION.verTab(), APLICACION.verTipoDatosCjtoEntrenamiento());

                if (NuevosCasos.ShowDialog() == DialogResult.OK)
                {
                    casosAmpliacion = NuevosCasos.MostrarTextoIntroducido();

                    if (String.IsNullOrEmpty(casosAmpliacion))
                    {
                        MessageBox.Show("No se han introducido nuevos casos para ampliar el conjunto de entrenamiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (casosAmpliacion == "Error: tipo distinto")
                    {
                        MessageBox.Show("Todos los elementos del conjunto de entrenamiento deben ser del mismo tipo, o números o cadenas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else if (!APLICACION.AnadirNuevosCasosConocidos(casosAmpliacion))
                    {
                        MessageBox.Show("Los nuevos casos conocidos no se han cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    else
                    {
                        MessageBox.Show("Se ha ampliado el conjunto de entrenamiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            catch
            {
                throw;
            }
        }
        
        #endregion

        #region Parte de vectores

        /// <summary>
        /// Almacena los nombres de las clases y de los atributos desde un fichero .names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCargarNamesVectores_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != "") cargarCases.InitialDirectory = path;

                else cargarCases.InitialDirectory = "C:\\";

                cargarNames.Title = "Selecciona un archivo .names";
                cargarNames.FileName = "";
                cargarNames.Filter = "Names files (*.names)|*.names";

                // Comprobar que se carga un archivo correcto

                if (cargarNames.ShowDialog() == DialogResult.OK)
                {
                    APLICACION.escribirRutaNames(cargarNames.FileName);

                    APLICACION.cambiarEstadoNames(true);

                    if (path == "")
                    {
                        path = APLICACION.leerRutaNames();

                        int i = path.Length - 1;

                        for (; path[i] != '\\'; i--) ;

                        path = path.Remove(i + 1);
                    }

                    APLICACION.LeerAtributos();

                    seLeyeronAtributos = true;
                }

                else seLeyeronAtributos = false;
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nEl archivo introducido no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                seLeyeronAtributos = false;
            }
        }

        private void botonCalcularVectores_Click(object sender, EventArgs e)
        {
            try
            {
                if (seLeyeronAtributos && seLeyoConjuntoEntrenamiento)
                {
                    APLICACION.obtenerN();

                    APLICACION.obtenerM();

                    if (!APLICACION.ComprobarExistenciaClases())
                    {
                        MessageBox.Show("Alguna de las clases de los casos del conjunto de entrenamiento no se encuentra definida en el archivo .names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (modoEjecucion == "Validación")
                    {
                        APLICACION.cambiarValidacion(true);                        
                        
                        seLeyoC = LeerC();

                        if (!seLeyoC) return;
                    }

                    else
                    {
                        if (seLeyeronCasosClasificar)
                        {
                            if (!APLICACION.ComprobarCambiosCasosClasificar(textBoxVectores.Text))
                            {
                                MessageBox.Show("Los nuevos casos a clasificar introducidos desde el cuadro de texto no son correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                return;
                            }
                        }

                        else
                        {
                            // Leo los nuevos casos del cuadro de texto

                            seLeyeronCasosClasificar = LeerCasosClasificar();

                            if (!seLeyeronCasosClasificar) return;
                        }
                    }

                    APLICACION.TratarValoresDesconocidos();

                    seLeyoK = LeerK();

                    if (!seLeyoK) return;

                    if (!seSeleccionoDistanciaVectores)
                    {
                        MessageBox.Show("No se ha seleccionado un tipo de distancia a aplicar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (APLICACION.mostrarDistanciaACalcularVectores() == "Minkowski")
                    {
                        seLeyoQ = LeerQ();

                        if (!seLeyoQ) return;
                    }
                    
                    if (APLICACION.verTab() == "Vectores" && ComprobarNormalizacion())
                    {
                        // Controlo una posible selección de rechazo

                        APLICACION.cambiarRechazo(checkRechazoVect.Checked);

                        if (checkRechazoVect.Checked == true)
                        {
                            seLeyoValorRechazo = LeerValorRechazo();

                            if (!seLeyoValorRechazo) return;
                        }

                        // Controlo una posible selección de regresión

                        APLICACION.cambiarRegresion(checkRegresion.Checked);

                        if (checkRegresion.Checked)
                        {
                            if (!APLICACION.esPosibleRegresion())
                            {
                                MessageBox.Show("No es posible aplicar regresión con el conjunto de entrenamiento actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                return;
                            }
                        }

                        if ((APLICACION.mostrarDistanciaACalcularVectores() == "Mahalanobis" || APLICACION.mostrarDistanciaACalcularVectores() == "Del coseno") && !APLICACION.verSiAplicadaTransformacion())
                        {
                            if (MessageBox.Show("Para calcular la distancia seleccionada es necesario transformar los atributos cualitativos a booleanos, ¿desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }

                            else transformarAtributosMenuItem_Click(sender, e);
                        }

                        if (modoEjecucion == "Validación")
                        {
                            ClasesCasos = APLICACION.ValidacionCruzada();

                            if (guardarSinMostrar)
                            {
                                APLICACION.GuardarResultados();

                                MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else MostrarResultados("Validación cruzada");
                        }

                        else
                        {
                            ClasesCasos = APLICACION.CalcularConVectores();

                            // Muestro los resultados por pantalla (si uso regresión, desactivo las probabilidades)

                            if (checkRegresion.Checked)
                            {
                                if (guardarSinMostrar)
                                {
                                    APLICACION.GuardarResultados();

                                    MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else MostrarResultados("Regresión");
                            }

                            else
                            {
                                if (guardarSinMostrar)
                                {
                                    APLICACION.GuardarResultados();

                                    MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else MostrarResultados("Normal");
                            }
                        }
                    }
                }

                else
                {
                    if (seLeyeronAtributos && !seLeyoConjuntoEntrenamiento)
                    {
                        MessageBox.Show("El fichero .data no se ha cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    else if (!seLeyeronAtributos && seLeyoConjuntoEntrenamiento)
                    {
                        MessageBox.Show("El fichero .names no se ha cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    else MessageBox.Show("Los ficheros .names y .data no se han cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nPor favor, revise los valores introducidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                APLICACION.RestaurarDatos();
            }

        }

        private void comboDistanciasVectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDistanciasVectores.Text)
            {
                case "Minkowski":

                    boxQ.Visible = true;

                    rotuloQ.Visible = true;

                    APLICACION.cambiarDistanciaACalcularVectores("Minkowski");

                    seSeleccionoDistanciaVectores = true;

                    break;
                
                case "Euclidea":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;
                    
                    APLICACION.cambiarDistanciaACalcularVectores("Euclidea");

                    seSeleccionoDistanciaVectores = true;

                    break;

                case "Manhattan":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    APLICACION.cambiarDistanciaACalcularVectores("Manhattan");

                    seSeleccionoDistanciaVectores = true;

                    break;

                case "Chebychev":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    APLICACION.cambiarDistanciaACalcularVectores("Chebychev");

                    seSeleccionoDistanciaVectores = true;

                    break;

                case "Divergencia":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    APLICACION.cambiarDistanciaACalcularVectores("Divergencia");

                    seSeleccionoDistanciaVectores = true;

                    break;

                case "Camberra":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    APLICACION.cambiarDistanciaACalcularVectores("Camberra");

                    seSeleccionoDistanciaVectores = true;

                    break;

                case "Del coseno":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    APLICACION.cambiarDistanciaACalcularVectores("Del coseno");

                    seSeleccionoDistanciaVectores = true;

                    break;

                case "Mahalanobis":

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    APLICACION.cambiarDistanciaACalcularVectores("Mahalanobis");

                    seSeleccionoDistanciaVectores = true;

                    break;

                default:

                    boxQ.Visible = false;

                    rotuloQ.Visible = false;

                    seSeleccionoDistanciaVectores = false;

                    break;
            }
        }

        private void botonPesadoAtributosVectores_Click(object sender, EventArgs e)
        {
            if (!seLeyeronAtributos)
            {
                MessageBox.Show("No se ha cargado ningún fichero .names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            ArrayList PesosAtributos = new ArrayList();

            VentanaPesadoAtributos PesadoAtributos = new VentanaPesadoAtributos(APLICACION.verAtributos(), APLICACION.verPesos());

            if (PesadoAtributos.ShowDialog() == DialogResult.Cancel)
            {
                APLICACION.cambiarPesosAtributos(PesadoAtributos.verListaPesos());
            }
        }

        private void ignorarAtributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!seLeyeronAtributos)
            {
                MessageBox.Show("No se ha cargado ningún fichero .names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            ArrayList AtributosIgnorados = new ArrayList();

            VentanaIgnorarAtributos Ignorar = new VentanaIgnorarAtributos(APLICACION.verAtributos());

            if (Ignorar.ShowDialog() == DialogResult.Cancel)
            {
                APLICACION.modificarAtributos(Ignorar.EstadoAtributos());
            }
        }

        private void botonPesadoCasosVectores_Click(object sender, EventArgs e)
        {
            MostrarVentanaPesadoCasos();
        }

        #endregion

        #region Parte de cadenas

        private void comboDistanciasCadenas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDistanciasCadenas.Text)
            {
                case "Levenshtein":

                    APLICACION.cambiarDistanciaACalcularCadenas("Levenshtein");

                    seSeleccionoDistanciaCadenas = true;

                    break;

                case "Lee":

                    APLICACION.cambiarDistanciaACalcularCadenas("Lee");

                    seSeleccionoDistanciaCadenas = true;

                    break;

                case "Hamming":

                    APLICACION.cambiarDistanciaACalcularCadenas("Hamming");

                    seSeleccionoDistanciaCadenas = true;

                    break;

                default:

                    seSeleccionoDistanciaCadenas = false;

                    break;
            }
        }

        private void botonCalcularCadenas_Click(object sender, EventArgs e)
        {
            try
            {
                if (seLeyoConjuntoEntrenamiento)
                {
                    APLICACION.obtenerN();

                    if (modoEjecucion == "Validación")
                    {
                        APLICACION.cambiarValidacion(true);

                        seLeyoC = LeerC();

                        if (!seLeyoC) return;
                    }

                    else
                    {
                        if (seLeyeronCasosClasificar)
                        {
                            if (!APLICACION.ComprobarCambiosCasosClasificar(textBoxCadenas.Text))
                            {
                                MessageBox.Show("Los nuevos casos a clasificar introducidos desde el cuadro de texto no son correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                return;
                            }
                        }

                        else
                        {
                            // Leo los nuevos casos del cuadro de texto

                            seLeyeronCasosClasificar = LeerCasosClasificar();

                            if (!seLeyeronCasosClasificar) return;
                        }
                    }

                    seLeyoK = LeerK();

                    if (!seLeyoK) return;

                    if (!seSeleccionoDistanciaCadenas)
                    {
                        MessageBox.Show("No se ha seleccionado un tipo de distancia a aplicar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (APLICACION.verTab() == "Cadenas")
                    {
                        APLICACION.cambiarRechazo(checkRechazoCad.Checked);

                        if (checkRechazoCad.Checked == true)
                        {
                            seLeyoValorRechazo = LeerValorRechazo();

                            if (!seLeyoValorRechazo) return;
                        }

                        if (APLICACION.mostrarDistanciaACalcularCadenas() == "Lee")
                        {
                            if (!APLICACION.VerificarMismaLongitud())
                            {
                                MessageBox.Show("Para poder calcular la distancia de Lee, todas las cadenas deben tener la misma longitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }
                        }

                        if (modoEjecucion == "Validación")
                        {
                            ClasesCasos = APLICACION.ValidacionCruzada();

                            if (guardarSinMostrar)
                            {
                                APLICACION.GuardarResultados();

                                MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else MostrarResultados("Validación cruzada");
                        }

                        else
                        {
                            ClasesCasos = APLICACION.CalcularConCadenas();

                            if (guardarSinMostrar)
                            {
                                APLICACION.GuardarResultados();

                                MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else MostrarResultados("Normal");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("El fichero .data no se ha cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nPor favor, revise los valores introducidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                APLICACION.RestaurarDatos();
            }
        }

        private void botonPesadoCasosCadenas_Click(object sender, EventArgs e)
        {
            MostrarVentanaPesadoCasos();
        }

        #endregion
        
        #region Parte de conjuntos

        private void comboDistanciasConjuntos_Click(object sender, EventArgs e)
        {
            if (!seLeyoConjuntoEntrenamiento)
            {
                MessageBox.Show("Debe cargarse previamente el conjunto de entrenamiento para saber qué distancias se pueden aplicar al conjunto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
        }       

        private void comboDistanciasConjuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDistanciasConjuntos.Text)
            {
                case "Hausdorff":

                    comboDistanciasEspacioBase.Enabled = true;

                    APLICACION.cambiarDistanciaACalcularConjuntos("Hausdorff");

                    seSeleccionoDistanciaConjuntos = true;

                    break;

                case "Hausdorff mínima":

                    comboDistanciasEspacioBase.Enabled = true;

                    APLICACION.cambiarDistanciaACalcularConjuntos("Hausdorff mínima");

                    seSeleccionoDistanciaConjuntos = true;

                    break;

                case "Clásica":

                    comboDistanciasEspacioBase.Enabled = false;
                    
                    APLICACION.cambiarDistanciaACalcularConjuntos("Clásica");

                    seSeleccionoDistanciaConjuntos = true;

                    break;

                default:

                    seSeleccionoDistanciaConjuntos = false;

                    break;
            }

            if (seSeleccionoDistanciaConjuntos)
            {
                comboDistanciasEspacioBase.Items.Clear();

                if (APLICACION.verTipoDatosCjtoEntrenamiento() == "Números")
                {
                    comboDistanciasEspacioBase.Items.Add("Euclidea");

                    comboDistanciasEspacioBase.Items.Add("Camberra");
                }

                else if (APLICACION.verTipoDatosCjtoEntrenamiento() == "Cadenas")
                {
                    comboDistanciasEspacioBase.Items.Add("Hamming");

                    comboDistanciasEspacioBase.Items.Add("Levenshtein");
                }

                else
                {
                    MessageBox.Show("Todos los elementos del conjunto de entrenamiento deben ser del mismo tipo, o números o cadenas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }
            }
        }

        private void comboDistanciasEspacioBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDistanciasEspacioBase.Text)
            {
                case "Euclidea":

                    APLICACION.cambiarDistanciaACalcularEspacioBase("Euclidea");

                    seSeleccionoDistanciaEspacioBase = true;

                    break;

                case "Camberra":

                    APLICACION.cambiarDistanciaACalcularEspacioBase("Camberra");

                    seSeleccionoDistanciaEspacioBase = true;

                    break;

                case "Hamming":

                    APLICACION.cambiarDistanciaACalcularEspacioBase("Hamming");

                    seSeleccionoDistanciaEspacioBase = true;

                    break;

                case "Levenshtein":

                    APLICACION.cambiarDistanciaACalcularEspacioBase("Levenshtein");

                    seSeleccionoDistanciaEspacioBase = true;

                    break;

                default:

                    seSeleccionoDistanciaEspacioBase = false;

                    break;
            }
        }

        private void botonCalcularConjuntos_Click(object sender, EventArgs e)
        {
            try
            {
                if (seLeyoConjuntoEntrenamiento)
                {
                    APLICACION.obtenerN();

                    if (modoEjecucion == "Validación")
                    {
                        APLICACION.cambiarValidacion(true);
                        
                        seLeyoC = LeerC();

                        if (!seLeyoC) return;
                    }

                    else
                    {
                        if (seLeyeronCasosClasificar)
                        {
                            if (!APLICACION.ComprobarCambiosCasosClasificar(textBoxConjuntos.Text))
                            {
                                MessageBox.Show("Los nuevos casos a clasificar introducidos desde el cuadro de texto no son correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                return;
                            }
                        }

                        else
                        {
                            // Leo los nuevos casos del cuadro de texto

                            seLeyeronCasosClasificar = LeerCasosClasificar();

                            if (!seLeyeronCasosClasificar) return;
                        }

                        if (!APLICACION.ComprobarMismoTipo())
                        {
                            MessageBox.Show("Todos los elementos de los conjuntos introducidos deben ser del mismo tipo, o números o cadenas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            return;
                        }
                    }

                    seLeyoK = LeerK();

                    if (!seLeyoK) return;

                    if (!seSeleccionoDistanciaConjuntos)
                    {
                        MessageBox.Show("No se ha seleccionado un tipo de distancia a aplicar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if ((APLICACION.mostrarDistanciaACalcularConjuntos() == "Hausdorff" || APLICACION.mostrarDistanciaACalcularConjuntos() == "Hausdorff mínima") && !seSeleccionoDistanciaEspacioBase)
                    {
                        MessageBox.Show("No se ha seleccionado un tipo de distancia a aplicar en el espacio base", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (APLICACION.verTab() == "Conjuntos")
                    {
                        APLICACION.cambiarRechazo(checkRechazoConj.Checked);

                        if (checkRechazoConj.Checked == true)
                        {
                            seLeyoValorRechazo = LeerValorRechazo();

                            if (!seLeyoValorRechazo) return;
                        }

                        if (modoEjecucion == "Validación")
                        {
                            ClasesCasos = APLICACION.ValidacionCruzada();

                            if (guardarSinMostrar)
                            {
                                APLICACION.GuardarResultados();

                                MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else MostrarResultados("Validación cruzada");
                        }

                        else
                        {
                            ClasesCasos = APLICACION.CalcularConConjuntos();

                            if (guardarSinMostrar)
                            {
                                APLICACION.GuardarResultados();

                                MessageBox.Show("La clasificación se ha realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else MostrarResultados("Normal");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("El fichero .data no se ha cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nPor favor, revise los valores introducidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                APLICACION.RestaurarDatos();
            }            
        }

        private void botonPesadoCasosConjuntos_Click(object sender, EventArgs e)
        {
            MostrarVentanaPesadoCasos();
        }

        #endregion

        private bool LeerCasosClasificar()
        {
            try
            {
                switch (APLICACION.verTab())
                {
                    case "Vectores":

                        textoIntroducido = textBoxVectores.Text;

                        break;

                    case "Cadenas":

                        textoIntroducido = textBoxCadenas.Text;

                        break;

                    case "Conjuntos":

                        textoIntroducido = textBoxConjuntos.Text;

                        break;
                }

                if (String.IsNullOrEmpty(textoIntroducido))
                {
                    MessageBox.Show("No se han introducido nuevos casos para clasificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                if (!APLICACION.AlmacenarCasosClasificar(textoIntroducido))
                {
                    MessageBox.Show("Los nuevos casos a clasificar no se han cargado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                return true;
            }

            catch (Exception excep)
            {
                MessageBox.Show(excep.Message + "\n\nPor favor, revise los valores introducidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return false;
            }
        }

        private void comboNormalizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (APLICACION.verTab() == "Vectores")
            {
                if (comboNormalizacionVect.Text == "Intervalo [0,1] (Por defecto)" || comboNormalizacionVect.Text == "Intervalo [0,1]")
                {
                    if (labelAVect.Visible == true)
                    {
                        labelAVect.Visible = false;

                        labelBVect.Visible = false;

                        boxAVect.Visible = false;

                        boxBVect.Visible = false;
                    }

                    if (comboTipoNormVect.Visible == false)
                    {
                        comboTipoNormVect.Visible = true;

                        labelNormalizar.Visible = true;
                    }

                    tipoNormalizacion = "[0,1]";

                    aInt = 0;

                    bInt = 1;
                }

                else if (comboNormalizacionVect.Text == "Media cero y varianza unidad")
                {
                    if (labelAVect.Visible == true)
                    {
                        labelAVect.Visible = false;

                        labelBVect.Visible = false;

                        boxAVect.Visible = false;

                        boxBVect.Visible = false;
                    }

                    if (comboTipoNormVect.Visible == false)
                    {
                        comboTipoNormVect.Visible = true;

                        labelNormalizar.Visible = true;
                    }                    

                    tipoNormalizacion = "mediaVarianza";

                    aInt = 0;

                    bInt = 0;
                }

                else if (comboNormalizacionVect.Text == "No normalizar")
                {
                    if (labelAVect.Visible == true)
                    {
                        labelAVect.Visible = false;

                        labelBVect.Visible = false;

                        boxAVect.Visible = false;

                        boxBVect.Visible = false;
                    }

                    comboTipoNormVect.Visible = false;

                    labelNormalizar.Visible = false;

                    tipoNormalizacion = "No normalizar";

                    aInt = -1;

                    bInt = -1;
                }


                else
                {
                    if (labelAVect.Visible == false)
                    {
                        labelAVect.Visible = true;

                        labelBVect.Visible = true;

                        boxAVect.Visible = true;

                        boxBVect.Visible = true;
                    }

                    if (comboTipoNormVect.Visible == false)
                    {
                        comboTipoNormVect.Visible = true;

                        labelNormalizar.Visible = true;
                    }

                    tipoNormalizacion = "[a,b]";
                }

            }
        }

        private bool ComprobarNormalizacion()
        {
            if ( (tipoNormalizacion == "[0,1]" && 
                   (comboNormalizacionVect.Text == "Intervalo [0,1] (Por defecto)" || comboNormalizacionVect.Text == "Intervalo [0,1]"))
                 || (tipoNormalizacion == "mediaVarianza" && comboNormalizacionVect.Text == "Media cero y varianza unidad") || 
                   (tipoNormalizacion == "No normalizar" && comboNormalizacionVect.Text == "No normalizar"))
            {                
                APLICACION.cambiarNormalizacion(tipoNormalizacion, aInt, bInt);

                if (!seCambioTipoNormalizacion) 
                {
                    // Se normalizan todas las variables por defecto

                    ArrayList lista = new ArrayList();

                    if (tipoNormalizacion != "No normalizar")
                    {
                        for (int i = 0; i < APLICACION.verM(); i++)
                        {
                            lista.Add(i);
                        }
                    }

                    APLICACION.cambiarListaAtributosNormalizar(lista);
                }

                return true;
            }

            else if (tipoNormalizacion == "[a,b]")
            {
                if (String.IsNullOrEmpty(boxAVect.Text))
                {
                    MessageBox.Show("No se han introducido valores correctos para el intervalo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                if (String.IsNullOrEmpty(boxBVect.Text))
                {
                    MessageBox.Show("No se han introducido valores correctos para el intervalo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                aInt = System.Convert.ToDouble(boxAVect.Text);

                bInt = System.Convert.ToDouble(boxBVect.Text);

                if (bInt <= aInt)
                {
                    MessageBox.Show("No se han introducido valores correctos para el intervalo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return false;
                }

                APLICACION.cambiarNormalizacion(tipoNormalizacion, aInt, bInt);

                if (!seCambioTipoNormalizacion)
                {
                    // Se normalizan todas las variables por defecto

                    ArrayList lista = new ArrayList();

                    for (int i = 0; i < APLICACION.verM(); i++)
                    {
                        lista.Add(i);
                    }

                    APLICACION.cambiarListaAtributosNormalizar(lista);
                }

                return true;
            }

            return false;
        }

        private void checkRechazo_CheckedChanged(object sender, EventArgs e)
        {
            switch (APLICACION.verTab())
            {
                case "Cadenas":

                    if ((checkRechazoCad.Checked && !textRechazoCad.Visible) || (!checkRechazoCad.Checked && textRechazoCad.Visible))
                    {                    
                        textRechazoCad.Visible = !(textRechazoCad.Visible);

                        boxRechazoCad.Visible = !(boxRechazoCad.Visible);
                    }

                    break;

                case "Conjuntos":

                    if ((checkRechazoConj.Checked && !textRechazoConj.Visible) || (!checkRechazoConj.Checked && textRechazoConj.Visible))
                    {   
                        textRechazoConj.Visible = !(textRechazoConj.Visible);

                        boxRechazoConj.Visible = !(boxRechazoConj.Visible);
                    }

                    break;

                case "Vectores":

                    if ((checkRechazoVect.Checked && !textRechazoVect.Visible) || (!checkRechazoVect.Checked && textRechazoVect.Visible))
                    {                    
                        textRechazoVect.Visible = !(textRechazoVect.Visible);

                        boxRechazoVect.Visible = !(boxRechazoVect.Visible);
                    }

                    break;
            }
        }

        private void MostrarVentanaPesadoCasos()
        {
            VentanaPesadoCasos ventana = new VentanaPesadoCasos(APLICACION.verPesadoCasos());

            if (ventana.ShowDialog() == DialogResult.Cancel)
            {
                switch (ventana.MostrarTipo())
                {
                    case "Inversamente":

                        APLICACION.cambiarPesadoCasos("Inversamente");

                        break;

                    case "Orden":

                        APLICACION.cambiarPesadoCasos("Orden");

                        break;

                    default:

                        APLICACION.cambiarPesadoCasos("Iguales");

                        break;
                }
            }
        }

        private void comboTipoNormVect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList lista = new ArrayList();
            
            switch (comboTipoNormVect.Text)
            {
                case "Todos los atributos":

                    for (int i = 0; i < APLICACION.verM(); i++)
                    {
                        lista.Add(i);
                    }

                    APLICACION.cambiarListaAtributosNormalizar(lista);

                    seCambioNormAAlgunos = false;

                    break;

                case "Un atributo concreto y":
                                                            
                    if (!seLeyeronAtributos)
                    {
                        MessageBox.Show("No se ha cargado ningún fichero .names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (!seCambioNormAAlgunos)
                    {
                        ArrayList vacio = new ArrayList();

                        APLICACION.cambiarListaAtributosNormalizar(vacio);

                        seCambioNormAAlgunos = true;
                    }

                    VentanaNormalizarAtributos ventana = new VentanaNormalizarAtributos(APLICACION.verAtributos(), APLICACION.verListaAtributosNormalizar(), APLICACION.verRangosAtributos(), APLICACION.verA(), APLICACION.verB());

                    if (ventana.ShowDialog() == DialogResult.Cancel)
                    {
                        APLICACION.cambiarListaAtributosNormalizar(ventana.EstadoAtributos());
                    }

                    break;
            }

            seCambioTipoNormalizacion = true;
        }

        private void modoDeValidacionCruzadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modoEjecucion == "Normal") modoEjecucion = "Validación";

            else modoEjecucion = "Normal";
            
            switch (APLICACION.verTab())
            {
                case "Vectores":

                    if (modoEjecucion == "Normal")
                    {
                        modoDeValidacionCruzadaToolStripMenuItem.Text = "Modo de validación cruzada";
                        
                        labelCVect.Visible = boxCVect.Visible = textBoxVectores.ReadOnly = false;

                        textBoxVectores.Text = "";
                    }
                    
                    else
                    {
                        modoDeValidacionCruzadaToolStripMenuItem.Text = "Modo normal";
                        
                        labelCVect.Visible = boxCVect.Visible = textBoxVectores.ReadOnly = true;

                        textBoxVectores.Text = "";
                    }

                    break;

                case "Conjuntos":

                    if (modoEjecucion == "Normal")
                    {
                        modoDeValidacionCruzadaToolStripMenuItem1.Text = "Modo de validación cruzada";
                        
                        labelCConj.Visible = boxCConj.Visible = textBoxConjuntos.ReadOnly = false;

                        textBoxConjuntos.Text = "";
                    }

                    else
                    {
                        modoDeValidacionCruzadaToolStripMenuItem1.Text = "Modo normal";
                        
                        labelCConj.Visible = boxCConj.Visible = textBoxConjuntos.ReadOnly = true;

                        textBoxConjuntos.Text = "";
                    }

                    break;

                case "Cadenas":

                    if (modoEjecucion == "Normal")
                    {
                        modoDeValidacionCruzadaToolStripMenuItem2.Text = "Modo de validación cruzada";
                        
                        labelCCad.Visible = boxCCad.Visible = textBoxCadenas.ReadOnly = false;

                        textBoxCadenas.Text = "";
                    }

                    else
                    {
                        modoDeValidacionCruzadaToolStripMenuItem2.Text = "Modo normal";
                        
                        labelCCad.Visible = boxCCad.Visible = textBoxCadenas.ReadOnly = true;

                        textBoxCadenas.Text = "";
                    }

                    break;
            }
        }

        private void botonMenuGuardar_Click(object sender, EventArgs e)
        {
            guardarResultados.InitialDirectory = path;            
            guardarResultados.Title = "Especifica el nombre del archivo de destino";
            guardarResultados.Filter = "Archivos de salida (*.out)|*.out";
            guardarResultados.OverwritePrompt = true;

            if (guardarResultados.ShowDialog() != DialogResult.Cancel)
            {
                string rutaGuardar = guardarResultados.FileName;

                APLICACION.escribirRutaGuardar(rutaGuardar);

                guardarSinMostrar = true;
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAcercaDe ventana = new VentanaAcercaDe();

            if (ventana.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }

        private void comboTipoNormVect_Click(object sender, EventArgs e)
        {
            if (!seLeyeronAtributos)
            {
                MessageBox.Show("Deben cargarse previamente los atributos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            if (!seLeyoConjuntoEntrenamiento)
            {
                MessageBox.Show("Debe cargarse previamente el conjunto de entrenamiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }
        }

        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helpProvider.HelpNamespace = Application.StartupPath + "\\Ayuda.chm";
            
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        private void mostrarConjuntoDeEntrenamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!seLeyoConjuntoEntrenamiento)
            {
                MessageBox.Show("Debe cargarse previamente el conjunto de entrenamiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            } 
            
            MessageBox.Show(APLICACION.verCopiaCjtoEntrenamiento(), "Conjunto de entrenamiento actual");
        }

        private void mostrarClasesYAtributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!seLeyeronAtributos)
            {
                MessageBox.Show("Deben cargarse previamente los atributos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            MessageBox.Show(APLICACION.verCopiaClasesyAtributos(), "Clases y atributos del sistema");

        }

        private void transformarAtributosMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (transformarAtributosMenuItem.Text == "Transformar atributos cualitativos a booleanos")
                {
                    if (!seLeyeronAtributos)
                    {
                        MessageBox.Show("Deben cargarse previamente los atributos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (!seLeyoConjuntoEntrenamiento)
                    {
                        MessageBox.Show("Debe cargarse previamente el conjunto de entrenamiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    } 

                    if (!seLeyeronCasosClasificar)
                    {
                        MessageBox.Show("Deben cargarse previamente los nuevos casos a clasificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }        

                    APLICACION.cambiarTransformacion(true);

                    APLICACION.RealizarTransformacion();

                    textBoxVectores.Text = APLICACION.verCopiaCasosClasificar();

                    transformarAtributosMenuItem.Text = "Deshacer transformación";
                }

                else
                {
                    APLICACION.DeshacerTransformacion();

                    textBoxVectores.Text = APLICACION.verCopiaCasosClasificar();

                    transformarAtributosMenuItem.Text = "Transformar atributos cualitativos a booleanos";
                }
            }

            catch
            {
                throw;
            }
        }

        private void tratamientoDeValoresDesconocidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaValoresDesconocidos ventana = new VentanaValoresDesconocidos(APLICACION.verOpcionValoresDesconocidos());

            if (ventana.ShowDialog() == DialogResult.Cancel)
            {
                APLICACION.cambiarOpcionValoresDesconocidos(ventana.verOpcion());
            }  
        }

        private void comboDistanciasEspacioBase_Click(object sender, EventArgs e)
        {
            if (comboDistanciasConjuntos.Text == "")
            {
                MessageBox.Show("Debe seleccionarse previamente la distancia a aplicar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }
            
            else if (comboDistanciasConjuntos.Text == "Clásica")
            {
                MessageBox.Show("Para la distancia seleccionada no es necesario seleccionar este tipo de distancia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }
                
        }
               
        
    }
}