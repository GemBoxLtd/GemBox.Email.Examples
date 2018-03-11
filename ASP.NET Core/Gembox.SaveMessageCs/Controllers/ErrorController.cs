using Microsoft.AspNetCore.Mvc;

namespace GemBox.SaveMessage.Controllers
{
    public class ErrorController : Controller
    {
        public string Error()
        {
            return "error";
        }
    }
}
