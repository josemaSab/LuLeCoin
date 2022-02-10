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
        public string Hash { get; }
        public string Emisor { get; set; }
        public string Destinatario { get; set; }
        public string Firma { get; set; }
        public double Cantidad { get; set; }
        public string Datos { get; set; }
        public long TimeStamp { get; set; }

        //CONTRUCTORES

        public Transaccion()
        {
        }

        public Transaccion(string emisor, string destinatario, string firma, double cantidad, string datos)
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
         * Metodo que obtiene todos los datos de la transaccion para tratarla
         * */
        public string getContenidoTransaccion()
        {
            StringBuilder sb = new StringBuilder();

            
            if(this == null)
            {
                return null;
            }
            //Pasamos a string los datos de la transaccion
            sb.Append(this.Emisor);
            sb.Append(this.Destinatario);
            sb.Append(this.Firma);
            sb.Append(this.Cantidad);
            sb.Append(this.Datos);
            sb.Append(this.TimeStamp);
            
            return sb.ToString();
        }

        /**
         * Calcula el hash de la transacción y pasa a ser el identificador hash
         */

        public string calculaHashTransaccion()
        {
            return HashearSHA256.calculoHash(getContenidoTransaccion());          
        }

        /**
         * Metodo que verifica si el hash de la transacción es valido
         */
        public bool esValidoHash()
        {
            string hash = this.Hash;
            string hashCalculado = calculaHashTransaccion();
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
            sb.Append($"Hash: {this.Hash}\n");
            sb.Append($"Emisor: {this.Emisor}\n");
            sb.Append($"Destinatario: {this.Destinatario}\n");
            sb.Append($"Cantidad: {this.Cantidad}\n");
            sb.Append($"Datos: {this.Datos}\n");
            sb.Append($"Fecha Transacción: {this.TimeStamp}\n");
            return sb.ToString();
        }
    }
}
