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

        public void calculoDificultad(long tiempoCreacion, long tiempoMinado)
        {
            long time= tiempoMinado-tiempoCreacion;
            //Si el tiempo en minar un bloque es menor que el tiempo previsto de minado
            //Se aumenta la dificultad de minado
            if(time < this.TiempoMinadoBloque)
            {
                this.Dificultad += 1;
            }
            //Si el tiempo en minar un bloque es mayor se disminuye la dificultad de minado
            else if(time > this.TiempoMinadoBloque)
            {
                this.Dificultad -= 1;            
            }
        } 
    }
}
