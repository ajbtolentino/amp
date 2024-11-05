using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventVendorTransactionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}