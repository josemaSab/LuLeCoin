using LuLeCoin.Modelos.Transacciones;

namespace LuLeCoin.Modelos.Bloques
{
    public class Bloque
    {
        public byte[] Hash { get; set;  }
        public byte[] PrevHash { get; set; }
        public int Dificultad { get; set; }
        public long Nonce { get; set; }
        public byte[] RaizArbolMerkle { get; set; }
        public long TimeStampCreacion { get; set; }
        public long TimeStampMinado { get; set; }
        public List<Transaccion> Transacciones { get; set; }

        //CONSTRUCTORES

        /**
         * Constructor con parametros
         */
        public Bloque(byte[] prevHash, int dificultad, List<Transaccion> transacciones)
        {
            PrevHash = prevHash;
            Dificultad = dificultad;
            Nonce = 0;
            TimeStampCreacion = CalculosFecha.calculaMilisegundos(DateTime.UtcNow);
            TimeStampMinado = CalculosFecha.calculaMilisegundos(DateTime.UtcNow);
            Transacciones = transacciones;
            RaizArbolMerkle = calculaRaizArbolMerkle();
            Hash = calculaHash();
        }

        /**
         * Metodo que calcula el hash del bloque a partir del contenido en array de bytes
         */
        public byte[] calculaHash()
        {
            byte[] hash = HashearSHA256.calculoHash(getContenidoBloque());
            return hash;
        }

        /**
         * Metodo que crea un array de bytes con todo el contenido del bloque para su posterior tratamiento
         */
        private byte[] getContenidoBloque()
        {
            byte[] contenido;
            StringBuilder sb = new StringBuilder();
            sb.Append(CalculosByteString.arrayBytesToString(this.PrevHash));
            sb.Append(CalculosByteString.arrayBytesToString(BitConverter.GetBytes(this.Dificultad)));
            sb.Append(CalculosByteString.arrayBytesToString(BitConverter.GetBytes(this.Nonce)));
            sb.Append(CalculosByteString.arrayBytesToString(this.RaizArbolMerkle));
            sb.Append(CalculosByteString.arrayBytesToString(BitConverter.GetBytes(this.TimeStampCreacion)));
            sb.Append(CalculosByteString.arrayBytesToString(BitConverter.GetBytes(this.TimeStampMinado)));
            //Recorremos la lista de transacciones y la tratamos y la agregamos al stringbuilder
            foreach(Transaccion t in Transacciones)
            {
                sb.Append(CalculosByteString.arrayBytesToString(t.getContenidoTransaccion()));
            }
            contenido = Encoding.ASCII.GetBytes(sb.ToString());
            return contenido;
        }

        /**
         * Metodo que calcula la raiz del arbol de Merkle  de la lista de las transacciones
         */
        private byte[] calculaRaizArbolMerkle()
        {
            //Creamos una cola
            Queue<byte[]> colaHashes = new Queue<byte[]>();
            //recorremos la lista de transacciones y agregamos a la cola los hashes
            foreach(Transaccion t in Transacciones)
            {
                colaHashes.Enqueue(t.Hash);
            }
            //Mientras la cola tenga mas de 1 elemento calcula el hash de los elementos tomados de dos en dos
            while(colaHashes.Count > 1)
            {
                
                //quitamos los dosprimeros registros para hashearlos
                byte[] hash1 = colaHashes.Dequeue();
                byte[] hash2 = colaHashes.Dequeue();
                //añadimos el hash resultante al final
                byte[] hash1Hash2 = hash1.Concat(hash2).ToArray();
                byte[] arrayHasehado = HashearSHA256.calculoHash(hash1Hash2);
                colaHashes.Enqueue(arrayHasehado);
            }

            return colaHashes.Dequeue();
        }

        /*
         * Comprueba que el bloque pasado por parametro es valido.
         * Comparando el hash que trae el bloque y el hash del calculo del contenido del mismo
         */
        public bool esValido()
        {
            byte[] hashCalculado = this.calculaHash();
            if(this.Hash == hashCalculado)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INFORMACION DE BLOQUE\n");
            sb.Append("---------------------\n");
            sb.Append($"Hash: {HashearSHA256.pasarArrayByteString(this.Hash)}\n");
            sb.Append($"Hash Anterior: {HashearSHA256.pasarArrayByteString(this.PrevHash)}\n");
            sb.Append($"Dificultad: {this.Dificultad}\n");
            sb.Append($"Nonce: {this.Nonce}\n");
            sb.Append($"Raiz Arbol de Merkle: {HashearSHA256.pasarArrayByteString(this.RaizArbolMerkle)}\n");
            sb.Append($"Fecha Creación Bloque: {CalculosFecha.calculaFecha(this.TimeStampCreacion)}\n");
            sb.Append($"Fecha Minado Bloque: {CalculosFecha.calculaFecha(this.TimeStampMinado)}\n");
            return sb.ToString();
        }

    }
}
