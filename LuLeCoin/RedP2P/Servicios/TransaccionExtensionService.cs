namespace LuLeCoin.Modelos.Transacciones
{
    public static class TransaccionExtensionService
    {
        /**
         * Metodo que hashea la clave privada del emisor para que no aparezca tal cual 
         * en las transacciones
         */
        public static byte[] hashearFirma(byte[] firma)
        {
            byte[] hashfirma = HashearSHA256.calculoHash(firma);
            return hashfirma;
        }

        /**
         * Metodo que comprueba que la firma es valida
         */
        public static bool verificarFirma(byte[] firma, byte[] hashFirma)
        {
            if(hashFirma == HashearSHA256.calculoHash(firma))
            {
                return true;
            }
            return false;
        }
    }
}
