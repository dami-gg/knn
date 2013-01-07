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
    public partial class VentanaPesadoAtributos : Form
    {
        public VentanaPesadoAtributos(ArrayList atributos, ArrayList pesos)
        {
            InitializeComponent();

            ListaAtributos = atributos;

            ListaPesos = pesos;

            MostrarTexto();
        }

        protected void MostrarTexto()
        {
            string aux, textoMostrar = "";

            double peso;

            for (int i = 0; i < ListaAtributos.Count; i++)
            {
                aux = System.Convert.ToString(((DictionaryEntry)ListaAtributos[i]).Value);

                peso = System.Convert.ToDouble(ListaPesos[i]);
                
                if (aux != "numero-ignorar" || aux != "texto-ignorar" || aux != "booleano-ignorar")
                {
                    textoMostrar += ((DictionaryEntry)ListaAtributos[i]).Key + " --> " + peso + "\r\n";
                }
            }

            boxLista.Text = textoMostrar;
        }

        private void cambiarPeso_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(boxAtributo.Text) || String.IsNullOrEmpty(boxPeso.Text))
            {
                MessageBox.Show("No se han introducido valores correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            if (System.Convert.ToDouble(boxPeso.Text) < 0)
            {
                MessageBox.Show("El peso no puede ser negativo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            // Buscar si el atributo introducido existe realmente

            for (int i = 0; i < ListaAtributos.Count; i++)
            {
                if (System.Convert.ToString(((DictionaryEntry)ListaAtributos[i]).Key) == boxAtributo.Text)
                {
                    if(boxPeso.Text.Contains("."))
                    {                    
                        // Lo de Globalization sirve para que reconozca el punto como separador de la parte entera y de la decimal en vez de la coma

                        ListaPesos[i] = Double.Parse(boxPeso.Text, System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("en-US"));

                    }

                    else
                    {
                        ListaPesos[i] = boxPeso.Text;
                    }
                        
                    MostrarTexto();

                    return;
                }
            }

            MessageBox.Show("El atributo introducido no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Salir(object sender, EventArgs e)
        {
            Close();
        }

        public ArrayList verListaPesos()
        {
            return ListaPesos;
        }

        private void botonMismoPeso_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListaPesos.Count; i++)
            {
                ListaPesos[i] = 1;
            }

            MostrarTexto();
        }
    }
}