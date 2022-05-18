using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaNamespace
{
    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;

        public float GananciasPorLocal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Local);
            }
        }

        public float GananciasPorProvincial
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Provincial);
            }
        }

        public float GanaciasPorTotal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return listaDeLlamadas;
            }
        }

        public Centralita()
        {
            listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa):this()
        {
            this.razonSocial = nombreEmpresa;
        }

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            if(nuevaLlamada != null)
            {
                listaDeLlamadas.Add(nuevaLlamada);
            }
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float acum = 0;

            foreach (Llamada aux in this.listaDeLlamadas)
            {
                //LOCAL
                if (aux is Local)
                {
                    if (tipo ==TipoLlamada.Local || tipo == TipoLlamada.Todas)
                    {
                        acum += ((Local)aux).CostoLlamada;
                    }
                }
                //PROVINCIAL
                else if (aux is Provincial)
                {
                    if (tipo ==TipoLlamada.Provincial || tipo == TipoLlamada.Todas)
                    {
                        acum += ((Provincial)aux).CostoLlamada;
                    }
                }
            }
            return acum;

        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Razon social: {this.razonSocial}\r\n Ganancia Total: {this.GanaciasPorTotal} Ganancia Local:{this.GananciasPorLocal} Ganancia Provincial:{this.GananciasPorProvincial}");
            foreach(Llamada aux in this.listaDeLlamadas)
            {
                sb.AppendLine(aux.ToString());
            }

            return sb.ToString();
        }

        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public static bool operator ==(Centralita c, Llamada llamada)
        {
            foreach(Llamada aux in c.listaDeLlamadas)
            {
                if(aux == llamada)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Centralita c, Llamada llamada)
        {
            return !(c == llamada);
        }

        public static Centralita operator +(Centralita c, Llamada nuevaLlamada)
        {
            try
            {
                if (c != nuevaLlamada)
                {
                    c.AgregarLlamada(nuevaLlamada);
                }
                else
                {
                    throw new CentralitaException("La llamada ya se encuentra registrada en el sistema", "Centralita", "Operator +");

                }
            }
            catch(CentralitaException)
            {
                throw;
            }
            
            
                

            return c;
        }
    }
}
