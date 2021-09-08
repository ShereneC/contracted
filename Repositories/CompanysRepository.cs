using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class CompanysRepository
  {

    private readonly IDbConnection _db;
    public CompanysRepository(IDbConnection db)
    {
        _db = db;
    }
    internal List<Company> GetAll()
    {
      string sql = @"
      SELECT *
      FROM companys
      ";
      // NOTE below is just the simple way of returning the items as a list
      return _db.Query<Company>(sql).ToList();
    }

    internal Company GetById(int id)
    {
            // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM companys WHERE id = @id";
      //   Query first or default returns a single object or NULL if not found
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }

    internal Company Create(Company newComp)
    {
            string sql = @"
      INSERT INTO companys
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
      newComp.Id = _db.ExecuteScalar<int>(sql, newComp);
      // this is returning exactly what you sent in.  
      return newComp;
    }

    internal void Delete(int id)
    {
            string sql = "DELETE FROM companys WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}