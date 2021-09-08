using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;
    public ContractorsService(ContractorsRepository repo)
    {
        _repo = repo;
    }


    internal List<Contractor> Get()
    {
      List<Contractor> tracts = _repo.GetAll();
      return tracts;
    }
    internal Contractor Get(int id)
    {
      Contractor tract = _repo.GetById(id);
      if (tract == null)
      {
        throw new Exception("Invalid Id");
      }
      return tract;
    }


    internal Contractor Create(Contractor newTract)
    {
      return _repo.Create(newTract);
    }


    internal Contractor Delete(int id)
    {
            Contractor tractToDelete = Get(id);
            _repo.Delete(id);
            return tractToDelete;
    }
  }
}