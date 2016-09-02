using System.Collections.Generic;
using ZavrsniRad.Model.Model;

namespace ZavrsniRad.Model.Data
{
    public class QuizData
    {
        public List<Question> EasyQuestions = new List<Question>();
        public List<Question> MediumQuestions = new List<Question>();
        public List<Question> HardQuestions = new List<Question>();

        public QuizData()
        {
            InitializeData();
        }

        void InitializeData()
        {
            var questionEasy1 = new Question
            {
                Id = 1,
                Text = "Prvo pitanje",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            var questionEasy2 = new Question
            {
                Id = 2,
                Text = "Drugo pitanje",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            var questionEasy3 = new Question
            {
                Id = 3,
                Text = "Trece pitanje",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            var questionEasy4 = new Question
            {
                Id = 4,
                Text = "Cetvrto pitanje",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            var questionEasy5 = new Question
            {
                Id = 5,
                Text = "Peto Pitanje",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Easy
            };

            EasyQuestions.Add(questionEasy1);
            EasyQuestions.Add(questionEasy2);
            EasyQuestions.Add(questionEasy3);
            EasyQuestions.Add(questionEasy4);
            EasyQuestions.Add(questionEasy5);

            var questionMedium1 = new Question
            {
                Id = 1,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            var questionMedium2 = new Question
            {
                Id = 2,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            var questionMedium3 = new Question
            {
                Id = 3,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            var questionMedium4 = new Question
            {
                Id = 4,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            var questionMedium5 = new Question
            {
                Id = 5,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Medium
            };

            MediumQuestions.Add(questionMedium1);
            MediumQuestions.Add(questionMedium2);
            MediumQuestions.Add(questionMedium3);
            MediumQuestions.Add(questionMedium4);
            MediumQuestions.Add(questionMedium5);

            var questionHard1 = new Question
            {
                Id = 1,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Hard
            };

            var questionHard2 = new Question
            {
                Id = 2,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Hard
            };

            var questionHard3 = new Question
            {
                Id = 3,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Hard
            };

            var questionHard4 = new Question
            {
                Id = 4,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Hard
            };

            var questionHard5 = new Question
            {
                Id = 5,
                Text = "",
                FirstAnswer = "",
                SecondAnswer = "",
                ThirdAnswer = "",
                CorrectAnswer = 1,
                Category = Category.Hard
            };

            HardQuestions.Add(questionHard1);
            HardQuestions.Add(questionHard2);
            HardQuestions.Add(questionHard3);
            HardQuestions.Add(questionHard4);
            HardQuestions.Add(questionHard5);
        }
    }
}

