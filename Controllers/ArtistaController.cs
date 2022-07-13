using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebArtistasSQL.Clases.Request;
using WebArtistasSQL.Models;
using WebArtistasSQL.Repositorios;

namespace WebArtistasSQL.Controllers
{
    public class ArtistaController : ApiController
    {
        private readonly ArtistaRepositorio _Arepositorio = new ArtistaRepositorio();
        

        [System.Web.Http.HttpGet]
        [ProducesResponseType(typeof(IEnumerable<artists>), (int) HttpStatusCode.OK)]
        public IHttpActionResult ObtenerArtistas()
        {
            var artistas = _Arepositorio.ObtenerArtistas();
            return Ok(artistas);
        }
        
        [System.Web.Http.HttpPost]
        [ProducesResponseType ((int) HttpStatusCode.OK)]
        [ProducesResponseType ((int) HttpStatusCode.BadRequest)]
        public IHttpActionResult CrearArtistas(NuevaArtistaRequest nuevoArtista)
        {
            if (string.IsNullOrEmpty(nuevoArtista.Nombre))
                return BadRequest("Ingrese el nombre del artista");
            var nuevoidentificador = _Arepositorio.ObtenerProximoSecuencial();
            var Artistanuevo = new artists(nuevoidentificador, nuevoArtista);
            _Arepositorio.Crear(Artistanuevo);
            return Ok("Artista registrado");
        }
        
        [System.Web.Http.HttpPut]
        [ProducesResponseType ((int) HttpStatusCode.OK)]
        [ProducesResponseType ((int) HttpStatusCode.BadRequest)]
        public IHttpActionResult ActualizarArtistas(int id, EditarArtistaRequest nuevoArtista)
        {
            if (string.IsNullOrEmpty(nuevoArtista.Nombre))
                return BadRequest("Ingrese el nombre del artista");
            if (_Arepositorio.ObtenerArtista(id) == null)
                return BadRequest("El artista no existe");
            _Arepositorio.Actualizar(id, nuevoArtista.Nombre);
            return Ok("Artista actualizado");
        }

       
    }
}
