using LuLeCoin.Calculos;
using System.Runtime.Serialization.Formatters.Binary;

namespace LuLeCoin.Modelos.Transacciones
{
    /*
    * La información principal en una transacción incluye:
    * 	- Hash de la transacción
    * 	- El emisor
    * 	- El destinatario
    * 	- La cantidad a ser transferida
    * 	- El timestamp de cuándo fue creada
    * 	- La firma con la clave privada del emisor
    * */
    public class Transaccion
    {
        public byte[] Hash { get; set; }
        public byte[] Emisor { get; set; }
        public byte[] Destinatario { get; set; }
        public byte[] Firma { get; set; }
        public double Cantidad { get; set; }
        public long TimeStamp { get; set; }

        //CONTRUCTORES

        public Transaccion()
        {
        }

        public Transaccion(byte[] emisor, byte[] destinatario, byte[] firma, double cantidad)
        {
            Emisor = emisor;
            Destinatario = destinatario;
            Firma = firma;
            Cantidad = cantidad;
            TimeStamp = CalculosFecha.calculaMilisegundos(CalculosFecha.ahora);
        }

        //METODOS
        /**
         * Metodo que transforma el objeto transacción en un array de bytes
         * */
        public byte[] getContenidoTransaccion(Transaccion transaccion)
        {
            if (transaccion == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, transaccion);
                return ms.ToArray();
            }

        }
    }
}
