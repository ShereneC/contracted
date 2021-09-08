using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class ContractorsRepository
  {

    private readonly IDbConnection _db;
    public ContractorsRepository(IDbConnection db)
    {
        _db = db;
    }
    internal List<Contractor> GetAll()
    {
      string sql = @"
      SELECT *
      FROM contractors
      ";
      // NOTE below is just the simple way of returning the items as a list
      return _db.Query<Contractor>(sql).ToList();
    }

    internal Contractor GetById(int id)
    {
            // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM contractors WHERE id = @id";
      //   Query first or default returns a single object or NULL if not found
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal Contractor Create(Contractor newTract)
    {
            string sql = @"
      INSERT INTO contractors
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
      newTract.Id = _db.ExecuteScalar<int>(sql, newTract);
      // this is returning exactly what you sent in.  
      return newTract;
    }

    internal void Delete(int id)
    {
            string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}