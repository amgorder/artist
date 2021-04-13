using System;
using System.Collections.Generic;
using artist.Models;
using painting.Repositories;


namespace painting.Services
{
    public class PaintingsService
    {
        private readonly PaintingsRepository _repo;

        public PaintingsService(PaintingsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Painting> Get()
        {
            return _repo.Get();
        }

        internal Painting Get(int id)
        {
            Painting painting = _repo.Get(id);
            if (painting == null)
            {
                throw new Exception("invalid id");
            }
            return painting;
        }

        internal Painting Create(Painting newPainting)
        {
            return _repo.Create(newPainting);
        }


        internal Painting Edit(Painting updated)
        {
            Painting original = Get(updated.Id);
            
            //null check properties you are editing in repo
            original.Description = updated.Description != null ? updated.Description : original.Description;
            original.Title = updated.Title != null ? updated.Title : original.Title;

            //remember if null checking an integer put an Elvis operator ? in the model following the type
            original.Year = updated.Year != null ? updated.Year : original.Year;


            return _repo.Edit(original);
        }

        internal Painting Delete(int id)
        {
            Painting original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}