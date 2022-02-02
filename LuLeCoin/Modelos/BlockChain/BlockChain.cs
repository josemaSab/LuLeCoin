using LuLeCoin.Modelos.Bloques;
using System.Text;

namespace LuLeCoin.Modelos.BlockChain
{
    public class BlockChain
    {
        //ATRIBUTOS
        public List<Bloque> CadenaBloques = new List<Bloque>();
        public int Dificultad { get; set; }
        public long CantidadMonedas { get; set; }

        //CONSTRUCTORES
        public BlockChain(int dificultad, long cantidadMonedas, Bloque genesis)
        {
            Dificultad = dificultad;
            CantidadMonedas = cantidadMonedas;
            CadenaBloques.Add(genesis);
        }

        //METODOS
        /**
         * Metodo que añade al BlockChain un bloque
        */
        public void AddBloque(Bloque bloque)
        {
            if (bloque.PrevHashBloque != null)
            {
                //Asignamos al campo de previus hash el hash del ultimo bloque
                bloque.PrevHashBloque = CadenaBloques.LastOrDefault().HashBloque;
            }
            //Lo añadimos al blockchain
            CadenaBloques.Add(bloque);
            Console.WriteLine(bloque.ToString());
        }

        /*
         * Metodo que hace el trabajo de minar un bloque
         */
        public Bloque minarBloque(int dificultad, Bloque bloque, Bloque prevBloque)
        {
            string hash="AAAAAAAAAA";//Iniciamos una cadena por defecto
            char[] hashArray = hash.ToCharArray(); //pasamos la cadena a array de caracteres
            int bloqueCorrecto = 0; //contador para comprobar que el bloque minado es correcto
            if (dificultad == null) throw new ArgumentException();
           
            if(isValidPrevBlock(bloque, prevBloque))
            {
                while (bloqueCorrecto != dificultad)
                { //mientras la dificultad no sea igual alcontador
                  //Comprobamos que todos los caracteres del hash son 0
                    for (int i = 0; i < dificultad; i++)
                    {
                        if (hashArray[i].Equals("0"))
                        {
                            bloqueCorrecto++; //si es 0 suma 1 al contador
                        }
                    }
                    bloque.Nonce++;//incrementamos el nonce
                    hash = CalculaHash(bloque.ToString());//calculamos en nuevo hash
                }

                bloque.TimeStamp = DateTime.Now; //Asignamos la fecha y hora de minado
                bloque.HashBloque = hash; //Asignamos el hash al bloque
                return bloque;
            }
            return null;
        }
        /**
         * Metodo que calcula el hash de un bloque
        */
        private static string CalculaHash(string cadena)
        {
            string hash;
            byte[] bloqueStringArray = Encoding.ASCII.GetBytes(cadena);//pasamos el string a array de bytes
            SHA256 sha256 = new SHA256Managed();
            byte[] resultadoBytes = sha256.ComputeHash(bloqueStringArray);//hasheamos el array de bytes
            hash = Encoding.Default.GetString(resultadoBytes); // convertimos a string el hash resultante
            return hash;
        }

        public static bool isValid(this Bloque block)
        {
            var bk = CalculaHash((string)block.ToString());
            return block.HashBloque.SequenceEqual(bk);
        }
        public static bool isValidPrevBlock(this Bloque block, Bloque prevBlock)
        {
            if (prevBlock == null) throw new ArgumentException(nameof(prevBlock));
            var prev = CalculaHash(prevBlock.PrevHashBloque);
            return isValid(prevBlock) && block.PrevHashBloque.SequenceEqual(prev);
        }

    }
}
