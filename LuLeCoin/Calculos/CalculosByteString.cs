namespace LuLeCoin.Calculos
{
    /**
     * Clase que realiza calculos para calculas array de bytes  a partir de 
     * una cadena de caracteres o viceversa
     */
    
    public static class CalculosByteString
    {
        /**
         * Metodo que devulve un array de bytes a partir de una cadena de caracteres
         */
        public static byte[] stringToArrayBytes(string cadena)
        {
            byte[] array = new byte[0];
            array = Encoding.ASCII.GetBytes(cadena);
            return array;

        }

        /**
         * Metodo que devulve un string a partir de un array de bytes
         */
        public static string arrayBytesToString(byte[] array)
        {
            string cadena = null;
            cadena = Encoding.ASCII.GetString(array);
            return cadena;
        }
    }
}
