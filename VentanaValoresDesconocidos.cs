using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KNN
{
    public partial class VentanaValoresDesconocidos : Form
    {
        public VentanaValoresDesconocidos(string opc)
        {
            InitializeComponent();

            opcion = opc;

            switch (opcion)
            {
                case "Media":

                    checkMedia.Checked = true;

                    return;

                case "Mediana":

                    checkMediana.Checked = true;

                    return;

                case "Eliminación":

                    checkEliminacion.Checked = true;

                    return;

                default:

                    checkEliminacion.Checked = true;

                    opcion = "Eliminación";

                    return;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string verOpcion()
        {
            return opcion;
        }

        private void checkEliminacion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEliminacion.Checked)
            {
                checkMedia.Checked = false;

                checkMediana.Checked = false;

                opcion = "Eliminación";
            }
        }

        private void checkMedia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMedia.Checked)
            {
                checkEliminacion.Checked = false;

                checkMediana.Checked = false;

                opcion = "Media";
            }
        }

        private void checkMediana_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMediana.Checked)
            {
                checkMedia.Checked = false;

                checkEliminacion.Checked = false;

                opcion = "Mediana";
            }
        }
    }
}