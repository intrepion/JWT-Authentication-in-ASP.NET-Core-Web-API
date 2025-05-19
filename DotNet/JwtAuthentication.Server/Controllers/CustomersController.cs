using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Server.Controllers;

public class CustomersController : Controller
{
    [HttpGet, Authorize]
    public IEnumerable<string> Get()
    {
        return ["John Doe", "Jane Doe"];
    }
}
