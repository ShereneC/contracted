using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;
    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Contractor>> Get()
    {
      try
      {
           List<Contractor> tracts = _cs.Get();
           return Ok(tracts);
      }
      catch (Exception err)
      {
          return BadRequest(err.Message);
      }
    }

        [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        Contractor tract = _cs.Get(id);
        return Ok(tract);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

        [HttpPost]

    public  ActionResult<Contractor> Create([FromBody] Contractor newTract)
    {
      try
      {
        Contractor created =  _cs.Create(newTract);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

        [HttpDelete("{id}")]
    public ActionResult<Contractor> Delete(int id)
    {
      try
      {
        Contractor tract = _cs.Delete(id);
        return Ok(tract);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}