using LuLeCoin.Modelos.Transacciones;

namespace LuLeCoin.Modelos.Bloques
{
    public class Bloque
    {
        //ATRIBUTOS

        public DateTime TimeStamp { get; set; }
        public string PrevHashBloque { get; set; }
        public string HashBloque { get; set; }
        public List<Transaccion> Transacciones = new List<Transaccion>();
        public int Nonce { get; set; }

        //CONTRUCTORES
        /**
         * Constructor con parametros
         */
        public Bloque(string prevHashBloque, List<Transaccion> transacciones)
        {
            HashBloque = null;
            PrevHashBloque = prevHashBloque;
            Transacciones = transacciones;
            Nonce = 0;
        }

        //METODOS

        /**
         * Metodo que devulve un json con toda la información del objeto
         */

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        
    }
}
