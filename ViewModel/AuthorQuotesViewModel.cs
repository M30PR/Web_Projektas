using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Projektas.ViewModel
{
    public class AuthorQuotesViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
