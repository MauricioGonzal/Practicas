using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaNamespace
{
    public class Local: Llamada, IGuardar<Local>
    {
        protected float costo;

        public override float CostoLlamada
        {
            get { return CalcularCosto(); }
        }

        public string RutaDeArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Local(string origen, float duracion, string destino, float costo):base(duracion, destino, origen)
        {
            this.costo = costo;

        }

        public Local(Llamada llamada, float costo): this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        {
            
            
        }
        private float CalcularCosto()
        {
            float costoLlamada;
            costoLlamada = duracion * costo;
            return costoLlamada;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Costo Llamada: {this.CostoLlamada}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Local;
        }

        public bool Guardar()
        {
            throw new NotImplementedException();
        }

        public Local Leer()
        {
            throw new NotImplementedException();
        }
    }
}
