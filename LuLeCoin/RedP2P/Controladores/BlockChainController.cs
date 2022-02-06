using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuLeCoin.RedP2P.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockChainController : ControllerBase
    {
        // GET: api/<BlockChainController>
        [HttpGet]
        public IEnumerable<Bloque> Get()
        {
            return BlockChainExtensionService.CadenaBloques;
        }

        // GET api/<BlockChainController>/5
        [HttpGet("{hash}")]
        public Bloque Get(string hash)
        {
            return BlockChainExtensionService.encuentraBloqueHash(hash);
        }

        // POST api/<BlockChainController>
        [HttpPost]
        public void Post([FromBody] List<Bloque> bloque)
        {
            //TODO Algoritmo de consenso de la cadena de bloque mas larga
        }
    }
}
