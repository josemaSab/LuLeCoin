namespace LuLeCoin.Modelos.BlockChain
{
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
        private  bool addBloque(Bloque bloque)
        {
            if (encuentraCeros(bloque))
            {
                BlockChainExtension.CadenaBloques.Add(bloque);
                //TODO Propagar por la red el bloque minado

                return true;
            }
            
            return false;
        }

        /**
         * Metodo que realiza la prueba de trabajo para minar el bloque
         */
        public Bloque minarBloque(Bloque bloque)
        {
            byte[] hash = new byte[0];
            if (bloque != null && bloque.esValido())
            {
                while (!encuentraCeros(bloque))
                {
                    bloque.Nonce++;
                    bloque.TimeStampMinado = CalculosFecha.calculaMilisegundos(DateTime.UtcNow);
                }
                Console.WriteLine("EUREKA!!!! Bloque minado.");
                Console.WriteLine(bloque.ToString());
                addBloque(bloque);
            }
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
            byte[] ceros = new byte[this.Dificultad];
            byte[] hashBloque = bloque.calculaHash();
            for (int i = 0; i < this.Dificultad; i++)
            {
                ceros[i] = hashBloque[i];
                if(ceros[i] == 0)
                {
                    contador++;
                }
            }
            if(contador == this.Dificultad)
            {
                return true;
            }
            return false;
        }
    }
}
