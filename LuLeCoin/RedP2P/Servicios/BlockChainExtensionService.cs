namespace LuLeCoin.Modelos.BlockChain
{
    /**
     * Servicio de Blockchain. Define una coleccion para guardar los bloques
     * y metodos para buscar y añadir bloques en la blockchain
     */
    public class BlockChainExtensionService
    {
        public static List<Bloque> CadenaBloques = new List<Bloque>();
        
        /**
         * Metodo que busca un bloque a partir del hash de bloque
         */
        public static Bloque encuentraBloqueHash(string hash)
        {
            Console.WriteLine($"Petición de busqueda de bloque con hash: {hash}");
            Bloque bloque = null;
            foreach(Bloque b in CadenaBloques)
            {
                if(b.Hash.Equals(hash))
                {
                    bloque = b;
                    Console.WriteLine($"Se ha encontrado el bloque con hash: {hash}");
                    Console.WriteLine(b.ToString());
                }
            }
            Console.WriteLine($"El bloque con hash {hash} no existe en la cadena de bloques");
            return bloque;
        }
        /**
         * Metofo para añadir un bloque al blockchain
         */
        public static void addBloqueBlockChain(Bloque bloque)
        {
            BlockChainExtensionService.CadenaBloques.Add(bloque);
            Console.WriteLine("Bloque añadido a la Blockchain.");
        }
    }
}
