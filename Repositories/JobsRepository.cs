using System.Data;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
  public class JobsRepository
    {
        private readonly IDbConnection _db;
        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (contractorId, companyId)
      VALUES
      (@ContractorId, @CompanyId);
      SELECT LAST_INSERT_ID();
      ";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}