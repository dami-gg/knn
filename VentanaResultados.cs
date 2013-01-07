using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SoftwareFX.ChartFX.Lite;

namespace KNN
{
    public partial class VentanaResultados : Form
    {
        public VentanaResultados(ArrayList array, string control, string path)
        {
            InitializeComponent();

            tipoResultados = control;

            if (tipoResultados == "Normal") ActivarProbabilidades = true;

            if (ActivarProbabilidades == false) botonProbabilidades.Visible = false;

            clases = array;

            guardarResultados.InitialDirectory = path;              
            
            MostrarResultados();

            HacerRecuento();

            MostrarGrafica();
        }

        private void MostrarResultados()
        {
            try
            {
                // Convertir el ArrayList a string para mostrarlo en la ventana

                string texto = "";

                switch (tipoResultados)
                {
                    case "Normal":

                        for (int i = 0; i < clases.Count; i++)
                        {
                            if (!MostrarProbabilidades)
                            {
                                texto += "Caso " + System.Convert.ToString(i + 1);

                                texto += "  --->  Clase " + System.Convert.ToString(((DictionaryEntry)clases[i]).Key) + "\r\n";
                            }

                            else
                            {
                                texto += "Caso " + System.Convert.ToString(i + 1);

                                texto += "  --->  Clase " + System.Convert.ToString(((DictionaryEntry)clases[i]).Key);

                                texto += "  --->  " + System.Convert.ToDouble(((DictionaryEntry)clases[i]).Value) + " %\r\n";
                            }
                        }

                        break;

                    case "Regresión":

                        for (int i = 0; i < clases.Count; i++)
                        {
                            texto += "Caso " + System.Convert.ToString(i + 1) + "  --->  Clase " + System.Convert.ToString(clases[i]) + "\r\n";
                        }

                        break;

                    case "Validación cruzada":

                        for (int i = 0; i < clases.Count; i++)
                        {
                            texto += "K = " + System.Convert.ToString(i + 1) + "  --->  Aciertos: " + System.Convert.ToInt32(clases[i]) + "\r\n";
                        }

                        MostrarKOptimo();

                        break;
                }

                cuadroResultados.Text = texto;
            }

            catch
            {
                throw;
            }
        }

        private void HacerRecuento ()
        {
            try
            {
                DictionaryEntry par = new DictionaryEntry();

                if (tipoResultados != "Validación cruzada")
                {
                    ArrayList aux = new ArrayList();

                    int conta;

                    for (int i = 0; i < clases.Count; i++)
                    {
                        if (!valoresGrafica.Contains(System.Convert.ToString(((DictionaryEntry)clases[i]).Key)))
                        {
                            valoresGrafica.Insert(valoresGrafica.Count, ((DictionaryEntry)clases[i]).Key);

                            aux.Insert(aux.Count, 1);
                        }

                        else // Aumento la cuenta
                        {
                            for (int j = 0; j < valoresGrafica.Count; j++)
                            {
                                if (System.Convert.ToString(valoresGrafica[j]) == System.Convert.ToString(((DictionaryEntry)clases[i]).Key))
                                {
                                    conta = System.Convert.ToInt32(aux[j]);

                                    conta++;

                                    aux[j] = conta;
                                }
                            }
                        }
                    }

                    for (int k = 0; k < valoresGrafica.Count; k++)
                    {
                        par.Key = System.Convert.ToString(valoresGrafica[k]);

                        par.Value = aux[k];

                        valoresGrafica[k] = par;
                    }
                }

                else
                {
                    for (int l = 0; l < clases.Count; l++)
                    {
                        par.Key = l + 1;

                        par.Value = System.Convert.ToInt32(clases[l]);

                        valoresGrafica.Add(par);
                    }
                }
            }

            catch
            {
                throw;
            }
        }

        private void MostrarGrafica()
        {
            try
            {
                grafica.Titles[0].Text = "Gráfica de resultados";

                grafica.Titles[0].TextColor = Color.Blue;

                grafica.Chart3D = true;

                grafica.BorderColor = Color.Blue;

                grafica.Gallery = Gallery.Bar;

                grafica.Grid = ChartGrid.Horz;

                grafica.AxisX.TextColor = Color.Blue;

                grafica.AxisY.LabelsFormat.Decimals = 0;

                grafica.AxisY.TextColor = Color.Blue;

                grafica.OpenData(COD.Values, 1, valoresGrafica.Count);

                for (int i = 0; i < valoresGrafica.Count; i++)
                {
                    grafica.Legend[i] = System.Convert.ToString(((DictionaryEntry)valoresGrafica[i]).Key);

                    grafica.Value[0, i] = System.Convert.ToInt32(((DictionaryEntry)valoresGrafica[i]).Value);
                }

                grafica.CloseData(COD.Values);
            }

            catch
            {
                throw;
            }
        }

        private void grafica_DoubleClick(object sender, MouseEventArgsX e)
        {
            try
            {
                if (grafica.Gallery == Gallery.Bar)
                {
                    grafica.Gallery = Gallery.Pie;

                    grafica.LegendBox = true;
                }

                else if (grafica.Gallery == Gallery.Pie)
                {
                    grafica.Gallery = Gallery.Area;

                    grafica.LegendBox = false;
                }

                else if (grafica.Gallery == Gallery.Area)
                {
                    grafica.Gallery = Gallery.Lines;
                }

                else if (grafica.Gallery == Gallery.Lines)
                {
                    grafica.Gallery = Gallery.Scatter;
                }

                else
                {
                    grafica.Gallery = Gallery.Bar;
                }
            }

            catch
            {
                throw;
            }
        }

        private void botonProbabilidades_Click(object sender, EventArgs e)
        {
            if (ActivarProbabilidades)
            {
                MostrarProbabilidades = !MostrarProbabilidades;

                if (!MostrarProbabilidades) botonProbabilidades.Text = "Mostrar probabilidades";

                else botonProbabilidades.Text = "Ocultar probabilidades";

                MostrarResultados();
            }
        }

        private void MostrarKOptimo()
        {
            try
            {
                boxKOptimo.Visible = true;

                labelKOptimo.Visible = true;

                int max = System.Convert.ToInt32(clases[0]);

                string texto = "1, ";

                for (int i = 1; i < clases.Count; i++)
                {
                    if (System.Convert.ToInt32(clases[i]) > max)
                    {
                        texto = System.Convert.ToString(i + 1) + ", ";

                        max = System.Convert.ToInt32(clases[i]);
                    }

                    else if (System.Convert.ToInt32(clases[i]) == max)
                    {
                        texto += System.Convert.ToString(i + 1) + ", ";
                    }
                }

                texto = texto.Remove(texto.Length - 2);

                boxKOptimo.Text = texto;
            }

            catch
            {
                throw;
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            guardarResultados.Title = "Especifica el nombre del archivo de destino";
            guardarResultados.Filter = "Archivos de salida (*.out)|*.out";
            guardarResultados.OverwritePrompt = true;

            if (guardarResultados.ShowDialog() != DialogResult.Cancel) rutaGuardar = guardarResultados.FileName;
        }

        public string verRutaGuardar()
        {
            return rutaGuardar;
        }
    }
}