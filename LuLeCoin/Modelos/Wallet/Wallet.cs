namespace LuLeCoin.Modelos
{
    /**
     * Clase Blockchain.Se definen los atributos y metodos
     */
    public class Wallet
    {
        public string ClavePublica { get; }
        public string ClavePrivada { get; }
        public double Saldo { get; set; }


        //CONSTRUCTORES
        public Wallet(string clavePrivada)
        {
            //Primero hasheamos la clave privada que sera secreta
            ClavePrivada = HashearSHA256.calculoHash(clavePrivada);
            //Se obtienen la direccion de la wallet que es la clave publica
            //volviendo a hashear la clave privada
            ClavePublica = HashearSHA256.calculoHash(this.ClavePrivada);
            //Saldo inicial de 50 LULE
            Saldo = 50d;
        }

        //METODOS
        /**
         * Metodo que muestra la informacion en forma de cadena de caracteres
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("WALLET CREADA\n");
            sb.Append("-------------\n");
            sb.Append($"Direccion wallet: {this.ClavePublica}");
            return sb.ToString();
        }
    }
}
