namespace LuLeCoin.Modelos.BlockChain
{
    public class BlockChainExtensionService
    {
        public static List<Bloque> CadenaBloques = new List<Bloque>();
        
        public static Bloque encuentraBloqueHash(string hash)
        {
            Console.WriteLine($"Petición de busqueda de bloque con hash: {hash}");
            Bloque bloque = null;
            byte[] hashBytes = CalculosByteString.stringToArrayBytes(hash);
            foreach(Bloque b in CadenaBloques)
            {
                if(b.Hash == hashBytes)
                {
                    bloque = b;
                    Console.WriteLine($"Se ha encontrado el bloque con hash: {hash}");
                    Console.WriteLine(b.ToString());
                }
            }
            Console.WriteLine($"El bloque con hash {hash} no existe en la cadena de bloques");
            return bloque;
        }

        public static void addBloqueBlockChain(Bloque bloque)
        {
            BlockChainExtensionService.CadenaBloques.Add(bloque);
            Console.WriteLine("Bloque añadido a la Blockchain.");
        }
    }
}
