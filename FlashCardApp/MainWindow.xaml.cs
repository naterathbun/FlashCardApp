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


        private void OpenFileBrowserAndSetFilePath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SetFilePathOfTextFile(openFileDialog);
            }
            // HEY NATE COME HERE AND CALL TEH FREAKING CREATE QUESTIONS METHOD YOU MORON
        }

        public void SetFilePathOfTextFile(OpenFileDialog openFileDialog)
        {
            this.QuestionTextFilePath = openFileDialog.FileName;
        }


        private void CreateQuestionsFromFile(string filePath)
        {
            int linesInTextFile= File.ReadLines(filePath).Count();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                        this.questionAnswerSet.Questions.Add(new QuestionAnswerPair(sr.ReadLine(),sr.ReadLine()));
                }
            }
        }

        public void UpdateQuestionBox()
        {
            questionTextBox.Text = questionAnswerSet.Questions[0].Question;
        }

    }
}
