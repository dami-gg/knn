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
    public partial class VentanaMostrarAtributos : Form
    {
        public VentanaMostrarAtributos(ArrayList atribs)
        {
            InitializeComponent();

            string texto = "";

            for (int i = 0; i < atribs.Count; i++)
            {
                texto += System.Convert.ToString(((DictionaryEntry)atribs[i]).Key);

                texto += "\r\n";
            }

            boxAtributos.Text = texto;
        }

        public VentanaMostrarAtributos(ArrayList atribs, ArrayList normalizados, ArrayList rangos, string intervalo)
        {
            InitializeComponent();

            string texto = "", tipo;

            for (int i = 0; i < atribs.Count; i++)
            {
                tipo = System.Convert.ToString(((DictionaryEntry)atribs[i]).Value);

                if (tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar" && tipo != "cuantitativo-ignorar")
                {
                    texto += System.Convert.ToString(((DictionaryEntry)atribs[i]).Key);

                    if (tipo == "cualitativo")
                    {
                        texto += "  --->  Cualitativo (no se puede normalizar)";
                    }

                    else if (tipo == "booleano")
                    {
                        if (!normalizados.Contains(i)) texto += "  --->  Booleano [0, 1] (no se puede normalizar)";

                        else texto += "  --->  " + intervalo;
                    }

                    else if (tipo == "cuantitativo")
                    {
                        if (!normalizados.Contains(i)) texto += "  --->  [" + System.Convert.ToString(((DictionaryEntry)rangos[i]).Key).Replace(',', '.') + ", " + System.Convert.ToString(((DictionaryEntry)rangos[i]).Value).Replace(',', '.') + "]";

                        else texto += "  --->  " + intervalo;
                    }

                    texto += "\r\n";
                }
            }

            boxAtributos.Text = texto;
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}