using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralitaNamespace;

namespace FrmMenu
{
    public partial class FrmLlamador : Form
    {
        Centralita centralita;
        public FrmLlamador(Centralita centralita)
        {
            InitializeComponent();
            this.centralita = centralita;
        }

        public Centralita Centralita
        {
            get
            {
                return this.centralita;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '3';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '4';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '5';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '6';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '8';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '9';
        }

        private void btnAsterisco_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '*';
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '0';
        }

        private void btnNumeral_Click(object sender, EventArgs e)
        {
            this.TxtNroDestino.Text += '#';
        }

        private void TxtNroDestino_TextChanged(object sender, EventArgs e)
        {
            if (!(TxtNroDestino.Text.StartsWith('#')))
            {
                this.cmbFranja.Enabled = false;
            }
            else
            {
                this.cmbFranja.Enabled = true;
            }
        }

        private void FrmLlamador_Load(object sender, EventArgs e)
        {
            cmbFranja.DataSource = Enum.GetValues(typeof(Franja));
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Llamada llamada;
            float duracion;
            duracion = 0;

            if(this.TxtNroDestino.Text.Length >0 && this.txtNroOrigen.Text.Length > 0)
            {

            
            if (this.cmbFranja.Enabled is false)
            {
                double min = 0.5;
                double max = 5.6;
                double range = max - min;
                
                    double sample = rnd.NextDouble();
                    double scaled = (sample * range) + min;
                    duracion = (float)scaled;
                    
                
                llamada = new Local(this.txtNroOrigen.Text, rnd.Next(1, 50), this.TxtNroDestino.Text, duracion);
            }
            else
            {
                Franja franjas;
                Enum.TryParse<Franja>(cmbFranja.SelectedValue.ToString(), out franjas);
                llamada = new Provincial(this.txtNroOrigen.Text, franjas, rnd.Next(1, 50), this.TxtNroDestino.Text);
            }
                try
                {
                    centralita += llamada;
                    MessageBox.Show("Operacion realizada con exito", "Llamador", MessageBoxButtons.OK);
                    this.Hide();
                }
                catch(CentralitaException)
                {
                    MessageBox.Show("La llamada no se ha podido cargar en el sistema. Verifique los datos ingresados");
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK);
            }

            
        }

        private void txtNroOrigen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNroOrigen.Text = "";
            this.TxtNroDestino.Text = "";

        }
    }
}
