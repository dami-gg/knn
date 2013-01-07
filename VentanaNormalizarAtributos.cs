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
    public partial class VentanaNormalizarAtributos : Form
    {
        public VentanaNormalizarAtributos(ArrayList atributos, ArrayList normalizados, ArrayList rangos, double intIzq, double intDer)
        {
            InitializeComponent();

            ListaAtributos = atributos;

            ListaNormalizados = normalizados;

            RangosAtributos = rangos;

            intervalo = "[" + intIzq + ", " + intDer + "]";

            MostrarTexto();
        }

        public ArrayList EstadoAtributos()
        {
            return ListaNormalizados;
        }

        protected void AnadirNormalizado(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(boxAtributo.Text))
            {
                MessageBox.Show("No se ha introducido ningún atributo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            int pos = BuscarAtributo(boxAtributo.Text);

            if (pos == -1) // No existe
            {
                MessageBox.Show("El atributo introducido no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            string tipo = System.Convert.ToString(((DictionaryEntry)ListaAtributos[pos]).Value);

            if (tipo == "texto-ignorar" || tipo == "numero-ignorar" || tipo == "booleano-ignorar")
            {
                MessageBox.Show("El atributo introducido se está ignorando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }
  
            else if (tipo == "texto")
            {
                MessageBox.Show("El atributo introducido es cualitativo y no se puede normalizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            else if (tipo == "booleano")
            {
                MessageBox.Show("El atributo introducido es booleano y no se puede normalizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            if (!ListaNormalizados.Contains(pos)) ListaNormalizados.Add(pos);

            MostrarTexto();
        }

        protected void QuitarNormalizado(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(boxAtributo.Text))
            {
                MessageBox.Show("No se ha introducido ningún atributo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            int pos = BuscarAtributo(boxAtributo.Text);

            if (pos == -1) // No existe
            {
                MessageBox.Show("El atributo introducido no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                return;
            }

            else
            {
                if (!ListaNormalizados.Contains(pos))
                {
                    // No está en la lista

                    MessageBox.Show("El atributo introducido no se encuentra entre los que se van a normalizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                else
                {
                    // Lo saco de la lista a normalizar

                    int j = 0;
                    
                    for (; j < ListaNormalizados.Count; j++)
                    {
                        if (System.Convert.ToString ( ((DictionaryEntry) ListaAtributos[((Int32) ListaNormalizados[j])]).Key) == boxAtributo.Text) break;
                    }

                    ListaNormalizados.RemoveAt(j);

                    MostrarTexto();
                }
            }
        }

        /// <summary>
        /// Devuelve la posición de un atributo que se le pasa como parámetro dentro de la lista de atributos,
        /// o -1 si no se encuentra en ella, o -2 si se está ignorando
        /// </summary>
        /// <param name="atributo"></param>
        /// <returns></returns>
        protected int BuscarAtributo(string atributo)
        {
            for (int i = 0; i < ListaAtributos.Count; i++)
            {
                if (System.Convert.ToString( ((DictionaryEntry)ListaAtributos[i]).Key) == atributo)
                {
                    return i;
                }
            }

            return -1;
        }

        protected void MostrarTexto()
        {            
            string aux, textoMostrar = "";

            int pos;

            for (int i = 0; i < ListaNormalizados.Count; i++)
            {
                pos = (Int32) ListaNormalizados[i];
                
                aux = System.Convert.ToString( ((DictionaryEntry)ListaAtributos[pos]).Key);
            
                textoMostrar += aux + "\r\n";
            }

            boxLista.Text = textoMostrar;
        }
        
        private void Salir(object sender, EventArgs e)
        {
            Close();
        }

        private void verAtributos_Click(object sender, EventArgs e)
        {
            Hide();

            VentanaMostrarAtributos Atribs = new VentanaMostrarAtributos(ListaAtributos, ListaNormalizados, RangosAtributos, intervalo);

            if (Atribs.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }

    }
}