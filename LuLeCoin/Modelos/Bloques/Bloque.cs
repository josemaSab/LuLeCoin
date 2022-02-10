using LuLeCoin.Modelos.Transacciones;

namespace LuLeCoin.Modelos.Bloques
{
    /**
     * Clase Bloque. Se definen los atributos y metodos 
     */
    public class Bloque
    {
        public string Hash { get; set;  }
        public string PrevHash { get; set; }
        public int Dificultad { get; set; }
        public long Nonce { get; set; }
        public string RaizArbolMerkle { get; set; }
        public long TimeStampCreacion { get; set; }
        public long TimeStampMinado { get; set; }
        public List<Transaccion> Transacciones { get; set; }

        //CONSTRUCTORES

        /**
         * Constructor con parametros
         */
        public Bloque(string prevHash, int dificultad, List<Transaccion> transacciones)
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
        public string calculaHash()
        {
            string hash = HashearSHA256.calculoHash(getContenidoBloque());
            return hash;
        }

        /**
         * Metodo que crea un array de bytes con todo el contenido del bloque para su posterior tratamiento
         */
        private string getContenidoBloque()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.PrevHash);
            sb.Append(this.Dificultad);
            sb.Append(this.Nonce);
            sb.Append(this.RaizArbolMerkle);
            sb.Append(this.TimeStampCreacion);
            sb.Append(this.TimeStampMinado); 
            return sb.ToString();
        }

        /**
         * Metodo que calcula la raiz del arbol de Merkle  de la lista de las transacciones
         */
        private string calculaRaizArbolMerkle()
        {
            //Creamos una cola
            Queue<string> colaHashes = new Queue<string>();
            //recorremos la lista de transacciones y agregamos a la cola los hashes
            foreach(Transaccion t in Transacciones)
            {
                colaHashes.Enqueue(t.Hash);
            }
            //Mientras la cola tenga mas de 1 elemento calcula el hash de los elementos tomados de dos en dos
            while(colaHashes.Count > 1)
            {
                
                //quitamos los dosprimeros registros para hashearlos
                string hash1 = colaHashes.Dequeue();
                string hash2 = colaHashes.Dequeue();
                //añadimos el hash resultante al final
                string hash1Hash2 = hash1 + hash2;
                string arrayHasehado = HashearSHA256.calculoHash(hash1Hash2);
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
            string hashCalculado = this.calculaHash();
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
            sb.Append($"Hash: {this.Hash}\n");
            sb.Append($"Hash Anterior: {this.PrevHash}\n");
            sb.Append($"Dificultad: {this.Dificultad}\n");
            sb.Append($"Nonce: {this.Nonce}\n");
            sb.Append($"Raiz Arbol de Merkle: {this.RaizArbolMerkle}\n");
            sb.Append($"Fecha Creación Bloque: {CalculosFecha.calculaFecha(this.TimeStampCreacion)}\n");
            sb.Append($"Fecha Minado Bloque: {CalculosFecha.calculaFecha(this.TimeStampMinado)}\n");
            return sb.ToString();
        }

    }
}
