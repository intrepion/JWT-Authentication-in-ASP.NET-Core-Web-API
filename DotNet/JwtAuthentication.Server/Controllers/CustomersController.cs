using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JwtAuthentication.Server.Controllers;

public class CustomersController : Controller
{
    [HttpGet, Authorize]
    public IEnumerable<string> Get()
    {
        return ["John Doe", "Jane Doe"];
    }
}
