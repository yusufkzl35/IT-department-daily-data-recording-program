using Erenbook.Login;
using Erenbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erenbook.Controllers
{
    [LoginFilter]
    public class KapıGirisleriController : Controller
    {
        // GET: KapıGirisleri
        EREN db = new EREN();
        public ActionResult Index()
        {
            
            return View(db.PersonelAccesIDs.ToList());
        }

    }
}