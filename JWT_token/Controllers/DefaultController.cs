using JWT_token.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
       
            [HttpGet("[action]")]
            public IActionResult Login()
            {
                return Created("", new BuiltToken().CreateToken());
            }

            [Authorize]
            [HttpGet("[action]")]
            public IActionResult Page1()
            {
                return Ok("Sayfa 1 İçin Girişiniz Başarılı");
            }
        
    }
}
