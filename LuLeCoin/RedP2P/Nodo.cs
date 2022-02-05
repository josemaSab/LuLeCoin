namespace LuLeCoin.RedP2P
{
    public class Nodo
    {
        public string Host { get; set; }
        public int Puerto { get; set; }
        
        //CONSTRCUTORES
        /**
         * Constructor con parametros
         */
        public Nodo(string host, int puerto)
        {
            Host = host;
            Puerto = puerto;
        }

        //Metodo que devulve los datos del nodo en un string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Host);
            sb.Append(':');
            sb.Append(Puerto);
            return sb.ToString();
        }
    }
}
