using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZLearn.Models
{
    public class MockFeedbackRepository : IFeedbackRepository
    {
        private List<Feedback> _feedbacks;
        public MockFeedbackRepository()
        {
            if (_feedbacks == null)
            {
                InitializeFeedback();
            }
        }

        private void InitializeFeedback()
        {
            _feedbacks = new List<Feedback>
            {
                new Feedback{ Id=1,Name="啊",Email="noname@hotmail.com",Message="ok"},
                new Feedback{ Id=1,Name="啊",Email="noname@hotmail.com"},
                new Feedback{ Id=1,Name="啊",Email="noname@hotmail.com"},
                new Feedback{ Id=1,Name="啊",Email="noname@hotmail.com"}
            };
        }

        public IEnumerable<Feedback> GetAllFeedBacks()
        {
            return _feedbacks;
        }

        public void AddFeedback(Feedback feedback)
        {
            _feedbacks.Add(feedback);
        }
    }
}
