using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZLearn.Models;
namespace LZLearn.ViewModels
{
    public class HomeViewModel
    {
        public IList<Noodles> Noodels{get ;set;}
        public IList<Feedback> Feedbacks { get; set; }
    }
}
