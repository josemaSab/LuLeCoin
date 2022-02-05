using LuLeCoin.RedP2P.Servicios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuLeCoin.RedP2P.Controladores
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class NodoController : ControllerBase
    {



        // GET: api/<NodoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string[] listado = new string[NodoService.ListaNodos.Count];
            for(int i = 0; i < listado.Length; i++)
            {
                listado[i] = NodoService.ListaNodos[i].ToString();
            }
            return listado;
        }

        // GET api/<NodoController>/5
        [HttpGet("{host}")]
        public string Get(string host)
        {
            return NodoService.buscarPorHost(host).ToString();
        }

        // POST api/<NodoController>
        [HttpPost]
        public void Post([FromBody] Nodo nodo)
        {
            if(nodo.Host != null && nodo.Puerto != null)
            {
                NodoService.addNodo(nodo);
            }
        }

        // PUT api/<NodoController>/5
        [HttpPut("{host}")]
        public void Put(string host, [FromBody] Nodo nodo)
        {
            //Si el nodo existe modifica los valores pasados en el body
            if (NodoService.buscarPorHost(host) != null)
            {
                NodoService.addNodo(nodo);
            }
        }

        // DELETE api/<NodoController>/5
        [HttpDelete("{host}")]
        public void Delete(string host)
        {
            Nodo nodo = NodoService.buscarPorHost(host);
            //Si el nodo existe modifica los valores pasados en el body
            if (nodo != null)
            {
                NodoService.removeNodo(nodo);
            }
        }
    }
}
