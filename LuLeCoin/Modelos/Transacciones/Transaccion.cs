using LuLeCoin.Calculos;
using LuLeCoin.Encriptacion;


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
        public byte[] Hash { get; }
        public byte[] Emisor { get; set; }
        public byte[] Destinatario { get; set; }
        public byte[] Firma { get; set; }
        public double Cantidad { get; set; }
        public byte[] Datos { get; set; }
        public long TimeStamp { get; set; }

        //CONTRUCTORES

        public Transaccion()
        {
        }

        public Transaccion(byte[] emisor, byte[] destinatario, byte[] firma, double cantidad, byte[] datos)
        {
            Emisor = emisor;
            Destinatario = destinatario;
            Firma = firma;
            Cantidad = cantidad;
            Datos = datos;
            TimeStamp = CalculosFecha.calculaMilisegundos(CalculosFecha.ahora);
            Hash = calculaHashTransaccion();
        }

        //METODOS
        /**
         * Metodo que transforma el objeto transacción en un array de bytes
         * */
        public byte[] getContenidoTransaccion()
        {
            byte[] contenido;
            StringBuilder sb = new StringBuilder();

            
            if(this == null)
            {
                return null;
            }
            //Pasamos a string los datos de la transaccion
            sb.Append(CalculosByteString.arrayBytesToString(this.Emisor));
            sb.Append(CalculosByteString.arrayBytesToString(this.Destinatario));
            sb.Append(CalculosByteString.arrayBytesToString(this.Firma));
            sb.Append(CalculosByteString.arrayBytesToString(BitConverter.GetBytes(this.Cantidad)));
            sb.Append(CalculosByteString.arrayBytesToString(this.Datos));
            sb.Append(CalculosByteString.arrayBytesToString(BitConverter.GetBytes(this.TimeStamp)));
            contenido = Encoding.ASCII.GetBytes(sb.ToString());
            return contenido;
        }

        /**
         * Calcula el hash de la transacción y pasa a ser el identificador hash
         */

        public byte[] calculaHashTransaccion()
        {
            return HashearSHA256.calculoHash(getContenidoTransaccion());          
        }

        /**
         * Metodo que verifica si el hash de la transacción es valido
         */
        public bool esValidoHash()
        {
            string hash = HashearSHA256.pasarArrayByteString(this.Hash);
            string hashCalculado = HashearSHA256.pasarArrayByteString(calculaHashTransaccion());
            if (hash.Equals(hashCalculado))
            {
                return true;
            }
            return false;
        }

        /**
         * Metodo que muestra una cadena de caracteres con los datos de la transacción.
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INFORMACION DE TRANSACCION\n");
            sb.Append("--------------------------\n");
            sb.Append($"Hash: {HashearSHA256.pasarArrayByteString(this.Hash)}\n");
            sb.Append($"Emisor: {HashearSHA256.pasarArrayByteString(this.Emisor)}\n");
            sb.Append($"Destinatario: {HashearSHA256.pasarArrayByteString(this.Destinatario)}\n");
            sb.Append($"Cantidad: {this.Cantidad}\n");
            sb.Append($"Datos: {HashearSHA256.pasarArrayByteString(this.Datos)}\n");
            sb.Append($"Fecha Transacción: {this.TimeStamp}\n");
            return sb.ToString();
        }
    }
}
