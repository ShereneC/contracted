using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class CompanysService
  {
    private readonly CompanysRepository _repo;
    public CompanysService(CompanysRepository repo)
    {
        _repo = repo;
    }


    internal List<Company> Get()
    {
      List<Company> comps = _repo.GetAll();
      return comps;
    }
    internal Company Get(int id)
    {
      Company comp = _repo.GetById(id);
      if (comp == null)
      {
        throw new Exception("Invalid Id");
      }
      return comp;
    }


    internal Company Create(Company newComp)
    {
      return _repo.Create(newComp);
    }


    internal Company Delete(int id)
    {
            Company compToDelete = Get(id);
            _repo.Delete(id);
            return compToDelete;
    }
  }
}