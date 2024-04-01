using Microsoft.AspNetCore.Mvc;
using WebAppDemo.DTOs;
using WebAppDemo.Services;

namespace WebAppDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FiboController : Controller
{
    static FiboService fiboService = new FiboService();

    // GET: api/<FiboController>
    [HttpGet]
    public FiboResult Get()
    {
        return new FiboResult
        {
            Result = fiboService.Compute(10)
        };
    }

    // GET api/<FiboController>/5
    [HttpGet("{id}")]
    public FiboResult Get(int id)
    {
        return new FiboResult
        {
            Result = fiboService.Compute(id)
        };
    }
}
