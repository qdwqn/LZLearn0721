using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZLearn.Models;
using LZLearn.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LZLearn.controllers
{
    //类以Controller结尾，通过命名规范，可以直接使用ASP.NET框架，调用配置，从而起到减少代码目的
    //特征注释路由示例：
    //[Route("Home")]
    //[Route("Home")]也可以换成模式匹配方法来映射URL
    //[Route("Home")]改为[Route("[controller]")]后将会默认映射HomeController在内的所有COntroller
    //[Route("[controller]")]
    //将[Route("[controller]")]改为[Route("[controller]/[action]")]
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private INoodleRepository _noodleRepository;
        private IFeedbackRepository _feedbackRepository;
        public HomeController(INoodleRepository noodleRepository,IFeedbackRepository feedbackRepository)
        {
            _noodleRepository = noodleRepository;
            _feedbackRepository = feedbackRepository;
        }

        //Get:/<Controller>/
        public IActionResult Index()
        {
            //var noodles = _noodleRepository.GetAllNoodles();
            var vieModel = new HomeViewModel()
            {
                Feedbacks = _feedbackRepository.GetAllFeedBacks().ToList(),
                Noodels = _noodleRepository.GetAllNoodles().ToList()
            };
            return View(vieModel);
        }

        //特征注释路由示例续：
        //[Route("Index")]
        //例,接下来给项目添加路由中间件，来帮助我们解析URL并映射给相应的Controller和Action

        //同样将[Route("Index")]换为[Route("[Action]")]
        //[Route("[Action]")]
        //或者将[Route("[Action]")]删除，写在Controller上方

        //public String Index()
        //{
        //    return "Hello From Home-Index";
        //}

        //[Route("AboutUs")]
        //[Route("[Action]")]
        //例,接下来给项目添加路由中间件，来帮助我们解析URL并映射给相应的Controller和Action
        public String About()
        {
            return "Hello From Home-About";
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
