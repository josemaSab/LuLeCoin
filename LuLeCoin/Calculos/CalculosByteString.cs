namespace LuLeCoin.Calculos
{
    public static class CalculosByteString
    {
        public static byte[] stringToArrayBytes(string cadena)
        {
            byte[] array = new byte[0];
            array = Encoding.ASCII.GetBytes(cadena);
            return array;

        }

        public static string arrayBytesToString(byte[] array)
        {
            string cadena = null;
            cadena = Encoding.ASCII.GetString(array);
            return cadena;
        }
    }
}
