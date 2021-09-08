using System;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }

    private Job GetById(int id)
    {
      Job found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal void Delete(int id)
    {
        // NOTE since I am not returning anything, do I need the following line?  I am not actually using the jobToDelete that I created.
            // Job jobToDelete = Get(id);
            _repo.Delete(id);

    }
  }
}