using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea10Ej.Models;

namespace Tarea10Ej.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class TareaController : ControllerBase
    {
        //Ejercicio 6
        [HttpGet("buscar/{fruta}")]
        public IActionResult buscarFruta(string fruta)
        {
            var frutas = new List<string> { "Mandarina", "Pomelo", "Manzana", "Pera", "Sandia" };
            if (frutas.Contains(fruta, StringComparer.OrdinalIgnoreCase))
            {
                return Ok(fruta);
            }
            return NotFound(new { mensaje = $"La fruta '{fruta}' no se encuentra en la lista." });
        }

        //Ejercicio 7
        [HttpPost("pares")]
        public IActionResult buscarPares([FromBody] List<int> numeros)
        {
            List<int> pares=new List<int>();
            foreach(int num in numeros)
            {
                if (num % 2 == 0)
                {
                    pares.Add(num);
                }
            }
            return Ok(pares);
        }

        //Ejercicio 8
        [HttpGet("traducir/{palabra}")]
        public IActionResult traducir(string palabra)
        {
             Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
             {
                { "hello", "hola" },
                { "apple", "manzana" },
                { "pear", "pera" },
                { "watermelon", "sandía" },
                { "grapefruit", "pomelo" },
                { "grape", "uva" },
                { "lemon", "limon" },

             };
            if(diccionario.TryGetValue(palabra,out string traduccion))
            {
                return Ok(new { palabra, traduccion });
            }
            return NotFound("La palabra ingresada  no se encontro");
        }
        [HttpPost("contarPalabras")]
        public IActionResult contarPalabras([FromBody] string texto)
        {
  
            if (string.IsNullOrEmpty(texto))
            {
                return BadRequest("Texto ingresado esta vacio");
             
            }
            int i = 0,h=texto.Length ,cont=0;
            for (i = 0; i < h; i++)
            {
                if (texto[i].ToString().Equals(" ",StringComparison.Ordinal))
                {
                    cont++;
                }
            }
            return Ok($"el string tiene {cont+1} palabras");
            
        }

        [HttpGet("productos")]
        public IActionResult getAllProducts()
        {
            List<Producto> productos = new List<Producto>(){
                new Producto( ){Id=1,Name="Chocolate",Price=45},
                new Producto( ){Id=2,Name="ComidaGato",Price=410},
                new Producto( ){Id=3,Name="Juguete",Price=33},
                new Producto( ){Id=4,Name="Peluche",Price=100}

            };
            return Ok(productos);   
        }
    }
}
