using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LZLearn.controllers
{
    public class NoodleController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IList<String> Index()
        {
            return new List<string> { "牛肉面","羊肉面","鸡蛋面"};
        }
    }
}