using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCardApp;
using Microsoft.Win32;
using System.IO;

namespace FlashCardApp
{
    public class QuestionAnswerSet
    {
        public List<QuestionAnswerPair> Questions { get; set; } = new List<QuestionAnswerPair>();

        public void LoadQuestionAnswerPairsFromFilePath()
        {
            
        }

        public void RandomizeQuestionOrder()
        {
            Random randomSeed = new Random();
            for (int i = (this.Questions.Count - 1); i > 0; --i)
            {
                int nextRandom = randomSeed.Next(i + 1);
                QuestionAnswerPair questionAnswerPair = this.Questions[i];
                this.Questions[i] = this.Questions[nextRandom];
                this.Questions[nextRandom] = questionAnswerPair;
            }


        }
    }
}
