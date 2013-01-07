using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KNN
{
    public partial class VentanaPesadoCasos : Form
    {
        public VentanaPesadoCasos(string tipo)
        {
            InitializeComponent();

            if (tipo == "Inversamente") checkInversamente.Checked = true;

            else if (tipo == "Orden") checkOrden.Checked = true;
        }

        public string MostrarTipo()
        {
            return tipoPesado;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            if (!checkInversamente.Checked && !checkOrden.Checked) tipoPesado = "";
            
            Close();
        }

        private void checkInversamente_CheckedChanged(object sender, EventArgs e)
        {
            if (checkInversamente.Checked)
            {
                checkOrden.Checked = false;

                tipoPesado = "Inversamente";
            }
        }

        private void checkOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOrden.Checked)
            {
                checkInversamente.Checked = false;

                tipoPesado = "Orden";
            }
        }

        
    }
}