using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO; // Para StreamReader y StreamWriter
using MathNet.Numerics.LinearAlgebra;

namespace KNN
{
    class KVecinos
    {
        #region Parte común

        #region Miembros

        /// <summary>
        /// Almacenará Principal, Vectores, Cadenas o Conjuntos según la pestaña que se elija en la ventana 
        /// </summary>
        protected string tipoAplicacion;

        /// <summary>
        /// Matriz que almacenará el conjunto de entrenamiento con todos los casos ya conocidos
        /// </summary>
        protected ArrayList CjtoEntrenamiento = new ArrayList();

        /// <summary>
        /// Matriz que almacenará los casos a clasificar introducidos por el usuario
        /// </summary>
        protected ArrayList CasosClasificar = new ArrayList();

        /// <summary>
        /// Apunta al caso que se debe clasificar a continuación
        /// </summary>
        protected int punteroCasosClasificar = 0;

        /// <summary>
        /// Almacena el contenido del fichero .txt para mostrarlo en la pantalla
        /// </summary>
        protected string listaCasosClasificar = "";

        /// <summary>
        /// Número de muestras del conjunto de entrenamiento
        /// </summary>
        protected int N;

        /// <summary>
        /// Valor de K para la búsqueda de los K-Vecinos
        /// </summary>
        protected int K;
        
        /// <summary>
        /// Vector que almacena la distancia entre un nuevo caso y los conocidos en un par (nº caso conocido, distancia)
        /// </summary>
        protected ArrayList Distancias = new ArrayList();

        /// <summary>
        /// Vector que almacena un par con el nombre de la clase y el número de vecinos más próximos que pertenecen a ella
        /// Se utilizará a la hora de determinar a qué clase pertenece un caso en función de las de sus K vecinos
        /// </summary>
        protected ArrayList Clases = new ArrayList();
        
        /// <summary>
        /// Ruta del archivo con extensión .data
        /// </summary>
        protected string rutaData = "";

        /// <summary>
        /// Ruta del archivo con extensión .txt
        /// </summary>
        protected string rutaTxt = "";

        /// <summary>
        /// Ruta del archivo donde se guardarán los resultados
        /// </summary>
        protected string rutaGuardar = "";

        /// <summary>
        /// Variable de control para comprobar si el fichero .data introducido es correcto
        /// </summary>
        protected bool dataCorrecto = false;

        /// <summary>
        /// Variable de control para comprobar si el fichero .txt introducido es correcto
        /// </summary>
        protected bool txtCorrecto = false;

        /// <summary>
        /// Técnica a aplicar en caso de empate.
        /// Por defecto: ModificarK (examinar los K-1 vecinos más próximos).
        /// Otro posible valor: MasCercano (tomar la clase del vecino más cercano).
        /// </summary>
        protected string opcionDesempate = "ModificarK";

        /// <summary>
        /// Indica si el usuario eligió usar clasificación por votación sin rechazo (false, por defecto) o con rechazo (true);
        /// </summary>
        protected bool VotacionConRechazo = false;

        /// <summary>
        /// Valor según el cuál se rechazarán o no las clasificaciones en la votación con rechazo
        /// </summary>
        protected int ValorRechazo = 0;
       
        /// <summary>
        /// Indica si se debe aplicar un peso distinto a cada caso o no, y en caso de que sí, de qué forma
        /// Iguales  --> No hay pesos distintos para los casos (por defecto)
        /// Inversamente --> Inversamente proporcional a la distancia
        /// Orden --> Según el orden de vecindad
        /// </summary>
        protected string PesadoCasos = "Iguales";

        /// <summary>
        /// Indica si hay que utilizar o no la validación cruzada
        /// </summary>
        protected bool usarValidacion = false;
        
        /// <summary>
        /// Indica en cuantos subconjuntos hay que dividir el conjunto de entrenamiento en el caso de validación cruzada
        /// </summary>
        protected int C;

        /// <summary>
        /// Almacena los subconjuntos en el caso de validación cruzada
        /// </summary>
        protected ArrayList subconjuntosValidacion = new ArrayList();

        /// <summary>
        /// Almacena en cada posición p, la tasa de aciertos en la validación cruzada para K = p+1 (empieza en K = 1)
        /// </summary>
        protected ArrayList TasasAciertos = new ArrayList();

        /// <summary>
        /// Almacena una copia del conjunto de entrenamiento inicial, para poder recuperarlo posteriormente si se desea
        /// </summary>
        protected ArrayList CopiaCjtoEntrenamientoInicial = new ArrayList();

        /// <summary>
        /// Almacena una copia de los casos a clasificar iniciales, para poder recuperarlos posteriormente si se desea
        /// </summary>
        protected ArrayList CopiaCasosClasificarIniciales = new ArrayList();

        /// <summary>
        /// Almacena una copia de las clases iniciales del sistema, para poder recuperarlas posteriormente si se desea
        /// </summary>
        protected ArrayList CopiaClasesIniciales = new ArrayList();

        /// <summary>
        /// Valor de K hasta el cuál se calculará la validación cruzada desde el valor 1
        /// </summary>
        protected int KValidacion;

        /// <summary>
        /// Almacena una copia del conjunto de entrenamiento para posteriormente generar el archivo de guardado
        /// </summary>
        protected string copiaCjtoEntrenamiento = "";

        /// <summary>
        /// Almacena una copia de los casos a clasificar
        /// </summary>
        protected string copiaCasosClasificar = "";

        /// <summary>
        /// Almacena las clases calculadas de los casos a clasificar en un par (clase, probabilidad)
        /// </summary>
        protected ArrayList ClasesCasos = new ArrayList();

        #endregion
             
        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public KVecinos() 
        {
            tipoAplicacion = "Principal";
        }

        #endregion

        #region Observadores

        /// <summary>
        /// Muestra la ruta del fichero .data
        /// </summary>
        /// <returns></returns>
        public string leerRutaData()
        {
            return rutaData;
        }

        /// <summary>
        /// Muestra la ruta del fichero .txt
        /// </summary>
        /// <returns></returns>
        public string leerRutaTxt()
        {
            return rutaTxt;
        }

        /// <summary>
        /// Muestra la ruta del fichero donde se guardarán los resultados
        /// </summary>
        /// <returns></returns>
        public string leerRutaGuadar()
        {
            return rutaGuardar;
        }

        /// <summary>
        /// Indica la validez del fichero .data
        /// </summary>
        /// <returns></returns>
        public bool verSiCorrectoData()
        {
            return dataCorrecto;
        }

        /// <summary>
        /// Indica la validez del fichero .txt
        /// </summary>
        /// <returns></returns>
        public bool verSiCorrectoTxt()
        {
            return txtCorrecto;
        }

        /// <summary>
        /// Indica la pestaña en la que nos encontramos
        /// </summary>
        /// <returns></returns>
        public string verTab()
        {
            return tipoAplicacion;
        }

        /// <summary>
        /// Devuelve el valor de K
        /// </summary>
        /// <returns></returns>
        public int verK()
        {
            return K;
        }
        
        /// <summary>
        /// Devuelve el valor de C
        /// </summary>
        /// <returns></returns>
        public int verC()
        {
            return C;
        }

        /// <summary>
        /// Retorna el número de casos que contiene el conjunto de entrenamiento
        /// </summary>
        /// <returns></returns>
        public int verN()
        {
            return N;
        }

        /// <summary>
        /// Retorna el contenido del fichero .txt
        /// </summary>
        /// <returns></returns>
        public string verListaCasosClasificar()
        {
            return listaCasosClasificar;
        }

        /// <summary>
        /// Retorna el tipo de pesado de casos a aplicar
        /// </summary>
        /// <returns></returns>
        public string verPesadoCasos()
        {
            return PesadoCasos;
        }

        /// <summary>
        /// Retorna una copia del conjunto de entrenamiento
        /// </summary>
        /// <returns></returns>
        public string verCopiaCjtoEntrenamiento()
        {
            return copiaCjtoEntrenamiento;
        }

        /// <summary>
        /// Retorna una copia de los casos a clasificar
        /// </summary>
        /// <returns></returns>
        public string verCopiaCasosClasificar()
        {
            return copiaCasosClasificar;
        }

        #endregion

        #region Modificadores

        /// <summary>
        /// Calcula el valor de la variable N
        /// </summary>
        public void obtenerN()
        {
            N = CjtoEntrenamiento.Count;
        }      
      
        /// <summary>
        /// Almacena la ruta del archivo .data
        /// </summary>
        /// <param name="ruta"></param>
        public void escribirRutaData (string ruta)
        {
            rutaData = ruta;
        }

        /// <summary>
        /// Almacena la ruta del archivo .txt
        /// </summary>
        /// <param name="ruta"></param>
        public void escribirRutaTxt(string ruta)
        {
            rutaTxt = ruta;
        }

        /// <summary>
        /// Almacena la ruta del archivo donde se guardarán los resultados
        /// </summary>
        /// <param name="ruta"></param>
        public void escribirRutaGuardar(string ruta)
        {
            rutaGuardar = ruta;
        }

        /// <summary>
        /// Modifica el estado de la ruta del archivo .data
        /// </summary>
        /// <param name="estado"></param>
        public void cambiarEstadoData (bool estado)
        {
            dataCorrecto = estado;
        }

        /// <summary>
        /// Modifica el estado de la ruta del archivo .txt
        /// </summary>
        /// <param name="estado"></param>
        public void cambiarEstadoTxt(bool estado)
        {
            txtCorrecto = estado;
        }

        /// <summary>
        /// Prepara las variables para su uso según a qué pestaña se haya cambiado en la ventana principal
        /// </summary>
        /// <param name="tab"></param>
        public void cambiarTabAbierta(string tab, string tabAnterior)
        {
            try
            {
                // Al cambiar de aplicación, todo lo almacenado se pierde, salvo que se provenga de Principal

                tipoAplicacion = tab;

                switch (tabAnterior)
                {
                    case "Vectores":

                        CjtoNormalizado.Clear();

                        NuevoCasoNormalizado.Clear();

                        Atributos.Clear();

                        CopiaAtributosIniciales.Clear();

                        PesosAtributos.Clear();

                        posAtributosIgnorados.Clear();

                        ListaAtributosNormalizar.Clear();

                        distanciaACalcularVectores = rutaNames = "";

                        tipoNormalizacion = "Intervalo";

                        M = 0;

                        aIntervalo = 0;

                        bIntervalo = 1;

                        posCualitativos.Clear();

                        valoresPosiblesCualitativos.Clear();

                        aplicarTransformacion = usarRegresion = namesCorrecto = false;

                        copiaClases = "";

                        copiaAtributos = "";

                        opcionValoresDesconocidos = "Eliminación";

                        break;

                    case "Cadenas":

                        distanciaACalcularCadenas = "";

                        break;

                    case "Conjuntos":

                        NumAtributosConjuntos.Clear();

                        MayorNumAtributos = 0;

                        distanciaACalcularConjuntos = distanciaACalcularEspacioBase = "";

                        A.Clear();

                        B.Clear();

                        tipoDatosCjtoEntrenamiento = "Sin comprobar";

                        break;

                    default:

                        // Principal, no ocurre nada

                        return;
                }

                CjtoEntrenamiento.Clear();

                CopiaCjtoEntrenamientoInicial.Clear();

                copiaCjtoEntrenamiento = "";

                N = K = KValidacion = ValorRechazo = C = 0;

                Clases.Clear();

                CopiaClasesIniciales.Clear();

                Distancias.Clear();

                CasosClasificar.Clear();

                CopiaCasosClasificarIniciales.Clear();

                copiaCasosClasificar = "";

                punteroCasosClasificar = 0;

                rutaData = rutaTxt = rutaGuardar = copiaCjtoEntrenamiento = listaCasosClasificar = "";

                VotacionConRechazo = dataCorrecto = txtCorrecto = usarValidacion = false;

                opcionDesempate = "ModificarK";

                PesadoCasos = "Iguales";

                subconjuntosValidacion.Clear();

                TasasAciertos.Clear();

                ClasesCasos.Clear();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Carga en K el valor introducido por el usuario en la ventana
        /// </summary>
        /// <param name="k"></param>
        public void almacenarK (int k)
        {
            K = k;
        }

        /// <summary>
        /// Carga en C el valor introducido por el usuario en la ventana
        /// </summary>
        /// <param name="c"></param>
        public void almacenarC(int c)
        {
            C = c;
        }

        /// <summary>
        /// Almacena el valor de la K para la validación cruzada
        /// </summary>
        /// <param name="k"></param>
        public void almacenarKValidacion(int k)
        {
            KValidacion = k;
        }

        /// <summary>
        /// Cambia el tipo de rechazo
        /// </summary>
        /// <param name="valor"></param>
        public void cambiarRechazo(bool valor)
        {
            VotacionConRechazo = valor;
        }

        /// <summary>
        /// Cambia el uso o no de la validación cruzada
        /// </summary>
        /// <param name="valor"></param>
        public void cambiarValidacion(bool valor)
        {
            usarValidacion = valor;
        }

        /// <summary>
        /// Almacena el valor de rechazo
        /// </summary>
        /// <param name="valor"></param>
        public void cambiarValorRechazo(int valor)
        {
            ValorRechazo = valor;
        }

        /// <summary>
        /// Cambia el tipo de pesado de casos
        /// </summary>
        /// <param name="valor"></param>
        public void cambiarPesadoCasos(string valor)
        {
            PesadoCasos = valor;
        }

        #endregion

        #region Operaciones auxiliares

        /// <summary>
        /// Comprueba si el contenido de un string es un número
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool EsNumero (string s)
        {
            try
            {
                bool esNumero;

                double valorNumerico;

                esNumero = Double.TryParse(Convert.ToString(s), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out valorNumerico);

                return esNumero;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Lee desde un fichero .data en C4.5 los casos conocidos
        /// </summary>
        public void LeerConjuntoEntrenamiento()
        {
            try
            {
                // Me aseguro de que se almacenarán los datos en un conjunto vacío

                CjtoEntrenamiento.Clear();

                ArrayList v = new ArrayList();

                string cadena = "";

                char caracter;

                StreamReader fichero = new StreamReader(@rutaData);

                fichero = new StreamReader(rutaData);

                if (tipoAplicacion == "Vectores")
                {
                    // Mientras no sea fin de fichero

                    while (fichero.Peek() >= 0)
                    {
                        // Lectura de datos (el 44 es el código ASCII de la coma (,))

                        caracter = (char)fichero.Read();

                        while (caracter != 44 && fichero.Peek() >= 0 && caracter != '\n' && caracter != '\r')
                        {
                            cadena += caracter;

                            caracter = (char)fichero.Read();
                        }

                        if (cadena != "")
                        {
                            if (fichero.Peek() < 0)
                            {
                                cadena += caracter;
                            }

                            cadena = cadena.Replace('.', ',');

                            cadena = cadena.Trim();

                            v.Add(cadena);

                            cadena = "";
                        }

                        if ((caracter == '\n' || fichero.Peek() < 0) && v.Count > 0)
                        {
                            CjtoEntrenamiento.Add(v.Clone());

                            v.Clear();
                        }
                    }
                }

                else if (tipoAplicacion == "Cadenas")
                {
                    ArrayList nombresClases = new ArrayList();

                    bool primeraCadena = true;

                    // Mientras no sea fin de fichero

                    while (fichero.Peek() >= 0)
                    {
                        // Lectura de datos                    

                        caracter = (char)fichero.Read();

                        while (caracter != ' ' && fichero.Peek() >= 0 && caracter != '\n' && caracter != '\r')
                        {
                            cadena += caracter;

                            caracter = (char)fichero.Read();
                        }

                        if (cadena != "")
                        {
                            if (primeraCadena)
                            {
                                primeraCadena = false;
                            }

                            // Como para cadenas no hay fichero .names, debo extraer las clases existentes del fichero .data

                            else
                            {
                                if (fichero.Peek() < 0)
                                {
                                    cadena += caracter;
                                }

                                if (!nombresClases.Contains(cadena))
                                {
                                    nombresClases.Add(cadena);
                                }

                                primeraCadena = true;
                            }

                            cadena = cadena.Trim();

                            v.Add(cadena);

                            cadena = "";
                        }

                        if ((caracter == '\n' || fichero.Peek() < 0) && v.Count > 0)
                        {
                            CjtoEntrenamiento.Add(v.Clone());

                            v.Clear();
                        }
                    }

                    DictionaryEntry par = new DictionaryEntry();

                    par.Value = 0;

                    for (int i = 0; i < nombresClases.Count; i++)
                    {
                        par.Key = nombresClases[i];

                        Clases.Add(par);
                    }
                }

                else if (tipoAplicacion == "Conjuntos")
                {
                    DictionaryEntry par = new DictionaryEntry();

                    par.Value = 0;

                    // Mientras no sea fin de fichero

                    while (fichero.Peek() >= 0)
                    {
                        // Lectura de datos (el 44 es el código ASCII de la coma (,))

                        caracter = (char)fichero.Read();

                        while (caracter != 44 && fichero.Peek() >= 0 && caracter != '\n' && caracter != '\r')
                        {
                            cadena += caracter;

                            caracter = (char)fichero.Read();
                        }

                        if (cadena != "")
                        {
                            if (fichero.Peek() < 0)
                            {
                                cadena += caracter;
                            }

                            if (caracter != '\r' && fichero.Peek() >= 0)
                            {
                                cadena = cadena.Replace('.', ',');

                                cadena = cadena.Trim();

                                v.Add(cadena);
                            }

                            else
                            {
                                cadena = cadena.Replace('.', ',');

                                cadena = cadena.Trim();

                                v.Add(cadena);

                                par.Key = cadena;

                                if (!Clases.Contains(par))
                                {
                                    Clases.Add(par);
                                }
                            }

                            cadena = "";
                        }

                        if ((caracter == '\n' || fichero.Peek() < 0) && v.Count > 0)
                        {
                            CjtoEntrenamiento.Add(v.Clone());

                            NumAtributosConjuntos.Add(v.Count);

                            if (v.Count > MayorNumAtributos) MayorNumAtributos = v.Count;

                            v.Clear();
                        }
                    }
                }

                fichero.Close();

                obtenerN();

                copiaCjtoEntrenamiento = ConvertirCjtoATexto();
                
                CopiaCjtoEntrenamientoInicial = new ArrayList(CjtoEntrenamiento);

                CopiaClasesIniciales = new ArrayList(Clases);

                if (tipoAplicacion == "Vectores") CalcularRangos();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Almacena en una matriz los nuevos casos a clasificar que han sido introducidos por el usuario en el textBox
        /// </summary>
        /// <param name="casosIntroducidos"></param>
        /// <returns></returns>
        public bool AlmacenarCasosClasificar (string casosIntroducidos)
        {
            try
            {                               
                // Me aseguro de que se almacenarán los datos en un conjunto vacío
                
                CasosClasificar.Clear();

                if (txtCorrecto && casosIntroducidos == "")
                {
                    StreamReader fichero = new StreamReader(@rutaTxt);

                    casosIntroducidos = fichero.ReadToEnd();

                }

                copiaCasosClasificar = casosIntroducidos;                

                int tam = casosIntroducidos.Length;

                listaCasosClasificar = casosIntroducidos;

                string cadena = "";

                if (tipoAplicacion == "Vectores")
                {
                    ArrayList v = new ArrayList();

                    bool parentesisAbierto = false, parentesisCerrado = false;

                    int contaAtributos = 0;

                    bool NuevoCaso = false;

                    for (int i = 0; i < tam; i++)
                    {
                        if (NuevoCaso)
                        {
                            // Lo que leemos ya son atributos

                            while (casosIntroducidos[i] != ',' && casosIntroducidos[i] != ')' && casosIntroducidos[i] != '\n' && casosIntroducidos[i] != '\r')
                            {
                                if ((casosIntroducidos[i] == ' ' && cadena != "") || casosIntroducidos[i] != ' ')
                                {
                                    cadena += casosIntroducidos[i];
                                }

                                i++;
                            }

                            if (cadena != "")
                            {
                                cadena = cadena.Replace('.', ',');

                                cadena = cadena.Trim();

                                v.Add(cadena);

                                contaAtributos++;

                                cadena = "";
                            }

                            if (casosIntroducidos[i] == ')')
                            {
                                if (contaAtributos != M)
                                {
                                    // No se introdujeron los datos correctamente

                                    v.Clear();

                                    CasosClasificar.Clear();

                                    return false;
                                }

                                else
                                {
                                    // Almaceno el nuevo caso

                                    CasosClasificar.Add(v.Clone());

                                    NuevoCaso = false;

                                    v.Clear();

                                    if (!parentesisCerrado) parentesisCerrado = true;
                                }
                            }
                        }

                        if (casosIntroducidos[i] == '(')
                        {
                            // A partir del paréntesis de apertura, para que sea correcto deberá haber M atributos y M-1 comas antes del paréntesis de cierre

                            contaAtributos = 0;

                            NuevoCaso = true;

                            if (!parentesisAbierto) parentesisAbierto = true;
                        }

                    }

                    if (!parentesisAbierto || !parentesisCerrado) return false;

                    CopiaCasosClasificarIniciales = new ArrayList(CasosClasificar);

                    return true;
                }

                else if (tipoAplicacion == "Cadenas")
                {
                    for (int i = 0; i < tam; i++)
                    {
                        if (casosIntroducidos[i] != ' ' && casosIntroducidos[i] != '\n' && casosIntroducidos[i] != '\r')
                        {
                            cadena += casosIntroducidos[i];
                        }

                        if ((casosIntroducidos[i] == ' ' || casosIntroducidos[i] == '\n' || casosIntroducidos[i] == '\r' || i == tam - 1) && cadena.Length > 0)
                        {
                            CasosClasificar.Add(cadena);

                            cadena = "";
                        }
                    }

                    CopiaCasosClasificarIniciales = new ArrayList(CasosClasificar);

                    return true;
                }

                else if (tipoAplicacion == "Conjuntos")
                {
                    ArrayList v = new ArrayList();

                    bool parentesisAbierto = false, parentesisCerrado = false;

                    bool NuevoCaso = false;

                    for (int i = 0; i < tam; i++)
                    {
                        if (NuevoCaso)
                        {
                            // Lo que leemos ya son atributos

                            while (casosIntroducidos[i] != ' ' && casosIntroducidos[i] != ',' && casosIntroducidos[i] != ')' && casosIntroducidos[i] != '\n' && casosIntroducidos[i] != '\r')
                            {
                                cadena += casosIntroducidos[i];

                                i++;
                            }

                            if (cadena != "")
                            {
                                cadena = cadena.Replace('.', ',');

                                cadena = cadena.Trim();

                                v.Add(cadena);

                                cadena = "";
                            }

                            if (casosIntroducidos[i] == ')')
                            {
                                // Almaceno el nuevo caso

                                CasosClasificar.Add(v.Clone());

                                NuevoCaso = false;

                                v.Clear();

                                if (!parentesisCerrado) parentesisCerrado = true;
                            }
                        }

                        if (casosIntroducidos[i] == '(')
                        {
                            NuevoCaso = true;

                            if (!parentesisAbierto) parentesisAbierto = true;
                        }

                    }

                    if (!parentesisAbierto || !parentesisCerrado) return false;

                    CopiaCasosClasificarIniciales = new ArrayList(CasosClasificar);

                    return true;
                }

                return false;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Comprueba si se han producido cambios en el contenido del textBox respecto a lo almacenado desde el archivo .txt
        /// </summary>
        /// <param name="contenidoBox"></param>
        public bool ComprobarCambiosCasosClasificar(string contenidoTextBox)
        {
            try
            {
                if (contenidoTextBox == listaCasosClasificar) return true;

                // Guardo una copia de seguridad de los casos a clasificar anteriores

                ArrayList copiaSeguridad = new ArrayList (CasosClasificar);

                // Almaceno dichos casos nuevos

                bool ok = AlmacenarCasosClasificar(contenidoTextBox);

                if (ok) return true;

                else
                {
                    // Dejo todo como estaba

                    CasosClasificar = new ArrayList(copiaSeguridad);

                    return false;
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Divide el conjunto de entrenamiento en C subconjuntos
        /// </summary>
        protected void DividirConjuntoEntrenamiento()
        {
            ArrayList aux = new ArrayList();

            subconjuntosValidacion.Clear();

            for (int i = 0; i < C; i++)
            {
                subconjuntosValidacion.Add(aux.Clone());
            }

            int subconj = 0;

            for (int j = 0; j < N; j++)
            {
                ((ArrayList)subconjuntosValidacion[subconj]).Add(j);

                if (subconj == C - 1) subconj = 0;

                else subconj++;
            }
        }

        /// <summary>
        /// Ordena el vector de distancias de forma ascendente mediante el algoritmo Mergesort
        /// </summary>
        /// <param name="ini"></param>
        /// <param name="fin"></param>
        protected ArrayList OrdenaDistancias(ArrayList lista)
        {
            try
            {
                if (lista.Count <= 1) return lista;

                int medio = lista.Count / 2;

                ArrayList parteIzquierda = new ArrayList();

                ArrayList parteDerecha = new ArrayList();

                for (int i = 0; i < medio; i++) parteIzquierda.Add(lista[i]);

                for (int i = medio; i < lista.Count; i++) parteDerecha.Add(lista[i]);

                return Merge(OrdenaDistancias(parteIzquierda), OrdenaDistancias(parteDerecha));
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Función auxiliar para la aplicación del algoritmo MergeSort
        /// </summary>
        /// <param name="ini"></param>
        /// <param name="med"></param>
        /// <param name="fin"></param>
        protected ArrayList Merge (ArrayList parteIzquierda, ArrayList parteDerecha)
        {
            try
            {

                ArrayList aux = new ArrayList();

                while (parteIzquierda.Count > 0 && parteDerecha.Count > 0)
                {
                    if (System.Convert.ToDouble(((DictionaryEntry)parteIzquierda[0]).Value) < System.Convert.ToDouble(((DictionaryEntry)parteDerecha[0]).Value))
                    {
                        aux.Add(parteIzquierda[0]);

                        parteIzquierda.RemoveAt(0);
                    }

                    else
                    {
                        aux.Add(parteDerecha[0]);

                        parteDerecha.RemoveAt(0);
                    }
                }

                for (int i = 0; i < parteIzquierda.Count; i++)
                {
                    aux.Add(parteIzquierda[i]);
                }

                for (int i = 0; i < parteDerecha.Count; i++)
                {
                    aux.Add(parteDerecha[i]);
                }

                return aux;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna la clase más votada de entre los K vecinos más cercanos
        /// </summary>
        /// <returns></returns>
        protected DictionaryEntry ClaseMasVotada()
        {
            try
            {
                // Si el peso depende del orden de vecindad, debo asignar los pesos antes por si hay más de un caso a la misma distancia
                
                ArrayList pesosOrdenVecindad = new ArrayList();

                if (PesadoCasos == "Orden") pesosOrdenVecindad = CalcularPesosOrdenVecindad();
                
                // Hago el recuento de clases de los vecinos

                DictionaryEntry aux = new DictionaryEntry();

                int posClase = 0;

                double voto;

                bool conConjuntos = false;

                if (tipoAplicacion == "Vectores") posClase = M;

                else if (tipoAplicacion == "Cadenas") posClase = 1;

                else if (tipoAplicacion == "Conjuntos") conConjuntos = true;

                for (int i = 0; i < K; i++)
                {
                    if (conConjuntos)
                    {
                        // Debo calcular la posición donde se encuentra la clase en cada iteración

                        posClase = ((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[i]).Key)]).Count - 1;
                    }

                    for (int j = 0; j < Clases.Count; j++)
                    {
                        if (System.Convert.ToString(((DictionaryEntry)Clases[j]).Key) == System.Convert.ToString(((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[i]).Key)])[posClase]))
                        {
                            switch (PesadoCasos)
                            {
                                case "Iguales":

                                    voto = 1;

                                    break;

                                case "Inversamente":

                                    voto = 1 / System.Convert.ToDouble(((DictionaryEntry)Distancias[i]).Value);

                                    break;

                                case "Orden":

                                    voto = System.Convert.ToDouble(pesosOrdenVecindad[i]);

                                    break;

                                default:

                                    voto = 1;

                                    break;
                            }

                            aux.Value = System.Convert.ToDouble(((DictionaryEntry)Clases[j]).Value) + voto;

                            aux.Key = ((DictionaryEntry)Clases[j]).Key;

                            Clases.RemoveAt(j);

                            Clases.Insert(j, aux);

                            break;
                        }
                    }
                }

                // Debo controlar, si a partir de los K, los siguientes casos están también a la misma distancia, pues en ese caso su voto también cuenta

                int p = K;

                double distanciaUltimoVecino = System.Convert.ToDouble(((DictionaryEntry)Distancias[K - 1]).Value);

                while (p < Distancias.Count && System.Convert.ToDouble(((DictionaryEntry)Distancias[p]).Value) == distanciaUltimoVecino)
                {
                    if (conConjuntos)
                    {
                        // Debo calcular la posición donde se encuentra la clase en cada iteración

                        posClase = ((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[p]).Key)]).Count - 1;
                    }

                    for (int w = 0; w < Clases.Count; w++)
                    {
                        if (System.Convert.ToString(((DictionaryEntry)Clases[w]).Key) == System.Convert.ToString(((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[p]).Key)])[posClase]))
                        {
                            switch (PesadoCasos)
                            {
                                case "Iguales":

                                    voto = 1;

                                    break;

                                case "Inversamente":

                                    voto = 1 / System.Convert.ToDouble(((DictionaryEntry)Distancias[p]).Value);

                                    break;

                                case "Orden":

                                    voto = System.Convert.ToDouble(pesosOrdenVecindad[p]);

                                    break;

                                default:

                                    voto = 1;

                                    break;
                            }

                            aux.Value = System.Convert.ToDouble(((DictionaryEntry)Clases[w]).Value) + voto;

                            aux.Key = ((DictionaryEntry)Clases[w]).Key;

                            Clases.RemoveAt(w);

                            Clases.Insert(w, aux);
                        }
                    }

                    p++;
                }

                int extras = p - (K - 1);

                // Y ahora busco la más votada que será la del nuevo caso (controlando un posible empate)

                ArrayList clasesEmpatadas = new ArrayList();

                string claseNuevoCaso = ComprobarSiHayEmpate(Clases, ref clasesEmpatadas);

                if (claseNuevoCaso == "Empate")
                {
                    // Desempatar

                    claseNuevoCaso = Desempatar(clasesEmpatadas);
                }

                clasesEmpatadas.Clear();

                DictionaryEntry resultado = new DictionaryEntry();

                double valor;

                for (int i = 0; i < Clases.Count; i++)
                {
                    if (System.Convert.ToString(((DictionaryEntry)Clases[i]).Key) == claseNuevoCaso)
                    {
                        valor = System.Convert.ToDouble(((DictionaryEntry)Clases[i]).Value);
                        
                        resultado.Value = Math.Round( (valor/(K + extras)) * 100, 2);

                        // En caso de haber votación con rechazo, debo comprobar que la clase más votada supera los K / M votos

                        if (VotacionConRechazo == true)
                        {
                            if (System.Convert.ToDouble(((DictionaryEntry)Clases[i]).Value) < ValorRechazo)
                            {
                                resultado.Key = "Dudoso";

                                return resultado;
                            }
                        }

                        resultado.Key = claseNuevoCaso;

                        return resultado;
                    }
                }

                return resultado;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Asigna los pesos a los casos para el caso de que se asignen por orden de vecindad
        /// </summary>
        /// <returns></returns>
        protected ArrayList CalcularPesosOrdenVecindad()
        {
            try
            {
                ArrayList pesos = new ArrayList();

                // Compruebo que no se entró por error

                if (PesadoCasos != "Orden") return null;

                // Primero calculo el número de casos para los que debo calcular el peso

                int conta = K, num = 1, pesoActual = K;

                while (conta < Distancias.Count && System.Convert.ToDouble(((DictionaryEntry)Distancias[conta]).Value) == System.Convert.ToDouble(((DictionaryEntry)Distancias[K-1]).Value))
                {
                    conta++;
                }

                double distanciaAnterior = System.Convert.ToDouble(((DictionaryEntry)Distancias[0]).Value), distancia;

                for (int i = 1; i < conta; i++)
                {
                    distancia = System.Convert.ToDouble(((DictionaryEntry)Distancias[i]).Value);

                    if (distancia == distanciaAnterior)
                    {
                        num++;
                    }

                    else
                    {
                        distanciaAnterior = distancia;

                        for (int j = 0; j < num; j++)
                        {
                            pesos.Add(pesoActual);

                            pesoActual--;
                        }

                        num = 1;
                    }
                }

                while (pesos.Count < conta)
                {
                    pesos.Add(System.Convert.ToDouble(pesoActual)/System.Convert.ToDouble(num));
                }

                return pesos;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Comprueba si se produjo un empate a la hora de recontar los votos para la clase más votada
        /// </summary>
        /// <param name="contadorClases"></param>
        /// <param name="clasesEmpatadas"></param>
        /// <returns></returns>
        protected string ComprobarSiHayEmpate (ArrayList contadorClases, ref ArrayList clasesEmpatadas)
        {
            try
            {
                int posMax = 0;

                bool empate = false;

                clasesEmpatadas.Add(0);

                for (int p = 1; p < contadorClases.Count; p++)
                {
                    if (System.Convert.ToDouble(((DictionaryEntry)contadorClases[p]).Value) > System.Convert.ToDouble(((DictionaryEntry)contadorClases[posMax]).Value))
                    {
                        posMax = p;

                        if (empate)
                        {
                            empate = false;
                        }

                        clasesEmpatadas.Clear();

                        clasesEmpatadas.Add(p);
                    }

                    else if (System.Convert.ToDouble(((DictionaryEntry)contadorClases[p]).Value) == System.Convert.ToDouble(((DictionaryEntry)contadorClases[posMax]).Value))
                    {
                        empate = true;

                        clasesEmpatadas.Add(p);
                    }
                }

                if (empate) return "Empate";

                else return System.Convert.ToString(((DictionaryEntry)contadorClases[posMax]).Key);
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Desempata la votación de la clase según el método que se haya seleccionado
        /// </summary>
        /// <param name="clasesEmpatadas"></param>
        /// <returns></returns>
        protected string Desempatar(ArrayList clasesEmpatadas)
        {
            try
            {
                string clase = "", claseKMenosUno = "";

                int posClase = 0;

                if (tipoAplicacion == "Vectores") posClase = M;

                else if (tipoAplicacion == "Cadenas") posClase = 1;

                switch (opcionDesempate)
                {
                    case "ModificarK":

                        ArrayList copiaClasesMenos = new ArrayList(), lista = new ArrayList();

                        copiaClasesMenos = Clases;

                        // Clase con K-1 vecinos

                        if (K > 1)
                        {
                            // Si fuera 1 no se podría calcular para 0 vecinos

                            // Hago el recuento de clases de los vecinos

                            DictionaryEntry aux = new DictionaryEntry();

                            for (int i = 0; i < K - 1; i++)
                            {
                                for (int j = 0; j < copiaClasesMenos.Count; j++)
                                {
                                    if (System.Convert.ToString(((DictionaryEntry)copiaClasesMenos[j]).Key) == System.Convert.ToString(((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[i]).Key)])[posClase]))
                                    {
                                        aux.Value = System.Convert.ToInt32(((DictionaryEntry)copiaClasesMenos[j]).Value) + 1;

                                        aux.Key = ((DictionaryEntry)copiaClasesMenos[j]).Key;

                                        copiaClasesMenos.RemoveAt(j);

                                        copiaClasesMenos.Insert(j, aux);
                                    }
                                }
                            }

                            // Análisis de resultados

                            claseKMenosUno = ComprobarSiHayEmpate(copiaClasesMenos, ref lista);
                        }                                                

                        // Si no se logra desempatar modificando K, se desempatará con la clase del vecino más cercano

                        clase = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[0]).Key)])[posClase]);

                        break;

                    case "MasCercano":

                        clase = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[0]).Key)])[posClase]);

                        break;
                }

                return clase;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Amplía el conjunto de entrenamiento
        /// </summary>
        /// <param name="casosIntroducidos"></param>
        /// <returns></returns>
        public bool AnadirNuevosCasosConocidos(string casosIntroducidos)
        {
            try
            {
                ArrayList v = new ArrayList(), aux = new ArrayList();

                int tam = casosIntroducidos.Length, contaAtributos = 0;

                string cadena = "";

                bool NuevoCaso = false, parentesisAbierto = false, parentesisCerrado = false;

                if (tipoAplicacion == "Vectores")
                {
                    for (int i = 0; i < tam; i++)
                    {
                        if (NuevoCaso)
                        {
                            // Lo que leemos ya son atributos

                            while (i < tam && casosIntroducidos[i] != ' ' && casosIntroducidos[i] != ',' && casosIntroducidos[i] != ')' && casosIntroducidos[i] != '\n' && casosIntroducidos[i] != '\r')
                            {
                                cadena += casosIntroducidos[i];

                                i++;
                            }

                            if (i < tam && cadena != "")
                            {
                                cadena = cadena.Replace('.', ',');

                                cadena = cadena.Trim();

                                v.Add(cadena);

                                contaAtributos++;

                                cadena = "";
                            }

                            if (i < tam && casosIntroducidos[i] == ')')
                            {
                                if (contaAtributos != M + 1)
                                {
                                    // No se introdujeron los datos correctamente

                                    v.Clear();

                                    aux.Clear();

                                    return false;
                                }

                                else
                                {
                                    // Almaceno el nuevo caso

                                    aux.Add(v.Clone());

                                    NuevoCaso = false;

                                    v.Clear();

                                    if (!parentesisCerrado) parentesisCerrado = true;
                                }
                            }
                        }

                        if (casosIntroducidos[i] == '(')
                        {
                            // A partir del paréntesis de apertura, para que sea correcto deberá haber M+1 elementos (atributos y clase)
                            // y M comas antes del paréntesis de cierre

                            contaAtributos = 0;

                            NuevoCaso = true;

                            if (!parentesisAbierto) parentesisAbierto = true;
                        }
                    }

                    if (!parentesisAbierto || !parentesisCerrado) return false;

                    // Se almacenan los nuevos casos conocidos en el conjunto de entrenamiento 
                    // y se incrementa el número de muestras N

                    for (int i = 0; i < aux.Count; i++)
                    {
                        CjtoEntrenamiento.Add((ArrayList)((ArrayList)aux[i]).Clone());

                        N++;
                    }

                    aux.Clear();

                    copiaCjtoEntrenamiento = ConvertirCjtoATexto();

                    CalcularRangos();

                    return true;
                }

                else if (tipoAplicacion == "Cadenas")
                {
                    for (int i = 0; i < tam; i++)
                    {
                        while (i < tam && casosIntroducidos[i] != ' ' && casosIntroducidos[i] != '\n' && casosIntroducidos[i] != '\r')
                        {
                            cadena += casosIntroducidos[i];

                            i++;
                        }

                        if (i < tam)
                        {
                            if ((casosIntroducidos[i] == ' ' || casosIntroducidos[i] == '\r') && cadena != "")
                            {
                                v.Add(cadena);

                                cadena = "";

                                contaAtributos++;

                                if (casosIntroducidos[i] == '\r')
                                {
                                    if (contaAtributos != 2) return false;

                                    else
                                    {
                                        CjtoEntrenamiento.Add(v.Clone());

                                        v.Clear();

                                        N++;

                                        contaAtributos = 0;
                                    }
                                }
                            }
                        }

                        else
                        {
                            v.Add(cadena);

                            cadena = "";

                            contaAtributos++;
                            
                            if (contaAtributos != 2) return false;

                            else
                            {
                                CjtoEntrenamiento.Add(v.Clone());

                                v.Clear();

                                N++;
                            }
                        }
                    }

                    if (System.Convert.ToString(copiaCjtoEntrenamiento[copiaCjtoEntrenamiento.Length - 1]) == "\n")
                        
                        copiaCjtoEntrenamiento += casosIntroducidos;

                    else copiaCjtoEntrenamiento += "\r\n" + casosIntroducidos;
                    
                    return true;
                }

                else if (tipoAplicacion == "Conjuntos")
                {
                    if (casosIntroducidos[casosIntroducidos.Length - 1] != '\n' && casosIntroducidos[casosIntroducidos.Length - 2] != '\r') casosIntroducidos += "\r\n";               
                    
                    for (int i = 0; i < tam; i++)
                    {
                        while (i < tam && casosIntroducidos[i] != ',' && casosIntroducidos[i] != '\n' && casosIntroducidos[i] != '\r')
                        {
                            cadena += casosIntroducidos[i];

                            i++;
                        }

                        if (i < tam && (casosIntroducidos[i] == '\n' || casosIntroducidos[i] == ',') && cadena != "")
                        {
                            cadena = cadena.Replace('.', ',');

                            cadena = cadena.Trim();

                            v.Add(cadena);

                            cadena = "";
                        }

                        if (i < tam && casosIntroducidos[i] == '\r')
                        {
                            // Almaceno el nuevo caso

                            aux.Add(v.Clone());

                            v.Clear();
                        }
                    }

                    // Se almacenan los nuevos casos conocidos en el conjunto de entrenamiento 
                    // y se incrementa el número de muestras N

                    for (int i = 0; i < aux.Count; i++)
                    {
                        CjtoEntrenamiento.Add((ArrayList)((ArrayList)aux[i]).Clone());

                        N++;
                    }

                    aux.Clear();

                    if (System.Convert.ToString(copiaCjtoEntrenamiento[copiaCjtoEntrenamiento.Length - 1]) == "\n")

                        copiaCjtoEntrenamiento += casosIntroducidos;

                    else copiaCjtoEntrenamiento += "\r\n" + casosIntroducidos;
                                                            
                    return true;
                }

                return false;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza todas las estructuras de datos con la información obtenida tras el análisis del último caso
        /// </summary>
        protected void ActualizarEstructuras()
        {
            try
            {
                // Aumento el puntero de los casos a clasificar

                punteroCasosClasificar++;

                // Reseteo los contadores de cada clase

                DictionaryEntry par = new DictionaryEntry();

                par.Value = 0;

                for (int i = 0; i < Clases.Count; i++)
                {
                    par.Key = ((DictionaryEntry)Clases[i]).Key;

                    Clases.RemoveAt(i);

                    Clases.Insert(i, par);
                }

                // Y borro las distancias calculadas pues ya no servirán para el nuevo caso a tratar

                Distancias.Clear();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda los datos necesarios para ser almacenados posteriormente en un fichero .txt
        /// </summary>
        public void GuardarResultados()
        {
            try
            {
                string datosAGuardar = "";

                string aux = "";

                datosAGuardar += "\r\nParámetros de configuración:\r\n\r\n";

                datosAGuardar += "Tipo de aplicación: " + verTab() + "\r\n\r\n";

                datosAGuardar += "Conjunto de entrenamiento:\r\n\r\n";

                datosAGuardar += copiaCjtoEntrenamiento + "\r\n\r\n";

                datosAGuardar += "Distancia a aplicar: ";

                switch (verTab())
                {
                    case "Vectores":

                        // Almaceno la distancia

                        datosAGuardar += mostrarDistanciaACalcularVectores();

                        if (mostrarDistanciaACalcularVectores() == "Minkowski") datosAGuardar += " con q = " + verQ() + "\r\n\r\n";

                        else datosAGuardar += "\r\n\r\n";

                        // Almaceno la normalización

                        if (tipoNormalizacion == "No normalizar")
                        {
                            datosAGuardar += "Normalización: No\r\n\r\n";
                        }

                        else
                        {
                            if (ListaAtributosNormalizar.Count == verM()) datosAGuardar += "Normalizar todos los atributos ";

                            else
                            {
                                datosAGuardar += "Normalizar ";

                                int pos;

                                for (int i = 0; i < ListaAtributosNormalizar.Count; i++)
                                {
                                    pos = System.Convert.ToInt32(ListaAtributosNormalizar[i]);

                                    aux += System.Convert.ToString(((DictionaryEntry)Atributos[pos]).Key) + "\r\n";
                                }
                            }

                            switch (tipoNormalizacion)
                            {
                                case "Intervalo":

                                    datosAGuardar += "al intervalo [" + verA() + ", " + verB() + "]";

                                    break;

                                case "mediaVarianza":

                                    datosAGuardar += "a media cero y varianza unidad";

                                    break;
                            }

                            if (aux.Length > 0)
                            {
                                datosAGuardar += " los siguientes atributos:\r\n\r\n";

                                datosAGuardar += aux + "\r\n";

                                aux = "";
                            }

                            else datosAGuardar += "\r\n\r\n";
                        }

                        // Almaceno la regresión

                        datosAGuardar += "Regresión: ";

                        if (usarRegresion) datosAGuardar += "Sí\r\n\r\n";

                        else datosAGuardar += "No\r\n\r\n";

                        // Almaceno la transformación

                        datosAGuardar += "Transformación de atributos cualitativos a booleanos: ";

                        if (aplicarTransformacion) datosAGuardar += "Sí\r\n\r\n";

                        else datosAGuardar += "No\r\n\r\n";

                        // Almaceno el pesado de atributos

                        datosAGuardar += "Pesado de atributos:";
                        
                        aux = "\r\n\r\n";

                        bool HayPesado = false;

                        double peso;

                        for (int i = 0; i < PesosAtributos.Count; i++)
                        {
                            peso = System.Convert.ToDouble(PesosAtributos[i]);

                            if (peso != 1 && !HayPesado) HayPesado = true;

                            aux += "Atributo " + System.Convert.ToString(((DictionaryEntry)Atributos[i]).Key) + "  --->  Peso " + peso + "\r\n\r\n";
                        }

                        if (!HayPesado) datosAGuardar += "No\r\n\r\n";

                        else datosAGuardar += aux;

                        break;

                    case "Cadenas":

                        // Almaceno la distancia

                        datosAGuardar += mostrarDistanciaACalcularCadenas() + "\r\n\r\n";

                        break;

                    case "Conjuntos":

                        // Almaceno la distancia

                        datosAGuardar += mostrarDistanciaACalcularConjuntos() + "\r\n\r\n";

                        datosAGuardar += "Distancia a aplicar en el espacio base: " + mostrarDistanciaACalcularEspacioBase() + "\r\n\r\n";

                        break;
                }

                // Almaceno el pesado de casos

                datosAGuardar += "Pesado de casos: ";

                if (PesadoCasos == "Iguales") datosAGuardar += "No\r\n\r\n";

                else if (PesadoCasos == "Orden") datosAGuardar += "Según el orden de vecindad\r\n\r\n";

                else datosAGuardar += "Inversamente proporcional a la distancia\r\n\r\n";
                
                // Almaceno la votación con rechazo

                if (VotacionConRechazo) datosAGuardar += "Votación con rechazo si el número de votos es menor que " + ValorRechazo;

                else datosAGuardar += "Votación sin rechazo";

                // Almaceno la K

                datosAGuardar += "\r\n\r\nK = " + verK();

                // Almaceno las clasificaciones hechas

                datosAGuardar += "\r\n\r\nResultados:\r\n\r\n";

                if (!usarValidacion)
                {
                    int caso = 0;

                    for (int i = 0; i < listaCasosClasificar.Length; i++)
                    {
                        if (listaCasosClasificar[i] != '\r')
                        {
                            datosAGuardar += listaCasosClasificar[i];
                        }

                        else
                        {
                            datosAGuardar += "  --->  Clase " + ((DictionaryEntry)ClasesCasos[caso]).Key;

                            if (!usarRegresion) datosAGuardar += "  --->  Probabilidad " + ((DictionaryEntry)ClasesCasos[caso]).Value + "%";

                            datosAGuardar += "\r\n";

                            i++;

                            caso++;
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < ClasesCasos.Count; i++)
                    {
                        datosAGuardar += "K = " + (i + 1) + "  --->  Aciertos: " + ClasesCasos[i] + "\r\n";
                    }

                    // Almaceno el K óptimo

                    int max = System.Convert.ToInt32(ClasesCasos[0]);

                    string texto = "1, ";

                    for (int i = 1; i < ClasesCasos.Count; i++)
                    {
                        if (System.Convert.ToInt32(ClasesCasos[i]) > max)
                        {
                            texto = System.Convert.ToString(i + 1) + ", ";

                            max = System.Convert.ToInt32(ClasesCasos[i]);
                        }

                        else if (System.Convert.ToInt32(ClasesCasos[i]) == max)
                        {
                            texto += System.Convert.ToString(i + 1) + ", ";
                        }
                    }

                    texto = texto.Remove(texto.Length - 2);

                    datosAGuardar += "\r\nValor óptimo de K: " + texto;
                }

                // Guardo los datos en la ruta indicada

                StreamWriter fichero = new StreamWriter(@rutaGuardar);

                fichero.Write(datosAGuardar);

                fichero.Close();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve las tasas de aciertos para todos los K solicitados
        /// </summary>
        /// <returns></returns>
        public ArrayList ValidacionCruzada()
        {
            try
            {
                DividirConjuntoEntrenamiento();

                // Guardo el conjunto de entrenamiento antes de ir cogiendo subconjuntos

                CopiaCjtoEntrenamientoInicial = new ArrayList(CjtoEntrenamiento);

                ClasesCasos.Clear();

                TasasAciertos.Clear();

                int contaAciertos = 0;

                for (int i = 1; i <= KValidacion; i++)
                {
                    almacenarK(i);

                    for (int j = 0; j < C; j++)
                    {
                        AsignarCjtoEntrenamientoValidacion(j);

                        AsignarCasosClasificarValidacion(j);

                        obtenerN();

                        switch (verTab())
                        {
                            case "Vectores":

                                ClasesCasos = CalcularConVectores();

                                break;

                            case "Cadenas":

                                ClasesCasos = CalcularConCadenas();

                                break;

                            case "Conjuntos":

                                ClasesCasos = CalcularConConjuntos();

                                break;
                        }

                        // Recuento los aciertos

                        contaAciertos += CalcularTasaAciertos(ClasesCasos, j);
                    }

                    TasasAciertos.Add(contaAciertos);

                    contaAciertos = 0;
                }

                // Dejo el conjunto de entrenamiento como estaba al principio para prevenir posibles errores futuros

                CjtoEntrenamiento = new ArrayList(CopiaCjtoEntrenamientoInicial);

                obtenerN();

                return TasasAciertos;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza la estructura correspondiente quitando el subconjunto que se le solicite con el fin de clasificarlo con la 
        /// validación cruzada
        /// </summary>
        /// <param name="subcjto"></param>
        /// <returns></returns>
        protected void AsignarCjtoEntrenamientoValidacion(int subcjto)
        {
            try
            {
                CjtoEntrenamiento.Clear();

                ArrayList aux = new ArrayList();

                int nInicial = CopiaCjtoEntrenamientoInicial.Count, tam = 0;

                for (int i = 0; i < nInicial; i++)
                {
                    if (!((ArrayList)subconjuntosValidacion[subcjto]).Contains(i))
                    {
                        // Aquí sí almaceno la clase

                        switch (verTab())
                        {
                            case "Vectores":

                                for (int j = 0; j < M + 1; j++)
                                {
                                    aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[j]);
                                }
                                
                                break;

                            case "Cadenas":

                                aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[0]);

                                aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[1]);

                                break;

                            case "Conjuntos":

                                tam = ((ArrayList)CopiaCjtoEntrenamientoInicial[i]).Count;

                                for (int j = 0; j < tam; j++)
                                {
                                    aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[j]);
                                }

                                break;
                        }
                        
                        CjtoEntrenamiento.Add(aux.Clone());

                        aux.Clear();
                    }
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza la estructura correspondiente con el subconjunto que se le solicite con el fin de clasificarlo con la 
        /// validación cruzada (sin la clase)
        /// </summary>
        /// <param name="subcjto"></param>
        /// <returns></returns>
        protected void AsignarCasosClasificarValidacion(int subcjto)
        {
            try
            {
                CasosClasificar.Clear();

                ArrayList aux = new ArrayList();

                int nInicial = CopiaCjtoEntrenamientoInicial.Count, tam = 0;

                for (int i = 0; i < nInicial; i++)
                {
                    if (((ArrayList)subconjuntosValidacion[subcjto]).Contains(i))
                    {
                        // No almaceno la clase, ya que debo recalcularla para contabilizar los aciertos

                        switch (verTab())
                        {
                            case "Vectores":

                                for (int j = 0; j < M; j++)
                                {
                                    aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[j]);
                                }

                                break;

                            case "Cadenas":

                                aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[0]);

                                break;

                            case "Conjuntos":

                                tam = ((ArrayList)CopiaCjtoEntrenamientoInicial[i]).Count;

                                for (int j = 0; j < tam - 1; j++)
                                {
                                    aux.Add(((ArrayList)CopiaCjtoEntrenamientoInicial[i])[j]);
                                }

                                break;
                        }

                        CasosClasificar.Add(aux.Clone());

                        aux.Clear();
                    }
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la tasa de aciertos, comparando los resultados obtenidos con los valores del conjunto de entrenamiento
        /// </summary>
        /// <param name="listaClases"></param>
        /// <param name="subcjto"></param>
        /// <returns></returns>
        protected int CalcularTasaAciertos(ArrayList listaClases, int subcjto)
        {
            try
            {
                int conta = 0, pos;

                string claseCalculada, claseOriginal;

                for (int i = 0; i < ((ArrayList)subconjuntosValidacion[subcjto]).Count; i++)
                {
                    pos = System.Convert.ToInt32(((ArrayList)subconjuntosValidacion[subcjto])[i]);

                    claseCalculada = System.Convert.ToString(((DictionaryEntry)listaClases[i]).Key);

                    claseOriginal = System.Convert.ToString(((ArrayList)CopiaCjtoEntrenamientoInicial[pos])[M]);

                    if (claseCalculada == claseOriginal) conta++;
                }

                return conta;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Restaura los valores iniciales almacenados cara a un posible error durante la ejecución
        /// </summary>
        public void RestaurarDatos()
        {
            try
            {
                CjtoEntrenamiento = new ArrayList(CopiaCjtoEntrenamientoInicial);

                obtenerN();

                if (verTab() == "Vectores")
                {
                    Atributos = new ArrayList(CopiaAtributosIniciales);

                    obtenerM();
                }

                CasosClasificar = new ArrayList(CopiaCasosClasificarIniciales);

                Clases = new ArrayList(CopiaClasesIniciales);
            }

            catch
            {
                throw;
            }
        }
        
        #endregion

        #endregion

        #region Parte de vectores

        #region Miembros

        /// <summary>
        /// Matriz que almacenará el conjunto de entrenamiento normalizado
        /// </summary>
        protected ArrayList CjtoNormalizado = new ArrayList();

        /// <summary>
        /// Array que almacena los atributos normalizados del nuevo caso a clasificar
        /// </summary>
        protected ArrayList NuevoCasoNormalizado = new ArrayList();

        /// <summary>
        /// Número de atributos de cada muestra
        /// </summary>
        protected int M;

        /// <summary>
        /// Vector que almacena el nombre de los atributos que definen los casos y su tipo (cuantitativo o cualitativo)
        /// </summary>
        protected ArrayList Atributos = new ArrayList();

        /// <summary>
        /// Almacena una copia de los atributos iniciales, para poder recuperarlos posteriormente si se desea
        /// </summary>
        protected ArrayList CopiaAtributosIniciales = new ArrayList();

        /// <summary>
        /// Vector que almacena los valores máximo y mínimo de un atributo numérico, o los valores que contiene si es cualitativo
        /// </summary>
        protected ArrayList RangosAtributos = new ArrayList();

        /// <summary>
        /// Vector que almacena el peso asignado a cada uno de los atributos, por defecto todos tienen peso 1
        /// </summary>
        protected ArrayList PesosAtributos = new ArrayList();

        /// <summary>
        /// Almacena un valor mayor que 0 para el cálculo de la distancia de Minkowski
        /// </summary>
        protected double qMinkowski;

        /// <summary>
        /// Ruta del archivo con extensión .names
        /// </summary>        
        protected string rutaNames;

        /// <summary>
        /// Variable de control para comprobar si el fichero .names introducido es correcto
        /// </summary>
        protected bool namesCorrecto = false;

        /// <summary>
        /// Tipo de distancia a calcular, según se seleccione en la pestaña de vectores
        /// </summary>
        protected string distanciaACalcularVectores = "";

        /// <summary>
        /// Tipo de normalización a aplicar a los atributos.
        /// Por defecto: Intervalo. 
        /// Otros posibles valores: mediaVarianza, No normalizar
        /// </summary>
        protected string tipoNormalizacion = "Intervalo";

        /// <summary>
        /// Valor de la parte izquierda del intervalo, por defecto 0 -> [0,1]
        /// </summary>
        protected double aIntervalo = 0;

        /// <summary>
        /// Valor de la parte derecha del intervalo, por defecto 1 -> [0,1]
        /// </summary>
        protected double bIntervalo = 1;

        /// <summary>
        /// Almacena los números de los atributos que se deben normalizar
        /// </summary>
        protected ArrayList ListaAtributosNormalizar = new ArrayList();

        /// <summary>
        /// Almacena una copia de los atributos a normalizar iniciales
        /// </summary>
        protected ArrayList ListaAtributosNormalizarIniciales = new ArrayList();

        /// <summary>
        /// Almacena las posiciones de los atributos que el usuario decide que se ignoren en los cálculos 
        /// </summary>
        protected ArrayList posAtributosIgnorados = new ArrayList();

        /// <summary>
        /// Al ir leyendo los atributos, almacenaré las posiciones de los cualitativos de cara a una posible transformación a variables booleanas
        /// </summary>
        protected ArrayList posCualitativos = new ArrayList();

        /// <summary>
        /// Almacena los posibles valores que puede tener un atributo cualitativo de acuerdo al archivo .names
        /// </summary>
        protected ArrayList valoresPosiblesCualitativos = new ArrayList();

        /// <summary>
        /// Indica si es necesario transformar las variables cualitativas a booleanas
        /// </summary>
        protected bool aplicarTransformacion = false;

        /// <summary>
        /// Almacena el valor de M previo a la transformación de las variables cualitativas a booleanas
        /// </summary>
        protected int valorMAntesTransformacion;

        /// <summary>
        /// Indica si se deben clasificar los ejemplos mediante regresión
        /// </summary>
        protected bool usarRegresion = false;

        /// <summary>
        /// Contiene una copia de la lista de clases del sistema
        /// </summary>
        protected string copiaClases = "";

        /// <summary>
        /// Contiene una copia de la lista de atributos del sistema
        /// </summary>
        protected string copiaAtributos = "";

        /// <summary>
        /// Almacena la forma en que se tratarán los valores desconocidos. Por defecto se borrarán los casos que los contengan
        /// </summary>
        protected string opcionValoresDesconocidos = "Eliminación";

        #endregion

        #region Observadores

        /// <summary>
        /// Muestra la ruta del fichero .names
        /// </summary>
        /// <returns></returns>
        public string leerRutaNames()
        {
            return rutaNames;
        }

        /// <summary>
        /// Indica la validez del fichero .names seleccionado
        /// </summary>
        /// <returns></returns>
        public bool verSiCorrectoNames()
        {
            return namesCorrecto;
        }

        /// <summary>
        /// Retorna la lista de atributos
        /// </summary>
        /// <returns></returns>
        public ArrayList verAtributos()
        {
            return Atributos;
        }

        /// <summary>
        /// Retorna los pesos de los atributos
        /// </summary>
        /// <returns></returns>
        public ArrayList verPesos()
        {
            return PesosAtributos;
        }

        /// <summary>
        /// Retorna los rangos de los atributos
        /// </summary>
        /// <returns></returns>
        public ArrayList verRangosAtributos()
        {
            return RangosAtributos;
        }

        /// <summary>
        /// Retorna las posiciones de los atributos que se ignoran
        /// </summary>
        /// <returns></returns>
        public ArrayList verPosAtributosIgnorados()
        {
            return posAtributosIgnorados;
        }

        /// <summary>
        /// Retorna el número de atributos que describen los casos
        /// </summary>
        /// <returns></returns>
        public int verM()
        {
            return M;
        }

        /// <summary>
        /// Retorna la distancia que se aplica a la hora de clasificar los nuevos casos
        /// </summary>
        /// <returns></returns>
        public string mostrarDistanciaACalcularVectores()
        {
            return distanciaACalcularVectores;
        }

        /// <summary>
        /// Muestra el valor del parámetro q de la distancia de Minkowski
        /// </summary>
        /// <returns></returns>
        public double verQ()
        {
            return qMinkowski;
        }

        /// <summary>
        /// Retorna la lista de atributos que se van a normalizar
        /// </summary>
        /// <returns></returns>
        public ArrayList verListaAtributosNormalizar()
        {
            return ListaAtributosNormalizar;
        }

        /// <summary>
        /// Retorna el tipo de normalización seleccionada
        /// </summary>
        /// <returns></returns>
        public string verNormalizacion()
        {
            if (tipoNormalizacion == "Intervalo")
            {
               if (aIntervalo == 0 && bIntervalo == 1)
               {
                    return "[0,1]";
               }

               return "[a,b]";
            }

            return tipoNormalizacion;
        }

        /// <summary>
        /// Muestra el valor izquierdo del intervalo de normalización
        /// </summary>
        /// <returns></returns>
        public double verA()
        {
            return aIntervalo;
        }

        /// <summary>
        /// Muestra el valor derecho del intervalo de normalización
        /// </summary>
        /// <returns></returns>
        public double verB()
        {
            return bIntervalo;
        }

        /// <summary>
        /// Retorna la lista de clases y atributos del sistema
        /// </summary>
        /// <returns></returns>
        public string verCopiaClasesyAtributos()
        {
            return ("Clases:\r\n\r\n" + copiaClases + "\r\n\r\nAtributos:\r\n\r\n" + copiaAtributos);
        }

        /// <summary>
        /// Muestra el tipo de acción que se realizará al encontrarse un valor desconocido
        /// </summary>
        /// <returns></returns>
        public string verOpcionValoresDesconocidos()
        {
            return opcionValoresDesconocidos;
        }

        /// <summary>
        /// Indica si los atributos cualitativos están transformados en booleanos
        /// </summary>
        /// <returns></returns>
        public bool verSiAplicadaTransformacion()
        {
            return aplicarTransformacion;
        }

        #endregion

        #region Modificadores

        /// <summary>
        /// Calcula el valor de la variable M
        /// </summary>
        public void obtenerM()
        {
            M = Atributos.Count;
        }

        /// <summary>
        /// Almacena la ruta del archivo .names
        /// </summary>
        /// <param name="ruta"></param>
        public void escribirRutaNames(string ruta)
        {
            rutaNames = ruta;
        }

        /// <summary>
        /// Modifica el estado de la ruta del archivo .names
        /// </summary>
        /// <param name="estado"></param>
        public void cambiarEstadoNames(bool estado)
        {
            namesCorrecto = estado;
        }

        /// <summary>
        /// Cambia el tipo de distancia a usar a la hora de clasificar los nuevos casos
        /// </summary>
        /// <param name="tipo"></param>
        public void cambiarDistanciaACalcularVectores(string tipo)
        {
            distanciaACalcularVectores = tipo;
        }

        /// <summary>
        /// Carga en Q el valor introducido por el usuario en la ventana para el cálculo de la distancia de Minkowski
        /// </summary>
        /// <param name="q"></param>
        public void almacenarQ(double q)
        {
            qMinkowski = q;
        }

        /// <summary>
        /// Modifica la lista de atributos
        /// </summary>
        /// <param name="atribs"></param>
        public void modificarAtributos(ArrayList atribs)
        {
            Atributos = atribs;
        }

        /// <summary>
        /// Actualiza los pesos de los atributos conforme a lo estipulado por el usuario en la ventana de la aplicación
        /// </summary>
        /// <param name="pesos"></param>
        public void cambiarPesosAtributos(ArrayList pesos)
        {
            PesosAtributos = pesos;
        }

        /// <summary>
        /// Cambia el tipo y el intervalo de normalización
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void cambiarNormalizacion(string tipo, double a, double b)
        {
            switch (tipo)
            {
                case "[0,1]":

                    tipoNormalizacion = "Intervalo";

                    aIntervalo = 0;

                    bIntervalo = 1;

                    break;

                case "[a,b]":

                    tipoNormalizacion = "Intervalo";

                    aIntervalo = a;

                    bIntervalo = b;

                    break;

                case "mediaVarianza":

                    tipoNormalizacion = tipo;

                    aIntervalo = 0;

                    bIntervalo = 0;

                    break;

                case "No normalizar":

                    tipoNormalizacion = tipo;

                    aIntervalo = -1;

                    bIntervalo = -1;

                    break;
            }
        }

        /// <summary>
        /// Cambia el uso o no de regresión
        /// </summary>
        /// <param name="valor"></param>
        public void cambiarRegresion(bool valor)
        {
            usarRegresion = valor;
        }

        /// <summary>
        /// Cambia el tipo de transformación a variables booleanas
        /// </summary>
        /// <param name="valor"></param>
        public void cambiarTransformacion(bool valor)
        {
            aplicarTransformacion = valor;
        }

        /// <summary>
        /// Modifica la lista de atributos a normalizar
        /// </summary>
        /// <param name="lista"></param>
        public void cambiarListaAtributosNormalizar(ArrayList lista)
        {
            ListaAtributosNormalizar = lista;
        }

        /// <summary>
        /// Modifica la acción a realizar al tratar valores desconocidos
        /// </summary>
        /// <param name="opcion"></param>
        public void cambiarOpcionValoresDesconocidos(string opcion)
        {
            opcionValoresDesconocidos = opcion;
        }
        
        #endregion

        #region Operaciones auxiliares

        /// <summary>
        /// Lee desde un fichero .names en C4.5 los nombres de las clases y de los atributos
        /// </summary>
        public void LeerAtributos()
        {
            try
            {
                // Me aseguro de que se almacenarán los datos en estructuras vacías

                Atributos.Clear();

                Clases.Clear();

                DictionaryEntry par;

                ArrayList auxiliar = new ArrayList();

                string cadena = "", primElem, segElem = "", aux;

                char caracter;

                bool lineaClases = true, ignorar = false;

                StreamReader fichero = new StreamReader(@rutaNames);

                // Mientras no sea fin de fichero

                while (fichero.Peek() >= 0)
                {
                    // Lectura de datos (el 124 es el código ASCII de la barra vertical (|) del comentario)

                    caracter = (char)fichero.Read();

                    if (caracter == 124 || caracter == '\n' || caracter == '\r')
                    {
                        // Estamos en una línea de comentarios o en blanco, se salta

                        while (caracter != '\n')
                        {
                            caracter = (char)fichero.Read();
                        }

                    }

                    else
                    {
                        if (lineaClases)
                        {
                            // Estamos en la línea donde se definen los nombres de las clases

                            // Lectura de datos (el 44 es el código ASCII de la coma (,) y el 46 del punto (.))

                            while (caracter != '\n' && caracter != 46)
                            {
                                while (caracter != 44 && caracter != 46 && caracter != ' ' && caracter != '\t' && caracter != '\r')
                                {
                                    cadena += caracter;

                                    caracter = (char)fichero.Read();
                                }

                                if (cadena != "")
                                {
                                    par.Key = cadena;

                                    par.Value = 0;

                                    Clases.Add(par);

                                    copiaClases += cadena + ", ";

                                    cadena = "";
                                }

                                caracter = (char)fichero.Read();
                            }

                            lineaClases = false;

                            copiaClases = copiaClases.Remove(copiaClases.Length - 2);
                        }

                        else
                        {                           
                            // Aquí ya se definen los atributos y su tipo que debemos almacenar

                            // Lectura del nombre del atributo (el 58 es el código ASCII de los dos puntos (:))

                            while (caracter != 58 && fichero.Peek() >= 0 && caracter != '\n' && caracter != '\r')
                            {
                                cadena += caracter;

                                caracter = (char)fichero.Read();
                            }

                            primElem = cadena;

                            cadena = "";

                            // Lectura del tipo del atributo

                            // Primero saltamos los dos puntos (:) y los espacios que pueda haber en medio

                            while (caracter == 58 || caracter == '\t' || caracter == ' ')
                            {
                                caracter = (char)fichero.Read();
                            }

                            while (fichero.Peek() >= 0 && caracter != '\n' && caracter != '\r')
                            {
                                cadena += caracter;

                                caracter = (char)fichero.Read();
                            }

                            aux = cadena;

                            cadena = "";

                            if (fichero.Peek() < 0)
                            {
                                aux += caracter;
                            }

                            // Clasificamos el tipo como cualitativo, cuantificativo o booleano en función del valor de aux

                            // Si contiene ignore, no almacenamos ni el atributo ni su tipo

                            if (aux.IndexOf("ignore") != -1) ignorar = true;

                            else
                            {
                                // Si es discrete o continuous --> cuantitativo

                                if (aux.IndexOf("discrete") != -1 || aux.IndexOf("continuous") != -1) segElem = "cuantitativo";

                              // Si contiene yes, no o no, yes --> booleano

                                else if (aux.IndexOf("yes, no") != -1 || aux.IndexOf("no, yes") != -1) segElem = "booleano";

                                // Si no es cualitativo

                                else
                                {
                                    segElem = "cualitativo";

                                    auxiliar.Add(primElem);

                                    for (int p = 0; p < aux.Length; p++)
                                    {
                                        // Lectura de los valores posibles del atributo (el 44 es el código ASCII de la coma (,))

                                        while (aux[p] == 44 || aux[p] == '\t' || aux[p] == ' ')
                                        {
                                            p++;
                                        }

                                        while (p != aux.Length && aux[p] != 44 && aux[p] != '\n' && aux[p] != '\r' && aux[p] != '\t' && aux[p] != ' ')
                                        {
                                            cadena += aux[p];

                                            p++;
                                        }

                                        auxiliar.Add(cadena);

                                        cadena = "";
                                    }

                                    valoresPosiblesCualitativos.Add(auxiliar.Clone());

                                    auxiliar.Clear();
                                }
                            }

                            // Se almacenan en un par y posteriormente en el vector

                            if (!ignorar && primElem != "")
                            {
                                par.Key = primElem;

                                par.Value = segElem;

                                copiaAtributos += primElem + "  --->  " + segElem + "\r\n";

                                Atributos.Add(par);

                                if (segElem == "cualitativo")
                                {
                                    // Almaceno la posición de los cualitativos

                                    posCualitativos.Add(Atributos.Count - 1);
                                }
                            }

                            primElem = segElem = "";

                            ignorar = false;

                        }
                    }
                }

                fichero.Close();

                obtenerM();

                CopiaAtributosIniciales = new ArrayList(Atributos);
                
                // Pongo los pesos de todos los atributos a 1 (valor por defecto)
                // y pongo todo los atributos en la lista de atributos a normalizar (por defecto)                

                for (int i = 0; i < M; i++)
                {
                    PesosAtributos.Add(1);
                    
                    ListaAtributosNormalizar.Add(i);
                }

                ListaAtributosNormalizarIniciales = (ArrayList)ListaAtributosNormalizar.Clone();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Comprueba si todas las clases de los casos del conjunto de entrenamiento se encuentran entre las definidas por el archivo .names
        /// </summary>
        /// <returns></returns>
        public bool ComprobarExistenciaClases()
        {
            try
            {
                string clase;

                bool existe;

                for (int i = 0; i < N; i++)
                {
                    existe = false;

                    clase = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]);

                    for (int j = 0; j < Clases.Count; j++)
                    {
                        if (System.Convert.ToString(((DictionaryEntry)Clases[j]).Key) == clase)
                        {
                            existe = true;

                            break;
                        }
                    }

                    if (!existe) return false;
                }

                return true;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula los valores máximo y mínimo de los atributos del conjunto de entrenamiento
        /// </summary>
        protected void CalcularRangos()
        {
            try
            {
                DictionaryEntry par = new DictionaryEntry();

                RangosAtributos.Clear();

                string tipo;
                
                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo" || tipo == "cuantitativo-ignorar")
                    {
                        par = BuscarMaxyMin(j);

                        RangosAtributos.Add(par);                        
                    }

                    else if (tipo == "booleano" || tipo == "booleano-ignorar")
                    {
                        par.Key = 0;

                        par.Value = 1;
                        
                        RangosAtributos.Add(par);
                    }

                    else
                    {
                        RangosAtributos.Add("Cualitativo");
                    }
                }

            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Busca los valores máximo y mínimo de un atributo columna del conjunto de entrenamiento
        /// </summary>
        /// <param name="columna"></param>
        /// <returns></returns>
        protected DictionaryEntry BuscarMaxyMin(int columna)
        {
            try
            {
                double max, min, aux;

                int i = 0;

                while (i < N && System.Convert.ToString(((ArrayList) CjtoEntrenamiento[i])[columna]) == "?")
                {
                    i++;
                }

                if (i == N)
                {
                    DictionaryEntry retorno = new DictionaryEntry();

                    retorno.Key = "?";

                    retorno.Value = "?";

                    return retorno;
                }

                max = min = System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[columna]);

                for (i++; i < N; i++)
                {
                    if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) != "?")
                    {
                        aux = System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[columna]);

                        if (aux > max) max = aux;

                        if (aux < min) min = aux;
                    }
                }

                DictionaryEntry valores = new DictionaryEntry();

                valores.Key = min;

                valores.Value = max;

                return valores;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Realiza la normalización de los datos que se le especifiquen
        /// </summary>
        /// <param name="datos"></param>
        protected void Normalizar(string datos)
        {
            try
            {
                if (datos == "CjtoEntrenamiento")
                {
                    if (tipoNormalizacion == "No normalizar")
                    {
                        CjtoNormalizado = new ArrayList(CjtoEntrenamiento);

                        return;
                    }
                    
                    CjtoNormalizado.Clear();

                    string tipo, valorTexto;

                    double media, varianza, valorNum, normalizado, max, min;

                    ArrayList aux = new ArrayList(), matrizTraspuesta = new ArrayList();

                    switch (verTab())
                    {
                        case "Vectores":

                            switch (tipoNormalizacion)
                            {
                                case "Intervalo":

                                    DictionaryEntry par = new DictionaryEntry();

                                    for (int j = 0; j < M + 1; j++)
                                    {
                                        if (j == M)
                                        {
                                            for (int i = 0; i < N; i++)
                                            {
                                                aux.Add(((ArrayList)CjtoEntrenamiento[i])[j]);
                                            }
                                        }

                                        else
                                        {
                                            if (ListaAtributosNormalizar.Contains(j))
                                            {
                                                tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                                                if (tipo == "cuantitativo")
                                                {
                                                    par = (DictionaryEntry) RangosAtributos[j];

                                                    max = System.Convert.ToDouble(par.Value);

                                                    min = System.Convert.ToDouble(par.Key);

                                                    for (int i = 0; i < N; i++)
                                                    {
                                                        valorNum = System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[j]);

                                                        normalizado = aIntervalo + (((bIntervalo - aIntervalo) / (max - min)) * (valorNum - min));

                                                        aux.Add(normalizado);
                                                    }
                                                }
                                                
                                                else
                                                {
                                                    for (int i = 0; i < N; i++)
                                                    {
                                                        valorTexto = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]);

                                                        aux.Add(valorTexto);
                                                    }
                                                }
                                            }

                                            else
                                            {
                                                // No hay que normalizarlos, se dejan tal como estaban

                                                for (int i = 0; i < N; i++)
                                                {
                                                    aux.Add(((ArrayList)CjtoEntrenamiento[i])[j]);
                                                }
                                            }
                                        }

                                        matrizTraspuesta.Add(aux.Clone());

                                        aux.Clear();
                                    }

                                    // Traspongo la matriz obtenida para que quede en el orden correcto

                                    for (int j = 0; j < N; j++)
                                    {
                                        for (int i = 0; i < M + 1; i++)
                                        {
                                            aux.Add(((ArrayList)matrizTraspuesta[i])[j]);
                                        }

                                        CjtoNormalizado.Add(aux.Clone());

                                        aux.Clear();
                                    }

                                    break;

                                case "mediaVarianza":

                                    for (int j = 0; j < M + 1; j++)
                                    {
                                        if (j == M)
                                        {
                                            for (int i = 0; i < N; i++)
                                            {
                                                aux.Add(((ArrayList)CjtoEntrenamiento[i])[j]);
                                            }
                                        }

                                        else
                                        {
                                            if (ListaAtributosNormalizar.Contains(j))
                                            {

                                                media = CalcularMedia(j);

                                                varianza = CalcularDesviacionTipica(j, media);

                                                tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                                                if (tipo == "cuantitativo" || tipo == "cuantitativo-ignorar")
                                                {
                                                    for (int i = 0; i < N; i++)
                                                    {
                                                        valorNum = System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[j]);

                                                        normalizado = (valorNum - media) / varianza;

                                                        aux.Add(normalizado);
                                                    }
                                                }

                                                else
                                                {
                                                    for (int i = 0; i < N; i++)
                                                    {
                                                        valorTexto = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]);

                                                        aux.Add(valorTexto);
                                                    }
                                                }
                                            }

                                            else
                                            {
                                                // No hay que normalizarlos, se dejan tal como estaban

                                                for (int i = 0; i < N; i++)
                                                {
                                                    aux.Add(((ArrayList)CjtoEntrenamiento[i])[j]);
                                                }
                                            }
                                        }

                                        matrizTraspuesta.Add(aux.Clone());

                                        aux.Clear();
                                    }

                                    // Traspongo la matriz obtenida para que quede en el orden correcto

                                    for (int j = 0; j < N; j++)
                                    {
                                        for (int i = 0; i < M + 1; i++)
                                        {
                                            aux.Add(((ArrayList)matrizTraspuesta[i])[j]);
                                        }

                                        CjtoNormalizado.Add(aux.Clone());

                                        aux.Clear();
                                    }

                                    break;
                            }

                            break;                        
                    }
                }

                else if (datos == "NuevoCaso")
                {
                    if (tipoNormalizacion == "No normalizar")
                    {
                        NuevoCasoNormalizado = new ArrayList((ArrayList) CasosClasificar[punteroCasosClasificar]);

                        return;
                    }
                    
                    NuevoCasoNormalizado.Clear();

                    string tipo, valorTexto;

                    double media, varianza, valorNum, normalizado, max, min;

                    switch (tipoNormalizacion)
                    {
                        case "Intervalo":

                            DictionaryEntry par = new DictionaryEntry();

                            for (int j = 0; j < M; j++)
                            {
                                if (ListaAtributosNormalizar.Contains(j))
                                {
                                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                                    if (tipo == "cuantitativo" || tipo == "cuantitativo-ignorar")
                                    {
                                        par = (DictionaryEntry)RangosAtributos[j];

                                        max = System.Convert.ToDouble(par.Value);

                                        min = System.Convert.ToDouble(par.Key);

                                        valorNum = System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[punteroCasosClasificar])[j]);

                                        normalizado = aIntervalo + (((bIntervalo - aIntervalo) / (max - min)) * (valorNum - min));

                                        NuevoCasoNormalizado.Add(normalizado);
                                    }

                                    else
                                    {
                                        valorTexto = System.Convert.ToString(((ArrayList)CasosClasificar[punteroCasosClasificar])[j]);

                                        NuevoCasoNormalizado.Add(valorTexto);
                                    }
                                }

                                else
                                {
                                    // No hay que normalizarlos, se dejan tal como estaban

                                    NuevoCasoNormalizado.Add(((ArrayList)CasosClasificar[punteroCasosClasificar])[j]);
                                }
                            }

                            break;

                        case "mediaVarianza":

                            ArrayList aux = new ArrayList();

                            for (int j = 0; j < M; j++)
                            {
                                if (ListaAtributosNormalizar.Contains(j))
                                {
                                    media = CalcularMedia(j);

                                    varianza = CalcularDesviacionTipica(j, media);

                                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                                    if (tipo == "cuantitativo" || tipo == "cuantitativo-ignorar")
                                    {
                                        valorNum = System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[punteroCasosClasificar])[j]);

                                        normalizado = (valorNum - media) / varianza;

                                        NuevoCasoNormalizado.Add(normalizado);
                                    }

                                    else
                                    {
                                        valorTexto = System.Convert.ToString(((ArrayList)CasosClasificar[punteroCasosClasificar])[j]);

                                        NuevoCasoNormalizado.Add(valorTexto);
                                    }
                                }

                                else
                                {
                                    // No hay que normalizarlos, se dejan tal como estaban

                                    NuevoCasoNormalizado.Add(((ArrayList)CasosClasificar[punteroCasosClasificar])[j]);
                                }
                            }

                            break;
                    }
                }
            }

            catch
            {
                throw;
            }
        }
                
        /// <summary>
        /// Calcula la distancia de Minkowski
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaMinkowski(int nCasoConocido)
        {
            try
            {
                double result, suma = 0, normX, normY, distanciaCualitativos;

                string tipo;

                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo")
                    {
                        normX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[nCasoConocido])[j]);

                        normY = System.Convert.ToDouble(NuevoCasoNormalizado[j]);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * Math.Pow(Math.Abs(normX - normY), qMinkowski);
                    }

                    else if (tipo != "cuantitativo-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                    {
                        distanciaCualitativos = CalcularDistanciaCualitativos(nCasoConocido, j);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * distanciaCualitativos;
                    }
                }

                result = Math.Pow(suma, 1 / qMinkowski);

                return result;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Calcula la distancia Euclidea
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>        
        protected double DistanciaEuclidea(int nCasoConocido)
        {
            try
            {
                double result, suma = 0, normX, normY, distanciaCualitativos;

                string tipo;

                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo")
                    {
                        normX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[nCasoConocido])[j]);

                        normY = System.Convert.ToDouble(NuevoCasoNormalizado[j]);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * Math.Pow(normX - normY, 2.0);
                    }

                    else if (tipo != "cuantitativo-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                    {
                        distanciaCualitativos = CalcularDistanciaCualitativos(nCasoConocido, j);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * distanciaCualitativos;
                    }
                }

                result = Math.Sqrt(suma);

                return result;
            }

            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Calcula la distancia de Manhattan
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaManhattan(int nCasoConocido)
        {
            try
            {
                double suma = 0, normX, normY, distanciaCualitativos;

                string tipo;

                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo")
                    {
                        normX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[nCasoConocido])[j]);

                        normY = System.Convert.ToDouble(NuevoCasoNormalizado[j]);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * Math.Abs(normX - normY);
                    }

                    else if (tipo != "cuantitativo-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                    {
                        distanciaCualitativos = CalcularDistanciaCualitativos(nCasoConocido, j);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * distanciaCualitativos;
                    }
                }

                return suma;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia de Chebychev
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaChebychev(int nCasoConocido)
        {
            try
            {
                double normX, normY, max = 0, aux;

                string tipo;

                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo")
                    {
                        normX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[nCasoConocido])[j]);

                        normY = System.Convert.ToDouble(NuevoCasoNormalizado[j]);

                        aux = System.Convert.ToDouble(PesosAtributos[j]) * Math.Abs(normX - normY);

                        if (aux > max) max = aux;
                    }

                    else if (tipo != "cuantitativo-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                    {
                        aux = System.Convert.ToDouble(PesosAtributos[j]) * CalcularDistanciaCualitativos(nCasoConocido, j);

                        if (aux > max) max = aux;
                    }

                }

                return max;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia de divergencia
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaDivergencia(int nCasoConocido)
        {
            try
            {
                double result, suma = 0, numerador, denominador, normX, normY, distanciaCualitativos;

                string tipo;

                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo")
                    {
                        normX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[nCasoConocido])[j]);

                        normY = System.Convert.ToDouble(NuevoCasoNormalizado[j]);

                        numerador = Math.Pow(normX - normY, 2.0);

                        denominador = Math.Pow(normX + normY, 2.0);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * (numerador / denominador);
                    }

                    else if (tipo != "cuantitativo-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                    {
                        distanciaCualitativos = CalcularDistanciaCualitativos(nCasoConocido, j);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * distanciaCualitativos;
                    }
                }

                result = Math.Sqrt(suma);

                return result;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Calcula la distancia de Camberra
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaCamberra(int nCasoConocido)
        {
            try
            {
                double result, suma = 0, numerador, denominador, normX, normY, distanciaCualitativos;

                string tipo;

                for (int j = 0; j < M; j++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value);

                    if (tipo == "cuantitativo")
                    {
                        normX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[nCasoConocido])[j]);

                        normY = System.Convert.ToDouble(NuevoCasoNormalizado[j]);

                        numerador = Math.Abs(normX - normY);

                        denominador = Math.Abs(normX + normY);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * (numerador / denominador);
                    }

                    else if (tipo != "cuantitativo-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                    {
                        distanciaCualitativos = CalcularDistanciaCualitativos(nCasoConocido, j);

                        suma += System.Convert.ToDouble(PesosAtributos[j]) * distanciaCualitativos;
                    }
                }

                result = Math.Sqrt(suma);

                return result;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Calcula la distancia del coseno
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaCoseno(int nCasoConocido)
        {
            try
            {
                double result = 0, numerador, denominador, cociente;

                ArrayList vectorX = (ArrayList)((ArrayList)CjtoNormalizado[nCasoConocido]).Clone();

                ArrayList vectorY = (ArrayList)NuevoCasoNormalizado.Clone();

                numerador = ProductoEscalar(vectorX, vectorY);

                double normaX = CalcularNorma(vectorX);

                double normaY = CalcularNorma(vectorY);

                denominador = normaX * normaY;

                cociente = numerador / denominador;

                result = Math.Cos(cociente);

                return result;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia de Mahalanobis
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaMahalanobis(int nCasoConocido)
        {
            try
            {
                double result = 0, radicando;

                ArrayList vectorX = (ArrayList)((ArrayList)CjtoNormalizado[nCasoConocido]).Clone();

                ArrayList vectorY = (ArrayList)NuevoCasoNormalizado.Clone();

                ArrayList S = MatrizCovarianzas();

                ArrayList resta = RestaVectores(vectorX, vectorY);

                Matrix inversa = InvertirMatriz(S);

                Matrix unoXN = ConvertirAMatrizNormal(resta);

                Matrix NxUno = ConvertirAMatrizTraspuesta(resta);

                Matrix prod1 = unoXN.Multiply(inversa);

                Matrix total = unoXN.Multiply(NxUno);

                string final = total.ToString();

                radicando = System.Convert.ToDouble((final.Replace("[[", "")).Replace("]]", ""));

                result = Math.Sqrt(radicando);                               
                
                return result;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia entre los atributos cualitativos que se indiquen
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <param name="posAtributo"></param>
        /// <returns></returns>
        protected double CalcularDistanciaCualitativos(int nCasoConocido, int posAtributo)
        {
            try
            {
                double distancia = -1;

                string cadenaA = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[nCasoConocido])[posAtributo]);

                string cadenaB = System.Convert.ToString(((ArrayList)CasosClasificar[punteroCasosClasificar])[posAtributo]);

                switch (tipoNormalizacion)
                {
                    case "Intervalo":

                        if (cadenaA == cadenaB) distancia = aIntervalo;

                        else distancia = bIntervalo;

                        break;

                    case "mediaVarianza":

                        if (cadenaA == cadenaB) distancia = 0;

                        else distancia = 1;

                        break;
                }

                return distancia;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la media de los valores de un atributo de los casos conocidos para su posterior normalización
        /// </summary>
        /// <returns></returns>
        protected double CalcularMedia(int columna)
        {
            try
            {
                int conta = 0;

                double media = 0, suma = 0;

                for (int i = 0; i < N; i++)
                {
                    if (System.Convert.ToString(((DictionaryEntry)Atributos[columna]).Value) == "cuantitativo")
                    {
                        // Lo de Globalization sirve para que reconozca el punto como separador de la parte entera y de la decimal en vez de la coma

                        suma += System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[columna]);

                        conta++;
                    }
                }

                if (conta != 0) media = suma / conta;

                return media;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Sobrecarga del método para su uso con valores desconocidos
        /// </summary>
        /// <param name="columna"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        protected string CalcularMedia(int columna, string clase)
        {
            try
            {
                int conta = 0;

                double media = 0, suma = 0;

                for (int i = 0; i < N; i++)
                {
                    if (System.Convert.ToString(((DictionaryEntry)Atributos[columna]).Value) == "cuantitativo" && 
                          System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]) == clase &&
                            System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) != "?")
                            
                    {
                        suma += System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[columna]);

                        conta++;
                    }

                    else if (System.Convert.ToString(((DictionaryEntry)Atributos[columna]).Value) == "booleano" &&
                               System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]) == clase &&
                                 System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) != "?")
                    {
                        if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) == "yes") suma++;

                        conta++;
                    }
                }

                if (conta == 0) return "ELIMINAR";

                media = suma / conta;

                return System.Convert.ToString(media);
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la moda de los valores de un determinado atributo cualitativo para su uso con valores desconocidos
        /// </summary>
        /// <param name="columna"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        protected string CalcularModa(int columna, string clase)
        {
            try
            {
                string moda = "";

                ArrayList elementos = new ArrayList();

                for (int i = 0; i < N; i++)
                {
                    if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]) == clase &&
                        System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) != "?")
                    {
                        elementos.Add(System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]));
                    }
                }

                if (elementos.Count == 0) return "ELIMINAR";
                
                ArrayList valores = new ArrayList();

                ArrayList contadores = new ArrayList();

                int pos = -1;
                                               
                valores.Add(elementos[0]);

                contadores.Add(1);

                for (int i = 1; i < elementos.Count; i++)
                {
                    if (!valores.Contains(System.Convert.ToString(elementos[i])))
                    {
                        valores.Add(elementos[i]);

                        contadores.Add(1);
                    }

                    else
                    {
                        pos = valores.IndexOf(System.Convert.ToString(elementos[i]));

                        contadores[pos] = System.Convert.ToInt32(contadores[pos]) + 1;
                    }
                }

                pos = 0;
                
                int max = System.Convert.ToInt32(contadores[0]);

                for (int k = 1; k < contadores.Count; k++)
                {
                    if (System.Convert.ToInt32(contadores[k]) > max)
                    {
                        max = System.Convert.ToInt32(contadores[k]);

                        pos = k;
                    }
                }

                moda = System.Convert.ToString(valores[pos]);

                return moda;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la mediana de los valores de un determinado atributo numérico para su uso con valores desconocidos
        /// </summary>
        /// <param name="columna"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        protected string CalcularMediana(int columna, string clase)
        {
            try
            {
                double mediana = 0;
                
                ArrayList elementosOrdenados = new ArrayList ();

                for (int i = 0; i < N; i++)
                {
                    if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]) == clase &&
                        System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) != "?")
                    {
                        if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) == "yes") elementosOrdenados.Add(1.0);

                        else if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[columna]) == "no") elementosOrdenados.Add(0.0);

                        else elementosOrdenados.Add(System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[columna]));
                    }
                }                                   

                if (elementosOrdenados.Count == 0) return "ELIMINAR";
                    
                elementosOrdenados.Sort();

                if (elementosOrdenados.Count % 2 == 0)

                    mediana = (System.Convert.ToInt32(elementosOrdenados[(elementosOrdenados.Count / 2) - 1]) + System.Convert.ToInt32(elementosOrdenados[elementosOrdenados.Count / 2])) / 2;

                else

                    mediana = System.Convert.ToDouble(elementosOrdenados[System.Convert.ToInt32(elementosOrdenados.Count / 2)]);

                return System.Convert.ToString(mediana);
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la desviación típica de los valores de un atributo de los casos conocidos para su posterior normalización
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
        protected double CalcularDesviacionTipica(int columna, double media)
        {
            try
            {
                int conta = 0;

                double desv, suma = 0;

                for (int i = 0; i < N; i++)
                {
                    if (System.Convert.ToString(((DictionaryEntry)Atributos[columna]).Value) == "cuantitativo")
                    {
                        suma += Math.Pow(System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[i])[columna]) - media, 2.0);

                        conta++;
                    }
                }

                desv = Math.Sqrt(suma / (conta - 1));

                return desv;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula el producto escalar entre dos vectores
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        protected double ProductoEscalar(ArrayList X, ArrayList Y)
        {
            try
            {

                double result = 0, valorX = 0, valorY = 0;

                string valorBool;

                for (int i = 0; i < M; i++)
                {
                    if (EsNumero(System.Convert.ToString(X[i]))) valorX = System.Convert.ToDouble(X[i]);

                    else
                    {
                        valorBool = System.Convert.ToString(X[i]);

                        switch (valorBool)
                        {
                            case "yes":

                                valorX = 1;

                                break;

                            case "no":

                                valorX = 0;

                                break;
                        }
                    }

                    if (EsNumero(System.Convert.ToString(Y[i]))) valorY = System.Convert.ToDouble(Y[i]);

                    else
                    {
                        valorBool = System.Convert.ToString(Y[i]);

                        switch (valorBool)
                        {
                            case "yes":

                                valorY = 1;

                                break;

                            case "no":

                                valorY = 0;

                                break;
                        }
                    }

                    result += valorX * valorY;
                }

                return result;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula norma de un vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected double CalcularNorma(ArrayList v)
        {
            try
            {
                double result = 0, suma = 0, valor = 0;

                string valorBool;

                for (int i = 0; i < v.Count; i++)
                {
                    if (EsNumero(System.Convert.ToString(v[i]))) valor = System.Convert.ToDouble(v[i]);

                    else
                    {
                        valorBool = System.Convert.ToString(v[i]);

                        switch (valorBool)
                        {
                            case "yes":

                                valor = 1;

                                break;

                            case "no":

                                valor = 0;

                                break;
                        }
                    }

                    suma += Math.Pow(valor, 2);
                }

                result = Math.Sqrt(suma);

                return result;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Resta dos vectores que se le pasan como argumento
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected ArrayList RestaVectores(ArrayList x, ArrayList y)
        {
            try
            {

                ArrayList resta = new ArrayList();

                double num, valorX, valorY;

                string tipo, aux;

                for (int i = 0; i < M; i++)
                {
                    tipo = System.Convert.ToString(((DictionaryEntry)Atributos[i]).Value);

                    if (tipo == "booleano")
                    {
                        aux = System.Convert.ToString(x[i]);

                        if (aux == "yes") valorX = 1;

                        else valorX = 0;

                        aux = System.Convert.ToString(y[i]);

                        if (aux == "yes") valorY = 1;

                        else valorY = 0;
                    }

                    else
                    {
                        valorX = System.Convert.ToDouble(x[i]);

                        valorY = System.Convert.ToDouble(y[i]);
                    }

                    num = valorX - valorY;

                    resta.Add(num);
                }

                return resta;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la matriz de covarianzas de dos vectores
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected ArrayList MatrizCovarianzas()
        {
            try
            {
                ArrayList matriz = new ArrayList();

                ArrayList v = new ArrayList();

                double aux;

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (j < i)
                        {
                            aux = System.Convert.ToDouble(((ArrayList)matriz[j])[i]);
                        }

                        else
                        {
                            aux = Covarianza(i, j);
                        }

                        v.Add(aux);
                    }

                    matriz.Add(v.Clone());

                    v.Clear();
                }

                return matriz;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la covarianza entre dos atributos del conjunto de entrenamiento
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected double Covarianza(int x, int y)
        {
            try
            {
                double cov = 0, mediaX = 0, mediaY = 0;

                string tipoX = System.Convert.ToString(((DictionaryEntry)Atributos[x]).Value);

                string tipoY = System.Convert.ToString(((DictionaryEntry)Atributos[y]).Value);

                string aux;

                for (int i = 0; i < N; i++)
                {
                    if (tipoX == "booleano")
                    {
                        aux = System.Convert.ToString(((ArrayList)CjtoNormalizado[i])[x]);

                        if (aux == "yes") mediaX += 1;
                    }

                    else mediaX += System.Convert.ToDouble(((ArrayList)CjtoNormalizado[i])[x]);

                    if (tipoY == "booleano")
                    {
                        aux = System.Convert.ToString(((ArrayList)CjtoNormalizado[i])[y]);

                        if (aux == "yes") mediaY += 1;
                    }

                    else mediaY += System.Convert.ToDouble(((ArrayList)CjtoNormalizado[i])[y]);
                }

                mediaX /= N;

                mediaY /= N;

                double valorX, valorY;

                for (int i = 0; i < N; i++)
                {
                    if (tipoX == "booleano")
                    {
                        aux = System.Convert.ToString(((ArrayList)CjtoNormalizado[i])[x]);

                        if (aux == "yes") valorX = 1;

                        else valorX = 0;
                    }

                    else valorX = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[i])[x]);

                    if (tipoY == "booleano")
                    {
                        aux = System.Convert.ToString(((ArrayList)CjtoNormalizado[i])[y]);

                        if (aux == "yes") valorY = 1;

                        else valorY = 0;
                    }

                    else valorY = System.Convert.ToDouble(((ArrayList)CjtoNormalizado[i])[y]);

                    cov += (valorX - mediaX) * (valorY - mediaY);
                }

                cov /= N;

                return cov;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Invierte la matriz que se le pasa como argumento
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        protected Matrix InvertirMatriz(ArrayList mat)
        {
            try
            {
                ArrayList inv = new ArrayList();

                double valor;

                // Almaceno los valores en una matriz de la librería para poder invertirla

                double[][] aux = Matrix.CreateMatrixData(M, M);

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        valor = System.Convert.ToDouble(((ArrayList)mat[i])[j]);

                        aux[i][j] = valor;
                    }
                }

                Matrix copia = new Matrix(aux);

                // La invierto

                copia = copia.Inverse();

                return copia;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte a un objeto matriz de la librería Iridium el ArrayList que se le pasa como parámetro (como vector fila)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected Matrix ConvertirAMatrizNormal(ArrayList v)
        {
            try
            {
                double valor;

                double[][] normal = Matrix.CreateMatrixData(1, M);

                for (int j = 0; j < M; j++)
                {
                    valor = System.Convert.ToDouble(v[j]);

                    normal[0][j] = valor;
                }

                Matrix copia = new Matrix(normal);

                return copia;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte a un objeto matriz de la librería Iridium el ArrayList que se le pasa como parámetro (como vector columna)
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected Matrix ConvertirAMatrizTraspuesta(ArrayList v)
        {
            try
            {
                double valor;

                double[][] traspuesta = Matrix.CreateMatrixData(M, 1);

                for (int i = 0; i < M; i++)
                {
                    valor = System.Convert.ToDouble(v[i]);

                    traspuesta[i][0] = valor;
                }

                Matrix copia = new Matrix(traspuesta);

                return copia;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula según el tipo de distancia elegida, la distancia entre el nuevo caso y cada uno de los del conjunto de entrenamiento,
        /// almacenándolas en el vector Distancias
        /// </summary>
        protected void CalcularDistanciaVectores ()
        {
            try
            {
                // Normalizo los atributos para el cálculo de distancias

                Normalizar("CjtoEntrenamiento");

                Normalizar("NuevoCaso");

                DictionaryEntry par = new DictionaryEntry();

                switch (distanciaACalcularVectores)
                {
                    case "Minkowski":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaMinkowski(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Euclidea":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaEuclidea(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Manhattan":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaManhattan(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Chebychev":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaChebychev(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Divergencia":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaDivergencia(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Camberra":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaCamberra(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Del coseno":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaCoseno(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Mahalanobis":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaMahalanobis(i);

                            Distancias.Add(par);
                        }

                        break;

                    default:

                        break;

                }
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Realiza los cálculos necesarios para obtener la clase de los nuevos casos a clasificar de la parte de vectores
        /// </summary>
        /// <returns></returns>
        public ArrayList CalcularConVectores()
        {
            try
            {
                punteroCasosClasificar = 0;
                
                ClasesCasos.Clear();

                while (punteroCasosClasificar < CasosClasificar.Count)
                {
                    // Llegados a este punto, ya está recopilada toda la información necesaria para realizar los cálculos y procedemos

                    CalcularDistanciaVectores();

                    // Antes de nada, ordeno el vector de distancias de manera que los K vecinos más próximos estén en las K primeras posiciones

                    Distancias = OrdenaDistancias(Distancias);

                    // Calculo de una manera u otra según haya que usar regresión o no

                    if (usarRegresion)
                    {
                        string claseNuevoCaso = System.Convert.ToString(Math.Round(Regresion(), 3)); // Uso solo 3 decimales

                        // Almaceno la información recopilada para mostrarla por pantalla

                        ClasesCasos.Add(claseNuevoCaso);
                    }

                    else 
                    {
                        DictionaryEntry claseNuevoCaso = ClaseMasVotada();

                        // Almaceno la información recopilada para mostrarla por pantalla

                        ClasesCasos.Add(claseNuevoCaso);
                    }

                    // Actualizo las estructuras de datos para almacenar el nuevo caso

                    ActualizarEstructuras();
                }

                return ClasesCasos;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Se ocupa de todo lo necesario para transformar los atributos cualitativos a booleanos
        /// </summary>
        public void RealizarTransformacion()
        {
            try
            {
                if (aplicarTransformacion)
                {
                    TransformacionBooleana();
                }
            }

            catch
            {
                throw;
            }
        }                
        
        /// <summary>
        /// Realiza la transformación de las variables cualitativas a booleanas
        /// </summary>
        protected void TransformacionBooleana()
        {
            try
            {
                ArrayList atribsAux = new ArrayList();

                ArrayList atribsNormAux = new ArrayList();

                ArrayList cjtoAux = new ArrayList();

                ArrayList casosAux = new ArrayList();

                ArrayList copiaValores = (ArrayList)valoresPosiblesCualitativos.Clone();

                ArrayList aux = new ArrayList();

                DictionaryEntry par = new DictionaryEntry();

                par.Value = "booleano";

                // Salvo el valor anterior de M

                valorMAntesTransformacion = M;

                // Transformo los atributos

                int contaDesdoblamientos = 0;

                for (int i = 0; i < M; i++)
                {
                    if (!posCualitativos.Contains(i))
                    {
                        atribsAux.Add(Atributos[i]);

                        if (ListaAtributosNormalizar.Contains(i)) atribsNormAux.Add(i + contaDesdoblamientos);
                    }

                    else
                    {
                        // Desdoblo

                        aux = (ArrayList)((ArrayList)copiaValores[0]).Clone();

                        for (int j = 1; j < aux.Count; j++)
                        {
                            par.Key = aux[j];

                            atribsAux.Add(par);

                            if (ListaAtributosNormalizar.Contains(i)) atribsNormAux.Add(i + contaDesdoblamientos);

                            contaDesdoblamientos++; 
                        }

                        contaDesdoblamientos--;

                        copiaValores.RemoveAt(0);
                    }
                }

                aux.Clear();

                copiaValores.Clear();

                int numADesdoblar = 0, pos = -1;

                // Transformo el conjunto de entrenamiento

                for (int i = 0; i < N; i++)
                {
                    copiaValores = (ArrayList)((ArrayList)CjtoEntrenamiento[i]).Clone();

                    for (int j = 0; j < M + 1; j++)
                    {
                        if (!posCualitativos.Contains(j))
                        {
                            aux.Add(copiaValores[j]);
                        }

                        else
                        {
                            // Busco en cuantos atributos debo desdoblar el atributo actual

                            for (int k = 0; k < valoresPosiblesCualitativos.Count; k++)
                            {
                                if (((ArrayList)valoresPosiblesCualitativos[k])[0] == ((DictionaryEntry)Atributos[j]).Key)
                                {
                                    pos = k;

                                    break;
                                }
                            }

                            numADesdoblar = ((ArrayList)valoresPosiblesCualitativos[pos]).Count - 1;

                            // Desdoblo

                            for (int p = 1; p <= numADesdoblar; p++)
                            {
                                if (System.Convert.ToString(copiaValores[j]) == System.Convert.ToString(((ArrayList)valoresPosiblesCualitativos[pos])[p]))
                                {
                                    aux.Add("yes");
                                }

                                else aux.Add("no");
                            }
                        }
                    }

                    cjtoAux.Add(aux.Clone());

                    aux.Clear();
                }

                numADesdoblar = 0;

                pos = -1;

                // Transformo los casos a clasificar

                for (int i = 0; i < CasosClasificar.Count; i++)
                {
                    copiaValores = (ArrayList)((ArrayList)CasosClasificar[i]).Clone();

                    for (int j = 0; j < M; j++)
                    {
                        if (!posCualitativos.Contains(j))
                        {
                            aux.Add(copiaValores[j]);
                        }

                        else
                        {
                            // Busco en cuantos atributos debo desdoblar el atributo actual

                            for (int k = 0; k < valoresPosiblesCualitativos.Count; k++)
                            {
                                if (((ArrayList)valoresPosiblesCualitativos[k])[0] == ((DictionaryEntry)Atributos[j]).Key)
                                {
                                    pos = k;

                                    break;
                                }
                            }

                            numADesdoblar = ((ArrayList)valoresPosiblesCualitativos[pos]).Count - 1;

                            // Desdoblo

                            for (int p = 1; p <= numADesdoblar; p++)
                            {
                                if (System.Convert.ToString(copiaValores[j]) == System.Convert.ToString(((ArrayList)valoresPosiblesCualitativos[pos])[p]))
                                {
                                    aux.Add("yes");
                                }

                                else aux.Add("no");
                            }
                        }
                    }

                    casosAux.Add(aux.Clone());

                    aux.Clear();
                }

                // Actualizo las estructuras

                Atributos = (ArrayList) atribsAux.Clone();

                copiaAtributos = "";

                for (int i = 0; i < Atributos.Count; i++)
                {
                    copiaAtributos += System.Convert.ToString(((DictionaryEntry)Atributos[i]).Key) + "  --->  " + System.Convert.ToString(((DictionaryEntry)Atributos[i]).Value) + "\r\n";
                }
                
                M = Atributos.Count;

                ListaAtributosNormalizar = (ArrayList)atribsNormAux.Clone();

                CjtoEntrenamiento = (ArrayList)cjtoAux.Clone();

                copiaCjtoEntrenamiento = "";

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M+1; j++)
                    {
                        copiaCjtoEntrenamiento += System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) + ", ";
                    }

                    copiaCjtoEntrenamiento = copiaCjtoEntrenamiento.Remove(copiaCjtoEntrenamiento.Length - 2);

                    copiaCjtoEntrenamiento += "\r\n";
                }                

                CasosClasificar = (ArrayList)casosAux.Clone();

                copiaCasosClasificar = "";

                for (int i = 0; i < CasosClasificar.Count; i++)
                {
                    copiaCasosClasificar += "(";

                    for (int j = 0; j < M; j++)
                    {
                        copiaCasosClasificar += System.Convert.ToString(((ArrayList) CasosClasificar[i])[j]) + ", ";
                    }

                    copiaCasosClasificar = copiaCasosClasificar.Remove(copiaCasosClasificar.Length - 2);

                    copiaCasosClasificar += ")\r\n";
                }

                listaCasosClasificar = copiaCasosClasificar;

                CalcularRangos();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deshace la transformación de los atributos cualitativos a booleanos y deja todo como estaba al principio
        /// </summary>
        public void DeshacerTransformacion()
        {
            try
            {
                if (aplicarTransformacion)
                {
                    M = valorMAntesTransformacion;

                    CjtoEntrenamiento = new ArrayList(CopiaCjtoEntrenamientoInicial);

                    copiaCjtoEntrenamiento = "";

                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < M+1; j++)
                        {
                            copiaCjtoEntrenamiento += System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) + ", ";
                        }

                        copiaCjtoEntrenamiento = copiaCjtoEntrenamiento.Remove(copiaCjtoEntrenamiento.Length - 2);

                        copiaCjtoEntrenamiento += "\r\n";
                    } 

                    Atributos = new ArrayList(CopiaAtributosIniciales);

                    copiaAtributos = "";

                    for (int i = 0; i < Atributos.Count; i++)
                    {
                        copiaAtributos += System.Convert.ToString(((DictionaryEntry)Atributos[i]).Key) + "  --->  " + System.Convert.ToString(((DictionaryEntry)Atributos[i]).Value) + "\r\n";
                    }

                    ListaAtributosNormalizar = (ArrayList)ListaAtributosNormalizarIniciales.Clone();

                    CasosClasificar = new ArrayList(CopiaCasosClasificarIniciales);

                    copiaCasosClasificar = "";

                    for (int i = 0; i < CasosClasificar.Count; i++)
                    {
                        copiaCasosClasificar += "(";

                        for (int j = 0; j < M; j++)
                        {
                            copiaCasosClasificar += System.Convert.ToString(((ArrayList)CasosClasificar[i])[j]) + ", ";
                        }

                        copiaCasosClasificar = copiaCasosClasificar.Remove(copiaCasosClasificar.Length - 2);

                        copiaCasosClasificar += ")\r\n";
                    }

                    listaCasosClasificar = copiaCasosClasificar;
                                                        
                    CalcularRangos();

                    aplicarTransformacion = false;
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Comprueba si es posible aplicar regresión
        /// </summary>
        /// <returns></returns>
        public bool esPosibleRegresion()
        {
            try
            {
                // Para ser posible la regresión, todas las clases del conjunto de entrenamiento deben ser valores numéricos

                string clase;

                for (int i = 0; i < Clases.Count; i++)
                {
                    clase = System.Convert.ToString(((DictionaryEntry)Clases[i]).Key);

                    if (!EsNumero(clase)) return false;
                }

                return true;
            }

            catch
            {
                throw;
            } 
        }

        /// <summary>
        /// Asigna la clase a un nuevo caso a clasificar usando regresión
        /// </summary>
        /// <returns></returns>
        protected double Regresion()
        {
            try
            {

                double suma = 0, ponderacion;

                for (int i = 0; i < K; i++)
                {
                    switch (PesadoCasos)
                    {
                        case "Iguales":

                            ponderacion = 1;

                            break;

                        case "Inversamente":

                            ponderacion = 1 / System.Convert.ToDouble(((DictionaryEntry)Distancias[i]).Value);

                            break;

                        case "Orden":

                            ponderacion = K - i;

                            break;

                        default:

                            ponderacion = 1;

                            break;
                    }

                    suma += ponderacion * System.Convert.ToDouble(((ArrayList)CjtoEntrenamiento[System.Convert.ToInt32(((DictionaryEntry)Distancias[i]).Key)])[M]);
                }

                return suma / K;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza la acción elegida sobre los valores desconocidos del conjunto de entrenamiento
        /// </summary>
        public void TratarValoresDesconocidos()
        {
            try
            {
                string clase = "", valor = "";

                switch (opcionValoresDesconocidos)
                {
                    case "Eliminación":

                        for (int i = 0; i < N; i++)
                        {
                            for (int j = 0; j < M; j++)
                            {
                                if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) == "?")
                                {
                                    CjtoEntrenamiento.RemoveAt(i);

                                    N--;

                                    i--;

                                    break;
                                }
                            }
                        }
                            
                        break;

                    case "Media":
                        
                        for (int i = 0; i < N; i++)
                        {
                            for (int j = 0; j < M; j++)
                            {
                                if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) == "?")
                                {
                                    clase = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]);
                                                                                                                
                                    if (System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value) == "cuantitativo" ||
                                          System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value) == "booleano")
                                    {
                                        valor = CalcularMedia(j, clase);

                                        if (valor == "ELIMINAR")
                                        {
                                            CjtoEntrenamiento.RemoveAt(i);

                                            N--;

                                            i--;

                                            j = M;
                                        }

                                        else ((ArrayList)CjtoEntrenamiento[i])[j] = valor;
                                    }

                                    else if (System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value) == "cualitativo")
                                    {
                                        valor = CalcularModa(j, clase);

                                        if (valor == "ELIMINAR")
                                        {
                                            CjtoEntrenamiento.RemoveAt(i);

                                            N--;

                                            i--;

                                            j = M;
                                        }

                                        else ((ArrayList)CjtoEntrenamiento[i])[j] = valor;
                                    }
                                }
                            }
                        }                                   
                        
                        break;

                    case "Mediana":

                        for (int i = 0; i < N; i++)
                        {
                            for (int j = 0; j < M; j++)
                            {
                                if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) == "?")
                                {
                                    clase = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[M]);
                                                                                                                
                                    if (System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value) == "cuantitativo" ||
                                          System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value) == "booleano")
                                    {
                                        valor = CalcularMediana(j, clase);

                                        if (valor == "ELIMINAR")
                                        {
                                            CjtoEntrenamiento.RemoveAt(i);

                                            N--;

                                            i--;

                                            j = M;
                                        }

                                        else ((ArrayList)CjtoEntrenamiento[i])[j] = valor;
                                    }

                                    else if (System.Convert.ToString(((DictionaryEntry)Atributos[j]).Value) == "cualitativo")
                                    {
                                        valor = CalcularModa(j, clase);

                                        if (valor == "ELIMINAR")
                                        {
                                            CjtoEntrenamiento.RemoveAt(i);

                                            N--;

                                            i--;

                                            j = M;
                                        }

                                        else ((ArrayList)CjtoEntrenamiento[i])[j] = valor;
                                    }
                                }
                            }
                        }     
                        
                        break;
                }

                obtenerN();

                copiaCjtoEntrenamiento = ConvertirCjtoATexto();

                CopiaCjtoEntrenamientoInicial = new ArrayList(CjtoEntrenamiento);

                CalcularRangos();
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Almacena el conjunto de entrenamiento en un string para ser mostrado por pantalla
        /// </summary>
        /// <returns></returns>
        protected string ConvertirCjtoATexto()
        {
            try
            {
                string texto = "";

                int pos = -1;

                for (int i = 0; i < N; i++)
                {
                    if (verTab() == "Vectores")
                    {
                        for (int j = 0; j < M+1; j++)
                        {
                            texto += System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) + ", ";
                        }

                        texto = texto.Remove(texto.Length - 2);

                        texto += "\r\n";
                    }

                    else
                    {
                        pos = ((ArrayList)CjtoEntrenamiento[i]).Count;

                        for (int j = 0; j < pos; j++)
                        {
                            texto += System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]) + ", ";
                        }

                        texto = texto.Remove(texto.Length - 2);

                        texto += "\r\n";
                    }
                }

                return texto;
            }

            catch
            {
                throw;
            }
        }
        
        #endregion

        #endregion

        #region Parte de cadenas

        #region Miembros

        /// <summary>
        /// Tipo de distancia a calcular, según se seleccione en la pestaña de cadenas
        /// </summary>
        protected string distanciaACalcularCadenas = "";

        #endregion

        #region Observadores

        /// <summary>
        /// Retorna la distancia que se aplica a la hora de clasificar los nuevos casos
        /// </summary>
        /// <returns></returns>
        public string mostrarDistanciaACalcularCadenas()
        {
            return distanciaACalcularCadenas;
        }

        #endregion

        #region Modificadores

        /// <summary>
        /// Cambia el tipo de distancia a usar a la hora de clasificar los nuevos casos
        /// </summary>
        /// <param name="tipo"></param>
        public void cambiarDistanciaACalcularCadenas(string tipo)
        {
            distanciaACalcularCadenas = tipo;
        }

        #endregion

        #region Operaciones auxiliares

        /// <summary>
        /// Función que verifica si las cadenas del conjunto de entrenamiento y las que se deben clasificar 
        /// tienen la misma longitud para poder calcular la distancia de Lee
        /// </summary>
        /// <returns></returns>
        public bool VerificarMismaLongitud ()
        {
            try
            {
                int tam = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[0])[0]).Length;

                for (int i = 1; i < N; i++)
                {
                    if (System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[0]).Length != tam) return false;
                }

                for (int j = 0; j < CasosClasificar.Count; j++)
                {
                    if (System.Convert.ToString(CasosClasificar[j]).Length != tam) return false;
                }

                return true;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Calcula la distancia de edición o de Levenshtein entre una cadena del conjunto de entrenamiento 
        /// y otra que se desea clasificar
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected int DistanciaLevenshtein(int nCasoConocido)
        {
            try
            {
                string cadenaConocida = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[nCasoConocido])[0]);

                string cadenaClasificar = System.Convert.ToString(CasosClasificar[punteroCasosClasificar]);

                int tamConocida = cadenaConocida.Length;

                int tamClasificar = cadenaClasificar.Length;

                int[,] d = new int[tamConocida + 1, tamClasificar + 1];

                int coste;

                if (tamConocida == 0) return tamClasificar;

                if (tamClasificar == 0) return tamConocida;

                for (int i = 0; i <= tamConocida; d[i, 0] = i++);

                for (int j = 0; j <= tamClasificar; d[0, j] = j++);

                for (int i = 1; i <= tamConocida; i++)
                {
                    for (int j = 1; j <= tamClasificar; j++)
                    {
                        coste = (cadenaClasificar.Substring(j - 1, 1) == cadenaConocida.Substring(i - 1, 1) ? 0 : 1);

                        d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + coste);
                    }
                }

                return d[tamConocida, tamClasificar];
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia de Hamming entre una cadena del conjunto de entrenamiento 
        /// y otra que se desea clasificar
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected int DistanciaHamming(int nCasoConocido)
        {
            try
            {
                string cadenaConocida = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[nCasoConocido])[0]);

                string cadenaClasificar = System.Convert.ToString(CasosClasificar[punteroCasosClasificar]);

                if (cadenaConocida == cadenaClasificar) return 0;

                return 1;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia de Lee entre una cadena del conjunto de entrenamiento 
        /// y otra que se desea clasificar
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaLee(int nCasoConocido)
        {
            try
            {
                string cadenaConocida = System.Convert.ToString(((ArrayList)CjtoEntrenamiento[nCasoConocido])[0]);

                string cadenaClasificar = System.Convert.ToString(CasosClasificar[punteroCasosClasificar]);

                int q = cadenaConocida.Length;

                double suma = 0, valorA, valorB;

                for (int i = 0; i < q; i++)
                {
                    valorA = Math.Abs(cadenaConocida[i] - cadenaClasificar[i]);

                    valorB = q - Math.Abs(cadenaConocida[i] - cadenaClasificar[i]);

                    suma += Math.Min(valorA, valorB);
                }

                return suma;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula según el tipo de distancia elegida, la distancia entre el nuevo caso y cada uno de los del conjunto de entrenamiento,
        /// almacenándolas en el vector Distancias
        /// </summary>
        protected void CalcularDistanciaCadenas()
        {
            try
            {
                DictionaryEntry par = new DictionaryEntry();

                switch (distanciaACalcularCadenas)
                {
                    case "Levenshtein":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaLevenshtein(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Hamming":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaHamming(i);

                            Distancias.Add(par);
                        }

                        break;

                    case "Lee":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaLee(i);

                            Distancias.Add(par);
                        }

                        break;

                    default:

                        break;
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza los cálculos necesarios para obtener la clase de los nuevos casos a clasificar de la parte de cadenas
        /// </summary>
        /// <returns></returns>
        public ArrayList CalcularConCadenas()
        {
            try
            {
                punteroCasosClasificar = 0;

                ClasesCasos.Clear();

                DictionaryEntry claseNuevoCaso;

                while (punteroCasosClasificar < CasosClasificar.Count)
                {
                    // Llegados a este punto, ya está recopilada toda la información necesaria para realizar los cálculos y procedemos

                    CalcularDistanciaCadenas();

                    // Antes de nada, ordeno el vector de distancias de manera que los K vecinos más próximos estén en las K primeras posiciones

                    Distancias = OrdenaDistancias(Distancias);

                    claseNuevoCaso = ClaseMasVotada();

                    // Almaceno la información recopilada para mostrarla por pantalla

                    ClasesCasos.Add(claseNuevoCaso);

                    // Actualizo las estructuras de datos para almacenar el nuevo caso

                    ActualizarEstructuras();
                }

                return ClasesCasos;
            }

            catch
            {
                throw;
            }
        }
                
        #endregion

        #endregion

        #region Parte de conjuntos

        #region Miembros

        /// <summary>
        /// Tipo de distancia a calcular, según se seleccione en la pestaña de conjuntos
        /// </summary>
        protected string distanciaACalcularConjuntos = "";

        /// <summary>
        /// Tipo de distancia a calcular para el espacio base de conjuntos en caso de que se elija Hausdorff
        /// </summary>
        protected string distanciaACalcularEspacioBase = "";

        /// <summary>
        /// Almacenará uno de los dos conjuntos necesarios a la hora de calcular las distancias
        /// </summary>
        protected ArrayList A = new ArrayList();

        /// <summary>
        /// Almacenará el otro de los dos conjuntos necesarios a la hora de calcular las distancias
        /// </summary>
        protected ArrayList B = new ArrayList();

        /// <summary>
        /// Almacena el número de atributos de cada caso conocido del conjunto de entrenamiento para el tipo conjuntos
        /// </summary>
        protected ArrayList NumAtributosConjuntos = new ArrayList();

        /// <summary>
        /// Indica cuál es la mayor cantidad de atributos que tienen los casos conocidos del conjunto de entrenamiento para el tipo conjuntos
        /// </summary>
        protected int MayorNumAtributos = 0;

        /// <summary>
        /// Indica el tipo de datos de los elementos del conjunto de entrenamiento
        /// </summary>
        protected string tipoDatosCjtoEntrenamiento = "Sin comprobar";

        #endregion

        #region Observadores

        /// <summary>
        /// Muestra el tipo de datos que contiene el conjunto de entrenamiento
        /// </summary>
        /// <returns></returns>
        public string verTipoDatosCjtoEntrenamiento()
        {
            if (verTab() == "Conjuntos")
            {
                calcularTipoCjtoEntrenamiento();

                return tipoDatosCjtoEntrenamiento;
            }

            return "Sin comprobar";
        }

        /// <summary>
        /// Retorna la distancia que se aplica a la hora de clasificar los nuevos casos
        /// </summary>
        /// <returns></returns>
        public string mostrarDistanciaACalcularConjuntos()
        {
            return distanciaACalcularConjuntos;
        }

        /// <summary>
        /// Retorna la distancia que se aplica en el espacio base
        /// </summary>
        /// <returns></returns>
        public string mostrarDistanciaACalcularEspacioBase()
        {
            return distanciaACalcularEspacioBase;
        }

        #endregion
        
        #region Modificadores

        /// <summary>
        /// Cambia el tipo de distancia a usar a la hora de clasificar los nuevos casos
        /// </summary>
        /// <param name="tipo"></param>
        public void cambiarDistanciaACalcularConjuntos(string tipo)
        {
            distanciaACalcularConjuntos = tipo;
        }

        /// <summary>
        /// Cambia el tipo de distancia a usar para el espacio base a la hora de clasificar los nuevos casos
        /// </summary>
        /// <param name="tipo"></param>
        public void cambiarDistanciaACalcularEspacioBase(string tipo)
        {
            distanciaACalcularEspacioBase = tipo;
        }

        #endregion

        #region Operaciones auxiliares

        /// <summary>
        /// Comprueba si todos los elementos del conjunto de entrenamiento y de los casos a clasificar son del mismo tipo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool ComprobarMismoTipo()
        {
            try
            {
                bool numericosCasos = false;

                // Compruebo los casos a clasificar

                for (int i = 0; i < CasosClasificar.Count; i++)
                {
                    for (int j = 0; j < ((ArrayList)CasosClasificar[i]).Count; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            numericosCasos = EsNumero(System.Convert.ToString(((ArrayList)CasosClasificar[i])[j]));
                        }

                        else
                        {
                            if (EsNumero(System.Convert.ToString(((ArrayList)CasosClasificar[i])[j])) != numericosCasos) return false;
                        }
                    }
                }

                if (((tipoDatosCjtoEntrenamiento == "Números") && !numericosCasos) || ((tipoDatosCjtoEntrenamiento == "Cadenas") && numericosCasos)) return false;

                return true;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Comprueba el tipo de los elementos del conjunto de entrenamiento
        /// </summary>
        public void calcularTipoCjtoEntrenamiento()
        {
            try
            {
                bool numericoCjto = false;

                // Compruebo el conjunto de entrenamiento

                for (int i = 0; i < N; i++)
                {
                    // La clase puede ser de cualquier tipo

                    for (int j = 0; j < ((ArrayList)CjtoEntrenamiento[i]).Count - 1; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            numericoCjto = EsNumero(System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j]));
                        }

                        else
                        {
                            if (EsNumero(System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[j])) != numericoCjto)
                            {
                                tipoDatosCjtoEntrenamiento = "Incorrectos";

                                return;
                            }
                        }
                    }
                }

                if (numericoCjto) tipoDatosCjtoEntrenamiento = "Números";

                else tipoDatosCjtoEntrenamiento = "Cadenas";
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza los cálculos necesarios para obtener la clase de los nuevos casos a clasificar de la parte de conjuntos
        /// </summary>
        /// <returns></returns>
        public ArrayList CalcularConConjuntos()
        {
            try
            {
                punteroCasosClasificar = 0;

                ClasesCasos.Clear();

                DictionaryEntry claseNuevoCaso;

                while (punteroCasosClasificar < CasosClasificar.Count)
                {
                    // Llegados a este punto, ya está recopilada toda la información necesaria para realizar los cálculos y procedemos

                    CalcularDistanciaConjuntos();

                    // Antes de nada, ordeno el vector de distancias de manera que los K vecinos más próximos estén en las K primeras posiciones

                    Distancias = OrdenaDistancias(Distancias);

                    claseNuevoCaso = ClaseMasVotada();

                    // Almaceno la información recopilada para mostrarla por pantalla

                    ClasesCasos.Add(claseNuevoCaso);

                    // Actualizo las estructuras de datos para almacenar el nuevo caso

                    ActualizarEstructuras();
                }

                return ClasesCasos;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula según el tipo de distancia elegida, la distancia entre el nuevo caso y cada uno de los del conjunto de entrenamiento,
        /// almacenándolas en el vector Distancias
        /// </summary>
        protected void CalcularDistanciaConjuntos()
        {
            try
            {
                DictionaryEntry par = new DictionaryEntry();

                switch (distanciaACalcularConjuntos)
                {
                    case "Clásica":

                        for (int i = 0; i < N; i++)
                        {
                            par.Key = i;

                            par.Value = DistanciaClasica(i);

                            Distancias.Add(par);
                        }

                        break;

                    default:

                        // Tanto en Hausdorff como en Hausdorff mínima

                        CalcularDistanciaEspacioBase();

                        break;
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia entre los elementos dentro del espacio base al que pertenecen
        /// </summary>
        protected void CalcularDistanciaEspacioBase()
        {
            try
            {
                DictionaryEntry par = new DictionaryEntry();

                A = (ArrayList)CasosClasificar[punteroCasosClasificar];

                ArrayList DistanciasElementosA = new ArrayList();

                ArrayList DistanciasElementosB = new ArrayList();

                double hAB, hBA;

                for (int i = 0; i < N; i++)
                {
                    par.Key = i;

                    for (int p = 0; p < ((ArrayList)CjtoEntrenamiento[i]).Count; p++)
                    {
                        if (p < ((ArrayList)CjtoEntrenamiento[i]).Count - 1)
                        {
                            B.Insert(B.Count, System.Convert.ToString(((ArrayList)CjtoEntrenamiento[i])[p]));
                        }
                    }

                    switch (distanciaACalcularEspacioBase)
                    {
                        case "Euclidea":

                            for (int j = 0; j < A.Count; j++)
                            {
                                DistanciasElementosA.Insert(DistanciasElementosA.Count, DistanciaEuclidea(j, A, B));
                            }

                            for (int k = 0; k < B.Count; k++)
                            {
                                DistanciasElementosB.Insert(DistanciasElementosB.Count, DistanciaEuclidea(k, B, A));
                            }

                            break;

                        case "Camberra":

                            for (int j = 0; j < A.Count; j++)
                            {
                                DistanciasElementosA.Insert(DistanciasElementosA.Count, DistanciaCamberra(j, A, B));
                            }

                            for (int k = 0; k < B.Count; k++)
                            {
                                DistanciasElementosB.Insert(DistanciasElementosB.Count, DistanciaCamberra(k, B, A));
                            }

                            break;

                        case "Hamming":

                            for (int j = 0; j < A.Count; j++)
                            {
                                DistanciasElementosA.Insert(DistanciasElementosA.Count, DistanciaHamming(j, A, B));
                            }

                            for (int k = 0; k < B.Count; k++)
                            {
                                DistanciasElementosB.Insert(DistanciasElementosB.Count, DistanciaHamming(k, B, A));
                            }

                            break;

                        case "Levenshtein":

                            for (int j = 0; j < A.Count; j++)
                            {
                                DistanciasElementosA.Insert(DistanciasElementosA.Count, DistanciaLevenshtein(j, A, B));
                            }

                            for (int k = 0; k < B.Count; k++)
                            {
                                DistanciasElementosB.Insert(DistanciasElementosB.Count, DistanciaLevenshtein(k, B, A));
                            }

                            break;                        
                    }

                    // Ordeno de menor a mayor

                    DistanciasElementosA.Sort();

                    DistanciasElementosB.Sort();

                    // Ordenar distancias de menor a mayor

                    if (distanciaACalcularConjuntos == "Hausdorff")
                    {
                        hAB = System.Convert.ToDouble(DistanciasElementosA[DistanciasElementosA.Count - 1]);

                        hBA = System.Convert.ToDouble(DistanciasElementosB[DistanciasElementosB.Count - 1]);

                        par.Value = Math.Max(hAB, hBA);
                    }

                    else if (distanciaACalcularConjuntos == "Hausdorff mínima")
                    {
                        hAB = System.Convert.ToDouble(DistanciasElementosA[0]);

                        hBA = System.Convert.ToDouble(DistanciasElementosB[0]);

                        par.Value = Math.Min(hAB, hBA);
                    }

                    Distancias.Insert(Distancias.Count, par);
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula la distancia clásica entre conjuntos
        /// </summary>
        /// <param name="nCasoConocido"></param>
        /// <returns></returns>
        protected double DistanciaClasica(int nCasoConocido)
        {
            try
            {
                double result;

                ArrayList union = UnionConjuntos((ArrayList)CasosClasificar[punteroCasosClasificar], (ArrayList)CjtoEntrenamiento[nCasoConocido]);

                ArrayList interseccion = InterseccionConjuntos((ArrayList)CasosClasificar[punteroCasosClasificar], (ArrayList)CjtoEntrenamiento[nCasoConocido]);

                result = System.Convert.ToDouble(union.Count - interseccion.Count) / System.Convert.ToDouble(union.Count);

                return result;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Sobrecarga del método para su uso con conjuntos en la distancia de Hausdorff
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected double DistanciaEuclidea(int pos, ArrayList x, ArrayList y)
        {
            try
            {
                double min = -1, aux;

                for (int i = 0; i < y.Count; i++)
                {
                    aux = Math.Sqrt(Math.Pow(System.Convert.ToDouble(x[pos]) - System.Convert.ToDouble(y[i]), 2.0));

                    min = Math.Min(aux, min);

                    // Si el mínimo es 0, para la distancia euclidea ya no va a ser posible una distancia menor, así que retorno

                    if (min == 0) return min;
                }

                return min;
            }

            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// Sobrecarga del método para su uso con conjuntos en la distancia de Hausdorff
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected double DistanciaCamberra(int pos, ArrayList x, ArrayList y)
        {
            try
            {
                double min = -1, aux, numerador, denominador;

                for (int i = 0; i < y.Count; i++)
                {
                    numerador = Math.Abs(System.Convert.ToDouble(x[pos]) - System.Convert.ToDouble(y[i]));

                    denominador = Math.Abs(System.Convert.ToDouble(x[pos]) + System.Convert.ToDouble(y[i]));
                    
                    aux = numerador / denominador;

                    min = Math.Min(aux, min);

                    // Si el mínimo es 0, para la distancia de Camberra ya no va a ser posible una distancia menor, así que retorno

                    if (min == 0) return min;
                }

                return min;      
            }

            catch
            {
                throw;
            }
        }        

        /// <summary>
        /// Sobrecarga del método para su uso con conjuntos en la distancia de Hausdorff
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected int DistanciaLevenshtein(int pos, ArrayList x, ArrayList y)
        {
            try
            {
                string cadenaConocida = System.Convert.ToString(x[pos]), cadenaClasificar;

                int tamConocida, tamClasificar, coste, aux, min = -1;

                for (int p = 0; p < y.Count; p++)
                {
                    cadenaClasificar = System.Convert.ToString(y[p]);

                    tamConocida = cadenaConocida.Length;

                    tamClasificar = cadenaClasificar.Length;

                    int[,] d = new int[tamConocida + 1, tamClasificar + 1];

                    if (tamConocida == 0) aux = tamClasificar;

                    else if (tamClasificar == 0) aux = tamConocida;

                    else
                    {
                        for (int i = 0; i <= tamConocida; d[i, 0] = i++) ;

                        for (int j = 0; j <= tamClasificar; d[0, j] = j++) ;

                        for (int i = 1; i <= tamConocida; i++)
                        {
                            for (int j = 1; j <= tamClasificar; j++)
                            {
                                coste = (cadenaClasificar.Substring(j - 1, 1) == cadenaConocida.Substring(i - 1, 1) ? 0 : 1);

                                d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + coste);
                            }
                        }

                        aux = d[tamConocida, tamClasificar];
                    }

                    min = Math.Min(aux, min);
                }

                return min;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Sobrecarga del método para su uso con conjuntos en la distancia de Hausdorff
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected int DistanciaHamming(int pos, ArrayList x, ArrayList y)
        {
            try
            {
                for (int i = 0; i < y.Count; i++)
                {
                    if (System.Convert.ToString(x[pos]) == System.Convert.ToString(y[i])) return 0; // Retorno porque ya no va a alcanzar un valor menor
                }

                return 1;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza la operación de unión de conjuntos entre dos conjuntos que se le pasan como referencia
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        protected ArrayList UnionConjuntos(ArrayList X, ArrayList Y)
        {
            try
            {
                ArrayList aux = new ArrayList(X);
                
                for (int i = 0; i < Y.Count -1 ; i++)
                {
                    if (!X.Contains(Y[i]))
                    {
                        aux.Insert(aux.Count, Y[i]);
                    }
                }

                return aux;
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza la operación de intersección de conjuntos entre dos conjuntos que se le pasan como referencia
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        protected ArrayList InterseccionConjuntos(ArrayList X, ArrayList Y)
        {
            try
            {
                ArrayList aux = new ArrayList();

                for (int i = 0; i < X.Count; i++)
                {
                    if (Y.Contains(X[i]) && Y.BinarySearch(X[i]) != Y.Count - 1)
                    {
                        aux.Insert(aux.Count, X[i]);
                    }
                }

                return aux;
            }

            catch
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}
