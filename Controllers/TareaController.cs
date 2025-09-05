using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea10Ej.Models;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("validar-edad/{edad}")]
        public IActionResult ValidarEdad(int edad)
        {
            if (edad < 0)
            {
                return BadRequest("La edad no puede ser negativa");
            }

            if (edad < 18)
            {
                return BadRequest( "Debes ser mayor de edad (18+)" );
            }

            return Ok("Edad válida, acceso permitido");
        }


        [HttpGet("dividir/{a}/{b}")]
        public IActionResult Dividir(int a, int b)
        {
            try
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("el dividendo no puede ser 0");
                }
                int resultado = a / b; 
                return Ok(new { a, b, resultado });
            }
            catch (DivideByZeroException error)
            {
                return BadRequest(new { Error = error.Message } );
            }
            
        }

        [HttpPost("validar-usuario")]
        public IActionResult ValidarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(new { mensaje = "Usuario válido", datos = usuario });
        }

        [HttpGet("caros")]
        public IActionResult GetProductosCaros()
        {
            List<Producto> productos = new List<Producto>(){
                new Producto( ){Id=1,Name="Chocolate",Price=45},
                new Producto( ){Id=2,Name="ComidaGato",Price=410},
                new Producto( ){Id=3,Name="Juguete",Price=33},
                new Producto( ){Id=4,Name="Peluche",Price=101},
                new Producto( ){Id=5,Name="Laptop",Price=1000}

            };
            var caros = productos.Where(p => p.Price > 100).ToList();
            return Ok(caros);
        }

        [HttpGet("ordenados")]
        public IActionResult GetUsuariosOrdenados([FromQuery] string orden = "asc")
        {
            List<Persona> personas = new List<Persona>
        {
            new Persona { Nombre = "Ana", Edad = 25 },
            new Persona { Nombre = "Luis", Edad = 30 },
            new Persona { Nombre = "Marta", Edad = 20 },
            new Persona { Nombre = "Pedro", Edad = 28 }
        };
            IEnumerable<Persona> resultado;

            if (orden.ToLower() == "desc")
            {
                resultado = personas.OrderByDescending(u => u.Edad).ToList();
            }
            else
            {
                resultado = personas.OrderBy(u => u.Edad).ToList();
            }

            return Ok(resultado);
        }

    }
}
