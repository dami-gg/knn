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
    public partial class VentanaIgnorarAtributos : Form
    {
        public VentanaIgnorarAtributos(ArrayList atributos)
        {
            InitializeComponent();

            ListaAtributos = atributos;

            MostrarTexto();
        }

        public ArrayList EstadoAtributos()
        {
            return ListaAtributos;
        }

        protected void AnadirIgnorado(object sender, EventArgs e)
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
                string tipo = System.Convert.ToString( ((DictionaryEntry)ListaAtributos[pos]).Value);

                if (tipo == "numero-ignorar" || tipo == "cualitativo-ignorar" || tipo == "booleano-ignorar")
                {
                    // Ya está ignorado

                    MessageBox.Show("El atributo introducido ya se está ignorando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                else
                {
                   tipo += "-ignorar";

                    DictionaryEntry par = new DictionaryEntry();

                    par.Key = boxAtributo.Text;

                    par.Value = tipo;

                    ListaAtributos.RemoveAt(pos);

                    ListaAtributos.Insert(pos, par);

                    ListaIgnorados.Add(boxAtributo.Text);

                    MostrarTexto();
                }
            }
        }

        protected void QuitarIgnorado(object sender, EventArgs e)
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
                string tipo = System.Convert.ToString( ((DictionaryEntry)ListaAtributos[pos]).Value);

                if (tipo != "numero-ignorar" && tipo != "cualitativo-ignorar" && tipo != "booleano-ignorar")
                {
                    // No está ignorado

                    MessageBox.Show("El atributo introducido no se está ignorando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                else
                {
                    string aux = "";

                    for (int i = 0; i < tipo.Length; i++)
                    {
                        if (tipo[i] == '-') break;

                        aux += tipo[i];
                    }

                    DictionaryEntry par = new DictionaryEntry();

                    par.Key = boxAtributo.Text;

                    par.Value = aux;

                    ListaAtributos.RemoveAt(pos);

                    ListaAtributos.Insert(pos, par);

                    // Lo saco de la lista de ignorados
                    
                    int j = 0;

                    for (; j < ListaIgnorados.Count; j++)
                    {
                        if (System.Convert.ToString (ListaIgnorados[j]) == boxAtributo.Text) break;
                    }

                    ListaIgnorados.RemoveAt(j);

                    MostrarTexto();
                }
            }
        }

        /// <summary>
        /// Devuelve la posición de un atributo que se le pasa como parámetro dentro de la lista de atributos
        /// o -1 si no se encuentra en ella
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

            for (int i = 0; i < ListaAtributos.Count; i++)
            {
                aux = System.Convert.ToString( ((DictionaryEntry)ListaAtributos[i]).Value);

                if (aux == "numero-ignorar" || aux == "cualitativo-ignorar" || aux == "booleano-ignorar")
                {
                    ListaIgnorados.Add(i);

                    textoMostrar += ((DictionaryEntry)ListaAtributos[i]).Key + "\r\n";
                }
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

            VentanaMostrarAtributos Atribs = new VentanaMostrarAtributos(ListaAtributos);

            if (Atribs.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }


    }
}