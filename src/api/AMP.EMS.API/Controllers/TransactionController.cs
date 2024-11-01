using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class TransactionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}