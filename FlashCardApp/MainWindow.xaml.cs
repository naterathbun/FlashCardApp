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
        public int CurrentQuestionID { get; set; }
        const int DefaultQuestionID = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


        public void LoadFileButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileBrowserAndSetFilePath();
            CreateQuestionsFromFile(QuestionTextFilePath);
            SetCurrentQuestionID(DefaultQuestionID);
            DisplayNewQuestionAnswerPair();
            ChangeLoadFileButtonColorToDefault();
            ChangeControlButtonsToGreen();
        }

        private void RevealHideButtonClicked(object sender, RoutedEventArgs e)
        {
            if (QuestionFileIsLoaded())
            {
                if (answerTextBox.Text == "")
                {
                    answerTextBox.Text = questionAnswerSet.Questions[CurrentQuestionID].Answer;
                }
                else
                {
                    answerTextBox.Text = "";
                }
            }
        }

        private void NextQuestionButtonClicked(object sender, RoutedEventArgs e)
        {
            if (QuestionFileIsLoaded())
            {
                IncreaseCurrentQuestionID();
                ShowQuestionBoxText(CurrentQuestionID);
                HideAnswerBoxText();
            }
        }

        private void PreviousQuestionButtonClicked(object sender, RoutedEventArgs e)
        {
            if (QuestionFileIsLoaded())
            {
                DecreaseCurrentQuestionID();
                ShowQuestionBoxText(CurrentQuestionID);
                HideAnswerBoxText();
            }
        }

        private void RandomizeButtonClicked(object sender, RoutedEventArgs e)
        {
            if (QuestionFileIsLoaded())
            {
                questionAnswerSet.RandomizeQuestionOrder();
                ShowQuestionBoxText(CurrentQuestionID);
                HideAnswerBoxText();
            }
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


        public void DisplayNewQuestionAnswerPair()
        {
            ShowQuestionBoxText(CurrentQuestionID);
            HideAnswerBoxText();
        }

        public void ShowQuestionBoxText(int questionIndex)
        {
            questionTextBox.Text = questionAnswerSet.Questions[questionIndex].Question;
        }

        public void ShowAnswerBoxText(int questionIndex)
        {
            answerTextBox.Text = questionAnswerSet.Questions[questionIndex].Answer;
        }

        public void HideAnswerBoxText()
        {
            answerTextBox.Text = "";
        }


        public void SetCurrentQuestionID(int newQuestionID)
        {
            CurrentQuestionID = newQuestionID;
        }

        public void IncreaseCurrentQuestionID()
        {
            CurrentQuestionID++;
            if (CurrentQuestionID > questionAnswerSet.Questions.Count() - 1)
            {
                CurrentQuestionID = DefaultQuestionID;
            }
        }

        public void DecreaseCurrentQuestionID()
        {
            CurrentQuestionID--;
            if (CurrentQuestionID < DefaultQuestionID)
            {
                CurrentQuestionID = questionAnswerSet.Questions.Count() - 1;
            }
        }

        public bool QuestionFileIsLoaded()
        {
            if (questionAnswerSet.Questions.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void ChangeLoadFileButtonColorToDefault()
        {
            loadFileButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));
        }

        public void ChangeControlButtonsToGreen()
        {
            previousQuestionButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22F72F"));
            nextQuestionButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22F72F"));
            revealHideButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22F72F"));
        }

    }
}
