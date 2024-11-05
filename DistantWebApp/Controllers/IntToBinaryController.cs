﻿using DistantWebApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistantWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntToBinaryController : ControllerBase
{
    // GET api/<IntToBinaryController>/5
    [HttpGet("{value}")]
    public string Get(int value)
    {
        return ConverterService.IntToBinary(value);
    }
}
