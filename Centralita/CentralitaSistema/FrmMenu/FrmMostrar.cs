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
    public partial class FrmMostrar : Form
    {
        private TipoLlamada tipoLlamada;
        Centralita centralita;

        public TipoLlamada TipoLlamada
        {
            set
            {
                this.tipoLlamada = value;
            }
        }
        public FrmMostrar(Centralita centralita)
        {
            this.centralita = centralita;
            InitializeComponent();
            
            

        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            float gananciaTotal = 0;
            float gananciaLocal = 0;
            float gananciaProvincial = 0;
            

            foreach (Llamada llamada in centralita.Llamadas)
            {
                gananciaTotal += llamada.CostoLlamada;
                if(llamada is Local && tipoLlamada== TipoLlamada.Local)
                {
                    richTextBox1.Text += llamada.ToString();
                    gananciaLocal += llamada.CostoLlamada;
                }
                else if(llamada is Provincial && tipoLlamada == TipoLlamada.Provincial)
                {
                    richTextBox1.Text += llamada.ToString();
                    gananciaProvincial += llamada.CostoLlamada;
                }
                else if(tipoLlamada == TipoLlamada.Todas)
                {
                    richTextBox1.Text += llamada.ToString();
                }
                
                
                    
                
            }



                switch (tipoLlamada)
            {
                case TipoLlamada.Todas:
                    richTextBox1.Text += $"\r\nGanancia Total: {gananciaTotal}";
                    break;
                case TipoLlamada.Local:
                    richTextBox1.Text += $"\r\nGanancia Local: {gananciaLocal}";

                    break;
                default:
                
                    richTextBox1.Text += $"\r\nGanancia Provincial: {gananciaProvincial}";

                    break;
            }

        }


    }
}
