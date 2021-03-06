namespace LuLeCoin.Modelos.BlockChain
{
    /**
     * Clase Blockchain. Se definen los atributos y metodos
     */
    public class BlockChain
    {
        public int Dificultad { get; set; }
        public int TransaccionesBloque { get; set; }
        public long TiempoMinadoBloque { get; set; }
        public bool Estado { get; set; }

        //CONTRUCTORES

        /**
         * Constructor con parametros
         */
        public BlockChain(int dificultad, int transaccionesBloque, long tiempoMinadoBloque, bool estado)
        {
            Dificultad = dificultad;
            TransaccionesBloque = transaccionesBloque;
            TiempoMinadoBloque = tiempoMinadoBloque;
            Estado = estado;
        }

        //METODOS

        public void calculoDificultad(long tiempoCreacion, long tiempoMinado)
        {
            long time= tiempoMinado-tiempoCreacion;
            //Si el tiempo en minar un bloque es menor que el tiempo previsto de minado
            //Se aumenta la dificultad de minado
            if(time < this.TiempoMinadoBloque)
            {
                this.Dificultad += 1;
            }
            //Si el tiempo en minar un bloque es mayor se disminuye la dificultad de minado
            else if(time > this.TiempoMinadoBloque)
            {
                this.Dificultad -= 1;            
            }
        }

        /**
         * Metodo que añade un bloque a la blockchain
         */
        private bool addBloque(Bloque bloque)
        {
            
            BlockChainExtensionService.addBloqueBlockChain(bloque);

            return true;
        }

        /**
         * Metodo que realiza la prueba de trabajo para minar el bloque
         */
        public Bloque minarBloque(Bloque bloque)
        {
            Console.WriteLine("Minando Bloque....");
            if (bloque != null)
            {
                while (!encuentraCeros(bloque))
                {
                    bloque.Nonce++;
                    bloque.TimeStampMinado = CalculosFecha.calculaMilisegundos(DateTime.UtcNow);
                    //Thread.Sleep(1);--> con la parada de un milisegundo igualamos la capacidad computacional de todos los
                    //equipos de la red. Sin que uno sea mas poderoso que otro.
                }
                Console.WriteLine("EUREKA!!!! Bloque minado.");
                Console.WriteLine(bloque.ToString());


                //SERVICIO DE NOTIFICACION A LA RED P2P
                //Comunicar a los nodos que hemos minado un bloque
                //si los nodos dan el devuleven true añade el bloque al blockchain
                addBloque(bloque);
                //si devuleven false hace peticion de la blockchain mas larga para descargarla
                
                //Console.WriteLine("Ya existe un bloque minado por otro nodo mas reciente.");
                //Console.WriteLine("Se procede a la descargar del bloque correcto.");

                //----------------//
                return bloque;
            }
            Console.WriteLine("El bloque esta vacio.");
            return null;
        }

        /**
         * Metodo que busca en un array de longitud igual a la dificultad
         * y comprueba que todos sus valores sean 0. Si es correcto devuleve true
         * Si no es correcto devuelve false
         */
        public bool encuentraCeros(Bloque bloque)
        {
            int contador = 0;
            char[] ceros = new char[this.Dificultad];
            string hashBloque = bloque.calculaHash();
            char[] hashCharArray = hashBloque.ToCharArray();
            //Console.WriteLine($"Prueba de trabajo: {hash}");
            for (int i = 0; i < this.Dificultad; i++)
            {
                ceros[i] = hashCharArray[i];
                if(ceros[i] == '0')
                {
                    contador++;
                }
            }
            if(contador == this.Dificultad)
            {
                Console.WriteLine($"Prueba de trabajo: {hashBloque}");
                return true;
            }
            return false;
        }

    }
}
