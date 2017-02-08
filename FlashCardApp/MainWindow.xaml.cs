using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using FlashCardApp;

namespace FlashCardApp
{
    public partial class MainWindow : Window
    {
        QuestionAnswerSet questionAnswerSet = new QuestionAnswerSet();
        public string QuestionTextFilePath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }




        public void LoadFileButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileBrowserAndSetFilePath();
            CreateQuestionsFromFile(QuestionTextFilePath);
            UpdateQuestionBox();
            UpdateAnswerbox();
        }

        public void OpenFileBrowserAndSetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SetFilePathOfTextFile(openFileDialog);
            }
        }

        public void SetFilePathOfTextFile(OpenFileDialog openFileDialog)
        {
            this.QuestionTextFilePath = openFileDialog.FileName;
        }

        public void CreateQuestionsFromFile(string filePath)
        {
            int linesInTextFile = File.ReadLines(filePath).Count();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    this.questionAnswerSet.Questions.Add(new QuestionAnswerPair(sr.ReadLine(), sr.ReadLine()));
                }
            }
        }

        public void UpdateQuestionBox()
        {
            questionTextBox.Text = questionAnswerSet.Questions[0].Question;
        }

        public void UpdateAnswerbox()
        {
            answerTextBox.Text = questionAnswerSet.Questions[0].Answer;
        }

    }


    /*
     * Next things to do: figure out how to do the show/hide based on QAPair property IsShown, add previous/next functionality, add randomize functionality
     */

         
}
