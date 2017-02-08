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
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsShown { get; set; }

        public QuestionAnswerPair(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
            this.IsShown = false;
        }

        public void ShowAnswer()
        {
            this.IsShown = true;
        }

        public void HideAnswer()
        {
            this.IsShown = false;
        }
        
    }
}
