using System;
using System.Web.Mvc;
using CatalogoMvc.Interfaces.ILogic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        #region Fields


        #endregion Fields

        #region Constructor
        
        #endregion Constructor

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}