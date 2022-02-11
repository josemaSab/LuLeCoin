namespace LuLeCoin.RedP2P.Servicios.Interfaces
{
    /**
     * Interfaz generica que define los metodos para las notificaciones
     */
    public interface GenericNotificaciones<T>
    {
        /**
         * Metodo generico de envio de notificaciones
         */
        bool enviarNotificacion(T objeto);
    }
}
