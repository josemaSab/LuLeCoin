using LuLeCoin.Modelos.Bloques;

namespace LuLeCoin.Modelos.BlockChain
{
    public class BlockChain
    {
        public List<Bloque> CadenaBloques = new List<Bloque>();
        public int Dificultad { get; set; }
        public int TransaccionesBloque { get; set; }
        public long TiempoMinadoBloque { get; set; }
        public bool Estado { get; set; }

        //CONTRUCTORES

        /**
         * Constructor con parametros
         */
        public BlockChain(int dificultad, int transaccionesBloque, long tiempoMinadoBloque, bool estado)
        {
            Dificultad = dificultad;
            TransaccionesBloque = transaccionesBloque;
            TiempoMinadoBloque = tiempoMinadoBloque;
            Estado = estado;
        }

        //METODOS
    }
}
