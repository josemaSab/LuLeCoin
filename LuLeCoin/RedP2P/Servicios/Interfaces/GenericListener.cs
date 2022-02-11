namespace LuLeCoin.RedP2P.Servicios.Interfaces
{
    /**
     * Interface generica que difine los metodos basicos para los
     * escuchadores.
     */
    public interface GenericListener<T>
    {
        /**
         * Metodo que añade un escuchador.
         */
        void addListener(T objeto);
        /**
         * Metodo que elimina a un escuchador
         */
        void removeListener(T objeto);
    }
}
