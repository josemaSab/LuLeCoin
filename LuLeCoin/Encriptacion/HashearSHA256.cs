namespace LuLeCoin.Encriptacion
{
    public static class HashearSHA256
    {
        public static SHA256 sha256 = SHA256.Create();


        /**
         * Metodo que calcula el hash de un array de bytes
        */
        public static byte[] calculoHash(byte[] array)
        {
            byte[] resultado = new byte[0];
            resultado = sha256.ComputeHash(array);
            return resultado;
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
