using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using WebArtistasSQL.Clases.Request;
using WebArtistasSQL.Models;
using WebArtistasSQL.Repositorios;

namespace WebArtistasSQL.Controllers
{
    public class TracksController : ApiController
    {
        private readonly ArtistaRepositorio _Arepositorio = new ArtistaRepositorio();

        private readonly TracksRepositorio _Trepositorio = new TracksRepositorio();

        [System.Web.Http.HttpGet]
        [ProducesResponseType(typeof(IEnumerable<artists>), (int) HttpStatusCode.OK)]
        public IHttpActionResult ObtenerTracks()
        {
            var Tracks = _Trepositorio.Obtenertracks();
            return Ok(Tracks);
        }
        
        [System.Web.Http.HttpPost]
        [ProducesResponseType ((int) HttpStatusCode.OK)]
        [ProducesResponseType ((int) HttpStatusCode.BadRequest)]
        public IHttpActionResult CrearTracks(NuevotrackRequest nuevotrack)
        {
            if (string.IsNullOrEmpty(nuevotrack.title))
                return BadRequest("Ingrese el titulo de la track");
            var artist = _Arepositorio.ObtenerArtistapornombre(nuevotrack.Nombre_artist);
            if (artist == null)
                return BadRequest($"No existe el artista {nuevotrack.Nombre_artist}");
            var nuevoidentificador = _Trepositorio.ObtenerProximoSecuencial();
            var Trackanuevo = new tracks(nuevoidentificador, nuevotrack, artist.id);
            _Trepositorio.Crear(Trackanuevo);
            return Ok("Artista registrado");
        }
        
        [System.Web.Http.HttpPut]
        [ProducesResponseType ((int) HttpStatusCode.OK)]
        [ProducesResponseType ((int) HttpStatusCode.BadRequest)]
        public IHttpActionResult ActualizarTracks(int id, EditarTracksRequest nuevotrack)
        {
            if (string.IsNullOrEmpty(nuevotrack.title))
                return BadRequest("Ingrese el track");
            if (_Trepositorio.ObtenerTrack(id) == null)
                return BadRequest("la cancion no existe");
            var trackencontrado = _Trepositorio.ObtenerTrackspornombre(nuevotrack.title);
            if (trackencontrado == null)
                return BadRequest($"No existe el artista {nuevotrack.title}");
            _Trepositorio.Actualizar(id, nuevotrack);
            return Ok("Artista actualizado");
        }

       
    }
}
