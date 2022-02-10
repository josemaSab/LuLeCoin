namespace LuLeCoin.Calculos
{
    /**
     * Clase que realiza el calculo para fechas
     */
    public static class CalculosFecha
    {
        public static DateTime ahora = DateTime.UtcNow;
        
        
        /**
         * Metodo que calcula la fecha en milisegundos
        */
        public static long calculaMilisegundos(DateTime dateTime)
        {
            long fechaMili = 0;
            TimeSpan timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);
            fechaMili = (long)timeSpan.TotalMilliseconds;
            return fechaMili;
        }

        /**
         * Metodo que convierte una fecha pasada en long a DateTime
         */
        public static DateTime calculaFecha(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToUniversalTime();
            return dtDateTime;
        }


    }
}
