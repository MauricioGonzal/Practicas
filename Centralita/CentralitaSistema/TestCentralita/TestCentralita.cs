using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralitaNamespace;
using System.Collections.Generic;

namespace TestCentralita
{
    [TestClass]
    public class TestCentralita
    {
        [TestMethod]
        public void NewCentralita_CuandoSeCreaUnObjetoTipoCentralita_DeberiaRetornarInstanciaListaDeLlamadas()
        {
            //arrange
            Centralita centralita;
            List<Llamada> lista;

            //act
            centralita = new Centralita();
            lista = centralita.Llamadas;

            //assert
            Assert.IsNotNull(lista);


        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void AgregarLlamada_CuandoSeCargaMismosDatosDeOrigenYDestinoEnLlamadaLocal_DeberiaLanzarCentralitaException()
        {
            //arrange
            Centralita centralita;
            Local llamada;

            //act
            centralita= new Centralita();
            llamada=new Local("222",2,"222", 2);
            centralita = centralita + llamada;
            llamada = new Local("222", 7, "222", 5);
            centralita = centralita + llamada;



        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void AgregarLlamada_CuandoSeCargaMismosDatosDeOrigenYDestinoEnLlamadaProvincial_DeberiaLanzarCentralitaException()
        {
            //arrange
            Centralita centralita;
            Provincial llamada;

            //act
            centralita = new Centralita();
            llamada = new Provincial("222", Franja.Franja_1, 7,"222");
            centralita = centralita + llamada;
            llamada = new Provincial("222", Franja.Franja_3, 8, "222");
            centralita = centralita + llamada;



        }


    }
}
