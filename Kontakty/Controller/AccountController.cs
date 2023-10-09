using Kontakty.DTO;
using Kontakty.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Kontakty.DTO.RegisterDTO;

namespace Kontakty.Controller
{
    [Route("api/accoutns")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterDTO dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
