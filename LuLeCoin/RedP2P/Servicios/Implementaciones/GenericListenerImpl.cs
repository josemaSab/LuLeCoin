using LuLeCoin.RedP2P.Servicios.Interfaces;

namespace LuLeCoin.RedP2P.Servicios.Implementaciones
{
    /**
     * Clase generica de implementación de listeners
     */
    public class GenericListenerImpl<T> : GenericListener<T>
    {
        //ATRIBUTOS
        List<T> listaListeners;

        //CONTRUCTORES
        public GenericListenerImpl()
        {
            this.listaListeners = new List<T>();
        }

        //METODOS

        /**
         * Metodo que añade un listener a la lista
         */
        void GenericListener<T>.addListener(T objeto)
        {
            this.listaListeners.Add(objeto);
            Console.WriteLine($"Se ha añadido un listener del tipo: {objeto.GetType().Name.ToString()}");
        }

        /**
         * Metodo que elimina un listener de la lista
         */
        void GenericListener<T>.removeListener(T objeto)
        {
            if (listaListeners.Contains(objeto))
            {
                this.listaListeners.Remove(objeto);
                Console.WriteLine($"Se ha eliminado un listener del tipo: {objeto.GetType().Name.ToString()}");
            }
        }
    }
}
