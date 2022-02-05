namespace LuLeCoin.Modelos.Transacciones
{
    public class PoolTransacciones
    {
        List<Transaccion> poolTransacciones = new List<Transaccion>();
        
        //METODOS

        /**
         * Metodo que elimina una transacción del pool de transacciones
         */
        public void eliminaTransaccion(Transaccion transaccion)
        {
            if (poolTransacciones.Contains(transaccion))
            {
                Console.WriteLine("Transacción encontrada en el pool de transacciones. Se prodecede a la eliminacion.");
                poolTransacciones.Remove(transaccion);
            }
            Console.WriteLine("La transacción no existe en el pool de transacciones.");
        }

        /**
         * Metodo que elimina una transacción del pool de transacciones a partir de un hash
         */
        public void eliminaTransaccion(string hashTransaccion)
        {
            foreach(Transaccion transaccion in poolTransacciones)
            {
                if (hashTransaccion.Equals(CalculosByteString.arrayBytesToString(transaccion.Hash)))
                {
                    Console.WriteLine("Transacción encontrada en el pool de transacciones. Se prodecede a la eliminacion.");
                    poolTransacciones.Remove(transaccion); 
                }
            }
            Console.WriteLine("La transacción no existe en el pool de transacciones.");
        }

        /**
         * Metodo que añade la transacción al pool si no existe
         */
        public void addTransaccion(Transaccion transaccion)
        {
            if (!poolTransacciones.Contains(transaccion))
            {
                Console.WriteLine("Transacción incluida en el pool de transacciones.");
                poolTransacciones.Add(transaccion);
            }
            Console.WriteLine("La transacción ya existe en el pool de transacciones.");
        }
    }
}
