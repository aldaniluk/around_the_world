using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Models
{
    public class QuestionsViewModel
    {
        public Question Question { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}