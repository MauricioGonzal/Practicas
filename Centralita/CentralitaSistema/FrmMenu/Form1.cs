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
    public partial class Form1 : Form
    {
        public Centralita centralita;
        public Form1()
        {
            InitializeComponent();
            centralita = new Centralita();
        }

        private void btnGenerarLlamada_Click(object sender, EventArgs e)
        {
            FrmLlamador frmLlamador = new FrmLlamador(centralita);
            frmLlamador.ShowDialog();
            this.centralita = frmLlamador.Centralita;
        }

        private void btnFacturacionTotal_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(this.centralita);
            frmMostrar.TipoLlamada = TipoLlamada.Todas;
            frmMostrar.Show();
            
            
            


        }

        private void btnFacturacionLocal_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(this.centralita);
            frmMostrar.TipoLlamada = TipoLlamada.Local;
            frmMostrar.Show();
        }

        private void btnFacturacionProvincial_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(this.centralita);
            frmMostrar.TipoLlamada = TipoLlamada.Provincial;
            frmMostrar.Show();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
