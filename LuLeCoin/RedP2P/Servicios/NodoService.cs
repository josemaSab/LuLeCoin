namespace LuLeCoin.RedP2P.Servicios
{
    public static class NodoService
    {
        public static List<Nodo> ListaNodos =new List<Nodo>();

        //Metodos

        public static Nodo buscarPorHost(string host)
        {
            foreach (Nodo n in ListaNodos)
            {
                if (host.Equals(n.Host))
                {
                    return n;
                }
            }
            return null;

        }

        /**
         * Metodo que añade un nodo a la lista
         */
        public static bool addNodo(Nodo nodo)
        {
            //Si el nodo existe devulve false
            if(buscarPorHost(nodo.Host) != null)
            {
                return false;
            }
            //Si el nodo no existe en la lista lo añade y devulve true
            ListaNodos.Add(nodo);
            Console.WriteLine($"Se ha añadido el nodo: {nodo.ToString()}");            
            return true;
        }

        /**
         * Metodo que elimina un nodo de la lista
         */
        public static bool removeNodo(Nodo nodo)
        {
            //Si el nodo existe en la lista lo elimina y devuelve true
            if(buscarPorHost(nodo.Host) != null)
            {
                ListaNodos.Remove(nodo);
                Console.WriteLine($"Se ha eliminado el nodo: {nodo.ToString()}");
                return true;
            }
            //Si el nodo no existe en la lista devuelve false
            return false;
            
        }
    }
}
