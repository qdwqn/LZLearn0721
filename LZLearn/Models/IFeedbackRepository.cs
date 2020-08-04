using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZLearn.Models
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAllFeedBacks();
        void AddFeedback(Feedback feedback);

    }
}
