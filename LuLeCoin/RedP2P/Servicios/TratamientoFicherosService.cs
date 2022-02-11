using System.Runtime.Serialization.Formatters.Binary;

namespace LuLeCoin.RedP2P.Servicios
{
    /**
     * Clase que se encarga de los datos de bloque en la blockchain
     * en el archivo en el que se guarda
     */
    public class TratamientoFicherosService
    {
        //ATRIBUTOS
        public  Stream StreamFile { get; set; }
        public string PathFileBlockChain { get; set; }

        //CONSTRUCTORES
        public TratamientoFicherosService()
        {
            this.PathFileBlockChain = "./BlockChain.dat";
            if (!File.Exists(this.PathFileBlockChain))
            {
                this.StreamFile = new FileStream(this.PathFileBlockChain, FileMode.Create, FileAccess.ReadWrite);
                this.StreamFile.Close();
            }  
        }

        /**
         * Metodo que calcula el numero total de bloques en el blockchain
         */
        public long calculoNumeroTotalBloques()
        {
            long numeroBloques = 0;
            return numeroBloques;
        }

        /**
         * Metodo que añade un bloque al fichero de la blockchain
         */
        public int addBloque(Bloque bloque)
        {
            bool resultado = false;
            if (bloque != null)
            {
                this.StreamFile = new FileStream(this.PathFileBlockChain, FileMode.Append, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    bf.Serialize(this.StreamFile, bloque);
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error al serializar el bloque: " + ex.Message);
                    return -1;
                }
                finally
                {
                    this.StreamFile.Close();
                }
                
            }
            return 0;
        }
        /*
        public Bloque findBloque(string hash)
        {
            Bloque bloque = null;
            if(hash != null)
            {
                this.StreamFile = new FileStream(this.PathFileBlockChain, FileMode.Open, FileAccess.Read);

            }
            return bloque;
        }

        */
    }
}
