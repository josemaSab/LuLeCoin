namespace LuLeCoin
{
    public static class ArranqueInicial
    {
        public static void runLuleBlockChain()
        {
            //CREAMOS NODOS FICTICIOS Y LOS AÑADIMOS A LA LISTA DE NODOS
            Nodo nodo1 = new Nodo("192.168.1.20", 8080);
            Nodo nodo2 = new Nodo("192.168.1.30", 8080);
            NodoService.addNodo(nodo1);
            NodoService.addNodo(nodo2);
            //CREACION DE WALLETS
            string claveWallet1 = "123456";
            string claveWallet2 = "654321";
            Wallet wallet1 = new Wallet(CalculosByteString.stringToArrayBytes(claveWallet1));
            Wallet wallet2 = new Wallet(CalculosByteString.stringToArrayBytes(claveWallet2));
            Console.WriteLine(wallet1.ToString());
            Console.WriteLine(wallet2.ToString());

            //CREACION DE TRANSACCION
            byte[] datos = CalculosByteString.stringToArrayBytes("Primera transferencia de wallet1 a wallet2");
            Transaccion transaccion1 = new Transaccion(wallet1.ClavePublica, wallet2.ClavePublica, TransaccionExtensionService.hashearFirma(wallet1.ClavePrivada), 15d, datos);
            Console.WriteLine(transaccion1.ToString());
            List<Transaccion> transacciones = new List<Transaccion>();
            transacciones.Add(transaccion1);

            //CREACION DE LA BLOCKCHAIN
            BlockChain blockChainLule = new BlockChain(5, 2000, 60000, true);

            //CREACION DEL BLOQUE GENESIS
            string hashAnterior = "Soy el comienzo";
            byte[] hashAnteriorArray = CalculosByteString.stringToArrayBytes(hashAnterior);
            Bloque genesis = new Bloque(HashearSHA256.calculoHash(hashAnteriorArray), blockChainLule.Dificultad, transacciones);
            Console.WriteLine(genesis.ToString());
            //MINANDO EL BLOQUE
            blockChainLule.minarBloque(genesis);
        }
    }
}
