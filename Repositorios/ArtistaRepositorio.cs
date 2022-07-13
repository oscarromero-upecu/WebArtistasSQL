using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebArtistasSQL.Clases.Request;
using WebArtistasSQL.Models;

namespace WebArtistasSQL.Repositorios
{
    public class ArtistaRepositorio 
    {
        private readonly UPECUEntities1 dbUPECU = new UPECUEntities1();

        public artists ObtenerArtista(int id)
        {
            return dbUPECU.artists.FirstOrDefault(a => a.id == id);
        }
        public IEnumerable<object> ObtenerArtistas()
        {
            return dbUPECU.artists.Select(s=>new
            {
                s.id,
                s.Nombre,
            });
        }

        public artists ObtenerArtistapornombre(string nombre)
        {
            return dbUPECU.artists.FirstOrDefault(t => t.Nombre == nombre);
        }
        public string ObtenerTrackporArtista(int id)
        {
            var Artista = dbUPECU.artists.FirstOrDefault(a => a.id == id);
            var Track = dbUPECU.tracks.FirstOrDefault(t => t.artist == Artista.id).title;
            if (Track == null)
                return ("Artitas no exite o no tine Tracks");
            return (Track).ToString();
            
        }

        public int ObtenerProximoSecuencial()
        {
            var ultimoArtista = dbUPECU.artists.OrderByDescending(a => a.id).FirstOrDefault();
            return ultimoArtista.id + 1;
        }
        public void Crear(artists artists)
        {
            dbUPECU.artists.Add(artists);
            dbUPECU.SaveChanges();
        }

        public void Actualizar(int id,string nombre)
        {
            var artistaencontrado = ObtenerArtista(id);
            if (artistaencontrado == null)
                throw new Exception("Artista no existente");
            artistaencontrado.Nombre = nombre;
            dbUPECU.SaveChanges();
        }

        public  void Eliminar (int id)
        {
            var artistaencontrado = ObtenerArtista(id);
            if (artistaencontrado == null)
                throw new Exception("Artista no existente");
            dbUPECU.artists.Remove(artistaencontrado);
            dbUPECU.SaveChanges();

        }
    }
}