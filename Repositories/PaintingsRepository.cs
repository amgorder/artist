using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using artist.Models;
using artist.Model;

namespace painting.Repositories
{
    public class PaintingsRepository
    {

        public readonly IDbConnection _db;

        public PaintingsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Painting> Get()
        {
            string sql = @"SELECT * FROM paintings; ";
            return _db.Query<Painting>(sql);
        }

        internal Painting Get(int Id)
        {
            string sql = @"SELECT * FROM paintings
             WHERE id = @Id; ";
            return _db.QueryFirstOrDefault<Painting>(sql, new { Id });
        }

        internal Painting Create(Painting newPainting)
        {
            string sql = @"
      INSERT INTO paintings
      (title, description, year, artistId)
      VALUES
      (@Title, @Description, @Year, @ArtistId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newPainting);
            newPainting.Id = id;
            return newPainting;
        }

        internal Painting Edit(Painting data)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE paintings
      SET
        title = @Title,
        description = @Description,
        year = @Year
      WHERE id = @Id;
      SELECT * FROM paintings WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Painting>(sql, data);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM paintings WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Painting> GetByArtistId(int id)
        {
            // string sql = "SELECT * FROM paintings WHERE artistId = @id;";

            // return _db.Query<Painting>(sql, new { id });


            string sql = @"
      SELECT 
      p.*,
      a.*
      FROM paintings p
      JOIN artists a ON p.artistId = a.id
      WHERE artistId = @id;";

            return _db.Query<Painting, Artist, Painting>(sql, (painting, artist) =>
            {
                painting.Artist = artist;
                return painting;
            }, new { id }, splitOn: "id");

        }
    }
}