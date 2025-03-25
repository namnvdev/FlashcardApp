using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashcardApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FlashcardController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
