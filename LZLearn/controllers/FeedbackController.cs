using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZLearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace LZLearn.controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            //Tag helper
            if (ModelState.IsValid)
            {
                //把新的评价加入到仓库里
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            return View();//返回用户评价输入页面，并且提示失败信息
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}