using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LZLearn.controllers
{
    public class UserController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

            //如果只希望将数据暴露给API，同时要求URL前缀带有admin才能访问controller
        [Route("admin/[controller]/[action]")]
        public IList<String> Index()
        {
            return new List<string> { "阿莱克斯","克斯","阿兰","阿拉"};
        }
    }
}