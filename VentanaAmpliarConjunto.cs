using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KNN
{
    public partial class VentanaAmpliarConjunto : Form
    {
        public VentanaAmpliarConjunto(string tipoAplicacion, string tipoDatos)
        {
            InitializeComponent();

            switch (tipoAplicacion)
            {
                case "Vectores":

                    TextoOcultoAlEscribir.Text = "Ejemplo:\r\n\r\n(atributo1, atributo2, atributo3, ..., atributoM, clase)\r\n(atributo1, atributo2, atributo3, ..., atributoM, clase)";

                    break;

                case "Cadenas":

                    TextoOcultoAlEscribir.Text = "Ejemplo:\r\n\r\ncadena1, clase\r\ncadenaC, clase";
                    
                    break;

                case "Conjuntos":

                    TextoOcultoAlEscribir.Text = "Ejemplo:\r\n\r\nelemento1, elemento2, elemento3, ..., elementoX, clase\r\nelemento1, elemento2, elemento3, ..., elementoY, clase";
                    
                    break;
            }

            tipoDatosCjto = tipoDatos;
        }

        private void LeerAmpliacion()
        {
            textoIntroducido = boxAmpliar.Text;
        }

        private void Anadir_Click(object sender, EventArgs e)
        {
            LeerAmpliacion();
        }

        public string MostrarTextoIntroducido()
        {
            try
            {
                if (tipoDatosCjto != "Sin comprobar")
                {
                    if (ComprobarMismoTipo()) return textoIntroducido;

                    return "Error: tipo distinto";
                }

                return textoIntroducido;
            }

            catch
            {
                throw;
            }
        }

        private bool ComprobarMismoTipo()
        {
            try
            {
                string cadena = "";

                double aux;

                bool numericaAmpli = false, primera = true;

                for (int i = 0; i < textoIntroducido.Length; i++)
                {
                    while (i < textoIntroducido.Length && textoIntroducido[i] != ',' && textoIntroducido[i] != '\r' && textoIntroducido[i] != '\n')
                    {
                        cadena += textoIntroducido[i];

                        i++;
                    }

                    if (i < textoIntroducido.Length && textoIntroducido[i] == ',')
                    {
                        cadena = cadena.Replace('.', ',');

                        cadena = cadena.Trim();

                        if (primera)
                        {
                            numericaAmpli = Double.TryParse(cadena, out aux);

                            primera = false;

                            cadena = "";
                        }

                        else
                        {
                            if (numericaAmpli && !Double.TryParse(cadena, out aux)) return false;

                            else if (!numericaAmpli && Double.TryParse(cadena, out aux)) return false;

                            cadena = "";
                        }
                    }

                    else if (i < textoIntroducido.Length && (textoIntroducido[i] == '\r' || textoIntroducido[i] == '\n')) cadena = "";
                }

                if (((tipoDatosCjto == "Números") && !numericaAmpli) || ((tipoDatosCjto == "Cadenas") && numericaAmpli)) return false;

                return true;
            }

            catch
            {
                throw;
            }
        }

    }
}