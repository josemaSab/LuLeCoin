namespace LuLeCoin.Encriptacion
{
    /**
     * Clase que realiza los calculos para hashear un string
     */
    public static class HashearSHA256
    {
        public static SHA256 sha256 = SHA256.Create();


        /**
         * Metodo que calcula el hash de un array de bytes
        */
        public static string calculoHash(string hash)
        {
            //convertimos el string hash pasado por parametro a array de bytes
            byte[] hashArray = CalculosByteString.stringToArrayBytes(hash);
            byte[] resultado = new byte[0];
            //hasheamos el array de bytes
            resultado = sha256.ComputeHash(hashArray);
            //Devolvemos el resultado en formato de string
            return pasarArrayByteString(resultado);
        }

        /**
         * Metodo que convierte un array de bytes a string en formato hexadecimal
        */
        public static string pasarArrayByteString(byte[] array)
        {
            string resultado = string.Empty;
            for(int i = 0; i < array.Length; i++)
            {
                //Se va generando la cadena de caracteres con hexadecimal
                resultado += $"{array[i]:X2}";
            }
            return resultado;
        }

    }
}
