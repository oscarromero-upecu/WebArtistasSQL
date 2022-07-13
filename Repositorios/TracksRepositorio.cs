using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebArtistasSQL.Clases.Request;
using WebArtistasSQL.Models;

namespace WebArtistasSQL.Repositorios
{
    public class TracksRepositorio
    {
        private readonly UPECUEntities1 dbUPECU = new UPECUEntities1();

        public tracks ObtenerTrack(int id)
        {
            var tracksid = dbUPECU.tracks.FirstOrDefault(t=>t.tra_id==id);
            return (tracksid);
        }
        public tracks ObtenerTrackspornombre(string title)
        {
            return dbUPECU.tracks.FirstOrDefault(t => t.title == title);
        }
        public IEnumerable<object> Obtenertracks()
        {
            return dbUPECU.tracks.Select(s => new
            {
                s.tra_id,
                s.title,
                s.artists.Nombre
            });
        }
        public int ObtenerProximoSecuencial()
        {
            var ultimoTrack = dbUPECU.tracks.Select(s => new
            {
                s.tra_id,
            }).OrderByDescending(t => t.tra_id).FirstOrDefault();
            return ultimoTrack.tra_id + 1;
        }

        public void Crear(tracks track)
        {
            dbUPECU.tracks.Add(track);
            dbUPECU.SaveChanges();
        }

        public void Actualizar(int id, EditarTracksRequest nuevotracks)
        {
            var trackencontrado = dbUPECU.tracks.FirstOrDefault(t => t.tra_id == id);
            if (trackencontrado == null)
                throw new Exception("Track no existente");
            trackencontrado.title = nuevotracks.title;
            dbUPECU.artists.artist = nuevotracks.artist;
            dbUPECU.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var trackencontrado = ObtenerTrack(id);
            if (trackencontrado == null)
                throw new Exception("Track no existente");
            //dbUPECU.artists.Remove(trackencontrado);
            dbUPECU.SaveChanges();

        }
    }
}