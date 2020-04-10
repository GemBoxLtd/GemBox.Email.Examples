using Microsoft.AspNetCore.Mvc;

namespace EmailCore.Controllers
{
    public class ErrorController : Controller
    {
        public string Error()
        {
            return "error";
        }
    }
}
