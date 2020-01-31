using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class ErrorController : Controller
    {
        public string Error()
        {
            return "error";
        }
    }
}
