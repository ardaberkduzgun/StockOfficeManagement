
using System.Web.Mvc;

 namespace OfficeStock.Portal.Controllers
{
    public class BaseController : Controller
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
    }
}