using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form_Laberinto
{
    public partial class Autoconstruir : Form
    {
        public Autoconstruir()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxRecorrer.SelectedIndex = 0;
            cbxTamanoCasilla.SelectedIndex = 0;
            cbxObjetivos.SelectedIndex = 0;
            cbxRetardo.SelectedIndex = 0;
        }

        /// <summary>
        /// Refresca el dibujo del laberinto para que no se pierda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (Laberinto.Dibujado)
                {
                    Laberinto.Dibujar(this.CreateGraphics());
                }
            }
            catch (Exception) { }
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            #region Validaciones

            errorProvider1.Clear();

            //Valida campos vacios
            if (cbxAncho.Text.Trim().Length == 0)
            { errorProvider1.SetError(cbxAncho, "Debe escribir el ancho del laberinto"); return; }
            if (cbxAlto.Text.Trim().Length == 0)
            { errorProvider1.SetError(cbxAlto, "Debe escribir el alto del laberinto"); return; }

            //Valida los tipos y rangos
            try
            {
                int iAncho = Convert.ToInt32(cbxAncho.Text);
                int iAlto = Convert.ToInt32(cbxAlto.Text);
                if (iAncho < 4)
                { errorProvider1.SetError(cbxAncho, "El ancho debe ser un número mayor o igual a 4"); return; }
                if (iAlto < 4)
                { errorProvider1.SetError(cbxAlto, "El alto debe ser un número mayor o igual a 4"); return; }
            }
            catch (Exception)
            {
                errorProvider1.SetError(cbxAncho, "Revise los valores");
                errorProvider1.SetError(cbxAlto, "Revise los valores");
                return;
            }

            pnlControles.Visible = false;
            btnVolver.Visible = true;
            btnVRML.Visible = true;
            btnResolver.Visible = true;
            picLogo.Visible = false;

            #endregion Validaciones

            //Asigna parámetros
            if (cbxRecorrer.SelectedIndex == 0) Laberinto.Recorrido = Direccion.ArribaAbajo;
            if (cbxRecorrer.SelectedIndex == 1) Laberinto.Recorrido = Direccion.IzquierdaDerecha;
            Laberinto.Ancho = Convert.ToInt32(cbxAncho.Text);
            Laberinto.Alto = Convert.ToInt32(cbxAlto.Text);
            Laberinto.TamanoCasilla = Convert.ToInt32(cbxTamanoCasilla.Text);
            Laberinto.Objetivos = Convert.ToInt32(cbxObjetivos.Text);
            Laberinto.Retardo_ms = Convert.ToInt32(cbxRetardo.Text);

            //Autoconstruye un laberinto
            Laberinto.Generar();
            //Lo dibuja en pantalla
            Laberinto.Dibujar(this.CreateGraphics());
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlControles.Visible = true;
            picLogo.Visible = true;
            btnVolver.Visible = false;
            btnVRML.Visible = false;
            btnResolver.Visible = false;
            Laberinto.Dibujado = false;
            Laberinto3D.Camino = null;

            //Limpia el formulario
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, 0, 0, this.Width, this.Height);
        }

        private void cbxTamanoCasilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iTamano = Convert.ToInt32(cbxTamanoCasilla.Text);

            cbxAlto.Items.Clear();
            for (int i = 4; i < 330 / iTamano; i += 2) //Valores de ancho (330px en total)
                cbxAlto.Items.Add(i.ToString());

            cbxAncho.Items.Clear();
            for (int i = 4; i < 660 / iTamano; i += 2)  //Valores de ancho (660px en total)
                cbxAncho.Items.Add(i.ToString());
        }

        /// <summary>
        /// Permite exportar el código VRML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVRML_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save file as...";
            dialog.Filter = "Simulación 3D (*.wrl)|";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Laberinto.CrearBackup();

                if (Laberinto3D.Camino == null)
                    Laberinto.Resolver(this.CreateGraphics());

                String sCodigo = VRML.Crear(Laberinto.Matriz);

                Laberinto.RestaurarBackup();

                //Escribe el archivo en disco
                using (StreamWriter outfile = new StreamWriter(dialog.FileName.Replace(".wrl", String.Empty) + ".wrl"))
                {
                    outfile.Write(sCodigo);
                }
            }
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            //Resuelve el laberinto
            Laberinto.Resolver(this.CreateGraphics());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            DialogResult d = c.ShowDialog();
            if (!d.Equals(DialogResult.Cancel))
            {
                MessageBox.Show("R=" + c.Color.R + ", G:" + c.Color.G + ",B:" + c.Color.B);
            }
        }
    }
}