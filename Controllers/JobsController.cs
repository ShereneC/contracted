using System;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        Job created = _js.Create(newJob);
        return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _js.Delete(id);
        return Ok("Delorted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}