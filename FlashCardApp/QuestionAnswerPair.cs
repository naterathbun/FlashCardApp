using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCardApp;

namespace FlashCardApp
{
    public class QuestionAnswerPair
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }

        public QuestionAnswerPair(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }
        
    }
}
