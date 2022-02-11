namespace LuLeCoin.RedP2P.Servicios.Interfaces
{
    /**
     * Interfaz que define los metodos que deben implementar
     * los notificadores dentro de la red P2P
     */
    public interface NotificaionesP2P
    {
        /**
         * Metodo que envia a la red el nuevo bloque mindado
         * devolverá true si el bloque es aceptado por almenos 10
         * nodos. Y false si no es aceptado.
         */
        bool nuevoBloqueMinado(Bloque bloque);
        /**
         * Metodo que recibe el utimo bloque minado y aceptado en la 
         * blockchain
         */
        Bloque recibirUltimoBloqueMinado();
        /**
         * Metodo que se encarga de recibir el archivo que contiene la blockchain
         */
        File recibirBlockChain();
        /**
         * Metodo que recibe todos los nodos vecinos de la red
         */
        List<Nodo> recibirTodosNodos();
        /**
         * Metodo que envia un nuevo nodo conectado a la red
         */
        bool enviarNodo(Nodo nodo);
        /**
         * Metodo que recibe un nodo
         */
        Nodo recibirNodo();
        /**
         * Metodo que compreba el estado de un nodo. Si esta activo o no
         */
        bool estadoNodo(Nodo nodo);


    }
}
