using Calculatorwebapi.model;
using Calculatorwebapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculatorwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuser userrepo;

        public UserController(Iuser userrepo)
        {
            this.userrepo = userrepo;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest model)
        {
            var user = userrepo.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            try
            {
                var user = userrepo.Create(model.ToUser(), model.Password,model.Email,model.FirstName,model.LastName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
