using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _058_Plotko_Denis.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Add(int x, int y)
        {
            return View(x+y);
        }
        public IActionResult Mul(int x, int y)
        {
            return View(x*y);
        }
        public IActionResult Div(int x, int y)
        {
            if (y != 0)
                return View(x / y);
            else
                return View("infinity" as object);
        }
        public IActionResult Sub(int x, int y)
        {
            return View(x-y);
        }
    }
}
