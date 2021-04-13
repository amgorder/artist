using System;
using System.Collections.Generic;
using artist.Model;
using artist.Repositories;


namespace artist.Services
{
    public class ArtistsService
    {
        private readonly ArtistsRepository _repo;

        public ArtistsService(ArtistsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Artist> Get()
        {
            return _repo.Get();
        }

        internal Artist Get(int id)
        {
            Artist artist = _repo.Get(id);
            if (artist == null)
            {
                throw new Exception("invalid id");
            }
            return artist;
        }

        internal Artist Create(Artist newArtist)
        {
            return _repo.Create(newArtist);
        }


        internal Artist Edit(Artist editArtist)
        {
            Artist original = Get(editArtist.Id);

            original.Name = editArtist.Name != null ? editArtist.Name : original.Name;

            original.Description = editArtist.Description != null ? editArtist.Description : original.Description;


            return _repo.Edit(original);
        }

        internal Artist Delete(int id)
        {
            Artist original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}