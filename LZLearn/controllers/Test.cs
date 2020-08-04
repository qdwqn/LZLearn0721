using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZLearn.controllers
{
    /*
     * 两种controller定义规范：
     * （1）在Test类加Controller
     * （2）使用面向切面AOP方式，给TestClass加Attribute
     *  (3) 通过继承Controller基类
     * 
     * （法1）public class TestController
     *  (法2)[Controller]
     * （法3）public class Test
     * 
     * 法2和法3区别：
     * 方法内使用this关键字后，controller基类提供了大量辅助方法
     
         */
    public class Test : Controller
    { 
        /*
         * Action函数：
         * （1）处理Http请求，并且返回HttpResponse的地方
         * 
         * ActionResult：
         * 可以根据数据类型，自动作类型转换，并且向外部发送合适数据
             */
        public ActionResult Index()
        {
            //Content内容可以为string、Json、Xml、自定义
            return Content("Hello From Test-Index");
        }

        public String About()
        {
            return "Hello From Test-About";
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
