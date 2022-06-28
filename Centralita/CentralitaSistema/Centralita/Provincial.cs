using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaNamespace
{
    public enum Franja
    {
        Franja_1,
        Franja_2,
        Franja_3
    }
    public class Provincial:Llamada, IGuardar<Provincial>
    {
        

        protected Franja franjaHoraria;

        private float CalcularCosto()
        {
            float costoTotal;
            

            switch (franjaHoraria)
            {
                case Franja.Franja_1:
                    costoTotal = base.Duracion * 0.99f;
                    break;
                case Franja.Franja_2:
                    costoTotal = base.Duracion * 1.25f;
                    break;
                default:
                    costoTotal = base.Duracion * 0.66f;
                    break;

            }

            return costoTotal;
        }

        public override float CostoLlamada
        {
            get
            {
                return CalcularCosto();
            }
        }

        public string RutaDeArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Provincial(Franja miFranja, Llamada llamada):this(llamada.NroOrigen, miFranja,  llamada.Duracion, llamada.NroDestino)
        {
            

        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino):base(duracion, destino, origen)
        {
            this.franjaHoraria = miFranja;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Costo: {this.CostoLlamada}  Franja horaria: {this.franjaHoraria}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Provincial;
        }

        public bool Guardar()
        {
            throw new NotImplementedException();
        }

        public Provincial Leer()
        {
            throw new NotImplementedException();
        }
    }
}
