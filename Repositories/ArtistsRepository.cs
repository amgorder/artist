using System;
using System.Collections.Generic;
using System.Data;
using artist.Model;
using Dapper;

namespace artist.Repositories
{
    public class ArtistsRepository
    {

        public readonly IDbConnection _db;

        public ArtistsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Artist> Get()
        {
            string sql = @"SELECT * FROM artists; ";
            return _db.Query<Artist>(sql);
        }

        internal Artist Get(int Id)
        {
            string sql = @"SELECT * FROM artists
             WHERE id = @Id; ";
            return _db.QueryFirstOrDefault<Artist>(sql, new { Id });
        }

        internal Artist Create(Artist newArtist)
        {
            string sql = @"
      INSERT INTO artists
      (name, description )
      VALUES
      (@Name, @Description);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newArtist);
            newArtist.Id = id;
            return newArtist
      ;
        }

        internal Artist Edit(Artist artistToEdit)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE artists
      SET
          name = @Name,
          description = @Description
      WHERE id = @Id;
      SELECT * FROM artists
      WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Artist>(sql, artistToEdit);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM artists WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}