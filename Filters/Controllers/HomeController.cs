using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Controllers
{
    [HttpsOnly]
    [Profile]
    [ViewResultDetails]
    public class HomeController : Controller
    {        
        public ViewResult Index() => View("Message", "This is the Index action on the Home controller");
        
        public ViewResult SecondAction() => View("Message", "This is the SecondAction action on the Home controller");
    }
}
