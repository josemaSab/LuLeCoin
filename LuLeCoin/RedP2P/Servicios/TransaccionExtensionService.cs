namespace LuLeCoin.Modelos.Transacciones
{
    /**
     * Clase que verifica las transacciones a traves de la firma y calcula el hash de la transaccion
     */
    public static class TransaccionExtensionService
    {
        /**
         * Metodo que hashea la clave privada del emisor para que no aparezca tal cual 
         * en las transacciones
         */
        public static string hashearFirma(string firma)
        {
            string hashfirma = HashearSHA256.calculoHash(firma);
            return hashfirma;
        }

        /**
         * Metodo que comprueba que la firma es valida
         */
        public static bool verificarFirma(string firma, string hashFirma)
        {
            if(hashFirma.Equals(HashearSHA256.calculoHash(firma)))
            {
                return true;
            }
            return false;
        }
    }
}
