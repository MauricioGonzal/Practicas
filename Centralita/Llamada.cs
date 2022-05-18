using System;
using System.Text;

namespace CentralitaNamespace
{
    public enum TipoLlamada
    {
        Local,
        Provincial,
        Todas
    }
    public abstract class Llamada
    {
        

        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public abstract float CostoLlamada
        {
            get;
        }

        public float Duracion
        {
            get { return duracion; }
        }

        public string NroDestino
        {
            get { return nroDestino; }
        }

        public string NroOrigen
        {
            get { return nroOrigen; }
        }



        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if(llamada1.Duracion > llamada2.Duracion)
            {
                return 1;
            }
            else if(llamada1.Duracion < llamada2.Duracion)
            {
                return -1;
            }
            else
            {
                return 0;
            }

            
            
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Duracion: {0}\r\n", this.Duracion.ToString());
            sb.AppendFormat("Nro Destino: {0}\r\n", this.NroDestino.ToString());
            sb.AppendFormat("Nro Origen: {0}\r\n", this.nroOrigen.ToString());

            return sb.ToString();

            
        }

        public static bool operator ==(Llamada l1, Llamada l2)
        {

            return l1.Equals(l2) && l1.NroDestino == l2.NroDestino && l1.NroOrigen == l2.NroOrigen;
          
        }

        public static bool operator !=(Llamada l1, Llamada l2)
        {
            return !(l1 == l2);
        }
    }
}
